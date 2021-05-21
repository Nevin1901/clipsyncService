using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace clipsyncService
{
    public partial class ClipSyncService : ServiceBase
    {
        public int pendingSync = 0;
        public bool sync = false;
        public List<string> gameProcesses = new List<string>()
        {
            "chrome", "firefox"
        };

        UserProcess userProcess = new UserProcess();
        public ClipSyncService()
        {
            InitializeComponent();
            this.eventLog1 = new EventLog();
            if (!EventLog.SourceExists("ClipSyncSource"))
            {
                EventLog.CreateEventSource("ClipSyncSource", "ClipSyncLog");
            }

            eventLog1.Source = "ClipSyncSource";
            eventLog1.Log = "ClipSyncLog";
            userProcess.SetGameList(gameProcesses);
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Service Started");
            Timer timer = new Timer
            {
                Interval = 2000
            };
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();
        }

        protected override void OnStop()
        {
            eventLog1.WriteEntry("Service Stopped");
        }

        public void OnTimer (object sender, ElapsedEventArgs args) // refactor this garbage please
        {
            if (sync == true)
            {
                // sync clips
                sync = false;
            }
            List<IApp> allUserProcesses = UserProcess.GetActiveProcesses();
            if (pendingSync < allUserProcesses.Count)
            {
                sync = true;
            }
            pendingSync = allUserProcesses.Count;
            eventLog1.WriteEntry(allUserProcesses.Count.ToString());
        }
    }
}