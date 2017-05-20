using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InternalPortal.Models
{
    public class PortalContext : DbContext
    {
        public PortalContext (DbContextOptions<PortalContext> options)
            : base(options)
        {
        }
        public DbSet<InternalPortal.Models.Project> Project { get; set; }
        public DbSet<InternalPortal.Models.User> User { get; set; }
        public DbSet<InternalPortal.Models.User> InternalUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(p => p.CreatedBy)
                .WithMany()
                .HasForeignKey(b => b.CreatedByUserId);
            modelBuilder.Entity<User>()
                .HasOne(p => p.UpdatedBy)
                .WithMany()
                .HasForeignKey(b => b.UpdatedByUserId);

            modelBuilder.Entity<InternalUser>()
               .HasOne(p => p.CreatedBy)
               .WithMany()
               .HasForeignKey(b => b.CreatedByInternalUserId);
            modelBuilder.Entity<InternalUser>()
                .HasOne(p => p.UpdatedBy)
                .WithMany()
                .HasForeignKey(b => b.UpdatedByInternalUserId);

            
        }
    }
}
