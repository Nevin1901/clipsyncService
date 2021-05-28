using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAppsService.Interfaces;

namespace UserAppsService.Models
{
    public class SelectedApp : ISelectedApp
    {
        [Key]
        public int Id { get; set; }

        public string AppName { get; set; }

        public SelectedApp(string appName)
        {
            AppName = appName;
        }
    }
}
