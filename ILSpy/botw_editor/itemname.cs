using System;

namespace botw_editor
{
	public class itemname
	{
		public string itemID = "";

		public string itemName = "";

		public itemname(string id = "", string name = "")
		{
			this.itemID = id;
			this.itemName = name;
		}

		public override string ToString()
		{
			if (!(this.itemName == ""))
			{
				return this.itemName;
			}
			return this.itemID;
		}
	}
}
