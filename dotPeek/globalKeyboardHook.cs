using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace botw_editor
{
  public class globalKeyboardHook
  {
    public List<Keys> HookedKeys = new List<Keys>();
    private IntPtr hhook = IntPtr.Zero;
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 256;
    private const int WM_KEYUP = 257;
    private const int WM_SYSKEYDOWN = 260;
    private const int WM_SYSKEYUP = 261;
    public globalKeyboardHook.keyboardHookStruct lastKey;
    private static globalKeyboardHook.keyboardHookProc callbackDelegate;

    public event KeyEventHandler KeyDown;

    public event KeyEventHandler KeyUp;

    public event KeyEventHandler KeyPress;

    public globalKeyboardHook()
    {
      this.hook();
    }

    ~globalKeyboardHook()
    {
      this.unhook();
    }

    public void hook()
    {
      if (globalKeyboardHook.callbackDelegate != null)
        throw new InvalidOperationException("Can't hook more than once");
      IntPtr hInstance = globalKeyboardHook.LoadLibrary("User32");
      globalKeyboardHook.callbackDelegate = new globalKeyboardHook.keyboardHookProc(this.hookProc);
      this.hhook = globalKeyboardHook.SetWindowsHookEx(13, globalKeyboardHook.callbackDelegate, hInstance, 0U);
      if (this.hhook == IntPtr.Zero)
        throw new Win32Exception();
    }

    public void unhook()
    {
      if (globalKeyboardHook.callbackDelegate == null)
        return;
      globalKeyboardHook.UnhookWindowsHookEx(this.hhook);
      globalKeyboardHook.callbackDelegate = (globalKeyboardHook.keyboardHookProc) null;
    }

    public int hookProc(int code, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam)
    {
      if (code >= 0)
      {
        KeyEventArgs args = new KeyEventArgs((Keys) lParam.vkCode);
        this.lastKey = lParam;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((wParam == 256 || wParam == 260) && (this.KeyDown != null || this.KeyPress != null))
        {
          // ISSUE: reference to a compiler-generated field
          if (this.KeyDown != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.KeyDown.Raise((object) this, args);
          }
          // ISSUE: reference to a compiler-generated field
          if (this.KeyPress != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.KeyPress.Raise((object) this, args);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if ((wParam == 257 || wParam == 261) && this.KeyUp != null)
          {
            // ISSUE: reference to a compiler-generated field
            this.KeyUp.Raise((object) this, args);
          }
        }
        if (args.Handled)
          return 1;
      }
      return globalKeyboardHook.CallNextHookEx(this.hhook, code, wParam, ref lParam);
    }

    public string GetKeyText(ref globalKeyboardHook.keyboardHookStruct lParam)
    {
      StringBuilder lpString = new StringBuilder(128);
      string str;
      if (lParam.scanCode >= 2 && lParam.scanCode <= 11)
      {
        str = ((lParam.scanCode - 1) % 10).ToString();
      }
      else
      {
        globalKeyboardHook.GetKeyNameText((uint) (1 + (lParam.scanCode << 16) + (lParam.flags << 24)), lpString, 128);
        str = lpString.ToString();
        if (str == "" && lParam.vkCode == 161 && lParam.scanCode == 54)
          str = "SHIFT";
      }
      return str;
    }

    [DllImport("user32.dll")]
    private static extern IntPtr SetWindowsHookEx(int idHook, globalKeyboardHook.keyboardHookProc callback, IntPtr hInstance, uint threadId);

    [DllImport("user32.dll")]
    private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

    [DllImport("user32.dll")]
    private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam);

    [DllImport("kernel32.dll")]
    private static extern IntPtr LoadLibrary(string lpFileName);

    [DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern int GetKeyNameText(uint lParam, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nSize);

    public delegate int keyboardHookProc(int code, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam);

    public struct keyboardHookStruct
    {
      public int vkCode;
      public int scanCode;
      public int flags;
      public int time;
      public int dwExtraInfo;
    }
  }
}
