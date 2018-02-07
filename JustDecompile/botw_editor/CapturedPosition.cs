using System;

namespace botw_editor
{
	public class CapturedPosition
	{
		public float X;

		public float Y;

		public float Z;

		public string Name = "";

		public CapturedPosition()
		{
		}

		public override string ToString()
		{
			string str = string.Concat(new string[] { "X=", this.X.ToString(), " Y=", this.Y.ToString(), " Z=", this.Z.ToString() });
			return string.Concat((this.Name != "" ? string.Concat(this.Name, " - ") : ""), str);
		}
	}
}