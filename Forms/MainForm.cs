using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using tbvolscroll.Properties;
using tbvolscroll.Forms;
using System.Media;
using System.IO;
using tbvolscroll.Classes;

namespace tbvolscroll
{
    public partial class MainForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                var Params = base.CreateParams;
                Params.ExStyle |= 0x80;

                return Params;
            }
        }

        public MainForm(bool noTray = false, bool attemptedAdmin = false, bool updateDoneArg = false)
        {
            InitializeComponent();

            if (updateDoneArg)
            {
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(10000, "Update complete", $"Successfully updated {Application.ProductName} to version {Application.ProductVersion}.", ToolTipIcon.Info);
            }

            bool hasAdmin = Utils.IsAdministrator();

            if (attemptedAdmin && hasAdmin)
            {
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(10000, "Administrator permissions granted", $"Successfully obtained administrator permissions after restarting.", ToolTipIcon.Info);
            }

            TitleLabelMenuItem.Text = $"{Application.ProductName} v{Application.ProductVersion}" + (hasAdmin ? " (Administrator)" : "");

            if (noTray)
                TrayNotifyIcon.Visible = false;

            if (!attemptedAdmin && !hasAdmin && Settings.Default.AutoRetryAdmin)
            {
                new Task(async () =>
                {
                    if (updateDoneArg)
                        await Task.Delay(5000);
                    TrayNotifyIcon.Visible = true;
                    TrayNotifyIcon.ShowBalloonTip(10000, "Administrator permissions unavailable", "Trying to request permissions on restart in a few moments.", ToolTipIcon.Warning);
                    await Task.Delay(5000);
                    Process proc = new Process();
                    proc.StartInfo.FileName = Application.ExecutablePath;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    proc.StartInfo.Arguments = "admin";
                    proc.Start();
                    ExitMenuItem.PerformClick();
                }).Start();
            }
        }

        public void SetVolumeBarPosition()
        {
            Point cursorPosition = Cursor.Position;
            switch (TaskbarHelper.Position)
            {
                case TaskbarPosition.Bottom:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                case TaskbarPosition.Left:
                    Left = cursorPosition.X + 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarPosition.Top:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y + 25;
                    break;
                case TaskbarPosition.Right:
                    Left = cursorPosition.X - Width - 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarPosition.Unknown:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                default:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;

            }
        }




        private async void AutoHideVolume()
        {
            Globals.IsDisplayingVolumeBar = true;
            Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
            Utils.ShowInactiveTopmost(this);

            while (Globals.VolumeBarAutoHideTimeout >= 10)
            {
                await Task.Delay(10);
                Globals.VolumeBarAutoHideTimeout -= 10;
            }

            if (!Globals.InputHandler.IsScrolling)
                HideVolumeBar();
            else
                AutoHideVolume();
        }

        public void HideVolumeBar()
        {
            Invoke((MethodInvoker)delegate
            {
                Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
                Globals.IsDisplayingVolumeBar = false;
                Hide();
            });
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            if (Globals.InputHandler != null)
                Globals.InputHandler.InputEvents.Dispose();
            TrayNotifyIcon.Dispose();
            Environment.Exit(0);
        }

        private void RestartAppNormal(object sender, EventArgs e)
        {
            if (Globals.InputHandler != null)
                Globals.InputHandler.InputEvents.Dispose();
            TrayNotifyIcon.Dispose();
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = "restart";
            proc.Start();
            ExitMenuItem.PerformClick();
        }

        private void ShowTrayMenuOnClick(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(TrayNotifyIcon, null);
        }

        private void OpenConfigureDialog(object sender, EventArgs e)
        {
            new ConfigurationForm(this).ShowDialog();
        }

        private void RestartAppAsAdministrator(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = "restart";
            proc.Start();
            ExitMenuItem.PerformClick();
        }

        private void DrawVolumeBarBorder(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), DisplayRectangle);
        }

        private void OpenStartupFolder(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }


        private async void VolumeMixerMenuItemClick(object sender, EventArgs e)
        {
            await Globals.AudioHandler.OpenSndVol();
        }

        private async void AudioDevicesMenuItemClick(object sender, EventArgs e)
        {
            new AudioPlaybackDevicesForm().ShowDialog();
            await Globals.AudioHandler.UpdateAudioState();
        }

        public async Task DoAppearanceUpdate(string updateType)
        {
            await Task.Run(async() =>
            {
                await Globals.AudioHandler.UpdateAudioState();
                Invoke((MethodInvoker)delegate
                {

                    switch (updateType)
                    {
                        case "volume":
                            VolumeTextLabel.Text = $"{Globals.AudioHandler.Volume}%";
                            TrayNotifyIcon.Text = $"{Application.ProductName} - {Globals.AudioHandler.Volume}%";

                            Width = (int)CalculateBarSize(VolumeTextLabel.Text).Width + Globals.AudioHandler.Volume + Settings.Default.BarWidthPadding;
                            if (Settings.Default.UseBarGradient)
                                VolumeTextLabel.BackColor = Utils.CalculateColor(Globals.AudioHandler.Volume);
                            else
                                VolumeTextLabel.BackColor = Settings.Default.BarColor;
                            break;
                        case "device":
                            VolumeTextLabel.Text = $"({Globals.CurrentAudioDeviceIndex + 1}/{Globals.AudioHandler.GetAudioDevicesList().Count}) {Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}";
                            Width = Settings.Default.BarWidthPadding + (int)CalculateBarSize(VolumeTextLabel.Text).Width + 10;
                            if (Settings.Default.UseBarGradient)
                                VolumeTextLabel.BackColor = Utils.CalculateColor(Globals.AudioHandler.Volume);
                            else
                                VolumeTextLabel.BackColor = Settings.Default.BarColor;
                            break;
                        case "mute":
                            if (Globals.AudioHandler.Muted)
                            {
                                VolumeTextLabel.Text = "Device Muted";
                                TrayNotifyIcon.Text = "Device is muted";
                            }
                            else
                            {
                                VolumeTextLabel.Text = "Device Unmuted";
                                TrayNotifyIcon.Text = $"Volume: {Globals.AudioHandler.Volume}%";
                            }
                            Width = Settings.Default.BarWidthPadding + (int)CalculateBarSize(VolumeTextLabel.Text).Width + 10;
                            if (Settings.Default.UseBarGradient)
                                VolumeTextLabel.BackColor = Utils.CalculateColor(Globals.AudioHandler.Volume);
                            else
                                VolumeTextLabel.BackColor = Settings.Default.BarColor;
                            break;
                        case "barfix":
                            Width = (int)CalculateBarSize(VolumeTextLabel.Text).Width + Globals.AudioHandler.Volume + Settings.Default.BarWidthPadding;
                            break;
                    }
                    if (updateType != "barfix")
                        Opacity = Settings.Default.BarOpacity;
                    Refresh();
                    SetVolumeBarPosition();
                    if (Globals.IsDisplayingVolumeBar)
                        return;
                    AutoHideVolume();
                });
            });
        }

        public void SetTrayIcon()
        {
            if (Globals.AudioHandler.AudioDisabled)
            {
                TrayNotifyIcon.Text = "Audio disabled";
                TrayNotifyIcon.Icon = Resources.voldisabled;
            }
            else if (Globals.AudioHandler.Muted)
            {
                TrayNotifyIcon.Text = "Device is muted";
                TrayNotifyIcon.Icon = Resources.volmute;
            }
            else
            {
                if (Globals.AudioHandler.Volume >= 90)
                    TrayNotifyIcon.Icon = Resources.vol100;
                if (Globals.AudioHandler.Volume >= 80 && Globals.AudioHandler.Volume < 90)
                    TrayNotifyIcon.Icon = Resources.vol90;
                if (Globals.AudioHandler.Volume >= 70 && Globals.AudioHandler.Volume < 80)
                    TrayNotifyIcon.Icon = Resources.vol80;
                if (Globals.AudioHandler.Volume >= 60 && Globals.AudioHandler.Volume < 70)
                    TrayNotifyIcon.Icon = Resources.vol70;
                if (Globals.AudioHandler.Volume >= 50 && Globals.AudioHandler.Volume < 60)
                    TrayNotifyIcon.Icon = Resources.vol60;
                if (Globals.AudioHandler.Volume >= 40 && Globals.AudioHandler.Volume < 50)
                    TrayNotifyIcon.Icon = Resources.vol50;
                if (Globals.AudioHandler.Volume >= 30 && Globals.AudioHandler.Volume < 40)
                    TrayNotifyIcon.Icon = Resources.vol40;
                if (Globals.AudioHandler.Volume >= 20 && Globals.AudioHandler.Volume < 30)
                    TrayNotifyIcon.Icon = Resources.vol30;
                if (Globals.AudioHandler.Volume >= 10 && Globals.AudioHandler.Volume < 20)
                    TrayNotifyIcon.Icon = Resources.vol20;
                if (Globals.AudioHandler.Volume > 0 && Globals.AudioHandler.Volume < 10)
                    TrayNotifyIcon.Icon = Resources.vol10;
            }
            Icon = TrayNotifyIcon.Icon;
        }

        public async Task SetMuteStatus(int delta)
        {
            bool isMuted = delta < 0;
            Globals.AudioHandler.SetMasterVolumeMute(isMuted);
            if (isMuted)
            {
                VolumeTextLabel.Text = "Device Muted";
                TrayNotifyIcon.Text = "Device is muted";
            }
            else
            {
                VolumeTextLabel.Text = "Device Unmuted";
                TrayNotifyIcon.Text = $"Volume: {Globals.AudioHandler.Volume}%";
            }
            Width = Settings.Default.BarWidthPadding + (int)CalculateBarSize(VolumeTextLabel.Text).Width + 10;
            VolumeTextLabel.BackColor = Color.SkyBlue;
            await Globals.AudioHandler.UpdateAudioState();
        }


        public SizeF CalculateBarSize(string text)
        {
            return VolumeTextLabel.CreateGraphics().MeasureString(text, VolumeTextLabel.Font);
        }

        private void PlaySystemSoundTrayMenu(object sender, MouseEventArgs e)
        {
            if (TitleLabelMenuItem.ContentRectangle.Contains(e.Location))
                SystemSounds.Exclamation.Play();
        }

        private void ShowVolumeSliderPopupForm(object sender, MouseEventArgs e)
        {
            if (Globals.ProgramIsReady)
            {
                if (e.Button == MouseButtons.Middle)
                {
                    Globals.IsDisplayingVolumeSliderControl = true;
                    TrayContextMenu.Hide();
                    new VolumeSliderControlForm().ShowDialog();
                    Globals.IsDisplayingVolumeSliderControl = false;
                }
            }
        }

        private void VolumeSliderPopupMenuItemClick(object sender, EventArgs e)
        {
            Globals.IsDisplayingVolumeSliderControl = true;
            new VolumeSliderControlForm().ShowDialog();
            Globals.IsDisplayingVolumeSliderControl = false;
        }
        private void OpenCheckForUpdatesForm(object sender, EventArgs e)
        {
            new CheckForUpdatesForm().ShowDialog();
        }

        private void OpenCurrentLocation(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private async void LoadProgramSettings(object sender, EventArgs e)
        {
            Globals.InputHandler = new InputHandler();
            await Task.Run(async () =>
            {
                if (Settings.Default.UpdateSettings)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.UpdateSettings = false;
                    Settings.Default.Save();
                }
                Globals.MainForm = this;
                Globals.AudioHandler = new AudioHandler();
                await Globals.AudioHandler.RefreshPlaybackDevices();
                await Globals.AudioHandler.UpdateAudioState();
                Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
                Invoke((MethodInvoker)async delegate
                {
                    VolumeTextLabel.Font = Settings.Default.FontStyle;
                    VolumeTextLabel.Text = $"{Globals.AudioHandler.Volume}%";
                    TrayNotifyIcon.Text = $"{Application.ProductName} - {Globals.AudioHandler.Volume}%";

                    SizeF newMinSizes = CalculateBarSize(VolumeTextLabel.Text);
                    MinimumSize = new Size(Settings.Default.BarWidthPadding + (int)newMinSizes.Width, Settings.Default.BarHeightPadding + (int)newMinSizes.Height);
                    Width = MinimumSize.Width;
                    Height = MinimumSize.Height;
                    SystemVolumeMixerMenuItem.Enabled = true;
                    AudioPlaybackDevicesMenuItem.Enabled = true;
                    VolumeSliderControlMenuItem.Enabled = true;
                    MoreOptionsMenuItem.Enabled = true;
                    await DoAppearanceUpdate("barfix"); // Call appearance update once so next update will be properly positioned (bug?)
                    Hide();
                    Globals.ProgramIsReady = true;
                });
            });

        }
    }
}