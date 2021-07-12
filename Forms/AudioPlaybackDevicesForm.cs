using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using AudioSwitcher.AudioApi;
using AudioSwitcher.AudioApi.CoreAudio;
using AudioSwitcher.AudioApi.Observables;

namespace tbvolscroll.Forms
{
    public partial class AudioPlaybackDevicesForm : Form
    {
        private readonly MainForm callbackForm;
        private bool didApplyDevice = false;
        public AudioPlaybackDevicesForm(MainForm callbackForm)
        {
            InitializeComponent();
            ImageList listViewHeightFix = new ImageList
            {
                ImageSize = new Size(1, 30)
            };
            DevicesListView.SmallImageList = listViewHeightFix;
            this.callbackForm = callbackForm;
            callbackForm.audioHandler.CoreAudioController.AudioDeviceChanged.Subscribe(OnDeviceChanged);
        }
        public void OnDeviceChanged(DeviceChangedArgs value)
        {
            if (!didApplyDevice)
            {
                Invoke((MethodInvoker)delegate
                {
                    RefreshButton.PerformClick();
                });
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
            await LoadAudioPlaybackDevicesList();
        }

        private async Task LoadAudioPlaybackDevicesList()
        {
            await callbackForm.audioHandler.RefreshPlaybackDevices();
            foreach (CoreAudioDevice d in callbackForm.audioHandler.AudioDevices)
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
                Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void CloseFormOnDeactivate(object sender, EventArgs e)
        {
            //Close();
        }
    }
}
