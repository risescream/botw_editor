using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace botw_editor
{
  public class Settings
  {
    public int auto_update_timer = 15;
    public List<string> item_ids = new List<string>();
    public List<string> item_names = new List<string>();
    public List<actiondata> custom_actions = new List<actiondata>();
    public List<string> action_keys = new List<string>();
    public List<actiondata> action_datas = new List<actiondata>();
    public List<CapturedPosition> capturedPositions = new List<CapturedPosition>();
    public int internalLoopMs = 100;
    public bool auto_update;
    public int spacingMs;

    public static Settings deserialize(byte[] serializedObject)
    {
      XmlSerializer fromType = XmlSerializer.FromTypes(new Type[1]
      {
        typeof (Settings)
      })[0];
      try
      {
        return (Settings) fromType.Deserialize((Stream) new MemoryStream(serializedObject));
      }
      catch (Exception ex)
      {
        return (Settings) null;
      }
    }

    public static Settings loadFile(string fileName)
    {
      try
      {
        if (File.Exists(fileName))
        {
          using (FileStream fileStream = File.OpenRead(fileName))
          {
            MemoryStream memoryStream = new MemoryStream();
            memoryStream.SetLength(fileStream.Length);
            fileStream.Read(memoryStream.GetBuffer(), 0, (int) fileStream.Length);
            return Settings.deserialize(memoryStream.ToArray());
          }
        }
      }
      catch (Exception ex)
      {
      }
      return (Settings) null;
    }

    public bool writeFile(string fileName)
    {
      byte[] buffer = this.serialize();
      try
      {
        using (FileStream fileStream = File.Create(fileName))
        {
          fileStream.Write(buffer, 0, buffer.Length);
          return true;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
    }

    public byte[] serialize()
    {
      using (MemoryStream memoryStream = new MemoryStream())
      {
        XmlSerializer.FromTypes(new Type[1]
        {
          typeof (Settings)
        })[0].Serialize((Stream) memoryStream, (object) this);
        return memoryStream.ToArray();
      }
    }

    public static string getConfigFilePath()
    {
      return Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".xml";
    }
  }
}
