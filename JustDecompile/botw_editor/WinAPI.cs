using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace botw_editor
{
	internal class WinAPI
	{
		public WinAPI()
		{
		}

		public static bool ApplicationIsActivated()
		{
			int num;
			IntPtr foregroundWindow = WinAPI.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return false;
			}
			int id = Process.GetCurrentProcess().Id;
			WinAPI.GetWindowThreadProcessId(foregroundWindow, out num);
			return num == id;
		}

		public static Control FindFocusedControl(Control control)
		{
			for (IContainerControl i = control as IContainerControl; i != null; i = control as IContainerControl)
			{
				control = i.ActiveControl;
			}
			return control;
		}

		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=true)]
		private static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", CharSet=CharSet.Auto, ExactSpelling=false, SetLastError=true)]
		private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);
	}
}