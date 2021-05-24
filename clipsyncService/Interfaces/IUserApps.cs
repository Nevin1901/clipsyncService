using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clipsyncService.Interfaces
{
    interface IUserApps
    {
        void SetApps(IApp[] apps);

        List<string> GetAllAppNames();

        List<IApp> GetSyncQueuedApps();

        bool ContainsApp(string appName);

        bool CheckSync();

        Task SyncApps();

    }
}
