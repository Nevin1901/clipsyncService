using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAppsService.Models
{
    class ClipContext : DbContext
    {
        public DbSet<App> Apps { get; set; }

        public DbSet<string> SelectedClips { get; set; }

        public ClipContext() : base("PrivateUserDatabase")
        {

        }
    }
}
