using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Interfaces
{
    public interface IFundingOpportunity : IRepository<FundingOpportunity>
    {
        Task<FundingOpportunity> GetByNameAsync(string fundingOpportunityName);
        IEnumerable<FundingOpportunity> GetAllFundingOpportunities();
        IEnumerable<FundingOpportunity> GetActiveFundingOpportunities();
        IEnumerable<FundingOpportunity> GetAwaitingPublishedFundingOpportunities();
        IEnumerable<FundingOpportunity> GetDraftFundingOpportunities();
        IEnumerable<FundingOpportunity> GetInactiveFundingOpportunities();
        IEnumerable<FundingOpportunity> GetArchivedFundingOpportunities();
        IEnumerable<FundingOpportunity> GetAllFundingOpportunitiesByProgram(Guid programId);
        IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesByProgram(Guid programId);
        IEnumerable<FundingOpportunity> GetAwaitingPublishedFundingOpportunitiesByProgram(Guid programId);
        IEnumerable<FundingOpportunity> GetDraftFundingOpportunitiesByProgram(Guid programId);
        IEnumerable<FundingOpportunity> GetInactiveFundingOpportunitiesByProgram(Guid programId);
        IEnumerable<FundingOpportunity> GetArchivedFundingOpportunitiesByProgram(Guid programId);
        IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesCollapsedRelationships();
        Task<FundingOpportunity> GetActiveFundingOpportunityCollapsedRelationships(Guid id);
        bool FundingOpportunityExists(Guid fundingOpportunityId);

    }
}
