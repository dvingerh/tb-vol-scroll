using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tbvolscroll.Forms
{
    public partial class VolumeSliderPopupForm : Form
    {
        MainForm callback;
        public VolumeSliderPopupForm(MainForm callback)
        {
            InitializeComponent();
            this.callback = callback;
            VolumeTrackBar.Value = callback.audioHandler.Volume;
            VolumeLabel.Text = $"{callback.audioHandler.Volume}%";
            AudioDeviceLabel.Text = callback.audioHandler.CoreAudioController.DefaultPlaybackDevice.Name;
        }

        private void OnFormShown(object sender, EventArgs e)
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

            Size = new Size(250, 50);
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
