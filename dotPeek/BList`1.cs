using System.Collections.Generic;
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
      return (XmlSchema) null;
    }

    public void ReadXml(XmlReader reader)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      int num = reader.IsEmptyElement ? 1 : 0;
      reader.Read();
      if (num != 0)
        return;
      while (reader.NodeType != XmlNodeType.EndElement)
      {
        reader.ReadStartElement("item");
        T obj = (T) xmlSerializer.Deserialize(reader);
        reader.ReadEndElement();
        this.Add(obj);
        int content = (int) reader.MoveToContent();
      }
      reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      foreach (T obj in (IEnumerable<T>) this.Items)
      {
        writer.WriteStartElement("item");
        xmlSerializer.Serialize(writer, (object) obj);
        writer.WriteEndElement();
      }
    }
  }
}
