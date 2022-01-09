using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi.CoreAudio;
using tbvolscroll.Classes;

namespace tbvolscroll.Forms
{
    public partial class AudioPlaybackDevicesForm : Form
    {
        private bool isRefreshing = false;
        public AudioPlaybackDevicesForm()
        {
            InitializeComponent();
            ImageList listViewHeightFix = new ImageList
            {
                ImageSize = new Size(1, 30)
            };
            DevicesListView.SmallImageList = listViewHeightFix;
            Globals.AudioPlaybackDevicesForm = this;
        }

        private async void OnFormShown(object sender, EventArgs e)
        {
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;

            switch (TaskbarHandler.Position)
            {
                case TaskbarHandler.TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHandler.TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHandler.TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarHandler.TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;
            }
            await LoadAudioPlaybackDevicesList();
            DevicesListView.Columns[0].Width = DevicesListView.Width - 210;
        }

        public async Task LoadAudioPlaybackDevicesList()
        {
            Invoke((MethodInvoker)delegate
            {
                SuspendLayout();
                DevicesListView.Items.Clear();
                ApplyButton.Enabled = false;
                RefreshButton.Enabled = false;
            });

            List<ListViewItem> deviceListViewItem = new List<ListViewItem>();
            List<CoreAudioDevice> audioDeviceList = await Globals.AudioHandler.GetPlaybackDevices();
            if (audioDeviceList != null)
            {
                foreach (CoreAudioDevice d in audioDeviceList)
                {
                    ListViewItem deviceItem = new ListViewItem()
                    {
                        Text = d.FullName
                    };
                    deviceItem.SubItems.Add(d.IsDefaultDevice ? "Yes" : "No");
                    deviceItem.SubItems.Add($"{(int)Math.Round(d.Volume)}%");
                    deviceItem.SubItems.Add(d.IsMuted ? "Yes" : "No");
                    deviceItem.BackColor = d.IsDefaultDevice ? Color.FromArgb(230, 255, 230) : Color.White;
                    deviceItem.Tag = d;
                    deviceListViewItem.Add(deviceItem);
                }
            }
            Invoke((MethodInvoker)delegate
            {
                DevicesListView.Items.AddRange(deviceListViewItem.ToArray());
                RefreshButton.Enabled = true;
                ResumeLayout();
            });
        }

        private async void ApplyButtonClick(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count > 0)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await newPlaybackDevice.SetAsDefaultAsync();
                await LoadAudioPlaybackDevicesList();
            }
            ApplyButton.Enabled = false;
        }

        private void ToggleApplyButton(object sender, EventArgs e)
        {
            ApplyButton.Enabled = DevicesListView.SelectedItems.Count > 0;
        }

        private async void DevicesListViewDoubleClick(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count > 0)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await Globals.AudioHandler.SetDefaultDevice(newPlaybackDevice);
                if (!isRefreshing)
                    Close();
            }
        }

        public async Task RefreshOnDeviceActivity()
        {
            if (!isRefreshing)
            {
                isRefreshing = true;
                await LoadAudioPlaybackDevicesList();
                isRefreshing = false;
            }
        }


        private async void RefreshButtonClick(object sender, EventArgs e)
        {
            await LoadAudioPlaybackDevicesList();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            if (!isRefreshing)
                Close();
        }
    }
}
