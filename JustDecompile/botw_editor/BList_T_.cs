using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace botw_editor
{
	[XmlRoot("blist")]
	public class BList<T> : BindingList<T>, IXmlSerializable
	{
		public BList()
		{
		}

		public XmlSchema GetSchema()
		{
			return null;
		}

		public void ReadXml(XmlReader reader)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			bool isEmptyElement = reader.IsEmptyElement;
			reader.Read();
			if (isEmptyElement)
			{
				return;
			}
			while (reader.NodeType != XmlNodeType.EndElement)
			{
				reader.ReadStartElement("item");
				T t = (T)xmlSerializer.Deserialize(reader);
				reader.ReadEndElement();
				base.Add(t);
				reader.MoveToContent();
			}
			reader.ReadEndElement();
		}

		public void WriteXml(XmlWriter writer)
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			foreach (T item in base.Items)
			{
				writer.WriteStartElement("item");
				xmlSerializer.Serialize(writer, item);
				writer.WriteEndElement();
			}
		}
	}
}