using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace botw_editor
{
	// Token: 0x0200000A RID: 10
	public class globalKeyboardHook
	{
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060000C5 RID: 197 RVA: 0x0001B978 File Offset: 0x00019B78
		// (remove) Token: 0x060000C6 RID: 198 RVA: 0x0001B9B0 File Offset: 0x00019BB0
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event KeyEventHandler KeyDown;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060000C7 RID: 199 RVA: 0x0001B9E8 File Offset: 0x00019BE8
		// (remove) Token: 0x060000C8 RID: 200 RVA: 0x0001BA20 File Offset: 0x00019C20
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event KeyEventHandler KeyUp;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x060000C9 RID: 201 RVA: 0x0001BA58 File Offset: 0x00019C58
		// (remove) Token: 0x060000CA RID: 202 RVA: 0x0001BA90 File Offset: 0x00019C90
		[method: CompilerGenerated]
		[CompilerGenerated]
		public event KeyEventHandler KeyPress;

		// Token: 0x060000CB RID: 203 RVA: 0x0001BAC5 File Offset: 0x00019CC5
		public globalKeyboardHook()
		{
			this.hook();
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0001BAEC File Offset: 0x00019CEC
		~globalKeyboardHook()
		{
			this.unhook();
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0001BB18 File Offset: 0x00019D18
		public void hook()
		{
			if (globalKeyboardHook.callbackDelegate != null)
			{
				throw new InvalidOperationException("Can't hook more than once");
			}
			IntPtr hInstance = globalKeyboardHook.LoadLibrary("User32");
			globalKeyboardHook.callbackDelegate = new globalKeyboardHook.keyboardHookProc(this.hookProc);
			this.hhook = globalKeyboardHook.SetWindowsHookEx(13, globalKeyboardHook.callbackDelegate, hInstance, 0u);
			if (this.hhook == IntPtr.Zero)
			{
				throw new Win32Exception();
			}
		}

		// Token: 0x060000CE RID: 206 RVA: 0x0001BB7F File Offset: 0x00019D7F
		public void unhook()
		{
			if (globalKeyboardHook.callbackDelegate == null)
			{
				return;
			}
			globalKeyboardHook.UnhookWindowsHookEx(this.hhook);
			globalKeyboardHook.callbackDelegate = null;
		}

		// Token: 0x060000CF RID: 207 RVA: 0x0001BB9C File Offset: 0x00019D9C
		public int hookProc(int code, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam)
		{
			if (code >= 0)
			{
				KeyEventArgs keyEventArgs = new KeyEventArgs((Keys)lParam.vkCode);
				this.lastKey = lParam;
				if ((wParam == 256 || wParam == 260) && (this.KeyDown != null || this.KeyPress != null))
				{
					if (this.KeyDown != null)
					{
						this.KeyDown.Raise(this, keyEventArgs);
					}
					if (this.KeyPress != null)
					{
						this.KeyPress.Raise(this, keyEventArgs);
					}
				}
				else if ((wParam == 257 || wParam == 261) && this.KeyUp != null)
				{
					this.KeyUp.Raise(this, keyEventArgs);
				}
				if (keyEventArgs.Handled)
				{
					return 1;
				}
			}
			return globalKeyboardHook.CallNextHookEx(this.hhook, code, wParam, ref lParam);
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x0001BC54 File Offset: 0x00019E54
		public string GetKeyText(ref globalKeyboardHook.keyboardHookStruct lParam)
		{
			StringBuilder stringBuilder = new StringBuilder(128);
			string text;
			if (lParam.scanCode >= 2 && lParam.scanCode <= 11)
			{
				text = ((lParam.scanCode - 1) % 10).ToString();
			}
			else
			{
				globalKeyboardHook.GetKeyNameText((uint)(1 + (lParam.scanCode << 16) + (lParam.flags << 24)), stringBuilder, 128);
				text = stringBuilder.ToString();
				if (text == "" && lParam.vkCode == 161 && lParam.scanCode == 54)
				{
					text = "SHIFT";
				}
			}
			return text;
		}

		// Token: 0x060000D1 RID: 209
		[DllImport("user32.dll")]
		private static extern IntPtr SetWindowsHookEx(int idHook, globalKeyboardHook.keyboardHookProc callback, IntPtr hInstance, uint threadId);

		// Token: 0x060000D2 RID: 210
		[DllImport("user32.dll")]
		private static extern bool UnhookWindowsHookEx(IntPtr hInstance);

		// Token: 0x060000D3 RID: 211
		[DllImport("user32.dll")]
		private static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam);

		// Token: 0x060000D4 RID: 212
		[DllImport("kernel32.dll")]
		private static extern IntPtr LoadLibrary(string lpFileName);

		// Token: 0x060000D5 RID: 213
		[DllImport("user32", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern int GetKeyNameText(uint lParam, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpString, int nSize);

		// Token: 0x040001EC RID: 492
		private const int WH_KEYBOARD_LL = 13;

		// Token: 0x040001ED RID: 493
		private const int WM_KEYDOWN = 256;

		// Token: 0x040001EE RID: 494
		private const int WM_KEYUP = 257;

		// Token: 0x040001EF RID: 495
		private const int WM_SYSKEYDOWN = 260;

		// Token: 0x040001F0 RID: 496
		private const int WM_SYSKEYUP = 261;

		// Token: 0x040001F1 RID: 497
		public List<Keys> HookedKeys = new List<Keys>();

		// Token: 0x040001F2 RID: 498
		public globalKeyboardHook.keyboardHookStruct lastKey;

		// Token: 0x040001F3 RID: 499
		private IntPtr hhook = IntPtr.Zero;

		// Token: 0x040001F7 RID: 503
		private static globalKeyboardHook.keyboardHookProc callbackDelegate;

		// Token: 0x0200001C RID: 28
		// (Invoke) Token: 0x06000151 RID: 337
		public delegate int keyboardHookProc(int code, int wParam, ref globalKeyboardHook.keyboardHookStruct lParam);

		// Token: 0x0200001D RID: 29
		public struct keyboardHookStruct
		{
			// Token: 0x04000269 RID: 617
			public int vkCode;

			// Token: 0x0400026A RID: 618
			public int scanCode;

			// Token: 0x0400026B RID: 619
			public int flags;

			// Token: 0x0400026C RID: 620
			public int time;

			// Token: 0x0400026D RID: 621
			public int dwExtraInfo;
		}
	}
}
