using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
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

        private List<string> _selectedApps;
        public UserProcess()
        {
            // get the apps from a database
        }

        public async Task<List<SelectedApp>> GetSelectedApps()
        {

            using (var context = new ClipContext())
            {
                context.SelectedClips.Add(new SelectedApp("firefox"));
                await context.SaveChangesAsync();
                List<SelectedApp> apps = await (from a in context.SelectedClips select a).ToListAsync();
                foreach (var app in apps)
                {
                    _selectedApps.Add(app.AppName);
                }
                return apps;
            }
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
