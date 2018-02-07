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

		public Settings()
		{
		}

		public static Settings deserialize(byte[] serializedObject)
		{
			Settings setting;
			XmlSerializer xmlSerializer = XmlSerializer.FromTypes(new Type[] { typeof(Settings) })[0];
			try
			{
				setting = (Settings)xmlSerializer.Deserialize(new MemoryStream(serializedObject));
			}
			catch (Exception exception)
			{
				setting = null;
			}
			return setting;
		}

		public static string getConfigFilePath()
		{
			return string.Concat(Path.GetFileNameWithoutExtension(Application.ExecutablePath), ".xml");
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
			catch (Exception exception)
			{
			}
			return null;
		}

		public byte[] serialize()
		{
			byte[] array;
			XmlSerializer xmlSerializer = XmlSerializer.FromTypes(new Type[] { typeof(Settings) })[0];
			using (MemoryStream memoryStream = new MemoryStream())
			{
				xmlSerializer.Serialize(memoryStream, this);
				array = memoryStream.ToArray();
			}
			return array;
		}

		public bool writeFile(string fileName)
		{
			bool flag = false;
			byte[] numArray = this.serialize();
			try
			{
				using (FileStream fileStream = File.Create(fileName))
				{
					fileStream.Write(numArray, 0, (int)numArray.Length);
					flag = true;
				}
			}
			catch (Exception exception)
			{
				flag = false;
			}
			return flag;
		}
	}
}