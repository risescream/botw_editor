using System;
using System.Collections.Generic;

namespace botw_editor
{
	public class QueueItem
	{
		public bool status;

		public string name = "";

		public string type = "";

		public string message = "";

		public QueueItemCode byteCode;

		public int valueInt32 = -1;

		public long valueInt64 = -1L;

		public byte valueByte;

		public object data;

		public List<object> datalist = new List<object>();

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
	}
}
