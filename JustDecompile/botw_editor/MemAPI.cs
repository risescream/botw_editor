using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace botw_editor
{
	internal class MemAPI
	{
		public const int PROCESS_QUERY_INFORMATION = 1024;

		public const int MEM_COMMIT = 4096;

		public const int PAGE_READWRITE = 4;

		public const int PROCESS_WM_READ = 16;

		public static object obj;

		private Process _p;

		private string _processName;

		private IntPtr hProc = IntPtr.Zero;

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

		static MemAPI()
		{
		}

		public MemAPI()
		{
		}

		public bool CheckOpenProcess()
		{
			bool flag = false;
			if (this.p == null)
			{
				return flag;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			if (intPtr != IntPtr.Zero)
			{
				flag = true;
				MemAPI.CloseHandle(intPtr);
			}
			return flag;
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern int CloseHandle(IntPtr hProcess);

		public void CloseProcessHandle()
		{
			if (this.hProc != IntPtr.Zero)
			{
				MemAPI.CloseHandle(this.hProc);
				this.hProc = IntPtr.Zero;
			}
		}

		public static short ExtractInt16FromArray(byte[] buffer, int start = 0)
		{
			byte[] numArray = new byte[2];
			Array.Copy(buffer, start, numArray, 0, 2);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numArray);
			}
			return BitConverter.ToInt16(numArray, 0);
		}

		public static int ExtractInt32FromArray(byte[] buffer, int start = 0)
		{
			byte[] numArray = new byte[4];
			Array.Copy(buffer, start, numArray, 0, 4);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numArray);
			}
			return BitConverter.ToInt32(numArray, 0);
		}

		public static string ExtractStringFromArray(byte[] buffer, int start = 0, int len = -1)
		{
			string str = "";
			int num = start;
			while (true)
			{
				if ((len < 0 ? false : num - start >= len) || num >= (int)buffer.Length)
				{
					break;
				}
				int num1 = num;
				num = num1 + 1;
				if (buffer[num1] == 0)
				{
					break;
				}
				str = string.Concat(str, Encoding.ASCII.GetString(buffer, num - 1, 1));
			}
			return str;
		}

		public static string ExtractStringFromMemory(long address, int maxBufferSize, Process p, IntPtr hProc)
		{
			string str = "";
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[maxBufferSize];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length - 1, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			int num1 = 0;
			while (num1 < (int)numArray.Length)
			{
				int num2 = num1;
				num1 = num2 + 1;
				if (numArray[num2] == 0)
				{
					break;
				}
				str = string.Concat(str, Encoding.ASCII.GetString(numArray, num1 - 1, 1));
			}
			return str;
		}

		public static string ExtractUnicodeStringFromArray(byte[] buffer, int start = 0)
		{
			string str = "";
			int num = start;
			do
			{
				if (num >= (int)buffer.Length)
				{
					break;
				}
				str = string.Concat(str, Encoding.Unicode.GetString(buffer, num, 2));
				num = num + 2;
			}
			while (buffer[num] != 0 || buffer[num + 1] != 0);
			return str;
		}

		public static string ExtractUnicodeStringFromArray2(byte[] buffer, int start = 0)
		{
			string str = "";
			int num = start;
			do
			{
				if (num >= (int)buffer.Length)
				{
					break;
				}
				str = string.Concat(str, Encoding.BigEndianUnicode.GetString(buffer, num, 2));
				num = num + 2;
			}
			while (buffer[num] != 0 || buffer[num + 1] != 0);
			return str;
		}

		public bool FindRegionByAddr(long addr, out long regionStart, out long regionSize, IntPtr hProc, bool needReadWrite = true)
		{
			IntPtr intPtr;
			MemAPI.MEMORY_BASIC_INFORMATION mEMORYBASICINFORMATION;
			bool flag = false;
			regionStart = (long)0;
			regionSize = (long)0;
			if (hProc != IntPtr.Zero)
			{
				intPtr = hProc;
			}
			else
			{
				if (this.p == null)
				{
					return false;
				}
				intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			}
			long num = 9223372036854775807L;
			long baseAddress = (long)0;
			do
			{
				MemAPI.VirtualQueryEx(intPtr, (IntPtr)baseAddress, out mEMORYBASICINFORMATION, (uint)Marshal.SizeOf(typeof(MemAPI.MEMORY_BASIC_INFORMATION)));
				if (addr >= (long)mEMORYBASICINFORMATION.BaseAddress && addr <= (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize)
				{
					if (!needReadWrite)
					{
						regionStart = (long)mEMORYBASICINFORMATION.BaseAddress;
						regionSize = (long)mEMORYBASICINFORMATION.RegionSize;
						flag = true;
						break;
					}
					else if (mEMORYBASICINFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE && mEMORYBASICINFORMATION.State == MemAPI.StateEnum.MEM_COMMIT)
					{
						regionStart = (long)mEMORYBASICINFORMATION.BaseAddress;
						regionSize = (long)mEMORYBASICINFORMATION.RegionSize;
						flag = true;
						break;
					}
				}
				if (baseAddress == (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize)
				{
					break;
				}
				baseAddress = (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize;
			}
			while (baseAddress <= num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return flag;
		}

		public bool FindRegionBySize(long size, out long regionStart, out long regionSize, IntPtr hProc, long startAddress = 0L, bool needReadWrite = true)
		{
			IntPtr intPtr;
			MemAPI.MEMORY_BASIC_INFORMATION mEMORYBASICINFORMATION;
			bool flag = false;
			regionStart = (long)0;
			regionSize = (long)0;
			if (hProc != IntPtr.Zero)
			{
				intPtr = hProc;
			}
			else
			{
				if (this.p == null)
				{
					return false;
				}
				intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			}
			long num = 9223372036854775807L;
			long baseAddress = startAddress;
			do
			{
				MemAPI.VirtualQueryEx(intPtr, (IntPtr)baseAddress, out mEMORYBASICINFORMATION, (uint)Marshal.SizeOf(typeof(MemAPI.MEMORY_BASIC_INFORMATION)));
				if ((long)mEMORYBASICINFORMATION.RegionSize == size)
				{
					if (!needReadWrite)
					{
						regionStart = (long)mEMORYBASICINFORMATION.BaseAddress;
						regionSize = (long)mEMORYBASICINFORMATION.RegionSize;
						flag = true;
						break;
					}
					else if (mEMORYBASICINFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE && mEMORYBASICINFORMATION.State == MemAPI.StateEnum.MEM_COMMIT)
					{
						regionStart = (long)mEMORYBASICINFORMATION.BaseAddress;
						regionSize = (long)mEMORYBASICINFORMATION.RegionSize;
						flag = true;
						break;
					}
				}
				if (baseAddress == (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize)
				{
					break;
				}
				baseAddress = (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize;
			}
			while (baseAddress <= num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return flag;
		}

		public static int findSequence(byte[] array, int start, byte[] sequence, bool loop = true, bool debug = false)
		{
			int length = (int)array.Length - (int)sequence.Length;
			byte num = sequence[0];
			while (start < length)
			{
				if (array[start] == num)
				{
					for (int i = 1; i < (int)sequence.Length && array[start + i] == sequence[i]; i++)
					{
						if (i == (int)sequence.Length - 1)
						{
							return start;
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

		public static int findSequenceMatch(byte[] array, int start, int[] sequence, bool loop = true, bool debug = false)
		{
			int length = (int)array.Length - (int)sequence.Length;
			int num = sequence[0];
			while (start < length)
			{
				if (num == -1 || num == -2 && array[start] != 0 || num > -1 && array[start] == (byte)num)
				{
					for (int i = 1; i <= (int)sequence.Length; i++)
					{
						if (i >= (int)sequence.Length)
						{
							return start;
						}
						if (i > 19)
						{
							int num1 = sequence[i];
							string.Concat("0x", num1.ToString("X"));
							int num2 = array[start + i];
							string.Concat("0x", num2.ToString("X"));
						}
						if (sequence[i] != -1 && (sequence[i] != -2 || array[start + i] == 0))
						{
							if (array[start + i] != (byte)sequence[i])
							{
								break;
							}
							if (i == (int)sequence.Length - 1)
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

		public static string GetBigEndianUnicodeString(byte[] buffer, int start, out int size)
		{
			string str = "";
			int num = start;
			int length = (int)buffer.Length - 1;
			size = 0;
			while (num < length && (buffer[num] != 0 || buffer[num + 1] != 0))
			{
				str = string.Concat(str, Encoding.BigEndianUnicode.GetString(buffer, num, 2));
				num = num + 2;
				size = size + 1;
			}
			return str;
		}

		public byte GetByteAt(long address)
		{
			byte num = 0;
			if (this.p == null)
			{
				return num;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			num = MemAPI.ReadByte(address, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
			return num;
		}

		public int GetBytesAt(long address, byte[] buffer, int count)
		{
			if (this.p == null)
			{
				return 0;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			int num = MemAPI.ReadBytes(address, buffer, count, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
			return num;
		}

		public int GetInt32At(long address)
		{
			int num = 0;
			if (this.p == null)
			{
				return num;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			num = MemAPI.ReadInt32(address, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
			return num;
		}

		public float GetSingleAt(long address)
		{
			float single = 0f;
			if (this.p == null)
			{
				return single;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			single = MemAPI.ReadSingle(address, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
			return single;
		}

		public string GetStringAt(long address)
		{
			string str = "";
			if (this.p == null)
			{
				return str;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			str = MemAPI.ExtractStringFromMemory(address, 128, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
			return str;
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern void GetSystemInfo(out MemAPI.SYSTEM_INFO lpSystemInfo);

		public uint GetUInt32At(long address)
		{
			uint num = 0;
			if (this.p == null)
			{
				return num;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			num = MemAPI.ReadUInt32(address, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
			return num;
		}

		public static int HexStringToInt32(string hexString)
		{
			int num = 0;
			try
			{
				num = Convert.ToInt32(hexString.Trim(), 16);
			}
			catch (Exception exception)
			{
			}
			return num;
		}

		public static long HexStringToInt64(string hexString)
		{
			long num = (long)0;
			try
			{
				num = Convert.ToInt64(hexString.Trim(), 16);
			}
			catch (Exception exception)
			{
			}
			return num;
		}

		public static bool IsAlphaNumAsciiChar(byte value)
		{
			if (value >= 48 && value <= 57 || value >= 65 && value <= 90 || value >= 97 && value <= 122)
			{
				return true;
			}
			return false;
		}

		public static bool IsAscii(byte value)
		{
			if (value >= 33 && value <= 126)
			{
				return true;
			}
			return false;
		}

		public static bool IsAsciiChar(byte value)
		{
			if (value >= 65 && value <= 90 || value >= 97 && value <= 122)
			{
				return true;
			}
			return false;
		}

		public static bool IsUpperChar(byte value)
		{
			if (value >= 65 && value <= 90)
			{
				return true;
			}
			return false;
		}

		public static bool IsValidItemIDInArray(byte[] array, int index)
		{
			bool flag = true;
			if (MemAPI.IsUpperChar(array[index]))
			{
				int num = index + 1;
				while (num < (int)array.Length && array[num] != 0)
				{
					if (MemAPI.IsAscii(array[num]))
					{
						num++;
					}
					else
					{
						flag = false;
						break;
					}
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}

		public MemAPI.MemoryRegion[] listProcessMemoryRegions(IntPtr hProc)
		{
			IntPtr intPtr;
			MemAPI.MEMORY_BASIC_INFORMATION mEMORYBASICINFORMATION;
			List<MemAPI.MemoryRegion> memoryRegions = new List<MemAPI.MemoryRegion>();
			if (hProc != IntPtr.Zero)
			{
				intPtr = hProc;
			}
			else
			{
				if (this.p == null)
				{
					return memoryRegions.ToArray();
				}
				intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			}
			long num = 9223372036854775807L;
			long baseAddress = (long)0;
			do
			{
				MemAPI.VirtualQueryEx(intPtr, (IntPtr)baseAddress, out mEMORYBASICINFORMATION, (uint)Marshal.SizeOf(typeof(MemAPI.MEMORY_BASIC_INFORMATION)));
				if ((long)mEMORYBASICINFORMATION.RegionSize > (long)0 && mEMORYBASICINFORMATION.State == MemAPI.StateEnum.MEM_COMMIT && mEMORYBASICINFORMATION.Type == MemAPI.TypeEnum.MEM_PRIVATE && (mEMORYBASICINFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE || mEMORYBASICINFORMATION.Protect == MemAPI.AllocationProtectEnum.PAGE_EXECUTE_READWRITE))
				{
					MemAPI.MemoryRegion memoryRegion = new MemAPI.MemoryRegion()
					{
						regionStart = (long)mEMORYBASICINFORMATION.BaseAddress,
						regionSize = (long)mEMORYBASICINFORMATION.RegionSize,
						state = mEMORYBASICINFORMATION.State,
						protect = mEMORYBASICINFORMATION.Protect
					};
					memoryRegions.Add(memoryRegion);
				}
				if (baseAddress == (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize)
				{
					break;
				}
				baseAddress = (long)mEMORYBASICINFORMATION.BaseAddress + (long)mEMORYBASICINFORMATION.RegionSize;
			}
			while (baseAddress <= num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return memoryRegions.ToArray();
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern IntPtr OpenProcess(MemAPI.ProcessAccessFlags dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		public bool OpenProcessHandle()
		{
			bool flag = false;
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
					flag = true;
				}
			}
			return flag;
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern IntPtr OpenThread(MemAPI.ThreadAccess dwDesiredAccess, bool bInheritHandle, uint dwThreadId);

		public long pagedMemorySearch(byte[] search, MemAPI.MemoryRegion[] regions)
		{
			long num = (long)-1;
			MemAPI.MemoryRegion[] memoryRegionArray = regions;
			for (int i = 0; i < (int)memoryRegionArray.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = memoryRegionArray[i];
				num = this.pagedMemorySearch(search, memoryRegion.regionStart, memoryRegion.regionSize);
				if (num > (long)0)
				{
					break;
				}
			}
			return num;
		}

		public long pagedMemorySearch(byte[] search, long startAddress, long regionSize)
		{
			long num = (long)-1;
			int num1 = 20480;
			int num2 = Math.Max((int)search.Length * 20, num1);
			if (this.p == null)
			{
				return num;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			byte[] numArray = new byte[num2];
			long num3 = startAddress + regionSize;
			long length = startAddress;
			while (length < num3)
			{
				MemAPI.ReadBytes(length, numArray, num2, this.p, intPtr);
				int num4 = -1;
				int num5 = MemAPI.findSequence(numArray, 0, search, true, false);
				num4 = num5;
				if (num5 < 0)
				{
					length = length + (long)((int)numArray.Length - (int)search.Length);
				}
				else
				{
					num = length + (long)num4;
					break;
				}
			}
			MemAPI.CloseHandle(intPtr);
			return num;
		}

		public long pagedMemorySearchMatch(int[] search, MemAPI.MemoryRegion[] regions)
		{
			long num = (long)-1;
			MemAPI.MemoryRegion[] memoryRegionArray = regions;
			for (int i = 0; i < (int)memoryRegionArray.Length; i++)
			{
				MemAPI.MemoryRegion memoryRegion = memoryRegionArray[i];
				num = this.pagedMemorySearchMatch(search, memoryRegion.regionStart, memoryRegion.regionSize);
				if (num > (long)0)
				{
					break;
				}
			}
			return num;
		}

		public long pagedMemorySearchMatch(int[] search, long startAddress, long regionSize)
		{
			long num = (long)-1;
			int num1 = 20480;
			int num2 = Math.Max((int)search.Length * 20, num1);
			if (this.p == null)
			{
				return num;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			byte[] numArray = new byte[num2];
			long num3 = startAddress + regionSize;
			long length = startAddress;
			while (length < num3)
			{
				MemAPI.ReadBytes(length, numArray, num2, this.p, intPtr);
				int num4 = -1;
				int num5 = MemAPI.findSequenceMatch(numArray, 0, search, true, false);
				num4 = num5;
				if (num5 < 0)
				{
					length = length + (long)((int)numArray.Length - (int)search.Length);
				}
				else
				{
					num = length + (long)num4;
					break;
				}
			}
			MemAPI.CloseHandle(intPtr);
			return num;
		}

		public static byte ReadByte(long address, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[1];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return numArray[0];
		}

		public static int ReadBytes(long address, byte[] buffer, int count, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, buffer, count, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return num;
		}

		public static byte[] ReadBytes(long address, int count, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[count];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return numArray;
		}

		public static int ReadInt32(long address, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[4];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numArray);
			}
			return BitConverter.ToInt32(numArray, 0);
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		private static extern bool ReadProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] buffer, int size, ref int lpNumberOfBytesRead);

		public static float ReadSingle(long address, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[4];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numArray);
			}
			return BitConverter.ToSingle(numArray, 0);
		}

		public static string ReadString(long address, int count, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[count + 1];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length - 1, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return Encoding.ASCII.GetString(numArray);
		}

		public static uint ReadUInt32(long address, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[4];
			int num = 0;
			MemAPI.ReadProcessMemory(intPtr, address, numArray, (int)numArray.Length, ref num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(numArray);
			}
			return BitConverter.ToUInt32(numArray, 0);
		}

		public static void ResumeProcess(Process p)
		{
			if (p.ProcessName == string.Empty)
			{
				return;
			}
			foreach (ProcessThread thread in p.Threads)
			{
				IntPtr intPtr = MemAPI.OpenThread(MemAPI.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
				if (intPtr == IntPtr.Zero)
				{
					continue;
				}
				while (MemAPI.ResumeThread(intPtr) > 0)
				{
				}
				MemAPI.CloseHandle(intPtr);
			}
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern int ResumeThread(IntPtr hThread);

		public void SetByteAt(long address, byte newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteByte(address, newValue, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
		}

		public void SetBytesAt(long address, byte[] buffer, int count)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteBytes(address, buffer, count, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
		}

		public void SetInt32At(long address, int newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteInt32(address, newValue, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
		}

		public void SetSingleAt(long address, float newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteSingle(address, newValue, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
		}

		public void SetUInt32At(long address, uint newValue)
		{
			if (this.p == null)
			{
				return;
			}
			IntPtr intPtr = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
			MemAPI.WriteUInt32(address, newValue, this.p, intPtr);
			MemAPI.CloseHandle(intPtr);
		}

		public static void SuspendProcess(Process p)
		{
			if (p.ProcessName == string.Empty)
			{
				return;
			}
			foreach (ProcessThread thread in p.Threads)
			{
				IntPtr intPtr = MemAPI.OpenThread(MemAPI.ThreadAccess.SUSPEND_RESUME, false, (uint)thread.Id);
				if (intPtr == IntPtr.Zero)
				{
					continue;
				}
				MemAPI.SuspendThread(intPtr);
				MemAPI.CloseHandle(intPtr);
			}
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern uint SuspendThread(IntPtr hThread);

		public void UpdateProcess(string processName = "")
		{
			processName = (processName == "" ? this._processName : processName);
			this.ProcessName = processName;
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false)]
		public static extern bool VirtualProtectEx(IntPtr hProcess, IntPtr dwAddress, UIntPtr nSize, uint flNewProtect, out uint lpflOldProtect);

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false, SetLastError=true)]
		public static extern int VirtualQueryEx(IntPtr hProcess, IntPtr lpAddress, out MemAPI.MEMORY_BASIC_INFORMATION lpBuffer, uint dwLength);

		public static void WriteByte(long address, byte newValue, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] numArray = new byte[] { newValue };
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, numArray, 1, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
		}

		public static int WriteBytes(long address, byte[] buffer, int count, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, buffer, (uint)count, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
			return num;
		}

		public static void WriteInt32(long address, int newValue, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] bytes = BitConverter.GetBytes(newValue);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, bytes, 4, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
		}

		[DllImport("kernel32.dll", CharSet=CharSet.None, ExactSpelling=false, SetLastError=true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, long lpBaseAddress, byte[] lpBuffer, uint nSize, out int lpNumberOfBytesWritten);

		public static void WriteSingle(long address, float newValue, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] bytes = BitConverter.GetBytes(newValue);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, bytes, 4, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
		}

		public static void WriteUInt32(long address, uint newValue, Process p, IntPtr hProc)
		{
			IntPtr intPtr = (hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc);
			byte[] bytes = BitConverter.GetBytes(newValue);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			int num = 0;
			MemAPI.WriteProcessMemory(hProc, address, bytes, 4, out num);
			if (hProc == IntPtr.Zero)
			{
				MemAPI.CloseHandle(intPtr);
			}
		}

		public enum AllocationProtectEnum : uint
		{
			PAGE_NOACCESS = 1,
			PAGE_READONLY = 2,
			PAGE_READWRITE = 4,
			PAGE_WRITECOPY = 8,
			PAGE_EXECUTE = 16,
			PAGE_EXECUTE_READ = 32,
			PAGE_EXECUTE_READWRITE = 64,
			PAGE_EXECUTE_WRITECOPY = 128,
			PAGE_GUARD = 256,
			PAGE_NOCACHE = 512,
			PAGE_WRITECOMBINE = 1024
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

		public class MemoryRegion
		{
			public long regionStart;

			public long regionSize;

			public MemAPI.AllocationProtectEnum protect;

			public MemAPI.StateEnum state;

			public MemoryRegion()
			{
			}
		}

		[Flags]
		public enum ProcessAccessFlags : uint
		{
			Terminate = 1,
			CreateThread = 2,
			VMOperation = 8,
			VMRead = 16,
			VMWrite = 32,
			DupHandle = 64,
			SetInformation = 512,
			QueryInformation = 1024,
			Synchronize = 1048576,
			All = 2035711
		}

		public enum Protection : uint
		{
			PAGE_NOACCESS = 1,
			PAGE_READONLY = 2,
			PAGE_READWRITE = 4,
			PAGE_WRITECOPY = 8,
			PAGE_EXECUTE = 16,
			PAGE_EXECUTE_READ = 32,
			PAGE_EXECUTE_READWRITE = 64,
			PAGE_EXECUTE_WRITECOPY = 128,
			PAGE_GUARD = 256,
			PAGE_NOCACHE = 512,
			PAGE_WRITECOMBINE = 1024
		}

		public enum StateEnum : uint
		{
			MEM_COMMIT = 4096,
			MEM_RESERVE = 8192,
			MEM_FREE = 65536
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

		public enum TypeEnum : uint
		{
			MEM_PRIVATE = 131072,
			MEM_MAPPED = 262144,
			MEM_IMAGE = 16777216
		}
	}
}