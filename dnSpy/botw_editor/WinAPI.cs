using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace botw_editor
{
	// Token: 0x02000014 RID: 20
	internal class WinAPI
	{
		// Token: 0x06000137 RID: 311 RVA: 0x0001D5E4 File Offset: 0x0001B7E4
		public static bool ApplicationIsActivated()
		{
			IntPtr foregroundWindow = WinAPI.GetForegroundWindow();
			if (foregroundWindow == IntPtr.Zero)
			{
				return false;
			}
			int id = Process.GetCurrentProcess().Id;
			int num;
			WinAPI.GetWindowThreadProcessId(foregroundWindow, out num);
			return num == id;
		}

		// Token: 0x06000138 RID: 312
		[DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
		private static extern IntPtr GetForegroundWindow();

		// Token: 0x06000139 RID: 313
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

		// Token: 0x0600013A RID: 314 RVA: 0x0001D620 File Offset: 0x0001B820
		public static Control FindFocusedControl(Control control)
		{
			for (IContainerControl containerControl = control as IContainerControl; containerControl != null; containerControl = (control as IContainerControl))
			{
				control = containerControl.ActiveControl;
			}
			return control;
		}
	}
}
