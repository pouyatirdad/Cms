using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MYCmsContext : DbContext
    {
        public DbSet<PageGroup> pageGroups { get; set; }
        public DbSet<Page> pages { get; set; }
        public DbSet<PageComment> pageComments { get; set; }
        public DbSet<Login> logins { get; set; }

    }
}
