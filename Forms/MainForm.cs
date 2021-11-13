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
using System.ServiceProcess;

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

        private readonly Timer hideVolumeBarTimer = new Timer();

        public MainForm(bool noTray = false, bool attemptedAdmin = false, bool updateDoneArg = false, bool audioSrvArg = false)
        {
            InitializeComponent();
            hideVolumeBarTimer.Tick += HideVolumeBar;

            if (noTray)
            {
                Globals.DisplayTrayIcon = false;
                TrayNotifyIcon.Visible = false;
            }


            if (audioSrvArg)
            {
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(2500, "Windows Audio service active", $"{Application.ProductName} has been restarted.", ToolTipIcon.Info);
            }

            if (updateDoneArg)
            {
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(2500, "Update complete", $"Successfully updated {Application.ProductName} to version {Application.ProductVersion}.", ToolTipIcon.Info);
            }

            bool hasAdmin = Utils.IsAdministrator();

            if (attemptedAdmin && hasAdmin)
            {
                TrayNotifyIcon.Visible = true;
                TrayNotifyIcon.ShowBalloonTip(2500, "Administrator permissions available", $"{Application.ProductName} has restarted with administrator permissions.", ToolTipIcon.Info);
            }

            TitleLabelMenuItem.Text = $"{Application.ProductName} v{Application.ProductVersion}" + (hasAdmin ? " (Administrator)" : "");


            if (!attemptedAdmin && !hasAdmin && Settings.Default.AutoRetryAdmin)
            {
                new Task(async () =>
                {
                    TrayNotifyIcon.Visible = true;
                    TrayNotifyIcon.ShowBalloonTip(2500, "Administrator permissions unavailable", $"{Application.ProductName} will restart requesting administrator permissions.", ToolTipIcon.Warning);
                    await Task.Delay(2500);
                    Process proc = new Process();
                    proc.StartInfo.FileName = Application.ExecutablePath;
                    proc.StartInfo.UseShellExecute = true;
                    proc.StartInfo.Verb = "runas";
                    proc.StartInfo.Arguments = "admin";
                    HandleApplicationExit(proc, 0);
                }).Start();
            }
            else
                InitialiseProgram().ConfigureAwait(false);
        }

        private async Task InitialiseProgram()
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
                Invoke((MethodInvoker)delegate
               {
                   VolumeTextLabel.Font = Settings.Default.FontStyle;
                   VolumeTextLabel.Text = $"{Globals.AudioHandler.Volume}%";

                   SizeF newMinSizes = Utils.CalculateBarSize(VolumeTextLabel, "100%");
                   Size minSize = new Size(Settings.Default.BarWidthPadding + (int)newMinSizes.Width, Settings.Default.BarHeightPadding + 5 + (int)newMinSizes.Height);
                   Height = minSize.Height;
                   VolumeTextLabel.Text = $"{Globals.AudioHandler.Volume}%";
                   TrayNotifyIcon.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: {Globals.AudioHandler.Volume}%";
                   Width = (int)Utils.CalculateBarSize(VolumeTextLabel, "100%").Width + Globals.AudioHandler.Volume + Settings.Default.BarWidthPadding;
                   if (Settings.Default.UseBarGradient)
                       VolumeTextLabel.BackColor = Utils.CalculateColor(Globals.AudioHandler.Volume);
                   else
                       VolumeTextLabel.BackColor = Settings.Default.BarColor;

                   SetVolumeBarPosition();
                   Utils.ShowInactiveTopmost();
                   Hide();

                   SystemVolumeMixerMenuItem.Enabled = true;
                   AudioPlaybackDevicesMenuItem.Enabled = true;
                   VolumeSliderControlMenuItem.Enabled = true;
                   MoreOptionsMenuItem.Enabled = true;


                   Globals.ProgramIsReady = true;
               });
            });
        }

        public void SetVolumeBarPosition()
        {
            Point cursorPosition = Cursor.Position;
            switch (TaskbarHelper.Position)
            {
                case TaskbarHelper.TaskbarPosition.Bottom:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                case TaskbarHelper.TaskbarPosition.Left:
                    Left = cursorPosition.X + 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarHelper.TaskbarPosition.Top:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y + 25;
                    break;
                case TaskbarHelper.TaskbarPosition.Right:
                    Left = cursorPosition.X - Width - 25;
                    Top = cursorPosition.Y - 5;
                    break;
                case TaskbarHelper.TaskbarPosition.Unknown:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;
                default:
                    Left = cursorPosition.X - Width / 2;
                    Top = cursorPosition.Y - Height - 5;
                    break;

            }
        }




        private void AutoHideVolume()
        {
            Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
            Utils.ShowInactiveTopmost();
            hideVolumeBarTimer.Interval = (Globals.VolumeBarAutoHideTimeout); 
            hideVolumeBarTimer.Start();
        }

        public void HideVolumeBar(object sender, EventArgs e)
        {
            Invoke((MethodInvoker)delegate
            {
                Globals.VolumeBarAutoHideTimeout = Settings.Default.AutoHideTimeOut;
                Hide();
                hideVolumeBarTimer.Stop();
            });
        }

        public void HandleApplicationExit(Process process, int code = 0)
        {
            if (Globals.InputHandler != null)
            {
                Globals.InputHandler.InputEvents.Dispose();
            }
            if (Globals.AudioHandler != null)
                Globals.AudioHandler.CoreAudioController.Dispose();
            TrayNotifyIcon.Visible = false;
            TrayNotifyIcon.Icon = null;
            TrayNotifyIcon.Dispose();
            Invoke((MethodInvoker)delegate
            {
                Globals.AppMutex.ReleaseMutex();
                Globals.AppMutex.Dispose();
            });

            if (process != null)
                process.Start();

            Environment.Exit(code);
        }
        public void ExitApplication(object sender, EventArgs e)
        {
            HandleApplicationExit(null, 0);
        }

        private void RestartAppNormal(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Arguments = "admin";
            HandleApplicationExit(proc, 0);
        }

        private void ShowTrayMenuOnClick(object sender, EventArgs e)
        {
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(TrayNotifyIcon, null);
        }

        private void OpenConfigureDialog(object sender, EventArgs e)
        {
            new ConfigurationForm().ShowDialog();
        }

        private void RestartAppAsAdministrator(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = "restart";
            HandleApplicationExit(proc, 0);
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

        public async Task DoScrollUpdate(string updateType)
        {
            await Task.Run(async() =>
            {
                hideVolumeBarTimer.Stop();
                await Globals.AudioHandler.UpdateAudioState();
                Invoke((MethodInvoker)delegate
                {

                    switch (updateType)
                    {
                        case "volume":
                            VolumeTextLabel.Text = $"{Globals.AudioHandler.Volume}%";
                            TrayNotifyIcon.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: {Globals.AudioHandler.Volume}%";

                            Width = (int)Utils.CalculateBarSize(VolumeTextLabel, "100%").Width + Globals.AudioHandler.Volume + Settings.Default.BarWidthPadding;
                            if (Settings.Default.UseBarGradient)
                                VolumeTextLabel.BackColor = Utils.CalculateColor(Globals.AudioHandler.Volume);
                            else
                                VolumeTextLabel.BackColor = Settings.Default.BarColor;
                            break;
                        case "device":
                            VolumeTextLabel.Text = $"({Globals.CurrentAudioDeviceIndex + 1}/{Globals.AudioHandler.GetAudioDevicesList().Count}) {Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}";
                            Width = Settings.Default.BarWidthPadding + (int)Utils.CalculateBarSize(VolumeTextLabel, VolumeTextLabel.Text).Width + 15;
                            VolumeTextLabel.BackColor = Settings.Default.BarColor;
                            break;
                        case "mute":
                            if (Globals.AudioHandler.Muted)
                            {
                                VolumeTextLabel.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: Muted";
                                TrayNotifyIcon.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: Muted";
                            }
                            else
                            {
                                VolumeTextLabel.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: Unmuted";
                                TrayNotifyIcon.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: {Globals.AudioHandler.Volume}%";
                            }
                            Width = Settings.Default.BarWidthPadding + (int)Utils.CalculateBarSize(VolumeTextLabel, VolumeTextLabel.Text).Width + 15;
                            VolumeTextLabel.BackColor = Settings.Default.BarColor;
                            break;
                    }
                    Opacity = Settings.Default.BarOpacity;
                    Globals.IsDisplayingVolumeBar = true;
                    SetVolumeBarPosition();
                    AutoHideVolume();
                });
            });
        }

        public void SetTrayIcon()
        {
            if (Globals.AudioHandler.AudioDisabled)
            {
                Globals.AudioHandler.AudioSrvStatusController.Refresh();
                if (Globals.AudioHandler.AudioSrvStatusController.Status == ServiceControllerStatus.Running)
                    TrayNotifyIcon.Text = "No playback devices available";
                else
                    TrayNotifyIcon.Text = "Windows Audio service not running";
                TrayNotifyIcon.Icon = Resources.voldisabled;
            }
            else if (Globals.AudioHandler.Muted)
            {
                TrayNotifyIcon.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: Muted";
                TrayNotifyIcon.Icon = Resources.volmute;
            }
            else
            {
                TrayNotifyIcon.Text = $"{Globals.AudioHandler.CoreAudioController.DefaultPlaybackDevice.Name}: {Globals.AudioHandler.Volume}%";
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
                    TrayContextMenu.Hide();
                    Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
                    Globals.VolumeSliderControlForm.ShowDialog();
                }
            }
        }

        private void VolumeSliderPopupMenuItemClick(object sender, EventArgs e)
        {
            Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
            Globals.VolumeSliderControlForm.ShowDialog();
        }
        private void OpenCheckForUpdatesForm(object sender, EventArgs e)
        {
            new CheckForUpdatesForm().ShowDialog();
        }

        private void OpenCurrentLocation(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private void HandleBalloonTipHide(object sender, EventArgs e)
        {
            if (!Globals.DisplayTrayIcon)
                TrayNotifyIcon.Visible = false;
        }
    }
}