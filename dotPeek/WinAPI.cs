using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace botw_editor
{
  internal class WinAPI
  {
    public static bool ApplicationIsActivated()
    {
      IntPtr foregroundWindow = WinAPI.GetForegroundWindow();
      if (foregroundWindow == IntPtr.Zero)
        return false;
      int id = Process.GetCurrentProcess().Id;
      int processId;
      WinAPI.GetWindowThreadProcessId(foregroundWindow, out processId);
      return processId == id;
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern int GetWindowThreadProcessId(IntPtr handle, out int processId);

    public static Control FindFocusedControl(Control control)
    {
      for (IContainerControl containerControl = control as IContainerControl; containerControl != null; containerControl = control as IContainerControl)
        control = containerControl.ActiveControl;
      return control;
    }
  }
}
