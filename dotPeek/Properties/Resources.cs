using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace botw_editor.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (botw_editor.Properties.Resources.resourceMan == null)
          botw_editor.Properties.Resources.resourceMan = new ResourceManager("botw_editor.Properties.Resources", typeof (botw_editor.Properties.Resources).Assembly);
        return botw_editor.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return botw_editor.Properties.Resources.resourceCulture;
      }
      set
      {
        botw_editor.Properties.Resources.resourceCulture = value;
      }
    }

    internal Resources()
    {
    }
  }
}
