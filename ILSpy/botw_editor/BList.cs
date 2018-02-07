using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace botw_editor
{
	[XmlRoot("blist")]
	public class BList<T> : BindingList<T>, IXmlSerializable
	{
		public XmlSchema GetSchema()
		{
			return null;
		}

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
