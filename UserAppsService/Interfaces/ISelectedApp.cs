using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAppsService.Interfaces
{
    public interface ISelectedApp
    {
        int Id { get; set; }
        string AppName { get; set; }
    }
}
