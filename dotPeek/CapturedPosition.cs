namespace botw_editor
{
  public class CapturedPosition
  {
    public string Name = "";
    public float X;
    public float Y;
    public float Z;

    public override string ToString()
    {
      return (this.Name != "" ? this.Name + " - " : "") + ("X=" + this.X.ToString() + " Y=" + this.Y.ToString() + " Z=" + this.Z.ToString());
    }
  }
}
