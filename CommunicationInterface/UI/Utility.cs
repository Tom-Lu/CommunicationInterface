namespace Communication.Interface.UI
{
    internal static class Utility
    {
        public delegate void InvokeHandler();
        public static void SafeInvoke(this System.Windows.Forms.Control control, InvokeHandler handler)
        {
            if (control.InvokeRequired) control.Invoke(handler);
            else handler();
        }
    }
}
