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
using Microsoft.Win32.SafeHandles;

namespace clipsyncService
{
    public partial class ClipSyncService : ServiceBase
    {
        public List<string> userProcesses = new List<string>();
        public List<string> gameProcesses = new List<string>()
        {
            "chrome", "firefox"
        };
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
        }

        protected override void OnStart(string[] args)
        {
            eventLog1.WriteEntry("Service Started");
            Timer timer = new Timer
            {
                Interval = 10000
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
            string allUserProcesses = "";
            foreach (string item in gameProcesses)
            {
                Process[] currentProcess = Process.GetProcessesByName(item);
                if (!(currentProcess.FirstOrDefault() is null))
                {
                    if (!userProcesses.Contains(currentProcess.FirstOrDefault()?.ProcessName))
                    {
                        userProcesses = userProcesses.Append(currentProcess.FirstOrDefault()?.ProcessName).ToList();
                    }
                }
                else
                {
                    if (userProcesses.Contains(item))
                    {
                        userProcesses.Remove(item);
                    }
                }
            }

            foreach (string userProcess in userProcesses)
            {
                allUserProcesses += $"{userProcess} ";
            }
            eventLog1.WriteEntry(allUserProcesses);
        }
    }
}