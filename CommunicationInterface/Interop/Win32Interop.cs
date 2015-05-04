using System;
using System.Runtime.InteropServices;

namespace Communication.Interface.Interop
{
    public class Win32Interop
    {
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("User32.dll", EntryPoint = "IsWindowVisible")]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("User32.dll", EntryPoint = "IsZoomed")]
        public static extern bool IsZoomed(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern int GetWindowRect(IntPtr hwnd, out  Rect lpRect);
        [DllImport("user32.dll")]
        public static extern long GetWindowLong(IntPtr hwnd, int index);
        [DllImport("user32.dll")]
        public static extern int GetDesktopWindow();
        [DllImport("user32.dll")]
        public static extern int GetWindow(IntPtr hwnd, uint Cmd);
        [DllImport("user32.dll")]
        public static extern int GetTopWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int GetParent(IntPtr hwnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();
        [DllImport("kernel32", SetLastError = true)]
        public static extern bool AttachConsole(int dwProcessId);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        public static int SW_HIDE = 0;
        public static int SW_SHOW = 5;

        public static void ShowConsoleWindow()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SW_SHOW);
            }
        }

        public static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, SW_HIDE);
        }

        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public bool IsSame(Rect Reference)
            {
                return this.Left == Reference.Left && this.Right == Reference.Right && this.Top == Reference.Top && this.Bottom == Reference.Bottom;
            }

            public static Rect Zero()
            {
                Rect zero;
                zero.Left = 0;
                zero.Top = 0;
                zero.Right = 0;
                zero.Bottom = 0;
                return zero;
            }
        }
    }
}
