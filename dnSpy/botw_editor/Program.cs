using System;
using System.Windows.Forms;

namespace botw_editor
{
	// Token: 0x02000010 RID: 16
	internal static class Program
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0001D33C File Offset: 0x0001B53C
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmMain());
		}
	}
}
