using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using AudioSwitcher.AudioApi.Session;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll.Forms
{
    public partial class VolumeSliderControlForm : Form
    {
        readonly MainForm callback;
        public VolumeSliderControlForm(MainForm callback)
        {
            InitializeComponent();
            this.callback = callback;
            VolumeTrackBar.Value = callback.audioHandler.Volume;
            VolumeLabel.Text = $"{callback.audioHandler.Volume}%";
            AudioDeviceLabel.Text = callback.audioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
        }

        private async void OnFormShown(object sender, EventArgs e)
        {
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;

            switch (TaskbarHelper.Position)
            {
                case TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width, workingArea.Bottom - Height);
                    break;
                case TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width, workingArea.Bottom - Height);
                    break;
                case TaskbarPosition.Left:
                    Location = new Point(workingArea.Left, workingArea.Bottom - Height);
                    break;
                case TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width, workingArea.Top);
                    break;

            }

            callback.audioHandler.CoreAudioController.AudioDeviceChanged.Subscribe(async x => {
                await Task.Run(async () =>
                {
                    await StartPeakVolumeMeter();
                });
            });

            await Task.Run(async () =>
            {
                await StartPeakVolumeMeter();
            });
        }

        public async Task StartPeakVolumeMeter()
        {
            var device = await callback.audioHandler.CoreAudioController.GetDefaultDeviceAsync(DeviceType.Playback, Role.Multimedia);
            device.PeakValueChanged.Subscribe(x =>
            {

                int value = (int)Math.Round((x.PeakValue / 100) * callback.audioHandler.Volume);
                Invoke((MethodInvoker)delegate
                {
                    PeakMeterProgressBar.Value = value;
                    if (value != 0)
                    {
                        PeakMeterProgressBar.Value = value - 1;
                        PeakMeterProgressBar.Value = value;
                    }
                    VolumeTrackBar.Value = callback.audioHandler.Volume;
                    VolumeLabel.Text = $"{callback.audioHandler.Volume}%";
                    AudioDeviceLabel.Text = callback.audioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
                });
            });
        }

        private void UpdateVolume(object sender, EventArgs e)
        {
            callback.audioHandler.SetMasterVolume(VolumeTrackBar.Value);
            callback.audioHandler.UpdateAudioState();
            if (callback.audioHandler.Volume == 0 && callback.audioHandler.Muted == false)
                callback.audioHandler.SetMasterVolumeMute(isMuted: true);
            else if (callback.audioHandler.Volume > 0 && callback.audioHandler.Muted == true)
                callback.audioHandler.SetMasterVolumeMute(isMuted: false);
            callback.audioHandler.UpdateAudioState();
            VolumeLabel.Text = $"{callback.audioHandler.Volume}%";
            callback.TrayNotifyIcon.Text = $"{Application.ProductName} - {callback.audioHandler.Volume}%";
            callback.SetTrayIcon();
            SystemSounds.Exclamation.Play();
        }

        private void CloseFormOnDeacivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
