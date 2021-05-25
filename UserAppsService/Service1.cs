using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;
using UserAppsService.Models;

namespace UserAppsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.


    public class Service1 : IEnumerable, IService1
    {
        private IApp[] _apps;
        private IApp[] _syncQueuedApps;
        private int _appCount;
        private bool _sync;

        public Service1()
        {

        }

        public void SetApps(IApp[] apps)
        {
            if (apps.Length < _appCount)
            {
                _sync = true;
                _syncQueuedApps = _apps.Except(apps).ToArray();
                // I was gonna mutate the main array but then I realized that the whole part of the IS SYNCED flag is garbage
            }

            // refactored as of 24/5/2021
            _appCount = apps.Length;
            Array.Resize(ref _apps, apps.Length);
            for (int i = 0; i < apps.Length; i++)
            {
                _apps[i] = apps[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
            return _syncQueuedApps.ToList();
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
