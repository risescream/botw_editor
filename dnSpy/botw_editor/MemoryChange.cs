using System;

namespace botw_editor
{
	// Token: 0x0200000F RID: 15
	public class MemoryChange
	{
		// Token: 0x04000205 RID: 517
		public long regionStart;

		// Token: 0x04000206 RID: 518
		public long regionSize;

		// Token: 0x04000207 RID: 519
		public long address;

		// Token: 0x04000208 RID: 520
		public byte oldValue;

		// Token: 0x04000209 RID: 521
		public byte newValue;

		// Token: 0x0400020A RID: 522
		public byte[] oldBuffer = new byte[432];

		// Token: 0x0400020B RID: 523
		public byte[] newBuffer = new byte[432];
	}
}
