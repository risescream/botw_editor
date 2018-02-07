using System;

namespace botw_editor
{
	// Token: 0x02000008 RID: 8
	public class CapturedPosition
	{
		// Token: 0x06000097 RID: 151 RVA: 0x0000DD5C File Offset: 0x0000BF5C
		public override string ToString()
		{
			string str = string.Concat(new string[]
			{
				"X=",
				this.X.ToString(),
				" Y=",
				this.Y.ToString(),
				" Z=",
				this.Z.ToString()
			});
			return ((this.Name != "") ? (this.Name + " - ") : "") + str;
		}

		// Token: 0x04000058 RID: 88
		public float X;

		// Token: 0x04000059 RID: 89
		public float Y;

		// Token: 0x0400005A RID: 90
		public float Z;

		// Token: 0x0400005B RID: 91
		public string Name = "";
	}
}
