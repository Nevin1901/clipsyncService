using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clipsyncService.Models
{
    class App : IApp
    {
        public string Title { get; set; }

        public bool SyncQueued { get; set; }

        public App(string title)
        {
            Title = title;
        }

        public bool IsOpen()
        {
            if (!(Process.GetProcessesByName(Title).FirstOrDefault() is null))
                return true;
            else
                return false;
        }

        public void Sync()
        {
            throw new NotImplementedException();
        }

    }
}
