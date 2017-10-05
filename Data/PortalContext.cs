using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models.Portal;
using InternalPortal.Models.Portal.Program;
using InternalPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InternalPortal.Models
{
    public class PortalContext : DbContext
    {
        public PortalContext (DbContextOptions<PortalContext> options)
            : base(options)
        {
        }

        public PortalContext()
        {
        }

        public DbSet<InternalPortal.Models.Project> Project { get; set; }
        public DbSet<InternalPortal.Models.User> User { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

       
          

        }

  

        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunity> FundingOpportunity { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.FundingProgram> FundingProgram { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.EligibilityCriteria> EligibilityCriteria { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityEligibilityCriteria> FundingOpportunityEligibilityCriteria { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityExpectedResult> FundingOpportunityExpectedResult { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityObjective> FundingOpportunityObjective { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.EligibleClientType> EligibleClientType { get; set; }

        public DbSet<InternalPortal.Models.Portal.Account> Account { get; set; }

        public DbSet<InternalPortal.Models.Contact> Contact { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.ExpectedResult> ExpectedResult { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.Objective> Objective { get; set; }

        public DbSet<InternalPortal.Models.Portal.Program.CostCategory> CostCategory { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.EligibleCostCategory> EligibleCostCategory { get; set; }
        public DbSet<InternalPortal.Models.Portal.InternalUser> InternalUser { get; set; }
        public DbSet<InternalPortal.Models.Portal.InternalUserRole> InternalUserRole { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.FrequentlyAskedQuestion> FrequentlyAskedQuestion { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityFrequentlyAskedQuestion> FundingOpportunityFrequentlyAskedQuestion { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.Consideration> Consideration { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityConsideration> FundingOpportunityConsideration { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityResource> FundingOpportunityResource { get; set; }
        public DbSet<InternalPortal.Models.Portal.FundingProgramInternalUser> FundingProgramInternalUser { get; set; }
        public DbSet<InternalPortal.Models.Portal.Program.FundingOpportunityInternalUser> FundingOpportunityInternalUser { get; set; }
    }
}
