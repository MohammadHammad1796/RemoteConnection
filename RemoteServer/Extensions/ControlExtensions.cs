using System.Windows.Forms;

namespace RemoteServer.Extensions
{
    public static class ControlExtensions
    {
        public static void Enable(this Control control)
        {
            control.Enabled = true;
        }
        public static void Disable(this Control control)
        {
            control.Enabled = false;
        }
    }
}