using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using tbvolscroll.Classes;

namespace tbvolscroll.Forms
{
    public partial class UpdateForm : Form
    {
        private UpdateHandler updateHandler;
        public UpdateForm()
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
    }
}
