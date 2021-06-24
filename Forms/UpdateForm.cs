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

namespace tbvolscroll.Forms
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private string exeUrl;

        private async void DoUpdateCheck(object sender, EventArgs e)
        {
            CheckingForUpdatesLabel.Text = $"Checking for updates...";
            CheckingForUpdatesLabel.Image = Properties.Resources.spinner;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36");
                var json = await wc.DownloadStringTaskAsync("https://api.github.com/repos/dvingerh/tb-vol-scroll/releases/latest");
                var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(json), new System.Xml.XmlDictionaryReaderQuotas());
                var jsonRoot = XElement.Load(jsonReader);

                float latestVersion = float.Parse(jsonRoot.XPathSelectElement("//tag_name").Value, System.Globalization.CultureInfo.InvariantCulture);
                float curVersion = float.Parse(Application.ProductVersion, System.Globalization.CultureInfo.InvariantCulture);
                if (latestVersion > curVersion)
                {
                    CheckingForUpdatesLabel.Text = $"Newer version available: {latestVersion.ToString().Replace(",", ".")}";
                    CheckingForUpdatesLabel.Image = Properties.Resources.success;
                    DownloadButton.Enabled = true;
                    XElement assetsEle = jsonRoot.XPathSelectElement("//assets[1]");
                    exeUrl = assetsEle.XPathSelectElement("//browser_download_url").Value;
                }
                else
                {
                    CheckingForUpdatesLabel.Text = $"No new updates available.";
                    CheckingForUpdatesLabel.Image = Properties.Resources.success;

                }
            }

        }

        private async void DoUpdate(object sender, EventArgs e)
        {
            DownloadButton.Enabled = false;
            DownloadButton.Text = "Retrieving file...";
            string tmpPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "tmp.exe");
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFileCompleted += new AsyncCompletedEventHandler(OnUpdateDownloaded);
                wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.90 Safari/537.36");
                await wc.DownloadFileTaskAsync(new Uri(exeUrl), tmpPath);
            }

        }

        private void OnUpdateDownloaded(object sender, AsyncCompletedEventArgs e)
        {
            string batPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "tmp.bat");
            using (var batFile = new StreamWriter(File.Create(batPath)))
            {
                batFile.WriteLine("@ECHO OFF");
                batFile.WriteLine("TIMEOUT /t 1 /nobreak");
                batFile.WriteLine("TASKKILL /F /IM {0}", Path.GetFileName(Assembly.GetExecutingAssembly().Location));
                batFile.WriteLine("TIMEOUT /t 1 /nobreak");
                batFile.WriteLine("DEL {0}", Path.GetFileName(Assembly.GetExecutingAssembly().Location));
                batFile.WriteLine("REN {0} {1}", "tmp.exe", "tb-vol-scroll.exe");
                batFile.WriteLine("DEL \"%~f0\" & START /B \"\" \"{0}\" update-done & PAUSE", "tb-vol-scroll.exe");
            }

            ProcessStartInfo startInfo = new ProcessStartInfo(batPath);
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = Path.GetDirectoryName(batPath);
            Process.Start(startInfo);
        }
    }
}
