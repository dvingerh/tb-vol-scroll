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
        }

        private void VolumeSliderPopupFormShown(object sender, EventArgs e)
        {
            Point curPoint = Cursor.Position;
            Location = new Point(curPoint.X - Width - 15, curPoint.Y - Height - 15);
            Size = new Size(200, 25);
        }

        private void UpdateVolume(object sender, EventArgs e)
        {
            callback.audioHandler.SetMasterVolume(VolumeTrackBar.Value);
            callback.audioHandler.UpdateAudioState();
            VolumeLabel.Text = $"{callback.audioHandler.Volume}%";
            callback.TrayNotifyIcon.Text = $"{Application.ProductName} - {callback.audioHandler.Volume}%";
            callback.SetTrayIcon();
            SystemSounds.Exclamation.Play();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }
    }
}
