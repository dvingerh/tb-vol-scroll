using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using tb_vol_scroll.Classes.ControlsEx;
using tb_vol_scroll.Classes.Handlers;

namespace tb_vol_scroll.Forms
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
            new FormShadowEx().ApplyShadows(this);
            CurrentVersionValueLabel.Text = Application.ProductVersion;
        }

        private async void UpdateForm_Shown(object sender, System.EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.FixedDialog;
            await CheckForUpdates();

        }

        private void UpdateForm_Deactivate(object sender, System.EventArgs e)
        {
            Close();
        }

        private async Task CheckForUpdates()
        {
            DownloadButton.Enabled = false;
            DownloadButton.Text = "Checking for updates...";

            var result = await UpdateHandler.CheckForUpdates();
            switch (result.Item1)
            {
                case true:
                    if (result.Item2 != null)
                    {
                        LatestVersionValueLabel.Text = $"{result.Item2.ToString().Replace(",", ".")}";
                        LatestVersionValueLabel.Image = Properties.Resources.exclamation;
                        LatestVersionValueLabel.ImageAlign = ContentAlignment.MiddleRight;
                        DownloadButton.Enabled = true;
                        DownloadButton.Text = "Download && Install";
                    }
                    else
                    {
                        LatestVersionValueLabel.Text = CurrentVersionValueLabel.Text;
                        LatestVersionValueLabel.Image = Properties.Resources.success;
                        LatestVersionValueLabel.ImageAlign = ContentAlignment.MiddleRight;
                        DownloadButton.Text = "No update available";

                    }
                    break;
                case false:
                    DownloadButton.Text = "Checking for updates failed";
                    LatestVersionValueLabel.Image = Properties.Resources.error;
                    LatestVersionValueLabel.ImageAlign = ContentAlignment.MiddleRight;
                    break;
                default:
                    break;
            }
        }

        private async void DownloadButton_Click(object sender, System.EventArgs e)
        {
            bool doDownload = true;
            if (UpdateHandler.IsPrerelease)
                doDownload = MessageBox.Show("This version is a pre-release. Do you still want to install it?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

            if (doDownload)
            {
                DownloadButton.Enabled = false;
                DownloadButton.Text = "Retrieving file...";
                UpdateHandler.DlClient.DownloadProgressChanged += UpdateDownloadProgress;
                UpdateHandler.DlClient.DownloadFileCompleted += OnUpdateDownloaded;
                await UpdateHandler.DownloadUpdate();
            }
        }

        private void UpdateDownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            DownloadButton.Text = $"Retrieving file... {e.ProgressPercentage}%";
        }

        private void OnUpdateDownloaded(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                DownloadButton.Text = "Error retrieving file.";
                return;
            }
            else
                UpdateHandler.UpdateExecutable();
        }

        private void ViewReleasesLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/dvingerh/tb-vol-scroll/releases");
        }
    }
}