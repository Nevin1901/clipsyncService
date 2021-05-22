using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clipsyncService
{
    public interface IApp
    {
        string Title { get; set; }

        bool SyncQueued { get; set; }

        bool IsRunning();

    }
}
