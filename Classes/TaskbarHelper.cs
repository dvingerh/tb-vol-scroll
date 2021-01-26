/******************************************************************************
 * Name:        Taskbar.cs
 * Description: Class to get the taskbar's position, size and other properties.
 * Author:      Franz Alex Gaisie-Essilfie
 *              based on code from https://winsharp93.wordpress.com/2009/06/29/find-out-size-and-position-of-the-taskbar/
 *
 * Change Log:
 *  Date        | Description
 * -------------|--------------------------------------------------------------
 *  2017-05-16  | Initial design
 */

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace tbvolscroll
{

    public enum TaskbarPosition
    {
        Unknown = -1,
        Left,
        Top,
        Right,
        Bottom,
    }

    public static class TaskbarHelper
    {

        ////private enum ABE : uint
        private enum AppBarEdge : uint
        {
            Left = 0,
            Top = 1,
            Right = 2,
            Bottom = 3
        }

        ////private enum ABM : uint
        private enum AppBarMessage : uint
        {
            New = 0x00000000,
            Remove = 0x00000001,
            QueryPos = 0x00000002,
            SetPos = 0x00000003,
            GetState = 0x00000004,
            GetTaskbarPos = 0x00000005,
            Activate = 0x00000006,
            GetAutoHideBar = 0x00000007,
            SetAutoHideBar = 0x00000008,
            WindowPosChanged = 0x00000009,
            SetState = 0x0000000A,
        }

        private static APPBARDATA _appBarData;



        public static bool IsTaskbarHidden()
        {
            Screen screen = Screen.FromPoint(Cursor.Position);
            RECT rect = new RECT();
            IntPtr windowHandle = GetForegroundWindow();

            StringBuilder classNameHolder = new StringBuilder(256);
            if (GetClassName(windowHandle.ToInt32(), classNameHolder, 256) > 0)
            {
                string className = classNameHolder.ToString();
                if (className == "Progman" || className == "WorkerW")
                    return false; // Always allow volume scrolling when desktop is visible and active window
            }

            GetWindowRect(new HandleRef(null, windowHandle), ref rect);
            bool isHidden = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top).Contains(screen.Bounds);
            return isHidden;
        }

        public static bool CursorInTaskbar()
        {
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;
            return !workingArea.Contains(position);
        }

        /// <summary>Gets the taskbar's position on the screen.</summary>
        public static TaskbarPosition Position
        {
            get
            {
                if (RefreshBoundsAndPosition())
                    return (TaskbarPosition)_appBarData.uEdge;

                return TaskbarPosition.Unknown;
            }
        }

        private static bool RefreshBoundsAndPosition()
        {
            //! SHAppBarMessage returns IntPtr.Zero **if it fails**
            return SHAppBarMessage(AppBarMessage.GetTaskbarPos, ref _appBarData) != IntPtr.Zero;
        }

        #region DllImports


        [DllImport("user32.dll")]
        static extern int GetClassName(int hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("shell32.dll", SetLastError = true)]
        private static extern IntPtr SHAppBarMessage(AppBarMessage dwMessage, [In] ref APPBARDATA pData);


        #endregion DllImports

        [StructLayout(LayoutKind.Sequential)]
        private struct APPBARDATA
        {
            public uint cbSize;
            public IntPtr hWnd;
            public uint uCallbackMessage;
            public AppBarEdge uEdge;
            public RECT rect;
            public int lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }
}