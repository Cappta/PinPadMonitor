using System;
using System.Windows.Forms;

namespace PinPadMonitor.Extensions
{
	public static class ControlExtensions
	{
		public static void ExecuteOnUIThread(this Control control, Action action)
		{
			if (control.InvokeRequired == false) { action(); }
			else { control.Invoke(action); }
		}
	}
}
