using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using clipsyncService.Interfaces;

namespace clipsyncService.Models
{
    public class UserApps : IEnumerable, IUserApps
    {
        private IApp[] _apps;
        private int _appCount = 0;
        private bool _sync = false;

        public UserApps()
        {

        }

        public void SetApps(IApp[] apps)
        {
            if (apps.Length < _appCount)
            {
                foreach (IApp app in apps)
                {
                    if (!ContainsApp(app.Title))
                    {
                        app.SyncQueued = true;
                    }
                }
                _sync = true;
            }
            // refactor this to be able to tell which app needs to be synced
            _appCount = apps.Length;
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

        public List<IApp> GetSyncQueuedApps()
        {
            List<IApp> syncQueuedApps = new List<IApp>();
            foreach (IApp app in _apps)
            {
                if (app.SyncQueued) syncQueuedApps.Add(app);
            }

            return syncQueuedApps;
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
            _sync = false;
        }

    }
}
