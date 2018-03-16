using AudioSwitcher.AudioApi.CoreAudio;
using Gma.System.MouseKeyHook;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbVolScroll
{
    public partial class frmMain : Form
    {

        #region AeroShadow

        private bool aeroEnabled;

        public class WIN32APIConstants
        {
            public const int CS_DROPSHADOW = 0x00020000;
            public const int WM_NCPAINT = 0x0085;
        }
        public class WIN32APIMethods
        {
            [DllImport("dwmapi.dll")]
            public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

            [DllImport("dwmapi.dll")]
            public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

            [DllImport("dwmapi.dll")]
            public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        }
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WIN32APIConstants.WM_NCPAINT:
                    if (aeroEnabled)
                    {
                        var var = 2;
                        WIN32APIMethods.DwmSetWindowAttribute(Handle, 2, ref var, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        WIN32APIMethods.DwmExtendFrameIntoClientArea(Handle, ref margins);
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CheckAeroEnabled();
                var cp = base.CreateParams;

                if (!aeroEnabled)
                {
                    cp.ClassStyle = cp.ClassStyle | WIN32APIConstants.CS_DROPSHADOW;
                    return cp;
                }
                else
                {
                    return cp;
                }
            }
        }

        private void CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                int response = WIN32APIMethods.DwmIsCompositionEnabled(ref enabled);
                aeroEnabled = (enabled == 1) ? true : false;
            }
            else
            {
                aeroEnabled = false;
            }
        }

        #endregion

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(HandleRef hWnd, [In, Out] ref RECT rect);

        private static void ShowInactiveTopmost(Form frm)
        {
            frm.Invoke((MethodInvoker)delegate
            {
                ShowWindow(frm.Handle, 4);
                SetWindowPos(frm.Handle.ToInt32(), -1, frm.Left, frm.Top, frm.Width, frm.Height, 16u);
            });
        }
        public struct RECT
        {
            public int Left;

            public int Top;

            public int Right;

            public int Bottom;
        }

        public static bool IsTaskbarHidden()
        {
            return CheckTaskbarVisibility(null);
        }

        public static bool CheckTaskbarVisibility(Screen screen)
        {
            if (screen == null)
            {
                screen = Screen.PrimaryScreen;
            }
            RECT rect = new RECT();
            GetWindowRect(new HandleRef(null, GetForegroundWindow()), ref rect);
            return new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top).Contains(screen.Bounds);
        }

        private RECT TaskbarRect;
        private IKeyboardMouseEvents MouseKeyEvents;
        private CoreAudioDevice DefaultPlaybackDevice = new CoreAudioController().GetDefaultDevice(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.Role.Communications);
        private CoreAudioController DefaultPlaybackDeviceController = new CoreAudioController();
        private string LastKnownDeviceId;
        private bool IsDisplayingVolume;
        private bool IsAltDown;
        int TimeOutHelper = 10;

        public frmMain()
        {
            InitializeComponent();

            IntPtr hwnd = FindWindow("Shell_traywnd", "");
            GetWindowRect(hwnd, out TaskbarRect);
            MouseKeyEvents = Hook.GlobalEvents();
            MouseKeyEvents.MouseWheel += OnMouseScroll;
            MouseKeyEvents.MouseMove += UpdateBarPositionMouseMove;
            MouseKeyEvents.KeyDown += EnableAltDown;
            MouseKeyEvents.KeyUp += DisableAltDown;
            LastKnownDeviceId = DefaultPlaybackDevice.Id.ToString();
            Hide();
            WindowState = FormWindowState.Minimized;
        }

        private void UpdateBarPositionMouseMove(object sender, MouseEventArgs e)
        {
            if (IsDisplayingVolume)
            {
                Point CursorPosition = Cursor.Position;
                Left = CursorPosition.X - Width / 2;
                Top = CursorPosition.Y - 20;
            }
        }

        private void DisableAltDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu)
            {
                IsAltDown = false;
            }
        }

        private void EnableAltDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.LMenu)
            {
                IsAltDown = true;
            }
        }

        public void OnMouseScroll(object sender, MouseEventArgs e)
        {
            Task.Run(delegate
            {
                TimeOutHelper = 10;
                DoVolumeChanges(e.Delta);
            });
        }

        public void DoVolumeChanges(int delta)
        {
            Invoke((MethodInvoker)delegate
            {
                if (CursorInTaskbar() && !IsTaskbarHidden())
                {
                    ShowInactiveTopmost(this);
                    UpdateDefaultDevice();
                    if (delta < 0)
                    {
                        if (IsAltDown)
                        {
                            DefaultPlaybackDevice.Volume = DefaultPlaybackDevice.Volume - 1;
                        }
                        else if (DefaultPlaybackDevice.Volume <= 10)
                        {
                            DefaultPlaybackDevice.Volume = DefaultPlaybackDevice.Volume - 1;
                        }
                        else
                        {
                            DefaultPlaybackDevice.Volume = DefaultPlaybackDevice.Volume - 5;
                        }
                    }
                    else
                    {
                        if (IsAltDown)
                        {
                            DefaultPlaybackDevice.Volume = DefaultPlaybackDevice.Volume + 1;
                        }
                        else if (DefaultPlaybackDevice.Volume < 10)
                        {
                            DefaultPlaybackDevice.Volume = DefaultPlaybackDevice.Volume + 1;
                        }
                        else
                        {
                            DefaultPlaybackDevice.Volume = DefaultPlaybackDevice.Volume + 5;
                        }
                    }


                    lblVolumePerc.Text = DefaultPlaybackDevice.Volume.ToString() + "%";
                    if (DefaultPlaybackDevice.Volume <= 10 || IsAltDown)
                    {
                        lblVolumePerc.Visible = true;
                    }
                    else if (!IsAltDown)
                    {
                        lblVolumePerc.Visible = false;
                    }




                    Point CursorPosition = Cursor.Position;
                    Width = (int)DefaultPlaybackDevice.Volume + 30;
                    Height = 16;
                    Left = CursorPosition.X - Width / 2;
                    Top = CursorPosition.Y - 20;

                    pnlColor.BackColor = CalculateColor(DefaultPlaybackDevice.Volume);
                    if (!IsDisplayingVolume)
                    {
                        Task.Run(() => AutoHideVolume());
                    }
                }
            });
        }

        public void UpdateDefaultDevice()
        {
            string CurrentDeviceId = DefaultPlaybackDeviceController.GetDefaultDevice(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.Role.Communications).Id.ToString();
            if (LastKnownDeviceId != CurrentDeviceId)
            {
                LastKnownDeviceId = CurrentDeviceId;
                DefaultPlaybackDevice = new CoreAudioController().GetDefaultDevice(AudioSwitcher.AudioApi.DeviceType.Playback, AudioSwitcher.AudioApi.Role.Communications);
            }
        }

        public bool CursorInTaskbar()
        {
            Point position = Cursor.Position; if (position.Y >= TaskbarRect.Top && position.Y <= TaskbarRect.Bottom) { return true; } else { return false; }
        }

        private static Color CalculateColor(double percentage)
        {
            double num = ((percentage > 50.0) ? (1.0 - 2.0 * (percentage - 50.0) / 100.0) : 1.0) * 255.0;
            double num2 = ((percentage > 50.0) ? 1.0 : (2.0 * percentage / 100.0)) * 255.0;
            double num3 = 0.0;
            return Color.FromArgb((int)num, (int)num2, (int)num3);
        }

        async Task PutTaskDelay()
        {
            await Task.Delay(100);
        }


        private async void AutoHideVolume()
        {
            Application.DoEvents();
            IsDisplayingVolume = true;
            ShowInactiveTopmost(this);

            while (TimeOutHelper != 0)
            {
                await PutTaskDelay();
                TimeOutHelper--;
            }

            await PutTaskDelay();
            Invoke((MethodInvoker)delegate
            {
                Hide();
                WindowState = FormWindowState.Minimized;
                lblVolumePerc.Visible = false;
            });
            IsDisplayingVolume = false;
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tsmRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}