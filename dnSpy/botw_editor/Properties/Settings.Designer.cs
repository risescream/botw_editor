using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace botw_editor.Properties
{
	// Token: 0x02000016 RID: 22
	[CompilerGenerated, GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000140 RID: 320 RVA: 0x0001D68C File Offset: 0x0001B88C
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400022E RID: 558
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
