using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace botw_editor.Properties
{
	// Token: 0x02000015 RID: 21
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), DebuggerNonUserCode, CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600013C RID: 316 RVA: 0x0001D649 File Offset: 0x0001B849
		internal Resources()
		{
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600013D RID: 317 RVA: 0x0001D651 File Offset: 0x0001B851
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					Resources.resourceMan = new ResourceManager("botw_editor.Properties.Resources", typeof(Resources).Assembly);
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600013E RID: 318 RVA: 0x0001D67D File Offset: 0x0001B87D
		// (set) Token: 0x0600013F RID: 319 RVA: 0x0001D684 File Offset: 0x0001B884
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400022C RID: 556
		private static ResourceManager resourceMan;

		// Token: 0x0400022D RID: 557
		private static CultureInfo resourceCulture;
	}
}
