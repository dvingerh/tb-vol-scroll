using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Principal;
using System.Management;
using System.Threading.Tasks;
using tbvolscroll.Properties;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;

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

        public static void ShowInactiveTopmost()
        {
            Globals.MainForm.Invoke((MethodInvoker)delegate
            {
                SetWindowPos(Globals.MainForm.Handle.ToInt32(), -1, Globals.MainForm.Left, Globals.MainForm.Top, Globals.MainForm.Width, Globals.MainForm.Height, 16u);
                ShowWindow(Globals.MainForm.Handle, 4);
            });
        }

        public static Size GetWindowSize(IntPtr hWnd)
        {
            Size cSize = new Size();
            GetWindowRect(hWnd, out RECT pRect);

            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;

            return cSize;
        }

        public static SizeF CalculateVolumeBarSize(Label label, string text)
        {
            return label.CreateGraphics().MeasureString(text, label.Font);
        }

        public static Font FindBestFitFont(Graphics g, string text, Font font, Size proposedSize)
        {
            int expandAmount = 16;
            while (true)
            {
                SizeF size = g.MeasureString(text, font);

                if (size.Height <= proposedSize.Height + expandAmount && size.Width <= proposedSize.Width + expandAmount) { return font; }

                Font oldFont = font;
                font = new Font(font.Name, font.Size - 1, font.Style, GraphicsUnit.Pixel);
                oldFont.Dispose();
            }
        }
        public static Icon GenerateTrayIcon(string text)
        {
            try
            {
                int iconWidth = 64;
                int iconHeight = 64;
                int fontSize = 64;
                using (Bitmap bitmap = new Bitmap(iconWidth, iconHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
                {
                    Font font = new Font("Segoe UI Semibold", fontSize, FontStyle.Regular, GraphicsUnit.Pixel);
                    Color textColor = Settings.Default.TrayIconTextSolidColor;

                    switch (text)
                    {
                        case "M":
                            textColor = CalculateColor(0);
                            break;
                        case "X":
                            textColor = CalculateColor(20);
                            break;
                        default:
                            textColor = Settings.Default.TrayIconTextUseGradientColor ? CalculateColor(AudioState.Volume) : Settings.Default.TrayIconTextSolidColor;
                            break;
                    }

                    bitmap.MakeTransparent(Color.Transparent);
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.Clear(Color.Transparent);
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
                        font = FindBestFitFont(graphics, text, font, bitmap.Size);
                        SizeF size = graphics.MeasureString(text, font);
                        graphics.DrawString(text, font, new SolidBrush(textColor), (iconWidth - size.Width) / 2, (iconHeight - size.Height) / 2);
                    }
                    return Icon.FromHandle(bitmap.GetHicon());
                }
            }
            catch
            {
                return Globals.MainForm.TrayNotifyIcon.Icon;
            }
        }
        public static async Task OpenSndVol()
        {
            Process sndvolProc = new Process();
            sndvolProc.StartInfo.FileName = "sndvol.exe";
            sndvolProc.Start();

            bool hasWindow = false;
            IntPtr windowHandle = new IntPtr();
            while (!hasWindow)
            {
                Process[] processes = Process.GetProcessesByName("sndvol");

                foreach (Process p in processes)
                {
                    IntPtr tempHandle = p.MainWindowHandle;
                    if (tempHandle.ToInt32() != 0)
                    {
                        windowHandle = tempHandle;
                        hasWindow = true;
                    }
                }
                await Task.Delay(1);
            }

            Screen screen = Screen.FromPoint(Cursor.Position);
            Point location = new Point();
            Rectangle workingArea = screen.WorkingArea;
            int sndWidth = Convert.ToInt32(Math.Round(0.75 * workingArea.Width));
            Size sndVolDimensions = GetWindowSize(windowHandle);

            switch (TaskbarHelper.Position)
            {
                case TaskbarHelper.TaskbarPosition.Bottom:
                    location = new Point(workingArea.Right - sndWidth, workingArea.Bottom - sndVolDimensions.Height);
                    break;
                case TaskbarHelper.TaskbarPosition.Right:
                    location = new Point(workingArea.Right - sndWidth, workingArea.Bottom - sndVolDimensions.Height);
                    break;
                case TaskbarHelper.TaskbarPosition.Left:
                    location = new Point(workingArea.Left, workingArea.Bottom - sndVolDimensions.Height);
                    break;
                case TaskbarHelper.TaskbarPosition.Top:
                    location = new Point(workingArea.Right - sndWidth, workingArea.Top);
                    break;
            }
            MoveWindow(windowHandle, location.X, location.Y, sndWidth, sndVolDimensions.Height, true);
        }
    }
}
