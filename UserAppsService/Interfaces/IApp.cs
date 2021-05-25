using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace UserAppsService.Interfaces
{
    [ServiceContract]
    public interface IApp
    {
        string Title { get; set; }

        string ProcessName { get; set; }

    // remember to add a process field name

        [OperationContract]
        bool IsRunning();

    }
}
