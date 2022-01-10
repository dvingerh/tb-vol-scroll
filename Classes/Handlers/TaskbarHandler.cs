using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using tbvolscroll.Properties;

namespace tbvolscroll
{
    public static class TaskbarHandler
    {

        #region DllImports
        [DllImport("user32.dll")]
        private static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rectangle rect);

        [DllImport("shell32.dll")]
        private static extern IntPtr SHAppBarMessage(int dwMessage, out TaskbarData pData);

        [DllImport("User32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindowByClassName(string lpClassName, IntPtr ZeroOnly);

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point p);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        private static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        private static extern IntPtr GetAncestor(IntPtr hwnd, GetAncestorFlags gaFlags);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetParent(IntPtr hWnd);

        private enum GetAncestorFlags
        {
            GetParent = 1,
            GetRoot = 2,
            GetRootOwner = 3
        }
        #endregion DllImports

        public enum TaskbarPosition
        {
            Unknown = -1,
            Left,
            Top,
            Right,
            Bottom,
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct TaskbarData
        {
            public uint cbSize;
            public IntPtr hWnd;
            public uint uCallbackMessage;
            public TaskbarPosition uEdge;
            public Rectangle rect;
            public int lParam;
        }


        private static IntPtr GetWindowRootOwner(IntPtr hWnd)
        {
            IntPtr hParent;

            hParent = GetAncestor(hWnd, GetAncestorFlags.GetRootOwner);
            if (hParent.ToInt64() == 0 || hParent == GetDesktopWindow())
            {
                hParent = GetParent(hWnd);
                if (hParent.ToInt64() == 0 || hParent == GetDesktopWindow())
                    hParent = hWnd;
            }

            return hParent;
        }

        public static bool IsCursorInTaskbar()
        {

            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            IntPtr window = WindowFromPoint(Cursor.Position);
            window = GetWindowRootOwner(window);
            StringBuilder classNameHolder = new StringBuilder(256);
            GetClassName(window.ToInt32(), classNameHolder, 256);
            string className = classNameHolder.ToString();
            IntPtr hWnd;
            if (screen.Primary)
                hWnd = FindWindowByClassName("Shell_TrayWnd", IntPtr.Zero);
            else
                hWnd = FindWindowByClassName("Shell_SecondaryTrayWnd", IntPtr.Zero);
            GetWindowRect(hWnd, out Rectangle shellTrayArea);

            bool taskbarIsVisible = (className == "Shell_TrayWnd" || className == "Shell_SecondaryTrayWnd");
            bool cursorIsInTaskbarArea = false;
            if (Settings.Default.IgnoreTaskbarVisibility)
            {
                int taskbarHeight = shellTrayArea.Height - shellTrayArea.Y;
                Rectangle workingArea = screen.Bounds;
                workingArea.Height -= taskbarHeight;
                if (!workingArea.Contains(position))
                    cursorIsInTaskbarArea = true;
            }
            else
                cursorIsInTaskbarArea = shellTrayArea.Contains(position);
            if (Settings.Default.IgnoreTaskbarVisibility)
                return cursorIsInTaskbarArea;
            return cursorIsInTaskbarArea && taskbarIsVisible;
        }

        public static TaskbarPosition Position
        {
            get
            {
                if (SHAppBarMessage(0x00000005, out TaskbarData taskbarData) != IntPtr.Zero)
                    return taskbarData.uEdge;
                else
                    return TaskbarPosition.Unknown;
            }
        }
    }
}