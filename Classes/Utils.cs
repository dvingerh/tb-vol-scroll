using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading.Tasks;
using tbvolscroll.Properties;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace tbvolscroll.Classes
{
    public static class Utils
    {
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint([In] Point pt, [In] uint dwFlags);
        [DllImport("Shcore.dll")]
        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] int dpiType, [Out] out uint dpiX, [Out] out uint dpiY);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        internal static extern bool MoveWindow(
        IntPtr hWnd,
        int X,
        int Y,
        int nWidth,
        int nHeight,
        bool bRepaint);

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
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static void ShowInactiveTopmost(Form form)
        {
            SetWindowPos(form.Handle.ToInt32(), -1, form.Left, form.Top, form.Width, form.Height, 16u);
            ShowWindow(form.Handle, 4);
        }

        public static Size GetWindowSize(IntPtr hWnd)
        {
            Size cSize = new Size();
            GetWindowRect(hWnd, out RECT pRect);

            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            return cSize;
        }

        public static Size CalculateLabelSize(Label label, string text)
        {
            return label.CreateGraphics().MeasureString(text, label.Font).ToSize();
        }

        private static Font FindBestFitFont(Graphics g, string text, Font font, Size proposedSize, float expandAmount)
        {
            while (true)
            {
                SizeF size = g.MeasureString(text, font);

                if (size.Height <= proposedSize.Height + expandAmount && size.Width <= proposedSize.Width + expandAmount) { return font; }

                Font oldFont = font;
                font = new Font(font.Name, font.Size - 1, font.Style);
                oldFont.Dispose();
            }
        }

        public static float GetDpiScale()
        {
            try
            {
                Screen screen = Screen.PrimaryScreen;
                var pnt = new Point(screen.Bounds.Left + 1, screen.Bounds.Top + 1);
                var mon = MonitorFromPoint(pnt, 2);
                GetDpiForMonitor(mon, 0, out uint dpiX, out uint dpiY);
                switch (dpiX)
                {
                    case 96:
                        return 1.0F;
                    case 120:
                        return 1.25F;
                    case 144:
                        return 1.5F;
                    case 168:
                        return 1.75F;
                    case 192:
                        return 2.0F;
                    default:
                        return (float)Math.Round(dpiX * 1.0147F);
                }
            }
            catch { return 1.0F; }
        }

        public static Icon GenerateTrayIcon(string text)
        {
            try
            {
                float iconWidth = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
                float iconHeight = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
                float fontSize = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
                float expandAmount = Globals.DpiScale < 1.25 ? 5 * Globals.DpiScale : 10 * Globals.DpiScale;

                TextRenderingHint hinting;

                switch (Globals.TextRenderingHintType)
                {
                    case 0:
                        hinting = TextRenderingHint.SystemDefault;
                        break;
                    case 1:
                        hinting = TextRenderingHint.ClearTypeGridFit;
                        break;
                    case 2:
                        hinting = TextRenderingHint.AntiAliasGridFit;
                        break;
                    case 3:
                        hinting = TextRenderingHint.SingleBitPerPixelGridFit;
                        break;
                    default:
                        hinting = Globals.DpiScale < 1.25 ? TextRenderingHint.ClearTypeGridFit : TextRenderingHint.AntiAliasGridFit;
                        break;
                }

                using (Bitmap bitmap = new Bitmap((int)iconWidth, (int)iconHeight, PixelFormat.Format32bppArgb))
                {
                    Font font = new Font("Segoe UI Semibold", fontSize, FontStyle.Regular);
                    Color textColor = Settings.Default.TrayIconTextSolidColor;

                    switch (text)
                    {
                        case "M":
                        case "X":
                            textColor = CalculateColor(0);
                            break;
                        case "T":
                            textColor = Globals.DefaultColor;
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
                        graphics.TextRenderingHint = hinting;
                        font = FindBestFitFont(graphics, text, font, bitmap.Size, expandAmount); 
                        SizeF size = graphics.MeasureString(text, font).ToSize();
                        graphics.DrawString(text, font, new SolidBrush(textColor), (iconWidth - size.Width) / 2, (iconHeight - size.Height) / 2);
                    }
                    return Icon.FromHandle(bitmap.GetHicon());
                }
            }
            catch
            {
                return Resources.voltray;
            }
        }

        public static async Task OpenSndVol()
        {
            await Task.Run(() =>
            {

                Process sndvolProc = new Process();
                sndvolProc.StartInfo.FileName = "sndvol.exe";
                sndvolProc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                sndvolProc.Start();

                bool hasWindow = false;
                IntPtr windowHandle = new IntPtr();
                while (!hasWindow)
                {
                    IntPtr tempHandle = sndvolProc.MainWindowHandle;
                    if (tempHandle.ToInt32() != 0)
                    {
                        windowHandle = tempHandle;
                        hasWindow = true;
                    }
                }

                Screen screen = Screen.FromPoint(Cursor.Position);
                Point location = new Point();
                Rectangle workingArea = screen.WorkingArea;

                Size sndVolDimensions = GetWindowSize(windowHandle);
                sndVolDimensions.Width = Convert.ToInt32(Math.Round(0.75 * workingArea.Width));
                switch (TaskbarHandler.Position)
                {
                    case TaskbarHandler.TaskbarPosition.Bottom:
                        location = new Point(workingArea.Right - sndVolDimensions.Width, workingArea.Bottom - sndVolDimensions.Height);
                        break;
                    case TaskbarHandler.TaskbarPosition.Right:
                        location = new Point(workingArea.Right - sndVolDimensions.Width, workingArea.Bottom - sndVolDimensions.Height);
                        break;
                    case TaskbarHandler.TaskbarPosition.Left:
                        location = new Point(workingArea.Left, workingArea.Bottom - sndVolDimensions.Height);
                        break;
                    case TaskbarHandler.TaskbarPosition.Top:
                        location = new Point(workingArea.Right - sndVolDimensions.Width, workingArea.Top);
                        break;
                }
                MoveWindow(windowHandle, location.X, location.Y, sndVolDimensions.Width, sndVolDimensions.Height, true);
            });
        }
    }
}
