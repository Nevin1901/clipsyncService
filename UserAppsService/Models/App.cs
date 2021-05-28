using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;

namespace UserAppsService.Models
{
    /// <summary>
    /// Any Open App
    /// </summary>
    public class App : IApp
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string ProcessName { get; set; }

        public bool SyncQueued { get; set; }

        public App(string title)
        {
            Title = title;
        }

        public App(string title, string processName)
        {
            Title = title;
            ProcessName = processName;
        }

        public bool IsRunning()
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
