using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using clipsyncService.Models;

namespace clipsyncService
{
    public partial class ClipSyncService : ServiceBase
    {
        public List<string> gameProcesses = new List<string>()
        {
            "chrome", "firefox"
        };

        private UserProcess _userProcess;
        private IApp[] _currentApps;
        private UserApps _userApps;
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
            _userProcess = new UserProcess(gameProcesses);
            _userApps = new UserApps();
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

        public async void OnTimer (object sender, ElapsedEventArgs args) // refactored as of 22/5/2021
        {
            string output = "";
            _currentApps = _userProcess.GetRunningApps().ToArray();
            _userApps.SetApps(_currentApps);
            if (_userApps.CheckSync()) // kind of shit code because it relies on the SyncApps function being called in order for it to not constantly sync, but it works for now
            {                          // because the sync bool not being disabled on the CheckSync function
                List<IApp> syncedApps = _userApps.GetSyncQueuedApps();
                foreach (IApp app in syncedApps)
                {
                    output += $"{app.Title} ";
                }
                await _userApps.SyncApps();
            }
            else
                output = "no";
            eventLog1.WriteEntry(output);
        }
    }
}