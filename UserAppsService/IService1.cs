using System;
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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IUserProcess
    {
        [OperationContract]
        List<IApp> GetRunningApps();

        [OperationContract]
        void AddSelectedApps(string appName);

        [OperationContract]
        void RemoveSelectedApps(string appName);

        [OperationContract]
        Task<List<SelectedApp>> GetSelectedApps();

    }
}
