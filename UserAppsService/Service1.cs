using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;
using UserAppsService.Models;

namespace UserAppsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.


    public class UserProcess : IUserProcess
    {

        private readonly List<string> _selectedApps;
        public UserProcess(List<string> selectedApps)
        {
            _selectedApps = new List<string>(selectedApps);
            using (var context = new ClipContext())
            {
            }
            // get the apps from a database
        }

        public void AddSelectedApps(string appName)
        {
            // add the apps to a local sqlite database
        }

        public void RemoveSelectedApps(string appName)
        {
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
