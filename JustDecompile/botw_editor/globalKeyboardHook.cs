using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace botw_editor
{
	public class globalKeyboardHook
	{
		private const int WH_KEYBOARD_LL = 13;

		private const int WM_KEYDOWN = 256;

		private const int WM_KEYUP = 257;

		private const int WM_SYSKEYDOWN = 260;

		private const int WM_SYSKEYUP = 261;

		public List<Keys> HookedKeys = new List<Keys>();

		public globalKeyboardHook.keyboardHookStruct lastKey;

		private IntPtr hhook = IntPtr.Zero;

		private static globalKeyboardHook.keyboardHookProc callbackDelegate;

		public globalKeyboardHook()
		{
			this.hook();
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam);

		~globalKeyboardHook()
		{
			this.unhook();
		}

		[DllImport("user32", CharSet=CharSet.Unicode, ExactSpelling=false, SetLastError=true)]
		private static extern int GetKeyNameText(uint lParam, StringBuilder lpString, int nSize);

		public string GetKeyText(ref globalKeyboardHook.keyboardHookStruct lParam)
		{
			string str = "";
			StringBuilder stringBuilder = new StringBuilder(128);
			if (lParam.scanCode < 2 || lParam.scanCode > 11)
			{
				globalKeyboardHook.GetKeyNameText((uint)(1 + (lParam.scanCode << 16) + (lParam.flags << 24)), stringBuilder, 128);
				str = stringBuilder.ToString();
				if (str == "" && lParam.vkCode == 161 && lParam.scanCode == 54)
				{
					str = "SHIFT";
				}
			}
			else
			{
				int num = (lParam.scanCode - 1) % 10;
				str = num.ToString();
			}
			return str;
		}

		public void hook()
		{
			if (globalKeyboardHook.callbackDelegate != null)
			{
				throw new InvalidOperationException("Can't hook more than once");
			}
			IntPtr intPtr = globalKeyboardHook.LoadLibrary("User32");
			globalKeyboardHook.callbackDelegate = new globalKeyboardHook.keyboardHookProc(this.hookProc);
			this.hhook = globalKeyboardHook.SetWindowsHookEx(13, globalKeyboardHook.callbackDelegate, intPtr, 0);
			if (this.hhook == IntPtr.Zero)
			{
				throw new Win32Exception();
			}
		}

		public int hookProc(int code, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam)
		{
			if (code >= 0)
			{
				KeyEventArgs keyEventArg = new KeyEventArgs((Keys)lParam.vkCode);
				this.lastKey = lParam;
				if ((wParam == 256 || wParam == 260) && (this.KeyDown != null || this.KeyPress != null))
				{
					if (this.KeyDown != null)
					{
						this.KeyDown.Raise(this, keyEventArg);
					}
					if (this.KeyPress != null)
					{
						this.KeyPress.Raise(this, keyEventArg);
					}
				}
				else if ((wParam == 257 || wParam == 261) && this.KeyUp != null)
				{
					this.KeyUp.Raise(this, keyEventArg);
				}
				if (keyEventArg.Handled)
				{
					return 1;
				}
			}
			return globalKeyboardHook.CallNextHookEx(this.hhook, code, wParam, ref lParam);
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern IntPtr LoadLibrary(string lpFileName);

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern IntPtr SetWindowsHookEx(int idHook, globalKeyboardHook.keyboardHookProc callback, IntPtr hInstance, uint threadId);

		public void unhook()
		{
			if (globalKeyboardHook.callbackDelegate == null)
			{
				return;
			}
			globalKeyboardHook.UnhookWindowsHookEx(this.hhook);
			globalKeyboardHook.callbackDelegate = null;
		}

		[DllImport("user32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

		public event KeyEventHandler KeyDown;

		public event KeyEventHandler KeyPress;

		public event KeyEventHandler KeyUp;

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