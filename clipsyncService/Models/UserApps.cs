using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clipsyncService.Interfaces;

namespace clipsyncService.Models
{
    public class UserApps : IEnumerable
    {
        private IApp[] _apps;
        private int appCount = 0;
        private bool _sync = false;

        public UserApps()
        {

        }

        public void SetApps(IApp[] apps)
        {
            if (apps.Length < appCount) _sync = true;
            appCount = apps.Length;
            Array.Resize(ref _apps, apps.Length);
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
                appNames.Add(app.Title);
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

        public bool CheckSync()
        {
            return _sync;
        }

        public async Task SyncApps()
        {
            // sync apps
        }

    }
}
