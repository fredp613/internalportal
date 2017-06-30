using InternalPortal.Models.Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InternalPortal.Models.Portal;
using InternalPortal.Models;

namespace InternalPortal.Models.Portal.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly PortalContext _context;
   
        public IProjectRepository Projects { get; private set; }
        public IFundingOpportunity FundingOpportunities { get; private set; }
        public IEligibleClientType EligibleClientTypes { get; private set; }
        public string Language { get; set; }

        public UnitOfWork(PortalContext context, string language)
        {
            _context = context;
            Language = language;
            Projects = new ProjectRepository(_context, language);
            FundingOpportunities = new FundingOpportunityRepository(_context, language);
            EligibleClientTypes = new EligibleClientTypeRepository(_context, language);

        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
