using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace tbvolscroll.Classes
{
    public class SysPowerHandler
    {

        private static ManagementEventWatcher managementEventWatcher;

        public SysPowerHandler()
        {
            var q = new WqlEventQuery();
            var scope = new ManagementScope("root\\CIMV2");

            q.EventClassName = "Win32_PowerManagementEvent";
            managementEventWatcher = new ManagementEventWatcher(scope, q);
            managementEventWatcher.EventArrived += PowerEventArrive;
            managementEventWatcher.Start();
        }
        private static void PowerEventArrive(object sender, EventArrivedEventArgs e)
        {
            foreach (PropertyData pd in e.NewEvent.Properties)
            {
                if (pd == null || pd.Value == null) continue;
                switch (pd.Value.ToString())
                {
                    case "4":
                        Globals.InputHandler.DisableInput();
                        Globals.InputHandler.InputEvents.Dispose();
                        Globals.AudioHandler.CoreAudioController.Dispose();
                        Globals.MainForm.TrayNotifyIcon.Visible = false;
                        break;
                    case "7":
                        managementEventWatcher.Stop();
                        Globals.MainForm.RestartAppNormal(null, null);
                        break;
                }
            }
        }
    }
}
