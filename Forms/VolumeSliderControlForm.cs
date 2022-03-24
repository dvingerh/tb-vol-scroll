using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;
using tb_vol_scroll.Classes;
using tb_vol_scroll.Classes.ControlsEx;
using tb_vol_scroll.Classes.Helpers;

namespace tb_vol_scroll.Forms
{
    public partial class VolumeSliderControlForm : Form
    {
        private readonly Queue<int> updateVolumeQueue = new Queue<int>();
        private Task currentUpdateVolumeTask = null;
        private readonly Queue<double> updatePeakValueQueue = new Queue<double>();
        private Task currentPeakValueTask = null;
        public VolumeSliderControlForm()
        {
            InitializeComponent();
            new FormShadowEx().ApplyShadows(this);
            UpdateDeviceState();
        }

        public void UpdateVolumeState()
        {
            if (Globals.AudioAvailable)
            {
                    Utils.InvokeIfRequired(this, () =>
                    {
                        if(updateVolumeQueue.Count == 0)
                            VolumeTrackBar.Value = Globals.AudioHandler.FriendlyVolume;
                        VolumeLabel.Text = $"{(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? ("Muted") : VolumeTrackBar.Value + "%")}";
     
                        Image iconImg = Utils.GetIconFromResource(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IconPath).ToBitmap();
                        if (Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted)
                            iconImg = ToolStripRenderer.CreateDisabledImage(iconImg);
                        AudioDevicePictureBox.Image = iconImg;
                        if (!Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted)
                            AudioDevicePictureBox.BackColor = Color.Transparent;
                        else
                            AudioDevicePictureBox.BackColor = Color.FromArgb(255, 225, 225, 225);
                        Invalidate();
                        Update();
                        if (Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted)
                            UpdatePeakValue(0);
                    });
            }
        }
        public void UpdateDeviceState()
        {
            if (Globals.AudioAvailable)
            {
                Utils.InvokeIfRequired(this, () =>
                {
                    AudioDeviceNameLabel.Text = $"{Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name}{(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsBluetooth ? " (Bluetooth)" : "")}";
                    VolumeLabel.Text = $"{(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted ? ("Muted") : VolumeTrackBar.Value + "%")}";
                    VolumeSliderTooltip.SetToolTip(AudioDeviceNameLabel, Globals.AudioHandler.AudioController.DefaultPlaybackDevice.Name);
                    Image iconImg = Utils.GetIconFromResource(Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IconPath).ToBitmap();
                    if (Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted)
                        iconImg = ToolStripRenderer.CreateDisabledImage(iconImg);
                    AudioDevicePictureBox.Image = iconImg;
                    UpdateVolumeState();
                });
            }
        }

        public async void UpdatePeakValue(double peakValue)
        {
            if (updatePeakValueQueue.Count == 0)
            {
                updatePeakValueQueue.Enqueue(peakValue);
                if (updatePeakValueQueue.Count != 0)
                    await ProcessPeakValueEventQueue();
            }
        }


        private async Task ProcessVolumeQueue()
        {
            if ((currentUpdateVolumeTask == null) || currentUpdateVolumeTask.IsCompleted)
            {
                if (updateVolumeQueue.Count != 0)
                {
                    var volumeArgs = updateVolumeQueue.Dequeue();
                    currentUpdateVolumeTask = HandleVolumeUpdate(volumeArgs);
                    await currentUpdateVolumeTask.ContinueWith(result => UpdateVolumeState());
                    if (updateVolumeQueue.Count != 0)
                        await ProcessVolumeQueue();
                }
            }
        }

