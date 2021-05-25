using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;

namespace clipsyncService.Interfaces
{
    interface IUserApps
    {
        /// <summary>
        /// Sets user applications
        /// </summary>
        /// <param name="apps"></param>
        void SetApps(IApp[] apps);

        /// <summary>
        /// Gets all user app names
        /// </summary>
        /// <returns></returns>
        List<string> GetAllAppNames();

        /// <summary>
        /// Returns a list of apps which need to be synced
        /// </summary>
        /// <returns></returns>
        List<IApp> GetSyncQueuedApps();

        /// <summary>
        /// Checks if user apps contain specific app
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        bool ContainsApp(string appName);

        /// <summary>
        /// Checks if a sync needs to be made
        /// </summary>
        /// <returns></returns>
        bool CheckSync();

        /// <summary>
        /// Syncs all apps
        /// </summary>
        /// <returns></returns>
        Task SyncApps();

    }
}
