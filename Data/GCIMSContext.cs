using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InternalPortal.Models
{
    public class GcimsContext : DbContext
    {
        public GcimsContext (DbContextOptions<GcimsContext> options)
            : base(options)
        {
        }

        public DbSet<tblProjects> tblProjects { get; set; }
        public DbSet<tblApplications> tblApplications { get; set; }
        public DbSet<tblContacts> tblContacts { get; set; }
        public DbSet<tblAddresses> tblAddresses { get; set; }
        public DbSet<tblClients> tblClients { get; set; }
        public DbSet<luCommitmentItems> luCommitmentItems { get; set; }
        public DbSet<luExpenseCategories> luExpenseCategories { get; set; }
    }
}
