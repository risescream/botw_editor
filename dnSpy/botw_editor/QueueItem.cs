using System;
using System.Collections.Generic;

namespace botw_editor
{
	// Token: 0x02000012 RID: 18
	public class QueueItem
	{
		// Token: 0x06000130 RID: 304 RVA: 0x0001D354 File Offset: 0x0001B554
		public QueueItem(QueueItemCode byteCode = QueueItemCode.NONE, string message = "", object data = null, bool status = false, string type = "", string name = "", List<object> datalist = null)
		{
			this.byteCode = byteCode;
			this.message = message;
			this.data = data;
			this.status = status;
			this.type = type;
			this.name = name;
			this.datalist = datalist;
		}

		// Token: 0x04000218 RID: 536
		public bool status;

		// Token: 0x04000219 RID: 537
		public string name = "";

		// Token: 0x0400021A RID: 538
		public string type = "";

		// Token: 0x0400021B RID: 539
		public string message = "";

		// Token: 0x0400021C RID: 540
		public QueueItemCode byteCode;

		// Token: 0x0400021D RID: 541
		public int valueInt32 = -1;

		// Token: 0x0400021E RID: 542
		public long valueInt64 = -1L;

		// Token: 0x0400021F RID: 543
		public byte valueByte;

		// Token: 0x04000220 RID: 544
		public object data;

		// Token: 0x04000221 RID: 545
		public List<object> datalist = new List<object>();
	}
}
