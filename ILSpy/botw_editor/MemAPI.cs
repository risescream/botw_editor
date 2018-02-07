using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace botw_editor
{
	internal class MemAPI
	{
		[Flags]
		public enum ProcessAccessFlags : uint
		{
			All = 2035711u,
			Terminate = 1u,
			CreateThread = 2u,
			VMOperation = 8u,
			VMRead = 16u,
			VMWrite = 32u,
			DupHandle = 64u,
			SetInformation = 512u,
			QueryInformation = 1024u,
			Synchronize = 1048576u
		}

		[Flags]
		public enum ThreadAccess
		{
			TERMINATE = 1,
			SUSPEND_RESUME = 2,
			GET_CONTEXT = 8,
			SET_CONTEXT = 16,
			SET_INFORMATION = 32,
			QUERY_INFORMATION = 64,
			SET_THREAD_TOKEN = 128,
			IMPERSONATE = 256,
			DIRECT_IMPERSONATION = 512
		}

		public struct MEMORY_BASIC_INFORMATION
		{
			public IntPtr BaseAddress;

			public IntPtr AllocationBase;

			public MemAPI.AllocationProtectEnum AllocationProtect;

			public IntPtr RegionSize;

			public MemAPI.StateEnum State;

			public MemAPI.AllocationProtectEnum Protect;

			public MemAPI.TypeEnum Type;
		}

		public struct MEMORY_BASIC_INFORMATION2
		{
			public IntPtr BaseAddress;

			public IntPtr AllocationBase;

			public uint AllocationProtect;

			public IntPtr RegionSize;

			public uint State;

			public uint Protect;

			public uint Type;
		}

		public enum AllocationProtectEnum : uint
		{
			PAGE_EXECUTE = 16u,
			PAGE_EXECUTE_READ = 32u,
			PAGE_EXECUTE_READWRITE = 64u,
			PAGE_EXECUTE_WRITECOPY = 128u,
			PAGE_NOACCESS = 1u,
			PAGE_READONLY,
			PAGE_READWRITE = 4u,
			PAGE_WRITECOPY = 8u,
			PAGE_GUARD = 256u,
			PAGE_NOCACHE = 512u,
			PAGE_WRITECOMBINE = 1024u
		}

		public enum StateEnum : uint
		{
			MEM_COMMIT = 4096u,
			MEM_FREE = 65536u,
			MEM_RESERVE = 8192u
		}

		public enum TypeEnum : uint
		{
			MEM_IMAGE = 16777216u,
			MEM_MAPPED = 262144u,
			MEM_PRIVATE = 131072u
		}

		public struct SYSTEM_INFO
		{
			public ushort processorArchitecture;

			private ushort reserved;

			public uint pageSize;

			public IntPtr minimumApplicationAddress;

			public IntPtr maximumApplicationAddress;

			public IntPtr activeProcessorMask;

			public uint numberOfProcessors;

			public uint processorType;

			public uint allocationGranularity;

			public ushort processorLevel;

			public ushort processorRevision;
		}

		public enum Protection : uint
		{
			PAGE_NOACCESS = 1u,
			PAGE_READONLY,
			PAGE_READWRITE = 4u,
			PAGE_WRITECOPY = 8u,
			PAGE_EXECUTE = 16u,
			PAGE_EXECUTE_READ = 32u,
			PAGE_EXECUTE_READWRITE = 64u,
			PAGE_EXECUTE_WRITECOPY = 128u,
			PAGE_GUARD = 256u,
			PAGE_NOCACHE = 512u,
			PAGE_WRITECOMBINE = 1024u
		}

		public class MemoryRegion
		{
			public long regionStart;

			public long regionSize;

			public MemAPI.AllocationProtectEnum protect;

			public MemAPI.StateEnum state;
		}

		public const int PROCESS_QUERY_INFORMATION = 1024;

		public const int MEM_COMMIT = 4096;

		public const int PAGE_READWRITE = 4;

		public const int PROCESS_WM_READ = 16;

		public static object obj;

		private Process _p;

		private string _processName;

		private IntPtr hProc = IntPtr.Zero;

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

		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr dwAddress, UIntPtr nSize, uint flNewProtect, out uint lpflOldProtect);

		[DllImport("kernel32.dll")]
		public static extern void GetSystemInfo(out MemAPI.SYSTEM_INFO lpSystemInfo);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MemAPI.MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenThread(MemAPI.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		[DllImport("kernel32.dll")]
		public static extern uint SuspendThread(IntPtr hThread);

		[DllImport("kernel32.dll")]
		public static extern int ResumeThread(IntPtr hThread);

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(MemAPI.ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		[DllImport("kernel32.dll")]
		public static extern int CloseHandle(IntPtr hProcess);

		[DllImport("kernel32.dll")]
		private static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

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

		public static bool IsAscii(byte value)
		{
			return value >= 33 && value <= 126;
		}

		public static bool IsAsciiChar(byte value)
		{
			return (value >= 65 && value <= 90) || (value >= 97 && value <= 122);
		}

		public static bool IsAlphaNumAsciiChar(byte value)
		{
			return (value >= 48 && value <= 57) || (value >= 65 && value <= 90) || (value >= 97 && value <= 122);
		}

		public static bool IsUpperChar(byte value)
		{
			return value >= 65 && value <= 90;
		}

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

		public void CloseProcessHandle()
		{
			if (this.hProc != IntPtr.Zero)
			{
				MemAPI.CloseHandle(this.hProc);
				this.hProc = IntPtr.Zero;
			}
		}

		public void UpdateProcess(string processName = "")
		{
			processName = ((processName == "") ? this._processName : processName);
			this.ProcessName = processName;
		}

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
	}
}
