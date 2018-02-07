using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace botw_editor.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static botw_editor.Properties.Settings defaultInstance;

		public static botw_editor.Properties.Settings Default
		{
			get
			{
				return botw_editor.Properties.Settings.defaultInstance;
			}
		}

		static Settings()
		{
			botw_editor.Properties.Settings.defaultInstance = (botw_editor.Properties.Settings)SettingsBase.Synchronized(new botw_editor.Properties.Settings());
		}

		public Settings()
		{
		}
	}
}