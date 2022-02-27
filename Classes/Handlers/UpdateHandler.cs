using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace tb_vol_scroll.Classes.Handlers
{
    public static class UpdateHandler
    {
        private readonly static string releasesApiUrl = "https://api.github.com/repos/dvingerh/tb-vol-scroll/releases";
        private readonly static string tmpBatPath = Path.Combine(Path.GetTempPath(), "tmp.bat");
        private readonly static string tmpExePath = Path.Combine(Path.GetTempPath(), "tmp.exe");
        private readonly static string selfExe = Assembly.GetExecutingAssembly().Location;
        private static WebClient dlClient;
        private static string exeUrl;
        private static string curVersion;
        private static string latestVersion;
        private static bool isPrerelease = false;

        public static bool IsPrerelease { get => isPrerelease; set => isPrerelease = value; }
        public static WebClient DlClient { get => dlClient; set => dlClient = value; }

        public static async Task<(bool, string)> CheckForUpdates()
        {
            try
            {
                dlClient = new WebClient() { Headers = { "user-agent: okhttp" } };
                var json = await dlClient.DownloadStringTaskAsync(releasesApiUrl);
                var jsonReader = JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(json), new System.Xml.XmlDictionaryReaderQuotas());
                var jsonRoot = XElement.Load(jsonReader);

                latestVersion = jsonRoot.XPathSelectElement("//tag_name").Value;
                curVersion = Application.ProductVersion;
                isPrerelease = Convert.ToBoolean(jsonRoot.XPathSelectElement("//prerelease").Value);
                if (string.Compare(latestVersion, curVersion) != 0)
                {
                    XElement assetsEle = jsonRoot.XPathSelectElement("//assets[1]");
                    exeUrl = assetsEle.XPathSelectElement("//browser_download_url").Value;
                    return (true, latestVersion);
                }
                else
                {
                    return (true, null);
                }
            }
            catch (Exception ex)
            {
                return (false, ex.ToString());
            }
        }

        public static async Task DownloadUpdate()
        {
            await dlClient.DownloadFileTaskAsync(new Uri(exeUrl), tmpExePath);
        }

        public static void UpdateExecutable()
        {
            string updateCmdStr = Properties.Resources.UpdateCmd;
            updateCmdStr = updateCmdStr.Replace("[SELFEXE]", Path.GetFileName(selfExe));
            updateCmdStr = updateCmdStr.Replace("[SELF]", selfExe);
            updateCmdStr = updateCmdStr.Replace("[TEMP]", tmpExePath);
            File.WriteAllText(tmpBatPath, updateCmdStr);

            ProcessStartInfo startInfo = new ProcessStartInfo(tmpBatPath)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(tmpBatPath)
            };
            Globals.MainForm.TrayNotifyIcon.Visible = false;
            Globals.MainForm.TrayNotifyIcon.Dispose();
            Process.Start(startInfo);
        }

    }
}
