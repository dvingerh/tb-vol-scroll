using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Principal;
using System.Management;
using System.Threading.Tasks;

namespace tbvolscroll.Classes
{
    public static class Utils
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(
        IntPtr hWnd,
        int X,
        int Y,
        int nWidth,
        int nHeight,
        bool bRepaint);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static Color CalculateColor(double percentage)
        {
            if (percentage > 100)
                percentage = 100;
            if (percentage < 0)
                percentage = 0;

            double num = ((percentage > 50.0) ? (1.0 - 2.0 * (percentage - 50.0) / 100.0) : 1.0) * 255.0;
            double num2 = ((percentage > 50.0) ? 1.0 : (2.0 * percentage / 100.0)) * 255.0;
            double num3 = 0.0;

            if (num < 0)
                num = 0;
            if (num2 < 0)
                num2 = 0;
            if (num > 255)
                num = 255;
            if (num2 > 255)
                num2 = 255;

            return Color.FromArgb((int)num, (int)num2, (int)num3);
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent())).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void ShowInactiveTopmost(MainForm mainForm)
        {
            mainForm.Invoke((MethodInvoker)delegate
            {
                SetWindowPos(mainForm.Handle.ToInt32(), -1, mainForm.Left, mainForm.Top, mainForm.Width, mainForm.Height, 16u);
                ShowWindow(mainForm.Handle, 4);
            });
        }

        public static async Task<bool> IsAudioServiceRunning()
        {
            return await Task.Run(() =>
            {
                try
                {
                    bool isRunning = false;
                    ManagementScope scope = new ManagementScope();
                    scope.Connect();
                    ManagementPath path = new ManagementPath("Win32_Service");
                    ManagementClass services = new ManagementClass(scope, path, null);
                    foreach (ManagementObject service in services.GetInstances())
                    {
                        if (service.GetPropertyValue("Name").ToString().ToLower().Equals("audiosrv"))
                        {
                            string state = service.GetPropertyValue("State").ToString();
                            if (state.Equals("Running"))
                                isRunning = true;
                            else
                                isRunning = false;
                        }
                    }
                    Globals.IsAudioServiceRunning = isRunning;
                    return isRunning;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); Globals.IsAudioServiceRunning = false; return false; }
            });


        }
        public static Size GetSndVolSize(IntPtr hWnd)
        {
            Size cSize = new Size();
            GetWindowRect(hWnd, out RECT pRect);

            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;

            return cSize;
        }

        public static SizeF CalculateBarSize(Label label, string text)
        {
            return label.CreateGraphics().MeasureString(text, label.Font);
        }
    }
}
