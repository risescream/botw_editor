using System.Windows.Forms;

namespace botw_editor
{
  public static class KeyEventHelper
  {
    public static void Raise(this KeyEventHandler eventHandler, object sender, KeyEventArgs args)
    {
      if (eventHandler == null)
        return;
      eventHandler(sender, args);
    }
  }
}
