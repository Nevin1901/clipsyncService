using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAppsService.Interfaces
{
    public interface IApp
    {
        string Title { get; set; }

        // remember to add a process field name

        bool IsRunning();

    }
}
