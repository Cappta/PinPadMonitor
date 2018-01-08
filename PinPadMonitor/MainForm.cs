using PinPadEmulator;
using PinPadEmulator.Crypto;
using PinPadEmulator.Devices;
using PinPadMonitor.Extensions;
using PinPadMonitor.Properties;
using PinPadSDK;
using PinPadSDK.Commands;
using PinPadSDK.Commands.Enums;
using PinPadSDK.Extensions;
using PinPadSDK.Fields;
using PinPadSDK.Windows;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace PinPadMonitor
{
	public partial class MainForm : Form
	{
		private const int RESPONSE_STATUS_TREE_NODE_INDEX = 2;

		private Interceptor interceptor;

		private readonly Deserializer<BaseCommand> deserializer = new Deserializer<BaseCommand>();

		private object lockObject = new object();

		public MainForm()
		{
			InitializeComponent();
			this.LoadSettings();
			this.FormClosed += this.SaveSettings;

			this.UxTreeView.KeyDown += this.TreeViewCopyHandler;
		}

		private void LoadSettings()
		{
			this.UxComboVirtualCom.Text = Settings.Default.VirtualSerialPort;
			this.UxComboRealCom.Text = Settings.Default.RealSerialPort;
		}

		private void SaveSettings(object sender, FormClosedEventArgs e)
		{
			Settings.Default.VirtualSerialPort = this.UxComboVirtualCom.Text;
			Settings.Default.RealSerialPort = this.UxComboRealCom.Text;
			Settings.Default.Save();
		}

		private void TreeViewCopyHandler(object sender, KeyEventArgs e)
		{
			if (e.Alt || e.Control == false || e.Shift || e.KeyCode != Keys.C) { return; }

			var treeView = sender as TreeView;
			if (treeView?.SelectedNode == null) { return; }

			Clipboard.SetText(treeView.SelectedNode.Text);
		}

		private void UxComUpdateTimer_Tick(object sender, System.EventArgs e)
		{
			var portNames = SerialPort.GetPortNames();

			this.SyncComboBoxItems(this.UxComboVirtualCom, portNames);
			this.SyncComboBoxItems(this.UxComboRealCom, portNames);
		}

		private void SyncComboBoxItems(ComboBox comboBox, string[] items)
		{
			foreach (var item in items)
			{
				if (comboBox.Items.Contains(item) == false)
				{
					comboBox.Items.Add(item);
				}
			}
			for (var index = comboBox.Items.Count - 1; index >= 0; index--)
			{
				var item = comboBox.Items[index];
				if (items.Contains(item) == false)
				{
					comboBox.Items.Remove(item);
				}
			}
		}

		private void UxButtonStart_Click(object sender, System.EventArgs e)
		{
			if (this.UxButtonStart.Text == "START")
			{
				this.StartIntercepting();
				this.DisableUxItems();
				this.UxButtonStart.Text = "STOP";
			}
			else
			{
				this.StopInterceptor();
				this.EnableUxItems();
				this.UxButtonStart.Text = "START";
			}
		}

		private void DisableUxItems()
		{
			this.UxComboVirtualCom.Enabled = false;
			this.UxComboRealCom.Enabled = false;
		}

		private void EnableUxItems()
		{
			this.UxComboVirtualCom.Enabled = true;
			this.UxComboRealCom.Enabled = true;
		}

		private void StartIntercepting()
		{
			var cryptoHandler = new PassiveCryptoHandler();
			var virtualDevice = new DecryptedDevice(cryptoHandler, new SerialDevice(this.UxComboVirtualCom.Text));
			var realDevice = new DecryptedDevice(cryptoHandler, new SerialDevice(this.UxComboRealCom.Text));

			this.interceptor = new Interceptor(virtualDevice, realDevice);
			this.interceptor.Request += this.OnRequest;
			this.interceptor.Response += this.OnResponse;
		}

		private void StopInterceptor()
		{
			this.interceptor.Dispose();
		}

		private void OnRequest(string request)
		{
			this.ExecuteOnUIThread(() => this.AppendCommand("REQ", request));
		}

		private void OnResponse(string response)
		{
			this.ExecuteOnUIThread(() => this.AppendCommand("RES", response));
		}

		private void AppendCommand(string prefix, string serialized)
		{
			var deserialized = this.deserializer.Deserialize(serialized);

			lock (this.lockObject)
			{
				var node = this.UxTreeView.Nodes.Add($"{prefix}: {serialized}");
				this.ExpandIntoNode(node, deserialized);
			}
		}

		private void ExpandIntoNode(TreeNode node, object obj)
		{
			node.Nodes.Add(obj.ToString());
			var type = obj.GetType();
			var properties = type.GetProperties();
			foreach (var property in properties)
			{
				var value = property.GetValue(obj, null);
				var dynamicValue = value as dynamic;
				var valueType = value?.GetType();
				var genericType = valueType?.IsGenericType == true ? valueType.GetGenericTypeDefinition() : null;

				var valueNode = default(TreeNode);
				if (genericType == typeof(Field<>))
				{
					var fieldValue = dynamicValue.Value as object;
					switch (fieldValue)
					{
						case byte[] byteArrayValue:
							valueNode = node.Nodes.Add($"{property.Name}: {value} | {byteArrayValue.ToHexString()}");
							valueNode.Nodes.Add(property.Name);
							valueNode.Nodes.Add(value.ToString());
							valueNode.Nodes.Add(byteArrayValue.ToHexString());
							break;

						case FieldGroup fieldGroupValue:
							valueNode = node.Nodes.Add($"{property.Name}: {value} | {fieldGroupValue}");
							valueNode.Nodes.Add(property.Name);
							valueNode.Nodes.Add(value.ToString());
							this.ExpandIntoNode(valueNode, fieldGroupValue);
							break;

						case ReturnCode returnCodeValue:
							valueNode = node.Nodes.Insert(RESPONSE_STATUS_TREE_NODE_INDEX, $"{property.Name}: {value} | {returnCodeValue}");
							valueNode.Nodes.Add(property.Name);
							valueNode.Nodes.Add(value.ToString());
							valueNode.Nodes.Add(returnCodeValue.ToString());
							break;

						default:
							var valueString = value.ToString();

							var objectValueString = fieldValue?.ToString();

							valueNode = node.Nodes.Add($"{property.Name}: {valueString} | {objectValueString}");
							valueNode.Nodes.Add(property.Name);
							valueNode.Nodes.Add(valueString);
							if (valueString != objectValueString) { valueNode.Nodes.Add(objectValueString); }
							break;
					}
				}
				else if (genericType == typeof(FieldList<>))
				{
					valueNode = node.Nodes.Add($"{property.Name}: {value}");
					valueNode.Nodes.Add(property.Name);
					valueNode.Nodes.Add(value.ToString());
					foreach (var entry in dynamicValue)
					{
						var entryNode = valueNode.Nodes.Add($"{entry}");
						ExpandIntoNode(entryNode, entry);
					}
				}
				else if(value is byte[] byteArrayValue)
				{
					valueNode = node.Nodes.Add($"{property.Name}: {byteArrayValue.ToHexString()}");
					valueNode.Nodes.Add(property.Name);
					valueNode.Nodes.Add(byteArrayValue.ToHexString());
				}
				else if (value == null || property.PropertyType.IsPrimitive || property.PropertyType == typeof(string))
				{
					valueNode = node.Nodes.Add($"{property.Name}: {value}");
					valueNode.Nodes.Add(property.Name);
					valueNode.Nodes.Add(value?.ToString());
				}
				else
				{
					valueNode = node.Nodes.Add($"{property.Name}: {value}");
					valueNode.Nodes.Add(property.Name);
					this.ExpandIntoNode(valueNode, value);
				}
			}
		}

		private void UxButtonReset_Click(object sender, System.EventArgs e)
		{
			lock (this.lockObject)
			{
				this.UxTreeView.Nodes.Clear();
			}
		}
	}
}
