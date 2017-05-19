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

            modelBuilder.Entity<Account>()
               .HasOne(p => p.PrimaryAddress)
               .WithMany()
               .HasForeignKey(b => b.PrimaryAddressId);

            modelBuilder.Entity<Account>()
                .HasOne(p => p.PaymentAddress)
                .WithMany()
                .HasForeignKey(b => b.PaymentAddressId);
        }
    }
}
