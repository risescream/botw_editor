using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace botw_editor
{
	// Token: 0x02000013 RID: 19
	public class Settings
	{
		// Token: 0x06000132 RID: 306 RVA: 0x0001D440 File Offset: 0x0001B640
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

		// Token: 0x06000133 RID: 307 RVA: 0x0001D494 File Offset: 0x0001B694
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

		// Token: 0x06000134 RID: 308 RVA: 0x0001D514 File Offset: 0x0001B714
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

		// Token: 0x06000135 RID: 309 RVA: 0x0001D570 File Offset: 0x0001B770
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

		// Token: 0x06000136 RID: 310 RVA: 0x0001D5CC File Offset: 0x0001B7CC
		public static string getConfigFilePath()
		{
			return Path.GetFileNameWithoutExtension(Application.ExecutablePath) + ".xml";
		}

		// Token: 0x04000222 RID: 546
		public int auto_update_timer = 15;

		// Token: 0x04000223 RID: 547
		public bool auto_update;

		// Token: 0x04000224 RID: 548
		public List<string> item_ids = new List<string>();

		// Token: 0x04000225 RID: 549
		public List<string> item_names = new List<string>();

		// Token: 0x04000226 RID: 550
		public List<actiondata> custom_actions = new List<actiondata>();

		// Token: 0x04000227 RID: 551
		public List<string> action_keys = new List<string>();

		// Token: 0x04000228 RID: 552
		public List<actiondata> action_datas = new List<actiondata>();

		// Token: 0x04000229 RID: 553
		public List<CapturedPosition> capturedPositions = new List<CapturedPosition>();

		// Token: 0x0400022A RID: 554
		public int internalLoopMs = 100;

		// Token: 0x0400022B RID: 555
		public int spacingMs;
	}
}
