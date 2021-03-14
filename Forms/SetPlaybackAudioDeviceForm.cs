using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;

namespace tbvolscroll.Forms
{
    public partial class SetPlaybackAudioDeviceForm : Form
    {
        public SetPlaybackAudioDeviceForm()
        {
            InitializeComponent();
            ImageList listViewHeightFix = new ImageList
            {
                ImageSize = new Size(1, 30)
            };
            DevicesListView.SmallImageList = listViewHeightFix;
        }

        private async void OnFormShown(object sender, EventArgs e)
        {
            Point curPoint = Cursor.Position;
            Location = new Point(curPoint.X - Width, curPoint.Y - Height);
            await LoadAudioPlaybackDevicesList();
        }

        private async Task LoadAudioPlaybackDevicesList()
        {
            await AudioHandler.RefreshPlaybackDevices();
            foreach (CoreAudioDevice d in AudioHandler.AudioDevices)
            {
                ListViewItem deviceItem = new ListViewItem()
                {
                    Text = d.FullName
                };
                deviceItem.SubItems.Add(d.IsDefaultDevice ? "Yes" : "No");
                deviceItem.SubItems.Add(d.IsMuted ? "Yes" : "No");
                deviceItem.SubItems.Add($"{d.Volume}%");
                deviceItem.BackColor = d.IsDefaultDevice ? Color.FromArgb(230, 255, 230) : Color.White;
                deviceItem.Tag = d;
                DevicesListView.Items.Add(deviceItem);
            }

            RefreshButton.Enabled = true;
        }

        private async void SaveButtonClick(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count > 0)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await newPlaybackDevice.SetAsDefaultAsync();
                Close();
            }
        }

        private void ToggleSaveButton(object sender, EventArgs e)
        {
            SaveButton.Enabled = DevicesListView.SelectedItems.Count > 0;
        }

        private void DevicesListViewDoubleClick(object sender, EventArgs e)
        {
            SaveButton.PerformClick();
        }

        private async void RefreshButtonClick(object sender, EventArgs e)
        {

            DevicesListView.Items.Clear();
            RefreshButton.Enabled = false;
            await LoadAudioPlaybackDevicesList();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
    }
}
