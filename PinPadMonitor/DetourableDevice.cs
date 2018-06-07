using PinPadSDK.Devices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PinPadMonitor
{
	public class DetourableDevice
	{
		private readonly IDevice device;
		private readonly List<ManualDevice> manualDevices = new List<ManualDevice>();

		public DetourableDevice(IDevice device)
		{
			this.device = device ?? throw new ArgumentNullException(nameof(device));
			this.device.Output += this.Device_Output;
		}

		private ManualDevice ActiveDevice { get { lock (this.manualDevices) { return this.manualDevices.LastOrDefault(); } } }

		public IDevice GetNextDevice()
		{
			var manualDevice = new ManualDevice();
			manualDevice.DisposeCalled += this.ManualDevice_DisposeCalled;
			manualDevice.InputCalled += this.ManualDevice_InputCalled;
			lock (this.manualDevices) { this.manualDevices.Add(manualDevice); }
			return manualDevice;
		}

		private void ManualDevice_DisposeCalled(ManualDevice manualDevice)
		{
			lock (this.manualDevices) { this.manualDevices.Remove(manualDevice); }
		}

		private void ManualDevice_InputCalled(ManualDevice manualDevice, byte[] data)
		{
			if(manualDevice != this.ActiveDevice) { return; }

			this.device.Input(data);
		}

		private void Device_Output(byte[] data)
		{
			this.ActiveDevice?.InvokeOutput(data);
		}

		public void Dispose()
		{
			this.device.Dispose();
		}
	}
}
