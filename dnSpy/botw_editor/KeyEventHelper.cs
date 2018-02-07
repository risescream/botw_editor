using System;
using System.Windows.Forms;

namespace botw_editor
{
	// Token: 0x0200000B RID: 11
	public static class KeyEventHelper
	{
		// Token: 0x060000D6 RID: 214 RVA: 0x0001BCEE File Offset: 0x00019EEE
		public static void Raise(this KeyEventHandler eventHandler, object sender, KeyEventArgs args)
		{
			if (eventHandler == null)
			{
				return;
			}
			eventHandler(sender, args);
		}
	}
}
