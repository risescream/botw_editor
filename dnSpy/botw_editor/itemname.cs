using System;

namespace botw_editor
{
	// Token: 0x0200000D RID: 13
	public class itemname
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x0001BE3C File Offset: 0x0001A03C
		public itemname(string id = "", string name = "")
		{
			this.itemID = id;
			this.itemName = name;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0001BE68 File Offset: 0x0001A068
		public override string ToString()
		{
			if (!(this.itemName == ""))
			{
				return this.itemName;
			}
			return this.itemID;
		}

		// Token: 0x040001FB RID: 507
		public string itemID = "";

		// Token: 0x040001FC RID: 508
		public string itemName = "";
	}
}
