using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace botw_editor
{
	// Token: 0x0200000E RID: 14
	internal class MemAPI
	{
		// Token: 0x060000E8 RID: 232
		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr dwAddress, UIntPtr nSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x060000E9 RID: 233
		[DllImport("kernel32.dll")]
		public static extern void GetSystemInfo(out MemAPI.SYSTEM_INFO lpSystemInfo);

		// Token: 0x060000EA RID: 234
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MemAPI.MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

		// Token: 0x060000EB RID: 235
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenThread(MemAPI.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		// Token: 0x060000EC RID: 236
		[DllImport("kernel32.dll")]
		public static extern uint SuspendThread(IntPtr hThread);

		// Token: 0x060000ED RID: 237
		[DllImport("kernel32.dll")]
		public static extern int ResumeThread(IntPtr hThread);

		// Token: 0x060000EE RID: 238
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(MemAPI.ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

		// Token: 0x060000EF RID: 239
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		// Token: 0x060000F0 RID: 240
		[DllImport("kernel32.dll")]
		public static extern int CloseHandle(IntPtr hProcess);

		// Token: 0x060000F1 RID: 241
		[DllImport("kernel32.dll")]
		private static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

		// Token: 0x060000F2 RID: 242 RVA: 0x0001BE8C File Offset: 0x0001A08C
		public static void SuspendProcess(Process p)
		{
			if (p.ProcessName == string.Empty)
			{
				return;
			}
			foreach (ProcessThread processThread in p.Threads)
			{
				IntPtr intPtr = MemAPI.OpenThread(MemAPI.ThreadAccess.SUSPEND_RESUME, false, (uint)processThread.Id);
				if (!(intPtr == IntPtr.Zero))
				{
					MemAPI.SuspendThread(intPtr);
					MemAPI.CloseHandle(intPtr);
				}
			}
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0001BF1C File Offset: 0x0001A11C
		public static void ResumeProcess(Process p)
		{
			if (p.ProcessName == string.Empty)
			{
				return;
			}
			foreach (ProcessThread processThread in p.Threads)
			{
				IntPtr intPtr = MemAPI.OpenThread(MemAPI.ThreadAccess.SUSPEND_RESUME, false, (uint)processThread.Id);
				if (!(intPtr == IntPtr.Zero))
				{
					int num;
					do
					{
						num = MemAPI.ResumeThread(intPtr);
					}
					while (num > 0);
					MemAPI.CloseHandle(intPtr);
				}
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0001BFB4 File Offset: 0x0001A1B4
		public static byte ReadByte(long address, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[1];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return array[0];
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0001C014 File Offset: 0x0001A214
		public static void WriteByte(long address, byte newValue, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] lpBuffer = new byte[]
			{
				newValue
			};
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, lpBuffer, 1u, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0001C070 File Offset: 0x0001A270
		public static int ReadBytes(long address, byte[] buffer, int count, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			int result = 0;
			MemAPI.ReadProcessMemory(hProcess, address, buffer, count, ref result);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return result;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0001C0C8 File Offset: 0x0001A2C8
		public static int WriteBytes(long address, byte[] buffer, int count, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			int result = 0;
			MemAPI.WriteProcessMemory(hProc, address, buffer, (uint)count, out result);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return result;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0001C120 File Offset: 0x0001A320
		public static byte[] ReadBytes(long address, int count, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[count];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return array;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0001C17C File Offset: 0x0001A37C
		public static int ReadInt32(long address, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[4];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0001C1EC File Offset: 0x0001A3EC
		public static uint ReadUInt32(long address, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[4];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			return BitConverter.ToUInt32(array, 0);
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0001C25C File Offset: 0x0001A45C
		public static float ReadSingle(long address, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[4];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			return BitConverter.ToSingle(array, 0);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0001C2CC File Offset: 0x0001A4CC
		public static void WriteInt32(long address, int newValue, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] bytes = BitConverter.GetBytes(newValue);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, bytes, 4u, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0001C334 File Offset: 0x0001A534
		public static void WriteUInt32(long address, uint newValue, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] bytes = BitConverter.GetBytes(newValue);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, bytes, 4u, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0001C39C File Offset: 0x0001A59C
		public static void WriteSingle(long address, float newValue, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] bytes = BitConverter.GetBytes(newValue);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, bytes, 4u, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0001C404 File Offset: 0x0001A604
		public static string ReadString(long address, int count, Process p, IntPtr hProc)
		{
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[count + 1];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length - 1, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return Encoding.ASCII.GetString(array);
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0001C470 File Offset: 0x0001A670
		public static int ExtractInt32FromArray(byte[] buffer, int start = 0)
		{
			byte[] array = new byte[4];
			Array.Copy(buffer, start, array, 0, 4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			return BitConverter.ToInt32(array, 0);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0001C4A4 File Offset: 0x0001A6A4
		public static short ExtractInt16FromArray(byte[] buffer, int start = 0)
		{
			byte[] array = new byte[2];
			Array.Copy(buffer, start, array, 0, 2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(array);
			}
			return BitConverter.ToInt16(array, 0);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0001C4D8 File Offset: 0x0001A6D8
		public static string ExtractStringFromArray(byte[] buffer, int start = 0, int len = -1)
		{
			string text = "";
			int num = start;
			while ((len < 0 || num - start < len) && num < buffer.Length && buffer[num++] != 0)
			{
				text += Encoding.ASCII.GetString(buffer, num - 1, 1);
			}
			return text;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0001C524 File Offset: 0x0001A724
		public static string GetBigEndianUnicodeString(byte[] buffer, int start, out int size)
		{
			string text = "";
			int num = start;
			int num2 = buffer.Length - 1;
			size = 0;
			while (num < num2 && (buffer[num] != 0 || buffer[num + 1] != 0))
			{
				text += Encoding.BigEndianUnicode.GetString(buffer, num, 2);
				num += 2;
				size++;
			}
			return text;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0001C574 File Offset: 0x0001A774
		public static string ExtractUnicodeStringFromArray2(byte[] buffer, int start = 0)
		{
			string text = "";
			int i = start;
			while (i < buffer.Length)
			{
				text += Encoding.BigEndianUnicode.GetString(buffer, i, 2);
				i += 2;
				if (buffer[i] == 0 && buffer[i + 1] == 0)
				{
					break;
				}
			}
			return text;
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0001C5B8 File Offset: 0x0001A7B8
		public static string ExtractUnicodeStringFromArray(byte[] buffer, int start = 0)
		{
			string text = "";
			int i = start;
			while (i < buffer.Length)
			{
				text += Encoding.Unicode.GetString(buffer, i, 2);
				i += 2;
				if (buffer[i] == 0 && buffer[i + 1] == 0)
				{
					break;
				}
			}
			return text;
		}

		// Token: 0x06000106 RID: 262 RVA: 0x0001C5FC File Offset: 0x0001A7FC
		public static string ExtractStringFromMemory(long address, int maxBufferSize, Process p, IntPtr hProc)
		{
			string text = "";
			IntPtr hProcess = (hProc == IntPtr.Zero) ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
			byte[] array = new byte[maxBufferSize];
			int num = 0;
			MemAPI.ReadProcessMemory(hProcess, address, array, array.Length - 1, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			int num2 = 0;
			while (num2 < array.Length && array[num2++] != 0)
			{
				text += Encoding.ASCII.GetString(array, num2 - 1, 1);
			}
			return text;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0001C68D File Offset: 0x0001A88D
		public static bool IsAscii(byte value)
		{
			return value >= 33 && value <= 126;
		}

		// Token: 0x06000108 RID: 264 RVA: 0x0001C69C File Offset: 0x0001A89C
		public static bool IsAsciiChar(byte value)
		{
			return (value >= 65 && value <= 90) || (value >= 97 && value <= 122);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x0001C6B5 File Offset: 0x0001A8B5
		public static bool IsAlphaNumAsciiChar(byte value)
		{
			return (value >= 48 && value <= 57) || (value >= 65 && value <= 90) || (value >= 97 && value <= 122);
		}

		// Token: 0x0600010A RID: 266 RVA: 0x0001C6D8 File Offset: 0x0001A8D8
		public static bool IsUpperChar(byte value)
		{
			return value >= 65 && value <= 90;
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001C6E8 File Offset: 0x0001A8E8
		public static bool IsValidItemIDInArray(byte[] array, int index)
		{
			bool result = true;
			if (!MemAPI.IsUpperChar(array[index]))
			{
				result = false;
			}
			else
			{
				int num = index + 1;
				while (num < array.Length && array[num] != 0)
				{
					if (!MemAPI.IsAscii(array[num]))
					{
						result = false;
						break;
					}
					num++;
				}
			}
			return result;
		}

		// Token: 0x0600010C RID: 268 RVA: 0x0001C72C File Offset: 0x0001A92C
		public static int findSequence(byte[] array, int start, byte[] sequence, bool loop = true, bool debug = false)
		{
			int num = array.Length - sequence.Length;
			byte b = sequence[0];
			while (start < num)
			{
				if (array[start] == b)
				{
					int num2 = 1;
					while (num2 < sequence.Length && array[start + num2] == sequence[num2])
					{
						if (num2 == sequence.Length - 1)
						{
							return start;
						}
						num2++;
					}
				}
				if (!loop)
				{
					break;
				}
				start++;
			}
			return -1;
		}

		// Token: 0x0600010D RID: 269 RVA: 0x0001C77C File Offset: 0x0001A97C
		public static int findSequenceMatch(byte[] array, int start, int[] sequence, bool loop = true, bool debug = false)
		{
			int num = array.Length - sequence.Length;
			int num2 = sequence[0];
			while (start < num)
			{
				if (num2 == -1 || (num2 == -2 && array[start] != 0) || (num2 > -1 && array[start] == (byte)num2))
				{
					for (int i = 1; i <= sequence.Length; i++)
					{
						if (i >= sequence.Length)
						{
							return start;
						}
						if (i > 19)
						{
							int num3 = sequence[i];
							"0x" + num3.ToString("X");
							int num4 = (int)array[start + i];
							"0x" + num4.ToString("X");
						}
						if (sequence[i] != -1 && (sequence[i] != -2 || array[start + i] == 0))
						{
							if (array[start + i] != (byte)sequence[i])
							{
								break;
							}
							if (i == sequence.Length - 1)
							{
								return start;
							}
						}
					}
				}
				if (!loop)
				{
					break;
				}
				start++;
			}
			return -1;
		}

		// Token: 0x0600010E RID: 270 RVA: 0x0001C844 File Offset: 0x0001AA44
		public static long HexStringToInt64(string hexString)
		{
			long result = 0L;
			try
			{
				result = Convert.ToInt64(hexString.Trim(), 16);
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0001C878 File Offset: 0x0001AA78
		public static int HexStringToInt32(string hexString)
		{
			int result = 0;
			try
			{
				result = Convert.ToInt32(hexString.Trim(), 16);
			}
			catch (Exception)
			{
			}
			return result;
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000110 RID: 272 RVA: 0x0001C8AC File Offset: 0x0001AAAC
		// (set) Token: 0x06000111 RID: 273 RVA: 0x0001C8E4 File Offset: 0x0001AAE4
		public Process p
		{
			get
			{
				if (this._p == null && this.ProcessName != "")
				{
					this._p = Process.GetProcessesByName(this.ProcessName).FirstOrDefault<Process>();
				}
				return this._p;
			}
			set
			{
				this._p = value;
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000112 RID: 274 RVA: 0x0001C8ED File Offset: 0x0001AAED
		// (set) Token: 0x06000113 RID: 275 RVA: 0x0001C903 File Offset: 0x0001AB03
		public string ProcessName
		{
			get
			{
				if (this._processName == null)
				{
					return "";
				}
				return this._processName;
			}
			set
			{
				if (value == "" || value == null)
				{
					this.p = null;
					return;
				}
				this._processName = value;
				this.p = Process.GetProcessesByName(this.ProcessName).FirstOrDefault<Process>();
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000114 RID: 276 RVA: 0x0001C93A File Offset: 0x0001AB3A
		// (set) Token: 0x06000115 RID: 277 RVA: 0x0001C942 File Offset: 0x0001AB42
		public IntPtr Handle
		{
			get
			{
				return this.hProc;
			}
			set
			{
				this.hProc = value;
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0001C94C File Offset: 0x0001AB4C
		public bool OpenProcessHandle()
		{
			bool result = false;
			this.UpdateProcess("");
			if (this.hProc != IntPtr.Zero)
			{
				return true;
			}
			if (this.p != null)
			{
				this.hProc = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
				if (this.hProc != IntPtr.Zero)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x06000117 RID: 279 RVA: 0x0001C9B3 File Offset: 0x0001ABB3
		public void CloseProcessHandle()
		{
			if (this.hProc != IntPtr.Zero)
			{
				MemAPI.CloseHandle(this.hProc);
				this.hProc = IntPtr.Zero;
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001C9DE File Offset: 0x0001ABDE
		public void UpdateProcess(string processName = "")
		{
			processName = ((processName == "") ? this._processName : processName);
			this.ProcessName = processName;
		}

		// Token: 0x06000119 RID: 281 RVA: 0x0001CA00 File Offset: 0x0001AC00
		public bool CheckOpenProcess()
		{
			bool result = false;
			if (this.p == null)
			{
				return result;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			if (intPtr != IntPtr.Zero)
			{
				result = true;
				MemAPI.CloseHandle(intPtr);
			}
			return result;
		}

		// Token: 0x0600011A RID: 282 RVA: 0x0001CA48 File Offset: 0x0001AC48
		public byte GetByteAt(long address)
		{
			byte result = 0;
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			result = MemAPI.ReadByte(address, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x0600011B RID: 283 RVA: 0x0001CA90 File Offset: 0x0001AC90
		public int GetBytesAt(long address, byte[] buffer, int count)
		{
			if (this.p == null)
			{
				return 0;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			int arg_37_0 = MemAPI.ReadBytes(address, buffer, count, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
			return arg_37_0;
		}

		// Token: 0x0600011C RID: 284 RVA: 0x0001CAD4 File Offset: 0x0001ACD4
		public int GetInt32At(long address)
		{
			int result = 0;
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			result = MemAPI.ReadInt32(address, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x0600011D RID: 285 RVA: 0x0001CB1C File Offset: 0x0001AD1C
		public uint GetUInt32At(long address)
		{
			uint result = 0u;
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			result = MemAPI.ReadUInt32(address, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x0600011E RID: 286 RVA: 0x0001CB64 File Offset: 0x0001AD64
		public float GetSingleAt(long address)
		{
			float result = 0f;
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			result = MemAPI.ReadSingle(address, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x0600011F RID: 287 RVA: 0x0001CBB0 File Offset: 0x0001ADB0
		public string GetStringAt(long address)
		{
			string result = "";
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			result = MemAPI.ExtractStringFromMemory(address, 128, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x06000120 RID: 288 RVA: 0x0001CC00 File Offset: 0x0001AE00
		public void SetByteAt(long address, byte newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteByte(address, newValue, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
		}

		// Token: 0x06000121 RID: 289 RVA: 0x0001CC44 File Offset: 0x0001AE44
		public void SetBytesAt(long address, byte[] buffer, int count)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteBytes(address, buffer, count, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
		}

		// Token: 0x06000122 RID: 290 RVA: 0x0001CC88 File Offset: 0x0001AE88
		public void SetInt32At(long address, int newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteInt32(address, newValue, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
		}

		// Token: 0x06000123 RID: 291 RVA: 0x0001CCCC File Offset: 0x0001AECC
		public void SetUInt32At(long address, uint newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteUInt32(address, newValue, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
		}

		// Token: 0x06000124 RID: 292 RVA: 0x0001CD10 File Offset: 0x0001AF10
		public void SetSingleAt(long address, float newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteSingle(address, newValue, this.p, hProcess);
			MemAPI.CloseHandle(hProcess);
		}

		// Token: 0x06000125 RID: 293 RVA: 0x0001CD54 File Offset: 0x0001AF54
		public bool FindRegionBySize(long size, out long regionStart, out long regionSize, IntPtr hProc, long startAddress = 0L, bool needReadWrite = true)
		{
			bool result = false;
			regionStart = 0L;
			regionSize = 0L;
			IntPtr hProcess;
			if (hProc == IntPtr.Zero)
			{
				if (this.p == null)
				{
					return false;
				}
				hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			}
			else
			{
				hProcess = hProc;
			}
			long num = 9223372036854775807L;
			long num2 = startAddress;
			MemAPI.MEMORY_BASIC_INFORMATION mEMORY_BASIC_INFORMATION;
			while (true)
			{
				MemAPI.VirtualQueryEx(hProcess, (IntPtr)num2, out mEMORY_BASIC_INFORMATION, (uint)Marshal.SizeOf(typeof(MemAPI.MEMORY_BASIC_INFORMATION)));
				if ((long)mEMORY_BASIC_INFORMATION.RegionSize == size)
				{
					if (!needReadWrite)
					{
						goto IL_B4;
					}
					if (mEMORY_BASIC_INFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE && mEMORY_BASIC_INFORMATION.State == MemAPI.StateEnum.MEM_COMMIT)
					{
						break;
					}
				}
				if (num2 == (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize)
				{
					goto IL_111;
				}
				num2 = (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize;
				if (num2 > num)
				{
					goto IL_111;
				}
			}
			regionStart = (long)mEMORY_BASIC_INFORMATION.BaseAddress;
			regionSize = (long)mEMORY_BASIC_INFORMATION.RegionSize;
			result = true;
			goto IL_111;
			IL_B4:
			regionStart = (long)mEMORY_BASIC_INFORMATION.BaseAddress;
			regionSize = (long)mEMORY_BASIC_INFORMATION.RegionSize;
			result = true;
			IL_111:
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return result;
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0001CE88 File Offset: 0x0001B088
		public bool FindRegionByAddr(long addr, out long regionStart, out long regionSize, IntPtr hProc, bool needReadWrite = true)
		{
			bool result = false;
			regionStart = 0L;
			regionSize = 0L;
			IntPtr hProcess;
			if (hProc == IntPtr.Zero)
			{
				if (this.p == null)
				{
					return false;
				}
				hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			}
			else
			{
				hProcess = hProc;
			}
			long num = 9223372036854775807L;
			long num2 = 0L;
			MemAPI.MEMORY_BASIC_INFORMATION mEMORY_BASIC_INFORMATION;
			while (true)
			{
				MemAPI.VirtualQueryEx(hProcess, (IntPtr)num2, out mEMORY_BASIC_INFORMATION, (uint)Marshal.SizeOf(typeof(MemAPI.MEMORY_BASIC_INFORMATION)));
				if (addr >= (long)mEMORY_BASIC_INFORMATION.BaseAddress && addr <= (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize)
				{
					if (!needReadWrite)
					{
						goto IL_D0;
					}
					if (mEMORY_BASIC_INFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE && mEMORY_BASIC_INFORMATION.State == MemAPI.StateEnum.MEM_COMMIT)
					{
						break;
					}
				}
				if (num2 == (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize)
				{
					goto IL_12D;
				}
				num2 = (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize;
				if (num2 > num)
				{
					goto IL_12D;
				}
			}
			regionStart = (long)mEMORY_BASIC_INFORMATION.BaseAddress;
			regionSize = (long)mEMORY_BASIC_INFORMATION.RegionSize;
			result = true;
			goto IL_12D;
			IL_D0:
			regionStart = (long)mEMORY_BASIC_INFORMATION.BaseAddress;
			regionSize = (long)mEMORY_BASIC_INFORMATION.RegionSize;
			result = true;
			IL_12D:
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return result;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0001CFD8 File Offset: 0x0001B1D8
		public MemAPI.MemoryRegion[] listProcessMemoryRegions(IntPtr hProc)
		{
			List<MemAPI.MemoryRegion> list = new List<MemAPI.MemoryRegion>();
			IntPtr hProcess;
			if (hProc == IntPtr.Zero)
			{
				if (this.p == null)
				{
					return list.ToArray();
				}
				hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			}
			else
			{
				hProcess = hProc;
			}
			long num = 9223372036854775807L;
			long num2 = 0L;
			do
			{
				MemAPI.MEMORY_BASIC_INFORMATION mEMORY_BASIC_INFORMATION;
				MemAPI.VirtualQueryEx(hProcess, (IntPtr)num2, out mEMORY_BASIC_INFORMATION, (uint)Marshal.SizeOf(typeof(MemAPI.MEMORY_BASIC_INFORMATION)));
				if ((long)mEMORY_BASIC_INFORMATION.RegionSize > 0L && mEMORY_BASIC_INFORMATION.State == MemAPI.StateEnum.MEM_COMMIT && mEMORY_BASIC_INFORMATION.Type == MemAPI.TypeEnum.MEM_PRIVATE && (mEMORY_BASIC_INFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE || mEMORY_BASIC_INFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_EXECUTE_READWRITE))
				{
					list.Add(new MemAPI.MemoryRegion
					{
						regionStart = (long)mEMORY_BASIC_INFORMATION.BaseAddress,
						regionSize = (long)mEMORY_BASIC_INFORMATION.RegionSize,
						state = mEMORY_BASIC_INFORMATION.State,
						protect = mEMORY_BASIC_INFORMATION.Protect
					});
				}
				if (num2 == (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize)
				{
					break;
				}
				num2 = (long)mEMORY_BASIC_INFORMATION.BaseAddress + (long)mEMORY_BASIC_INFORMATION.RegionSize;
			}
			while (num2 <= num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(hProcess);
			}
			return list.ToArray();
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0001D13C File Offset: 0x0001B33C
		public long pagedMemorySearch(byte[] search, MemAPI.MemoryRegion[] regions)
		{
			long num = -1L;
			for (int i = 0; i < regions.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = regions[i];
				num = this.pagedMemorySearch(search, memoryRegion.regionStart, memoryRegion.regionSize);
				if (num > 0L)
				{
					break;
				}
			}
			return num;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x0001D17C File Offset: 0x0001B37C
		public long pagedMemorySearchMatch(int[] search, MemAPI.MemoryRegion[] regions)
		{
			long num = -1L;
			for (int i = 0; i < regions.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = regions[i];
				num = this.pagedMemorySearchMatch(search, memoryRegion.regionStart, memoryRegion.regionSize);
				if (num > 0L)
				{
					break;
				}
			}
			return num;
		}

		// Token: 0x0600012A RID: 298 RVA: 0x0001D1BC File Offset: 0x0001B3BC
		public long pagedMemorySearch(byte[] search, long startAddress, long regionSize)
		{
			long result = -1L;
			int val = 20480;
			int num = Math.Max(search.Length * 20, val);
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			byte[] array = new byte[num];
			long num2 = startAddress + regionSize;
			for (long num3 = startAddress; num3 < num2; num3 += (long)(array.Length - search.Length))
			{
				MemAPI.ReadBytes(num3, array, num, this.p, hProcess);
				int num4;
				if ((num4 = MemAPI.findSequence(array, 0, search, true, false)) >= 0)
				{
					result = num3 + (long)num4;
					break;
				}
			}
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x0001D260 File Offset: 0x0001B460
		public long pagedMemorySearchMatch(int[] search, long startAddress, long regionSize)
		{
			long result = -1L;
			int val = 20480;
			int num = Math.Max(search.Length * 20, val);
			if (this.p == null)
			{
				return result;
			}
			IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			byte[] array = new byte[num];
			long num2 = startAddress + regionSize;
			for (long num3 = startAddress; num3 < num2; num3 += (long)(array.Length - search.Length))
			{
				MemAPI.ReadBytes(num3, array, num, this.p, hProcess);
				int num4;
				if ((num4 = MemAPI.findSequenceMatch(array, 0, search, true, false)) >= 0)
				{
					result = num3 + (long)num4;
					break;
				}
			}
			MemAPI.CloseHandle(hProcess);
			return result;
		}

		// Token: 0x040001FD RID: 509
		public const int PROCESS_QUERY_INFORMATION = 1024;

		// Token: 0x040001FE RID: 510
		public const int MEM_COMMIT = 4096;

		// Token: 0x040001FF RID: 511
		public const int PAGE_READWRITE = 4;

		// Token: 0x04000200 RID: 512
		public const int PROCESS_WM_READ = 16;

		// Token: 0x04000201 RID: 513
		public static object obj;

		// Token: 0x04000202 RID: 514
		private Process _p;

		// Token: 0x04000203 RID: 515
		private string _processName;

		// Token: 0x04000204 RID: 516
		private IntPtr hProc = IntPtr.Zero;

		// Token: 0x0200001E RID: 30
		[Flags]
		public enum ProcessAccessFlags : uint
		{
			// Token: 0x0400026F RID: 623
			All = 2035711u,
			// Token: 0x04000270 RID: 624
			Terminate = 1u,
			// Token: 0x04000271 RID: 625
			CreateThread = 2u,
			// Token: 0x04000272 RID: 626
			VMOperation = 8u,
			// Token: 0x04000273 RID: 627
			VMRead = 16u,
			// Token: 0x04000274 RID: 628
			VMWrite = 32u,
			// Token: 0x04000275 RID: 629
			DupHandle = 64u,
			// Token: 0x04000276 RID: 630
			SetInformation = 512u,
			// Token: 0x04000277 RID: 631
			QueryInformation = 1024u,
			// Token: 0x04000278 RID: 632
			Synchronize = 1048576u
		}

		// Token: 0x0200001F RID: 31
		[Flags]
		public enum ThreadAccess
		{
			// Token: 0x0400027A RID: 634
			TERMINATE = 1,
			// Token: 0x0400027B RID: 635
			SUSPEND_RESUME = 2,
			// Token: 0x0400027C RID: 636
			GET_CONTEXT = 8,
			// Token: 0x0400027D RID: 637
			SET_CONTEXT = 16,
			// Token: 0x0400027E RID: 638
			SET_INFORMATION = 32,
			// Token: 0x0400027F RID: 639
			QUERY_INFORMATION = 64,
			// Token: 0x04000280 RID: 640
			SET_THREAD_TOKEN = 128,
			// Token: 0x04000281 RID: 641
			IMPERSONATE = 256,
			// Token: 0x04000282 RID: 642
			DIRECT_IMPERSONATION = 512
		}

		// Token: 0x02000020 RID: 32
		public struct MEMORY_BASIC_INFORMATION
		{
			// Token: 0x04000283 RID: 643
			public IntPtr BaseAddress;

			// Token: 0x04000284 RID: 644
			public IntPtr AllocationBase;

			// Token: 0x04000285 RID: 645
			public MemAPI.AllocationProtectEnum AllocationProtect;

			// Token: 0x04000286 RID: 646
			public IntPtr RegionSize;

			// Token: 0x04000287 RID: 647
			public MemAPI.StateEnum State;

			// Token: 0x04000288 RID: 648
			public MemAPI.AllocationProtectEnum Protect;

			// Token: 0x04000289 RID: 649
			public MemAPI.TypeEnum Type;
		}

		// Token: 0x02000021 RID: 33
		public struct MEMORY_BASIC_INFORMATION2
		{
			// Token: 0x0400028A RID: 650
			public IntPtr BaseAddress;

			// Token: 0x0400028B RID: 651
			public IntPtr AllocationBase;

			// Token: 0x0400028C RID: 652
			public uint AllocationProtect;

			// Token: 0x0400028D RID: 653
			public IntPtr RegionSize;

			// Token: 0x0400028E RID: 654
			public uint State;

			// Token: 0x0400028F RID: 655
			public uint Protect;

			// Token: 0x04000290 RID: 656
			public uint Type;
		}

		// Token: 0x02000022 RID: 34
		public enum AllocationProtectEnum : uint
		{
			// Token: 0x04000292 RID: 658
			PAGE_EXECUTE = 16u,
			// Token: 0x04000293 RID: 659
			PAGE_EXECUTE_READ = 32u,
			// Token: 0x04000294 RID: 660
			PAGE_EXECUTE_READWRITE = 64u,
			// Token: 0x04000295 RID: 661
			PAGE_EXECUTE_WRITECOPY = 128u,
			// Token: 0x04000296 RID: 662
			PAGE_NOACCESS = 1u,
			// Token: 0x04000297 RID: 663
			PAGE_READONLY,
			// Token: 0x04000298 RID: 664
			PAGE_READWRITE = 4u,
			// Token: 0x04000299 RID: 665
			PAGE_WRITECOPY = 8u,
			// Token: 0x0400029A RID: 666
			PAGE_GUARD = 256u,
			// Token: 0x0400029B RID: 667
			PAGE_NOCACHE = 512u,
			// Token: 0x0400029C RID: 668
			PAGE_WRITECOMBINE = 1024u
		}

		// Token: 0x02000023 RID: 35
		public enum StateEnum : uint
		{
			// Token: 0x0400029E RID: 670
			MEM_COMMIT = 4096u,
			// Token: 0x0400029F RID: 671
			MEM_FREE = 65536u,
			// Token: 0x040002A0 RID: 672
			MEM_RESERVE = 8192u
		}

		// Token: 0x02000024 RID: 36
		public enum TypeEnum : uint
		{
			// Token: 0x040002A2 RID: 674
			MEM_IMAGE = 16777216u,
			// Token: 0x040002A3 RID: 675
			MEM_MAPPED = 262144u,
			// Token: 0x040002A4 RID: 676
			MEM_PRIVATE = 131072u
		}

		// Token: 0x02000025 RID: 37
		public struct SYSTEM_INFO
		{
			// Token: 0x040002A5 RID: 677
			public ushort processorArchitecture;

			// Token: 0x040002A6 RID: 678
			private ushort reserved;

			// Token: 0x040002A7 RID: 679
			public uint pageSize;

			// Token: 0x040002A8 RID: 680
			public IntPtr minimumApplicationAddress;

			// Token: 0x040002A9 RID: 681
			public IntPtr maximumApplicationAddress;

			// Token: 0x040002AA RID: 682
			public IntPtr activeProcessorMask;

			// Token: 0x040002AB RID: 683
			public uint numberOfProcessors;

			// Token: 0x040002AC RID: 684
			public uint processorType;

			// Token: 0x040002AD RID: 685
			public uint allocationGranularity;

			// Token: 0x040002AE RID: 686
			public ushort processorLevel;

			// Token: 0x040002AF RID: 687
			public ushort processorRevision;
		}

		// Token: 0x02000026 RID: 38
		public enum Protection : uint
		{
			// Token: 0x040002B1 RID: 689
			PAGE_NOACCESS = 1u,
			// Token: 0x040002B2 RID: 690
			PAGE_READONLY,
			// Token: 0x040002B3 RID: 691
			PAGE_READWRITE = 4u,
			// Token: 0x040002B4 RID: 692
			PAGE_WRITECOPY = 8u,
			// Token: 0x040002B5 RID: 693
			PAGE_EXECUTE = 16u,
			// Token: 0x040002B6 RID: 694
			PAGE_EXECUTE_READ = 32u,
			// Token: 0x040002B7 RID: 695
			PAGE_EXECUTE_READWRITE = 64u,
			// Token: 0x040002B8 RID: 696
			PAGE_EXECUTE_WRITECOPY = 128u,
			// Token: 0x040002B9 RID: 697
			PAGE_GUARD = 256u,
			// Token: 0x040002BA RID: 698
			PAGE_NOCACHE = 512u,
			// Token: 0x040002BB RID: 699
			PAGE_WRITECOMBINE = 1024u
		}

		// Token: 0x02000027 RID: 39
		public class MemoryRegion
		{
			// Token: 0x040002BC RID: 700
			public long regionStart;

			// Token: 0x040002BD RID: 701
			public long regionSize;

			// Token: 0x040002BE RID: 702
			public MemAPI.AllocationProtectEnum protect;

			// Token: 0x040002BF RID: 703
			public MemAPI.StateEnum state;
		}
	}
}
