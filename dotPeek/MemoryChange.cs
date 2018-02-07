namespace botw_editor
{
  public class MemoryChange
  {
    public byte[] oldBuffer = new byte[432];
    public byte[] newBuffer = new byte[432];
    public long regionStart;
    public long regionSize;
    public long address;
    public byte oldValue;
    public byte newValue;
  }
}
