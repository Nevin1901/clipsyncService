using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clipsyncService.UserApps;

namespace clipsyncService.Models
{
    public class UserApps : IEnumerable
    {
        private IApp[] _apps;

        public UserApps(IApp[] apps)
        {
            _apps = new IApp[apps.Length];
            for (int i = 0; i < apps.Length; i++)
            {
                _apps[i] = apps[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator) GetEnumerator();
        }

        public UserAppsEnum GetEnumerator()
        {
            return new UserAppsEnum(_apps);
        }

        public List<string> GetAllAppNames()
        {
            List<string> appNames = new List<string>();
            foreach (var app in _apps)
            {
                appNames = appNames.Append(app.Title).ToList();
            }

            return appNames;
        }

        public bool ContainsApp(string appName)
        {
            foreach (var app in _apps)
            {
                if (app.Title == appName)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
