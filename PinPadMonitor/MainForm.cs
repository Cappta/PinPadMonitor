using Microsoft.CSharp.RuntimeBinder;
using PinPadEmulator;
using PinPadEmulator.Crypto;
using PinPadEmulator.Devices;
using PinPadMonitor.Properties;
using PinPadSDK;
using PinPadSDK.Commands;
using PinPadSDK.Windows;
using System;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace PinPadMonitor
{
	public partial class MainForm : Form
	{
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
			this.Invoke(new Action(() =>
			{
				this.AppendCommand("REQ", request);
			}));
		}

		private void OnResponse(string response)
		{
			this.Invoke(new Action(() =>
			{
				this.AppendCommand("RES", response);
			}));
		}

		private void AppendCommand(string prefix, string command)
		{
			var commandObject = this.deserializer.Deserialize(command);

			lock (this.lockObject)
			{
				var node = this.UxTreeView.Nodes.Add($"{prefix}: {command}");
				var type = commandObject.GetType();
				var properties = type.GetProperties();
				foreach (var property in properties)
				{
					dynamic value = property.GetValue(commandObject, null);

					try
					{
						var valueString = default(string);
						if(value.Value.GetType() == typeof(byte[])) { valueString = value.ToString(); }
						else { valueString = value.Value.ToString(); }

						node.Nodes.Add($"{property.Name} = {valueString}");
						continue;
					}
					catch (RuntimeBinderException)
					{
						node.Nodes.Add($"{property.Name} = {value}");
					}
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
