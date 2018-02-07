using System.Collections.Generic;

namespace botw_editor
{
  public class QueueItem
  {
    public string name = "";
    public string type = "";
    public string message = "";
    public int valueInt32 = -1;
    public long valueInt64 = -1;
    public List<object> datalist = new List<object>();
    public bool status;
    public QueueItemCode byteCode;
    public byte valueByte;
    public object data;

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