        private async Task HandleVolumeUpdate(int volumeArgs)
        {
            if (volumeArgs != Globals.AudioHandler.FriendlyVolume)
            {
                await Globals.AudioHandler.SetDeviceVolume(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, volumeArgs);
                if (Globals.AudioHandler.FriendlyVolume == 0 && Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted == false)
                {
                    await Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, isMuted: true);
                }
                else if (Globals.AudioHandler.FriendlyVolume > 0 && Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted == true)
                    await Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, isMuted: false);
            }

        }

        private async Task ProcessPeakValueEventQueue()
        {
            if ((currentPeakValueTask == null) || currentPeakValueTask.IsCompleted)
            {
                if (updatePeakValueQueue.Count != 0)
                {
                    var peakValueArgs = updatePeakValueQueue.Dequeue();
                    currentPeakValueTask = HandlePeakValueUpdate(peakValueArgs);
                    await currentPeakValueTask;
                    if (updatePeakValueQueue.Count != 0)
                        await ProcessPeakValueEventQueue();
                }
            }
        }

        public async Task HandlePeakValueUpdate(double peakValue)
        {
            if (Globals.AudioAvailable)
            {
                await Task.Run(() =>
                {
                    Utils.InvokeIfRequired(this, () =>
                    {
                        double curValue = Math.Round(peakValue / 100 * Globals.AudioHandler.FriendlyVolume, 2);
                        double widthPerc = Math.Round((double)PeakMeterPanel.Width / 100, 2);
                        double maxValue = Math.Round(peakValue / 100 * 100, 2);
                        if (peakValue != 100)
                        {
                            PeakMeterPictureBox.BackColor = Utils.GetColorByPercentage(100 - curValue);
                            TruePeakMeterPictureBox.BackColor = Color.FromArgb(255, 200, 200, 200);
                            PeakMeterPictureBox.Width = (int)Math.Round(curValue * widthPerc) - 2;

                        }
                        else
                        {
                            Color curColor = Utils.GetColorByPercentage(100 - curValue);
                            PeakMeterPictureBox.BackColor = Color.FromArgb(255, (int)(curColor.R * 0.8), (int)(curColor.G * 0.8), (int)(curColor.B * 0.8));
                            TruePeakMeterPictureBox.BackColor = Color.FromArgb(255, 170, 170, 170);
                        }
                        TruePeakMeterPictureBox.Width = (int)Math.Round(maxValue * widthPerc) - 2;
                        Invalidate();
                        Update();

                    });
                });
            }
        }


        #region Appearance Fixes

        private void VolumeSliderControlForm_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                Rectangle rect = DisplayRectangle;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void VolumeSliderControlForm_Shown(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;

            switch (Taskbar.Position)
            {
                case Taskbar.TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case Taskbar.TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case Taskbar.TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case Taskbar.TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;

            }
            Activate();
            Invalidate();

        }

        private void VolumeSliderControlForm_Activated(object sender, EventArgs e)
        {
            Invalidate();
            Utils.AvoidControlFocus(Handle);
        }

        #endregion

        private void VolumeSliderControlForm_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
        private async void VolumeTrackBar_Scroll(object sender, EventArgs e)
        {
            if(updateVolumeQueue.Count == 0)
                updateVolumeQueue.Enqueue(VolumeTrackBar.Value);
            if (updateVolumeQueue.Count != 0)
                await ProcessVolumeQueue();
            Utils.AvoidControlFocus(Handle);
            //SystemSounds.Exclamation.Play();
        }


        private void PeakMeterPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                Rectangle rect = PeakMeterPanel.DisplayRectangle;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void VolumeSliderControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateVolumeQueue.Clear();
            updatePeakValueQueue.Clear();
            currentUpdateVolumeTask = null;
            currentPeakValueTask = null;
        }

        private void VolumeTrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            SystemSounds.Exclamation.Play();
        }

        private async void AudioDevicePictureBox_Click(object sender, EventArgs e)
        {
            await Globals.AudioHandler.SetDeviceMute(Globals.AudioHandler.AudioController.DefaultPlaybackDevice, !Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted);
        }

        private void AudioDevicePictureBox_MouseEnter(object sender, EventArgs e)
        {
                AudioDevicePictureBox.BackColor = Color.FromArgb(255, 225, 225, 225);

        }

        private void AudioDevicePictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!Globals.AudioHandler.AudioController.DefaultPlaybackDevice.IsMuted)
                AudioDevicePictureBox.BackColor = Color.Transparent;

        }

        private void AudioDevicePictureBox_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(255, 200, 200, 200), 2))
            {
                Rectangle rect = AudioDevicePictureBox.DisplayRectangle;
                e.Graphics.DrawRectangle(pen, rect);
            }

        }
    }
}
