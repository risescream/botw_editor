using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace botw_editor
{
	// Token: 0x02000006 RID: 6
	[XmlRoot("blist")]
	public class BList<T> : BindingList<T>, IXmlSerializable
	{
		// Token: 0x0600008D RID: 141 RVA: 0x0000D92F File Offset: 0x0000BB2F
		public XmlSchema GetSchema()
		{
			return null;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000D934 File Offset: 0x0000BB34
		public void ReadXml(XmlReader reader)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			bool arg_1D_0 = reader.IsEmptyElement;
			reader.Read();
			if (arg_1D_0)
			{
				return;
			}
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				reader.ReadStartElement("item");
				T item = (T)((object)xmlSerializer.Deserialize(reader));
				reader.ReadEndElement();
				base.Add(item);
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000D9A0 File Offset: 0x0000BBA0
		public void WriteXml(XmlWriter writer)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			foreach (T current in base.Items)
			{
				writer.WriteStartElement("item");
				xmlSerializer.Serialize(writer, current);
				writer.WriteEndElement();
			}
		}
	}
}
