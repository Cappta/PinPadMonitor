using PinPadSDK.Devices;
using System;

namespace PinPadMonitor
{
	public class ManualDevice : IDevice
	{
		public event Action<byte[]> Output;
		public event Action<ManualDevice, byte[]> InputCalled;
		public event Action<ManualDevice> DisposeCalled;

		public void InvokeOutput(byte[] data)
		{
			this.Output?.Invoke(data);
		}

		public void Input(params byte[] data)
		{
			this.InputCalled?.Invoke(this, data);
		}

		public void Dispose()
		{
			this.DisposeCalled?.Invoke(this);
		}
	}
}
