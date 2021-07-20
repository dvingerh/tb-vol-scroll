using System;
using System.Diagnostics;
using System.Windows.Forms;
using tbvolscroll.Classes;

namespace tbvolscroll.Forms
{
    public partial class CheckForUpdatesForm : Form
    {
        private readonly UpdateHandler updateHandler;
        public CheckForUpdatesForm()
        {
            InitializeComponent();
            updateHandler = new UpdateHandler(this);
        }

        public bool isUpdating = false;

        private async void DoUpdateCheck(object sender, EventArgs e)
        {
            Application.DoEvents();
            if (!isUpdating)
            {
                CheckingForUpdatesLabel.Text = $"Checking for updates...";
                CheckingForUpdatesLabel.Image = Properties.Resources.spinner;
                await updateHandler.CheckForUpdates();
            }
        }

        private async void StartUpdateDownload(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            CheckingForUpdatesLabel.Text = $"Retrieving file...";
            CheckingForUpdatesLabel.Image = Properties.Resources.spinner;
            isUpdating = true;
            await updateHandler.DownloadUpdate();

        }

        private void DontCloseOnUpdate(object sender, FormClosingEventArgs e)
        {
            if (isUpdating)
                e.Cancel = true;
        }

        private void ViewReleasesLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(updateHandler.RepoUrl);
        }

        private void CloseFormOnDeacivate(object sender, EventArgs e)
        {
            if (!isUpdating)
                Close();
        }
    }
}
