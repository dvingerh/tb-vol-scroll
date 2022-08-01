using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using tb_vol_scroll.Classes;
using tb_vol_scroll.Classes.Handlers;
using tb_vol_scroll.Classes.Helpers;
using tb_vol_scroll.Forms;
using tb_vol_scroll.Properties;
using static tb_vol_scroll.Classes.Helpers.Enums;

namespace tb_vol_scroll
{
    public partial class MainForm : Form
    {

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;

                createParams.ExStyle |= 0x08000000;
                return createParams;
            }
        }

        public Timer HideBarTimer { get => hideBarTimer; set => hideBarTimer = value; }

        private Timer hideBarTimer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            Globals.MainForm = this;
            if (!Globals.AppArgs.Contains("administrator") && !Utils.IsAdministrator() && Settings.Default.AutoRetryAdmin)
            {
                Globals.AppArgs.Add("administrator");
                Process proc = new Process();
                proc.StartInfo.FileName = Application.ExecutablePath;
                proc.StartInfo.UseShellExecute = true;
                proc.StartInfo.Verb = "runas";
                proc.StartInfo.Arguments = string.Join(" ", Globals.AppArgs.ToArray() );
                Utils.HandleApplicationExit(proc);
            }

            if (Globals.AppArgs.Contains("updated"))
            {
                if (Settings.Default.UpgradeRequired)
                {
                    Settings.Default.Upgrade();
                    Settings.Default.UpgradeRequired = false;
                    Settings.Default.Save();
                    ShowNotification("Update complete", $"Successfully updated {Application.ProductName} to version {Application.ProductVersion}.", ToolTipIcon.Info);
                }
            }

            hideBarTimer.Tick += (s, e) => { SetBarVisibility(false); hideBarTimer.Stop(); };
        }

        public void SetBarVisibility(bool visibility = false)
        {
            Utils.InvokeIfRequired(this, () =>
            {
                if (visibility)
                {
                    hideBarTimer.Stop();
                    SetBarPosition();
                    Utils.ShowFormWithoutFocus(this);
                    Visible = true;
                    hideBarTimer.Start();
                }
                else
                {
                    hideBarTimer.Stop();
                    Visible = false;
                }
            });
        }

        public void SetAppAppearances(ActionTriggerType type = ActionTriggerType.InternalEvent)
        {
            Utils.InvokeIfRequired(this, () =>
            {
                switch (type)
                {
                    case ActionTriggerType.RegularVolumeScroll:
                    case ActionTriggerType.PreciseVolumeScroll:
                        Width = MinimumSize.Width + Globals.AudioHandler.FriendlyVolume + Settings.Default.StatusBarWidthPadding;
                        BarTextLabel.Text = $"{Globals.AudioHandler.FriendlyVolume}%";
                        BarTextLabel.ForeColor = Settings.Default.StatusBarTextColorIsGradient ? Utils.GetColorByPercentage(Globals.AudioHandler.FriendlyVolume) : Settings.Default.StatusBarTextColor;
                        BarTextLabel.BackColor = Settings.Default.StatusBarColorIsGradient ? Utils.GetColorByPercentage(Globals.AudioHandler.FriendlyVolume) : Settings.Default.StatusBarColor;
                        break;
                    case ActionTriggerType.MuteToggleScroll:
                        BarTextLabel.Text = $"{Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name}: {(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? "Muted" : "Unmuted")}";
                        BarTextLabel.ForeColor = Color.Black;
                        BarTextLabel.BackColor = Color.SkyBlue;
                        Width = MinimumSize.Width + Utils.CalculateMinimumBarSize(BarTextLabel, BarTextLabel.Text).Width + Settings.Default.StatusBarWidthPadding;
                        break;
                    case ActionTriggerType.DeviceSwitchScroll:
                        int curDeviceIndex = Globals.AudioHandler.AudioDevices.IndexOf(Globals.AudioHandler.AudioController.DefaultPlaybackDevice) + 1;
                        BarTextLabel.Text = $"({curDeviceIndex}/{Globals.AudioHandler.AudioDevices.Count}) {Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name}: Active";
                        BarTextLabel.ForeColor = Color.Black;
                        BarTextLabel.BackColor = Color.SkyBlue;
                        Width = MinimumSize.Width + Utils.CalculateMinimumBarSize(BarTextLabel, BarTextLabel.Text).Width + Settings.Default.StatusBarWidthPadding;
                        break;
                    case ActionTriggerType.InternalEvent:
                        TrayNotifyIcon.Icon = Utils.GenerateTrayIcon(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? "M" : Globals.AudioHandler.FriendlyVolume.ToString());
                        TrayNotifyIcon.Text = $"{Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name}{(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsBluetooth ? " (Bluetooth)" : "")}: {(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? "Muted" : Globals.AudioHandler.FriendlyVolume.ToString() + "%")}";
                        break;
                    case ActionTriggerType.ConfigurationApplied:
                        Font = Settings.Default.StatusBarFontStyle;
                        MinimumSize = Utils.CalculateMinimumBarSize(BarTextLabel, "100%");
                        
                        TrayNotifyIcon.Icon = Utils.GenerateTrayIcon(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? "M" : Globals.AudioHandler.FriendlyVolume.ToString());
                        TrayNotifyIcon.Text = $"{Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name}{(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsBluetooth ? " (Bluetooth)" : "")}: {(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? "Muted" : Globals.AudioHandler.FriendlyVolume.ToString() + "%")}";
                        Width = MinimumSize.Width + Globals.AudioHandler.FriendlyVolume + Settings.Default.StatusBarWidthPadding;
                        Height = MinimumSize.Height + Settings.Default.StatusBarHeightPadding;
                        Opacity = Settings.Default.StatusBarOpacity;
                        HideBarTimer.Interval = Settings.Default.AutoHideTimeOut;
                        break;
                    case ActionTriggerType.AudioDisabled:
                        Globals.InputHandler.InputEnabled = false;
                        AudioPlaybackDevicesMenuItem.Enabled = false;
                        VolumeSliderControlMenuItem.Enabled = false;
                        TrayNotifyIcon.Icon = Utils.GenerateTrayIcon("X");
                        TrayNotifyIcon.Text = "Audio playback device unavailable";
                        //ShowNotification("Audio playback device unavailable", $"Audio control has been disabled.", ToolTipIcon.Warning);
                        break;
                    case ActionTriggerType.AudioEnabled:
                        Globals.InputHandler.InputEnabled = true;
                        AudioPlaybackDevicesMenuItem.Enabled = true;
                        VolumeSliderControlMenuItem.Enabled = true;
                        TrayNotifyIcon.Icon = Utils.GenerateTrayIcon("T");
                        TrayNotifyIcon.Text = $"{Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name}{(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsBluetooth ? " (Bluetooth)" : "")}: {(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? "Muted" : Globals.AudioHandler.FriendlyVolume.ToString() + "%")}";
                        //ShowNotification("Audio playback device available", $"Audio control has been enabled.", ToolTipIcon.Info);
                        break;
                    case ActionTriggerType.Startup:
                        Size labelSize = Utils.CalculateMinimumBarSize(BarTextLabel, "100%");
                        Size volumeBarMinSize = new Size(labelSize.Width, labelSize.Height);
                        MinimumSize = volumeBarMinSize;
                        Height = volumeBarMinSize.Height + Settings.Default.StatusBarHeightPadding;
                        Width = volumeBarMinSize.Width + Settings.Default.StatusBarWidthPadding;
                        Opacity = Settings.Default.StatusBarOpacity;
                        Font = Settings.Default.StatusBarFontStyle;
                        hideBarTimer.Interval = Settings.Default.AutoHideTimeOut;
                        TrayNotifyIcon.Icon = Utils.GenerateTrayIcon("T");
                        TrayNotifyIcon.Visible = !Globals.AppArgs.Contains("trayless");
                        break;

                }
                Invalidate();
                Update();
            });
        }

        public void ShowNotification(string title, string text, ToolTipIcon icon)
        {
            TrayNotifyIcon.Visible = true;
            TrayNotifyIcon.ShowBalloonTip(5000, title, text, icon);
        }
        public void SetBarPosition()
        {
            Utils.InvokeIfRequired(this, () =>
            {
                Point cursorPosition = Cursor.Position;
                switch (Taskbar.Position)
                {
                    case Taskbar.TaskbarPosition.Bottom:
                        Left = cursorPosition.X - Width / 2;
                        Top = cursorPosition.Y - Height - 5;
                        break;
                    case Taskbar.TaskbarPosition.Left:
                        Left = cursorPosition.X + 25;
                        Top = cursorPosition.Y - 5;
                        break;
                    case Taskbar.TaskbarPosition.Top:
                        Left = cursorPosition.X - Width / 2;
                        Top = cursorPosition.Y + 25;
                        break;
                    case Taskbar.TaskbarPosition.Right:
                        Left = cursorPosition.X - Width - 25;
                        Top = cursorPosition.Y - 5;
                        break;
                    case Taskbar.TaskbarPosition.Unknown:
                        Left = cursorPosition.X - Width / 2;
                        Top = cursorPosition.Y - Height - 5;
                        break;
                    default:
                        Left = cursorPosition.X - Width / 2;
                        Top = cursorPosition.Y - Height - 5;
                        break;

                }
            });
        }

        private void BarTextLabel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                Rectangle rect = BarTextLabel.DisplayRectangle;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            SetAppAppearances(ActionTriggerType.Startup);
            SetBarVisibility(false);

            TitleLabelMenuItem.Text = $"{Application.ProductName} {Application.ProductVersion}";

            Image uacImage = Utils.GetUacShield();

            if (!Utils.IsAdministrator())
                uacImage = ToolStripRenderer.CreateDisabledImage(uacImage);
            TitleLabelMenuItem.Image = uacImage;

            Globals.InputHandler = new InputHandler();
            Globals.AudioHandler = new AudioHandler();

            if (!Globals.AudioHandler.IsAudioAvailable())
                SetAppAppearances(ActionTriggerType.AudioDisabled);
            else
            {
                SetAppAppearances(ActionTriggerType.InternalEvent);
                Globals.InputHandler.InputEnabled = true;
                AudioPlaybackDevicesMenuItem.Enabled = true;
                VolumeSliderControlMenuItem.Enabled = true;
            }
        }




        private void RestartAdministratorMenuItem_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = Application.ExecutablePath;
            proc.StartInfo.UseShellExecute = true;
            proc.StartInfo.Verb = "runas";
            proc.StartInfo.Arguments = "administrator";
            Utils.HandleApplicationExit(proc);
        }

        private void RestartNormalMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Utils.HandleApplicationExit();
        }

        private void TrayContextMenu_Closing(object sender, ToolStripDropDownClosingEventArgs e)
        {
            e.Cancel = e.CloseReason == ToolStripDropDownCloseReason.ItemClicked;
        }

        private void AudioPlaybackDevicesMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.AudioAvailable)
            {
                Globals.AudioPlaybackDevicesForm = new AudioPlaybackDevicesForm();
                Globals.AudioPlaybackDevicesForm.ShowDialog();
                Globals.AudioPlaybackDevicesForm = null;
            }
        }

        private void SystemVolumeMixerMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenSystemVolumeMixer();
        }

        private void VolumeSliderControlMenuItem_Click(object sender, EventArgs e)
        {
            if (Globals.AudioAvailable)
            {
                Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
                Globals.VolumeSliderControlForm.ShowDialog();
                Globals.VolumeSliderControlForm = null;
            }
        }

        private async void TrayNotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (Globals.AudioAvailable)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Globals.VolumeSliderControlForm != null)
                        Globals.VolumeSliderControlForm.Close();
                    else
                    {
                        Globals.VolumeSliderControlForm = new VolumeSliderControlForm();
                        Globals.VolumeSliderControlForm.ShowDialog();
                    }
                    Globals.VolumeSliderControlForm = null;
                }
                else if (e.Button == MouseButtons.Middle)
                    await Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, !Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted);
            }
            else
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                mi.Invoke(TrayNotifyIcon, null);
            }
        }

        private void CheckForUpdatesMenuItem_Click(object sender, EventArgs e)
        {
            UpdateForm updateForm = new UpdateForm();
            updateForm.ShowDialog();
        }

        private void ConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationForm configurationForm = new ConfigurationForm();
            configurationForm.ShowDialog();
        }

        private void OpenCurrentDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        private void OpenStartupDirectoryMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Startup));
        }

        private void TrayNotifyIcon_BalloonTipClosed(object sender, EventArgs e)
        {
            TrayNotifyIcon.Visible = !Globals.AppArgs.Contains("trayless");

        }
    }
}