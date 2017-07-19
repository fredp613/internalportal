using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Interfaces
{
    public interface IFundingOpportunity : IRepository<FundingOpportunity>
    {
        IEnumerable<FundingOpportunity> GetActiveFundingOpportunities();
        IEnumerable<FundingOpportunity> GetAwaitingPublishedFundingOpportunities();
        IEnumerable<FundingOpportunity> GetDraftFundingOpportunities();
        IEnumerable<FundingOpportunity> GetInactiveFundingOpportunities();
        IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesCollapsedRelationships();
        Task<FundingOpportunity> GetActiveFundingOpportunityCollapsedRelationships(Guid id);
        bool FundingOpportunityExists(Guid fundingOpportunityId);

    }
}
