using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clipsyncService.Interfaces;

namespace clipsyncService.Models
{
    class UserProcess : IUserProcess
    {
        private readonly List<string> _selectedApps;
        public UserProcess(List<string> selectedApps)
        {
            _selectedApps = new List<string>(selectedApps);
        }
        public List<IApp> GetRunningApps()
        {
            List<IApp> apps = new List<IApp>();
            foreach (string app in _selectedApps)
            {
                if (!(Process.GetProcessesByName(app).FirstOrDefault() is null))
                {
                    apps.Add(new App(app));
                }
            }

            return apps;
        }
    }
}
