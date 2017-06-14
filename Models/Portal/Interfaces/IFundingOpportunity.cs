using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Interfaces
{
    public interface IFundingOpportunity : IRepository<FundingOpportunity>
    {
        IEnumerable<FundingOpportunity> GetActiveFundingOpportunities();

        Task<FundingOpportunity> GetActiveFundingOpportunitiesCollapsedRelationships(Guid id);
        bool FundingOpportunityExists(Guid fundingOpportunityId);

    }
}
