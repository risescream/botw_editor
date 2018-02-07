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
    private IntPtr hProc = IntPtr.Zero;
    public const int PROCESS_QUERY_INFORMATION = 1024;
    public const int MEM_COMMIT = 4096;
    public const int PAGE_READWRITE = 4;
    public const int PROCESS_WM_READ = 16;
    public static object obj;
    private Process _p;
    private string _processName;

    public Process p
    {
      get
      {
        if (this._p == null && this.ProcessName != "")
          this._p = ((IEnumerable<Process>) Process.GetProcessesByName(this.ProcessName)).FirstOrDefault<Process>();
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
          return "";
        return this._processName;
      }
      set
      {
        if (value == "" || value == null)
        {
          this.p = (Process) null;
        }
        else
        {
          this._processName = value;
          this.p = ((IEnumerable<Process>) Process.GetProcessesByName(this.ProcessName)).FirstOrDefault<Process>();
        }
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
        return;
      foreach (ProcessThread thread in (ReadOnlyCollectionBase) p.Threads)
      {
        IntPtr num1 = MemAPI.OpenThread(MemAPI.ThreadAccess.SUSPEND_RESUME, false, (uint) thread.Id);
        if (!(num1 == IntPtr.Zero))
        {
          int num2 = (int) MemAPI.SuspendThread(num1);
          MemAPI.CloseHandle(num1);
        }
      }
    }

    public static void ResumeProcess(Process p)
    {
      if (p.ProcessName == string.Empty)
        return;
      foreach (ProcessThread thread in (ReadOnlyCollectionBase) p.Threads)
      {
        IntPtr num = MemAPI.OpenThread(MemAPI.ThreadAccess.SUSPEND_RESUME, false, (uint) thread.Id);
        if (!(num == IntPtr.Zero))
        {
          do
            ;
          while (MemAPI.ResumeThread(num) > 0);
          MemAPI.CloseHandle(num);
        }
      }
    }

    public static byte ReadByte(long address, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] buffer = new byte[1];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, buffer, buffer.Length, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return buffer[0];
    }

    public static void WriteByte(long address, byte newValue, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] lpBuffer = new byte[1]{ newValue };
      int lpNumberOfBytesWritten = 0;
      MemAPI.WriteProcessMemory(hProc, address, lpBuffer, 1U, out lpNumberOfBytesWritten);
      if (!(hProc == IntPtr.Zero))
        return;
      MemAPI.CloseHandle(hProcess);
    }

    public static int ReadBytes(long address, byte[] buffer, int count, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, buffer, count, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return lpNumberOfBytesRead;
    }

    public static int WriteBytes(long address, byte[] buffer, int count, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      int lpNumberOfBytesWritten = 0;
      MemAPI.WriteProcessMemory(hProc, address, buffer, (uint) count, out lpNumberOfBytesWritten);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return lpNumberOfBytesWritten;
    }

    public static byte[] ReadBytes(long address, int count, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] buffer = new byte[count];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, buffer, buffer.Length, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return buffer;
    }

    public static int ReadInt32(long address, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] buffer = new byte[4];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, buffer, buffer.Length, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) buffer);
      return BitConverter.ToInt32(buffer, 0);
    }

    public static uint ReadUInt32(long address, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] buffer = new byte[4];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, buffer, buffer.Length, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) buffer);
      return BitConverter.ToUInt32(buffer, 0);
    }

    public static float ReadSingle(long address, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] buffer = new byte[4];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, buffer, buffer.Length, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) buffer);
      return BitConverter.ToSingle(buffer, 0);
    }

    public static void WriteInt32(long address, int newValue, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] bytes = BitConverter.GetBytes(newValue);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      int lpNumberOfBytesWritten = 0;
      MemAPI.WriteProcessMemory(hProc, address, bytes, 4U, out lpNumberOfBytesWritten);
      if (!(hProc == IntPtr.Zero))
        return;
      MemAPI.CloseHandle(hProcess);
    }

    public static void WriteUInt32(long address, uint newValue, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] bytes = BitConverter.GetBytes(newValue);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      int lpNumberOfBytesWritten = 0;
      MemAPI.WriteProcessMemory(hProc, address, bytes, 4U, out lpNumberOfBytesWritten);
      if (!(hProc == IntPtr.Zero))
        return;
      MemAPI.CloseHandle(hProcess);
    }

    public static void WriteSingle(long address, float newValue, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] bytes = BitConverter.GetBytes(newValue);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) bytes);
      int lpNumberOfBytesWritten = 0;
      MemAPI.WriteProcessMemory(hProc, address, bytes, 4U, out lpNumberOfBytesWritten);
      if (!(hProc == IntPtr.Zero))
        return;
      MemAPI.CloseHandle(hProcess);
    }

    public static string ReadString(long address, int count, Process p, IntPtr hProc)
    {
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] numArray = new byte[count + 1];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, numArray, numArray.Length - 1, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return Encoding.ASCII.GetString(numArray);
    }

    public static int ExtractInt32FromArray(byte[] buffer, int start = 0)
    {
      byte[] numArray = new byte[4];
      Array.Copy((Array) buffer, start, (Array) numArray, 0, 4);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) numArray);
      return BitConverter.ToInt32(numArray, 0);
    }

    public static short ExtractInt16FromArray(byte[] buffer, int start = 0)
    {
      byte[] numArray = new byte[2];
      Array.Copy((Array) buffer, start, (Array) numArray, 0, 2);
      if (BitConverter.IsLittleEndian)
        Array.Reverse((Array) numArray);
      return BitConverter.ToInt16(numArray, 0);
    }

    public static string ExtractStringFromArray(byte[] buffer, int start = 0, int len = -1)
    {
      string str = "";
      int num = start;
      while ((len < 0 ? 1 : (num - start < len ? 1 : 0)) != 0 && num < buffer.Length && (int) buffer[num++] != 0)
        str += Encoding.ASCII.GetString(buffer, num - 1, 1);
      return str;
    }

    public static string GetBigEndianUnicodeString(byte[] buffer, int start, out int size)
    {
      string str = "";
      int index = start;
      int num = buffer.Length - 1;
      size = 0;
      while (index < num && ((int) buffer[index] != 0 || (int) buffer[index + 1] != 0))
      {
        str += Encoding.BigEndianUnicode.GetString(buffer, index, 2);
        index += 2;
        size = size + 1;
      }
      return str;
    }

    public static string ExtractUnicodeStringFromArray2(byte[] buffer, int start = 0)
    {
      string str = "";
      int index = start;
      while (index < buffer.Length)
      {
        str += Encoding.BigEndianUnicode.GetString(buffer, index, 2);
        index += 2;
        if ((int) buffer[index] == 0 && (int) buffer[index + 1] == 0)
          break;
      }
      return str;
    }

    public static string ExtractUnicodeStringFromArray(byte[] buffer, int start = 0)
    {
      string str = "";
      int index = start;
      while (index < buffer.Length)
      {
        str += Encoding.Unicode.GetString(buffer, index, 2);
        index += 2;
        if ((int) buffer[index] == 0 && (int) buffer[index + 1] == 0)
          break;
      }
      return str;
    }

    public static string ExtractStringFromMemory(long address, int maxBufferSize, Process p, IntPtr hProc)
    {
      string str = "";
      IntPtr hProcess = hProc == IntPtr.Zero ? MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, p.Id) : hProc;
      byte[] numArray = new byte[maxBufferSize];
      int lpNumberOfBytesRead = 0;
      MemAPI.ReadProcessMemory(hProcess, address, numArray, numArray.Length - 1, ref lpNumberOfBytesRead);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      int num = 0;
      while (num < numArray.Length && (int) numArray[num++] != 0)
        str += Encoding.ASCII.GetString(numArray, num - 1, 1);
      return str;
    }

    public static bool IsAscii(byte value)
    {
      return (int) value >= 33 && (int) value <= 126;
    }

    public static bool IsAsciiChar(byte value)
    {
      return (int) value >= 65 && (int) value <= 90 || (int) value >= 97 && (int) value <= 122;
    }

    public static bool IsAlphaNumAsciiChar(byte value)
    {
      return (int) value >= 48 && (int) value <= 57 || (int) value >= 65 && (int) value <= 90 || (int) value >= 97 && (int) value <= 122;
    }

    public static bool IsUpperChar(byte value)
    {
      return (int) value >= 65 && (int) value <= 90;
    }

    public static bool IsValidItemIDInArray(byte[] array, int index)
    {
      bool flag = true;
      if (!MemAPI.IsUpperChar(array[index]))
      {
        flag = false;
      }
      else
      {
        for (int index1 = index + 1; index1 < array.Length && (int) array[index1] != 0; ++index1)
        {
          if (!MemAPI.IsAscii(array[index1]))
          {
            flag = false;
            break;
          }
        }
      }
      return flag;
    }

    public static int findSequence(byte[] array, int start, byte[] sequence, bool loop = true, bool debug = false)
    {
      int num1 = array.Length - sequence.Length;
      byte num2 = sequence[0];
      for (; start < num1; ++start)
      {
        if ((int) array[start] == (int) num2)
        {
          for (int index = 1; index < sequence.Length && (int) array[start + index] == (int) sequence[index]; ++index)
          {
            if (index == sequence.Length - 1)
              return start;
          }
        }
        if (!loop)
          break;
      }
      return -1;
    }

    public static int findSequenceMatch(byte[] array, int start, int[] sequence, bool loop = true, bool debug = false)
    {
      int num1 = array.Length - sequence.Length;
      int num2 = sequence[0];
      for (; start < num1; ++start)
      {
        if (num2 == -1 || num2 == -2 && (int) array[start] != 0 || num2 > -1 && (int) array[start] == (int) (byte) num2)
        {
          for (int index = 1; index <= sequence.Length; ++index)
          {
            if (index >= sequence.Length)
              return start;
            if (index > 19)
            {
              string str1 = "0x" + sequence[index].ToString("X");
              string str2 = "0x" + ((int) array[start + index]).ToString("X");
            }
            if (sequence[index] != -1 && (sequence[index] != -2 || (int) array[start + index] == 0))
            {
              if ((int) array[start + index] == (int) (byte) sequence[index])
              {
                if (index == sequence.Length - 1)
                  return start;
              }
              else
                break;
            }
          }
        }
        if (!loop)
          break;
      }
      return -1;
    }

    public static long HexStringToInt64(string hexString)
    {
      long num = 0;
      try
      {
        num = Convert.ToInt64(hexString.Trim(), 16);
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public static int HexStringToInt32(string hexString)
    {
      int num = 0;
      try
      {
        num = Convert.ToInt32(hexString.Trim(), 16);
      }
      catch (Exception ex)
      {
      }
      return num;
    }

    public bool OpenProcessHandle()
    {
      bool flag = false;
      this.UpdateProcess("");
      if (this.hProc != IntPtr.Zero)
        return true;
      if (this.p != null)
      {
        this.hProc = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
        if (this.hProc != IntPtr.Zero)
          flag = true;
      }
      return flag;
    }

    public void CloseProcessHandle()
    {
      if (!(this.hProc != IntPtr.Zero))
        return;
      MemAPI.CloseHandle(this.hProc);
      this.hProc = IntPtr.Zero;
    }

    public void UpdateProcess(string processName = "")
    {
      processName = processName == "" ? this._processName : processName;
      this.ProcessName = processName;
    }

    public bool CheckOpenProcess()
    {
      bool flag = false;
      if (this.p == null)
        return flag;
      IntPtr hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      if (hProcess != IntPtr.Zero)
      {
        flag = true;
        MemAPI.CloseHandle(hProcess);
      }
      return flag;
    }

    public byte GetByteAt(long address)
    {
      byte num1 = 0;
      if (this.p == null)
        return num1;
      IntPtr num2 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      byte num3 = MemAPI.ReadByte(address, this.p, num2);
      MemAPI.CloseHandle(num2);
      return num3;
    }

    public int GetBytesAt(long address, byte[] buffer, int count)
    {
      if (this.p == null)
        return 0;
      IntPtr num1 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      int num2 = MemAPI.ReadBytes(address, buffer, count, this.p, num1);
      MemAPI.CloseHandle(num1);
      return num2;
    }

    public int GetInt32At(long address)
    {
      int num1 = 0;
      if (this.p == null)
        return num1;
      IntPtr num2 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      int num3 = MemAPI.ReadInt32(address, this.p, num2);
      MemAPI.CloseHandle(num2);
      return num3;
    }

    public uint GetUInt32At(long address)
    {
      uint num1 = 0;
      if (this.p == null)
        return num1;
      IntPtr num2 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      uint num3 = MemAPI.ReadUInt32(address, this.p, num2);
      MemAPI.CloseHandle(num2);
      return num3;
    }

    public float GetSingleAt(long address)
    {
      float num1 = 0.0f;
      if (this.p == null)
        return num1;
      IntPtr num2 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      float num3 = MemAPI.ReadSingle(address, this.p, num2);
      MemAPI.CloseHandle(num2);
      return num3;
    }

    public string GetStringAt(long address)
    {
      string str = "";
      if (this.p == null)
        return str;
      IntPtr num = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      string stringFromMemory = MemAPI.ExtractStringFromMemory(address, 128, this.p, num);
      MemAPI.CloseHandle(num);
      return stringFromMemory;
    }

    public void SetByteAt(long address, byte newValue)
    {
      if (this.p == null)
        return;
      IntPtr num = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      MemAPI.WriteByte(address, newValue, this.p, num);
      MemAPI.CloseHandle(num);
    }

    public void SetBytesAt(long address, byte[] buffer, int count)
    {
      if (this.p == null)
        return;
      IntPtr num = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      MemAPI.WriteBytes(address, buffer, count, this.p, num);
      MemAPI.CloseHandle(num);
    }

    public void SetInt32At(long address, int newValue)
    {
      if (this.p == null)
        return;
      IntPtr num = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      MemAPI.WriteInt32(address, newValue, this.p, num);
      MemAPI.CloseHandle(num);
    }

    public void SetUInt32At(long address, uint newValue)
    {
      if (this.p == null)
        return;
      IntPtr num = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      MemAPI.WriteUInt32(address, newValue, this.p, num);
      MemAPI.CloseHandle(num);
    }

    public void SetSingleAt(long address, float newValue)
    {
      if (this.p == null)
        return;
      IntPtr num = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      MemAPI.WriteSingle(address, newValue, this.p, num);
      MemAPI.CloseHandle(num);
    }

    public bool FindRegionBySize(long size, out long regionStart, out long regionSize, IntPtr hProc, long startAddress = 0, bool needReadWrite = true)
    {
      bool flag = false;
      regionStart = 0L;
      regionSize = 0L;
      IntPtr hProcess;
      if (hProc == IntPtr.Zero)
      {
        if (this.p == null)
          return false;
        hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      }
      else
        hProcess = hProc;
      long maxValue = long.MaxValue;
      long num = startAddress;
      do
      {
        MemAPI.MEMORY_BASIC_INFORMATION lpBuffer;
        MemAPI.VirtualQueryEx(hProcess, (IntPtr) num, out lpBuffer, (uint) Marshal.SizeOf(typeof (MemAPI.MEMORY_BASIC_INFORMATION)));
        if ((long) lpBuffer.RegionSize == size)
        {
          if (needReadWrite)
          {
            if (lpBuffer.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE && lpBuffer.State == MemAPI.StateEnum.MEM_COMMIT)
            {
              regionStart = (long) lpBuffer.BaseAddress;
              regionSize = (long) lpBuffer.RegionSize;
              flag = true;
              break;
            }
          }
          else
          {
            regionStart = (long) lpBuffer.BaseAddress;
            regionSize = (long) lpBuffer.RegionSize;
            flag = true;
            break;
          }
        }
        if (num != (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize)
          num = (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize;
        else
          break;
      }
      while (num <= maxValue);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return flag;
    }

    public bool FindRegionByAddr(long addr, out long regionStart, out long regionSize, IntPtr hProc, bool needReadWrite = true)
    {
      bool flag = false;
      regionStart = 0L;
      regionSize = 0L;
      IntPtr hProcess;
      if (hProc == IntPtr.Zero)
      {
        if (this.p == null)
          return false;
        hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      }
      else
        hProcess = hProc;
      long maxValue = long.MaxValue;
      long num = 0;
      do
      {
        MemAPI.MEMORY_BASIC_INFORMATION lpBuffer;
        MemAPI.VirtualQueryEx(hProcess, (IntPtr) num, out lpBuffer, (uint) Marshal.SizeOf(typeof (MemAPI.MEMORY_BASIC_INFORMATION)));
        if (addr >= (long) lpBuffer.BaseAddress && addr <= (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize)
        {
          if (needReadWrite)
          {
            if (lpBuffer.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE && lpBuffer.State == MemAPI.StateEnum.MEM_COMMIT)
            {
              regionStart = (long) lpBuffer.BaseAddress;
              regionSize = (long) lpBuffer.RegionSize;
              flag = true;
              break;
            }
          }
          else
          {
            regionStart = (long) lpBuffer.BaseAddress;
            regionSize = (long) lpBuffer.RegionSize;
            flag = true;
            break;
          }
        }
        if (num != (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize)
          num = (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize;
        else
          break;
      }
      while (num <= maxValue);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return flag;
    }

    public MemAPI.MemoryRegion[] listProcessMemoryRegions(IntPtr hProc)
    {
      List<MemAPI.MemoryRegion> memoryRegionList = new List<MemAPI.MemoryRegion>();
      IntPtr hProcess;
      if (hProc == IntPtr.Zero)
      {
        if (this.p == null)
          return memoryRegionList.ToArray();
        hProcess = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      }
      else
        hProcess = hProc;
      long maxValue = long.MaxValue;
      long num = 0;
      do
      {
        MemAPI.MEMORY_BASIC_INFORMATION lpBuffer;
        MemAPI.VirtualQueryEx(hProcess, (IntPtr) num, out lpBuffer, (uint) Marshal.SizeOf(typeof (MemAPI.MEMORY_BASIC_INFORMATION)));
        if ((long) lpBuffer.RegionSize > 0L && lpBuffer.State == MemAPI.StateEnum.MEM_COMMIT && lpBuffer.Type == MemAPI.TypeEnum.MEM_PRIVATE && (lpBuffer.Protect == MemAPI.AllocationProtectEnum.PAGE_READWRITE || lpBuffer.Protect == MemAPI.AllocationProtectEnum.PAGE_EXECUTE_READWRITE))
          memoryRegionList.Add(new MemAPI.MemoryRegion()
          {
            regionStart = (long) lpBuffer.BaseAddress,
            regionSize = (long) lpBuffer.RegionSize,
            state = lpBuffer.State,
            protect = lpBuffer.Protect
          });
        if (num != (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize)
          num = (long) lpBuffer.BaseAddress + (long) lpBuffer.RegionSize;
        else
          break;
      }
      while (num <= maxValue);
      if (hProc == IntPtr.Zero)
        MemAPI.CloseHandle(hProcess);
      return memoryRegionList.ToArray();
    }

    public long pagedMemorySearch(byte[] search, MemAPI.MemoryRegion[] regions)
    {
      long num = -1;
      foreach (MemAPI.MemoryRegion region in regions)
      {
        num = this.pagedMemorySearch(search, region.regionStart, region.regionSize);
        if (num > 0L)
          break;
      }
      return num;
    }

    public long pagedMemorySearchMatch(int[] search, MemAPI.MemoryRegion[] regions)
    {
      long num = -1;
      foreach (MemAPI.MemoryRegion region in regions)
      {
        num = this.pagedMemorySearchMatch(search, region.regionStart, region.regionSize);
        if (num > 0L)
          break;
      }
      return num;
    }

    public long pagedMemorySearch(byte[] search, long startAddress, long regionSize)
    {
      long num1 = -1;
      int val2 = 20480;
      int count = Math.Max(search.Length * 20, val2);
      if (this.p == null)
        return num1;
      IntPtr num2 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      byte[] numArray = new byte[count];
      long num3 = startAddress;
      long num4 = startAddress + regionSize;
      long address = num3;
      while (address < num4)
      {
        MemAPI.ReadBytes(address, numArray, count, this.p, num2);
        int sequence;
        if ((sequence = MemAPI.findSequence(numArray, 0, search, true, false)) >= 0)
        {
          num1 = address + (long) sequence;
          break;
        }
        address += (long) (numArray.Length - search.Length);
      }
      MemAPI.CloseHandle(num2);
      return num1;
    }

    public long pagedMemorySearchMatch(int[] search, long startAddress, long regionSize)
    {
      long num1 = -1;
      int val2 = 20480;
      int count = Math.Max(search.Length * 20, val2);
      if (this.p == null)
        return num1;
      IntPtr num2 = MemAPI.OpenProcess(MemAPI.ProcessAccessFlags.All, false, this.p.Id);
      byte[] numArray = new byte[count];
      long num3 = startAddress;
      long num4 = startAddress + regionSize;
      long address = num3;
      while (address < num4)
      {
        MemAPI.ReadBytes(address, numArray, count, this.p, num2);
        int sequenceMatch;
        if ((sequenceMatch = MemAPI.findSequenceMatch(numArray, 0, search, true, false)) >= 0)
        {
          num1 = address + (long) sequenceMatch;
          break;
        }
        address += (long) (numArray.Length - search.Length);
      }
      MemAPI.CloseHandle(num2);
      return num1;
    }

    [Flags]
    public enum ProcessAccessFlags : uint
    {
      All = 2035711,
      Terminate = 1,
      CreateThread = 2,
      VMOperation = 8,
      VMRead = 16,
      VMWrite = 32,
      DupHandle = 64,
      SetInformation = 512,
      QueryInformation = 1024,
      Synchronize = 1048576,
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
      DIRECT_IMPERSONATION = 512,
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
      PAGE_WRITECOMBINE = 1024,
    }

    public enum StateEnum : uint
    {
      MEM_COMMIT = 4096,
      MEM_RESERVE = 8192,
      MEM_FREE = 65536,
    }

    public enum TypeEnum : uint
    {
      MEM_PRIVATE = 131072,
      MEM_MAPPED = 262144,
      MEM_IMAGE = 16777216,
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
      PAGE_WRITECOMBINE = 1024,
    }

    public class MemoryRegion
    {
      public long regionStart;
      public long regionSize;
      public MemAPI.AllocationProtectEnum protect;
      public MemAPI.StateEnum state;
    }
  }
}
