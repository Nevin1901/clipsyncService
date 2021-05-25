using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;

namespace UserAppsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        /// <summary>
        /// Sets user applications
        /// </summary>
        /// <param name="apps"></param>
        [OperationContract]
        void SetApps(IApp[] apps);

        /// <summary>
        /// Gets all user app names
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<string> GetAllAppNames();

        /// <summary>
        /// Returns a list of apps which need to be synced
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<IApp> GetSyncQueuedApps();

        /// <summary>
        /// Checks if user apps contain specific app
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        [OperationContract]
        bool ContainsApp(string appName);

        /// <summary>
        /// Checks if a sync needs to be made
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        bool CheckSync();

        /// <summary>
        /// Syncs all apps
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        Task SyncApps();
    }
}
