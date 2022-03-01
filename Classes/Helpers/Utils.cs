using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;
using tb_vol_scroll.Properties;

namespace tb_vol_scroll.Classes.Helpers
{
    public static class Utils
    {
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public extern static bool DestroyIcon(IntPtr handle);
        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("User32.dll")]
        private static extern IntPtr MonitorFromPoint([In] Point pt, [In] uint dwFlags);
        [DllImport("Shcore.dll")]

        private static extern IntPtr GetDpiForMonitor([In] IntPtr hmonitor, [In] int dpiType, [Out] out uint dpiX, [Out] out uint dpiY);

        [DllImport("shell32", CharSet = CharSet.Unicode)]
        public static extern int ExtractIconEx(string lpszFile, int nIconIndex, out IntPtr phiconLarge, IntPtr phiconSmall, int nIcons);


        [DllImport("Shell32.dll", SetLastError = false)]

        public static extern Int32 SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        [DllImport("user32.dll")]
        internal static extern bool MoveWindow(
        IntPtr hWnd,
        int X,
        int Y,
        int nWidth,
        int nHeight,
        bool bRepaint);

        [DllImport("user32.dll")]
        private extern static int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private static int MakeParam(int loWord, int hiWord)
        {
            return (hiWord << 16) | (loWord & 0xffff);
        }

        public enum SHSTOCKICONID : uint
        {
            SIID_SHIELD = 77
        }

        [Flags]
        public enum SHGSI : uint
        {
            SHGSI_ICON = 0x000000100,
            SHGSI_SMALLICON = 0x000000001
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHSTOCKICONINFO
        {
            public UInt32 cbSize;
            public IntPtr hIcon;
            public Int32 iSysIconIndex;
            public Int32 iIcon;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szPath;
        }


        public static void AvoidControlFocus(IntPtr handle)
        {
            SendMessage(handle, 0x0128, MakeParam(1, 0x1), 0);
        }
        public static Size GetWindowSize(IntPtr hWnd)
        {
            Size cSize = new Size();
            GetWindowRect(hWnd, out RECT pRect);

            cSize.Width = pRect.Right - pRect.Left;
            cSize.Height = pRect.Bottom - pRect.Top;
            return cSize;
        }
        public static void ShowFormWithoutFocus(Form form)
        {
            SetWindowPos(form.Handle.ToInt32(), -1, form.Left, form.Top, form.Width, form.Height, 0x0010);
            ShowWindow(form.Handle, 4);
        }

        public static bool IsAdministrator()
        {
            return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        }

        public static Bitmap GetUacShield()
        {
            SHSTOCKICONINFO iconResult = new SHSTOCKICONINFO();
            iconResult.cbSize = (uint)Marshal.SizeOf(iconResult);

            SHGetStockIconInfo(SHSTOCKICONID.SIID_SHIELD, SHGSI.SHGSI_ICON | SHGSI.SHGSI_SMALLICON, ref iconResult);
            using (Icon tmpIcon = Icon.FromHandle(iconResult.hIcon))
            {
                Icon newIcon = (Icon)tmpIcon.Clone();
                DestroyIcon(tmpIcon.Handle);
                return newIcon.ToBitmap();
            }
        }



        public static Size CalculateMinimumBarSize(Label label, string text)
        {
            return label.CreateGraphics().MeasureString(text, label.Font).ToSize();
        }

        public static void InvokeIfRequired(Control control, MethodInvoker action)
        {
            try
            {
                if (control.InvokeRequired)
                    control.Invoke(action);
                else
                    action();
            }
            catch { }
        }

        public static Color GetColorByPercentage(double percentage)
        {
            if (percentage > 100)
                percentage = 100;
            if (percentage < 0)
                percentage = 0;

            double redVal = ((percentage > 50.0) ? (1.0 - 2.0 * (percentage - 50.0) / 100.0) : 1.0) * 255.0;
            double greenVal = ((percentage > 50.0) ? 1.0 : (2.0 * percentage / 100.0)) * 255.0;
            double blueVal = 0.0;

            if (redVal < 0)
                redVal = 0;
            if (greenVal < 0)
                greenVal = 0;
            if (redVal > 255)
                redVal = 255;
            if (greenVal > 255)
                greenVal = 255;

            return Color.FromArgb((int)redVal, (int)greenVal, (int)blueVal);
        }

