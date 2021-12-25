using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tbvolscroll.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.ServiceProcess; // not referenced by default

    public class AudioSrvPoller : ServiceController
    {
        public event EventHandler<ServiceStatusEventArgs> StatusChanged;
        private readonly Dictionary<ServiceControllerStatus, Task> _tasks = new Dictionary<ServiceControllerStatus, Task>();

        new public ServiceControllerStatus Status
        {
            get
            {
                base.Refresh();
                return base.Status;
            }
        }

        public AudioSrvPoller(string ServiceName) : base(ServiceName)
        {
            foreach (ServiceControllerStatus status in Enum.GetValues(typeof(ServiceControllerStatus)))
            {
                _tasks.Add(status, null);
            }
            StartListening();
        }

        private void StartListening()
        {
            foreach (ServiceControllerStatus status in Enum.GetValues(typeof(ServiceControllerStatus)))
            {
                if (this.Status != status && (_tasks[status] == null || _tasks[status].IsCompleted))
                {
                    _tasks[status] = Task.Run(() =>
                    {
                        try
                        {
                            base.WaitForStatus(status);
                            OnStatusChanged(new ServiceStatusEventArgs(status));
                            StartListening();
                        }
                        catch
                        {
                            // You can either raise another event here with the exception or ignore it since it most likely means the service was uninstalled/lost communication
                        }
                    });
                }
            }
        }

        protected virtual void OnStatusChanged(ServiceStatusEventArgs e)
        {
            EventHandler<ServiceStatusEventArgs> handler = StatusChanged;
            handler?.Invoke(this, e);
        }
    }

    public class ServiceStatusEventArgs : EventArgs
    {
        public ServiceControllerStatus Status { get; private set; }
        public ServiceStatusEventArgs(ServiceControllerStatus Status)
        {
            this.Status = Status;
        }
    }
}
