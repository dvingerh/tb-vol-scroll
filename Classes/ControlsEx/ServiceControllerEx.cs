using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace tb_vol_scroll.Classes.ControlsExt
{
    // By https://stackoverflow.com/a/68154774

    public class ServiceControllerExt : ServiceController
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

        public ServiceControllerExt(string ServiceName) : base(ServiceName)
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
                        catch { }
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