        private static Font FindBestFitFont(Graphics g, string text, Font font, Size proposedSize, float iconPadding)
        {
            Font oldFont = font;
            try
            {
                while (true)
                {

                    SizeF size = g.MeasureString(text, font);
                    if (size.Height <= proposedSize.Height + iconPadding && size.Width <= proposedSize.Width + iconPadding)
                    { return font; }

                    font = new Font(font.Name, font.Size *0.99F, font.Style);
                }
            }
            catch { return oldFont; }
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

        public static Icon GenerateTrayIcon(string iconText)
        {
            float iconWidth = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
            float iconHeight = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
            float fontSize = Globals.DpiScale < 1.25 ? 16 * Globals.DpiScale : 32 * Globals.DpiScale;
            float iconPadding = Globals.DpiScale < 1.25 ? 4 * Globals.DpiScale : 8 * Globals.DpiScale;
            float alignmentX = 0;// = Globals.DpiScale < 1.25 ? 5 * Globals.DpiScale : 10 * Globals.DpiScale;
            float alignmentY = 0;// = Globals.DpiScale < 1.25 ? 5 * Globals.DpiScale : 10 * Globals.DpiScale;

            TextRenderingHint hinting = TextRenderingHint.ClearTypeGridFit;

            if (Settings.Default.TrayIconOverrideAutoSettings)
            {
                iconWidth = Settings.Default.TrayIconWidth;
                iconHeight = Settings.Default.TrayIconHeight;
                fontSize = Settings.Default.TrayIconFontStyle.Size;
                alignmentX = Settings.Default.TrayIconXAlignment;
                alignmentY = Settings.Default.TrayIconYAlignment;

                if (iconWidth == 0)
                    iconWidth = 1;
                if (iconHeight == 0)
                    iconHeight = 1;

                switch (Settings.Default.TrayIconTextRenderingHinting)
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
            }

            using (Bitmap bitmap = new Bitmap((int)iconWidth, (int)iconHeight, PixelFormat.Format32bppArgb))
            {
                Font font = Settings.Default.TrayIconOverrideAutoSettings ? Settings.Default.TrayIconFontStyle : new Font("Segoe UI Semibold", fontSize, FontStyle.Regular);
                Color textColor = Settings.Default.TrayIconColorText;

                switch (iconText)
                {
                    case "M":
                    case "X":
                        textColor = GetColorByPercentage(0);
                        break;
                    case "T":
                        textColor = Globals.DefaultColor;
                        break;
                    default:
                        textColor = Settings.Default.TrayIconColorTextIsGradient ? GetColorByPercentage(Globals.AudioHandler.FriendlyVolume) : Settings.Default.TrayIconColorText;
                        break;
                }

                bitmap.MakeTransparent(Color.Transparent);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.Clear(Color.Transparent);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.TextRenderingHint = hinting;
                    font = FindBestFitFont(graphics, iconText, font, bitmap.Size, iconPadding);
                    SizeF size = graphics.MeasureString(iconText, font).ToSize();
                    graphics.DrawString(iconText, font, new SolidBrush(textColor), ((iconWidth - size.Width) / 2) + alignmentX, ((iconHeight - size.Height) / 2) + alignmentY);
                    using (Icon tmpIcon = Icon.FromHandle(bitmap.GetHicon()))
                    {
                        Icon newIcon = (Icon)tmpIcon.Clone();
                        DestroyIcon(tmpIcon.Handle);
                        return newIcon;
                    }
                }
            }
        }

        public static void HandleApplicationExit(Process process = null, int code = 0)
        {
            if (Globals.InputHandler != null)
                Globals.InputHandler.UnhookAll();
            if (Globals.AudioHandler != null && Globals.AudioHandler.AudioController != null)
                Globals.AudioHandler.AudioController.Dispose();

            Globals.MainForm.TrayNotifyIcon.Visible = false;
            Globals.MainForm.TrayNotifyIcon.Icon = null;
            Globals.MainForm.TrayNotifyIcon.Dispose();

            InvokeIfRequired(Globals.MainForm, () =>
            {
                Globals.AppMutex.ReleaseMutex();
                Globals.AppMutex.Dispose();
            });
            if (process != null)
                process.Start();
            Environment.Exit(code);
        }

        public static async Task OpenSystemVolumeMixer()
        {
            await Task.Run(() =>
            {
                foreach (Process proc in Process.GetProcessesByName("sndvol"))
                    proc.CloseMainWindow();
                Process sndvolProc = new Process();
                sndvolProc.StartInfo.FileName = "sndvol";
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
                sndVolDimensions.Width = Convert.ToInt32(Math.Round(0.5 * workingArea.Width));
                switch (Taskbar.Position)
                {
                    case Taskbar.TaskbarPosition.Bottom:
                        location = new Point(workingArea.Right - sndVolDimensions.Width, workingArea.Bottom - sndVolDimensions.Height);
                        break;
                    case Taskbar.TaskbarPosition.Right:
                        location = new Point(workingArea.Right - sndVolDimensions.Width, workingArea.Bottom - sndVolDimensions.Height);
                        break;
                    case Taskbar.TaskbarPosition.Left:
                        location = new Point(workingArea.Left, workingArea.Bottom - sndVolDimensions.Height);
                        break;
                    case Taskbar.TaskbarPosition.Top:
                        location = new Point(workingArea.Right - sndVolDimensions.Width, workingArea.Top);
                        break;
                }
                MoveWindow(windowHandle, location.X, location.Y, sndVolDimensions.Width, sndVolDimensions.Height, true);
            });
        }


        // By https://stackoverflow.com/a/3426721
        public static IEnumerable<Control> GetAllControls(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAllControls(ctrl))
                                      .Concat(controls);
        }
    }


}