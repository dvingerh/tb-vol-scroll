using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;
using tbvolscroll.Classes;

namespace tbvolscroll.Forms
{
    public partial class AudioPlaybackDevicesForm : Form
    {
        private bool didApplyDevice = false;
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
        public async Task RefeshOnDeviceActivity()
        {
            if (!didApplyDevice && !isRefreshing)
            {
                isRefreshing = true;
                Invoke((MethodInvoker)delegate
                {
                    RefreshButton.PerformClick();
                });
                await Task.Delay(100);
                isRefreshing = false;
            }
        }

        private async void OnFormShown(object sender, EventArgs e)
        {
            Point position = Cursor.Position;
            Screen screen = Screen.FromPoint(position);
            Rectangle workingArea = screen.WorkingArea;

            switch (TaskbarHelper.Position)
            {
                case TaskbarPosition.Bottom:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarPosition.Right:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarPosition.Left:
                    Location = new Point(workingArea.Left + 10, workingArea.Bottom - Height - 10);
                    break;
                case TaskbarPosition.Top:
                    Location = new Point(workingArea.Right - Width - 10, workingArea.Top + 10);
                    break;
            }
            await LoadAudioPlaybackDevicesList();
            DevicesListView.Columns[0].Width = DevicesListView.Width - 250;
        }

        private async Task LoadAudioPlaybackDevicesList()
        {
            SuspendLayout();
            await Globals.AudioHandler.RefreshPlaybackDevices();
            foreach (CoreAudioDevice d in Globals.AudioHandler.AudioDevices)
            {
                ListViewItem deviceItem = new ListViewItem()
                {
                    Text = d.FullName
                };
                deviceItem.SubItems.Add(d.IsDefaultDevice ? "Yes" : "No");
                deviceItem.SubItems.Add($"{d.Volume}%");
                deviceItem.SubItems.Add(d.IsMuted ? "Yes" : "No");
                deviceItem.BackColor = d.IsDefaultDevice ? Color.FromArgb(230, 255, 230) : Color.White;
                deviceItem.Tag = d;
                DevicesListView.Items.Add(deviceItem);
            }
            RefreshButton.Enabled = true;
            ResumeLayout();
            Refresh();
        }

        private async void ApplyButtonClick(object sender, EventArgs e)
        {
            if (DevicesListView.SelectedItems.Count > 0)
            {
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await newPlaybackDevice.SetAsDefaultAsync();
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
                didApplyDevice = true;
                CoreAudioDevice newPlaybackDevice = (CoreAudioDevice)DevicesListView.SelectedItems[0].Tag;
                await newPlaybackDevice.SetAsDefaultAsync();
                Globals.AudioPlaybackDevicesForm = null;
                Close();
            }
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
                Globals.AudioPlaybackDevicesForm = null;
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CloseFormOnDeactivate(object sender, EventArgs e)
        {
            Globals.AudioPlaybackDevicesForm = null;
            Close();
        }
    }
}
