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

		public bool auto_update;

		public List<string> item_ids = new List<string>();

		public List<string> item_names = new List<string>();

		public List<actiondata> custom_actions = new List<actiondata>();

		public List<string> action_keys = new List<string>();

		public List<actiondata> action_datas = new List<actiondata>();

		public List<CapturedPosition> capturedPositions = new List<CapturedPosition>();

		public int internalLoopMs = 100;

		public int spacingMs;

		public static Settings deserialize(byte[] serializedObject)
		{
			XmlSerializer xmlSerializer = XmlSerializer.FromTypes(new Type[]
			{
				typeof(Settings)
			})[0];
			Settings result;
			try
			{
				result = (Settings)xmlSerializer.Deserialize(new MemoryStream(serializedObject));
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
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
						fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
						return Settings.deserialize(memoryStream.ToArray());
					}
				}
			}
			catch (Exception)
			{
			}
			return null;
		}

		public bool writeFile(string fileName)
		{
			bool result = false;
			byte[] array = this.serialize();
			try
			{
				using (FileStream fileStream = File.Create(fileName))
				{
					fileStream.Write(array, 0, array.Length);
					result = true;
				}
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public byte[] serialize()
		{
			XmlSerializer xmlSerializer = XmlSerializer.FromTypes(new Type[]
			{
				typeof(Settings)
			})[0];
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				xmlSerializer.Serialize(memoryStream, this);
				result = memoryStream.ToArray();
			}
			return result;
		}

		public static string getConfigFilePath()
		{
			return Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".xml";
		}
	}
}
