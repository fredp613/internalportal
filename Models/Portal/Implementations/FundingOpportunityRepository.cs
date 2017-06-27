using InternalPortal.Models.Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models.Helpers;
using System.Reflection;

namespace InternalPortal.Models.Portal.Implementations
{
    public class FundingOpportunityRepository : Repository<FundingOpportunity>, IFundingOpportunity
    {
        public PortalContext PortalContext
        {
            get { return Context as PortalContext; }
        }
        private string _Language;
        public FundingOpportunityRepository(PortalContext context, string language) : base(context, language)
        {
            _Language = language;
        }
        

        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunities()
        {
            var fos = PortalContext.FundingOpportunity.Where(f => f.ActivationStartDate <= DateTime.Now.Date)
                                   .Include(o => o.FundingOpportunityObjectives)
                                           .ThenInclude(fo => fo.Objective)
                                   .Include(foer => foer.FundingOpportunityExpectedResults)
                                            .ThenInclude(er => er.ExpectedResult)
                                   .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                            .ThenInclude(ec => ec.EligibilityCriteria)
                                   .Include(fas => fas.EligibleClientTypes)
                                   .ToList();

            foreach (var x in fos)
            {
                x.Lang = _Language;
                foreach (var y in x.FundingOpportunityEligibilityCriterias)
                {
                    y.EligibilityCriteria.Lang = _Language;
                }
                foreach (var y in x.FundingOpportunityExpectedResults)
                {
                    y.ExpectedResult.Lang = _Language;
                }
                foreach (var y in x.FundingOpportunityObjectives)
                {
                    y.Objective.Lang = _Language;
                }
            }

            return fos;
        }

      

        public bool FundingOpportunityExists(Guid fundingOpportunityId)
        {
            return PortalContext.FundingOpportunity.Any(fo => fo.FundingOpportunityId == fundingOpportunityId);
        }

        public async override Task<FundingOpportunity> GetAsync(Guid id)
        {
            var entity = await PortalContext.Set<FundingOpportunity>()
                .Include(o => o.FundingOpportunityObjectives)
                         .ThenInclude(fo => fo.Objective)
                .Include(foer => foer.FundingOpportunityExpectedResults)
                        .ThenInclude(er => er.ExpectedResult)
                .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                        .ThenInclude(ec => ec.EligibilityCriteria)
                .Include(fas => fas.EligibleClientTypes)
                .SingleOrDefaultAsync(i=>i.FundingOpportunityId == id);


            if (entity != null)
            {
                GetProperty.TrySetProperty(entity, "Lang", _Language);
            }
            return entity;

        }

        public async Task<FundingOpportunity> GetActiveFundingOpportunityCollapsedRelationships(Guid id)
        {
            var entity = await PortalContext.Set<FundingOpportunity>()
               .Include(o => o.FundingOpportunityObjectives)
                        .ThenInclude(fo => fo.Objective)
               .Include(foer => foer.FundingOpportunityExpectedResults)
                       .ThenInclude(er => er.ExpectedResult)
               .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                       .ThenInclude(ec => ec.EligibilityCriteria)
               .Include(fas => fas.EligibleClientTypes)
               .SingleOrDefaultAsync(i => i.FundingOpportunityId == id);

            foreach (var x in entity.FundingOpportunityEligibilityCriterias)
            {
                entity.EligibilityCriterias += x.EligibilityCriteria.Description + "\n \n";
            }
            foreach (var x in entity.FundingOpportunityExpectedResults)
            {
                entity.ExpectedResults += x.ExpectedResult.Description + "\n \n";
            }
            foreach (var x in entity.FundingOpportunityObjectives)
            {
                entity.Objectives += x.Objective.Description + "\n \n";
            }

            return entity;

        }

        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesCollapsedRelationships()
        {

            var fos = PortalContext.FundingOpportunity.Where(f => f.ActivationStartDate <= DateTime.Now.Date)
                                  .Include(o => o.FundingOpportunityObjectives)
                                          .ThenInclude(fo => fo.Objective)
                                  .Include(foer => foer.FundingOpportunityExpectedResults)
                                           .ThenInclude(er => er.ExpectedResult)
                                  .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                           .ThenInclude(ec => ec.EligibilityCriteria)
                                  .Include(fas => fas.EligibleClientTypes)
                                  .ToList();

            foreach (var x in fos)
            {
                x.Lang = _Language;
                foreach (var y in x.FundingOpportunityEligibilityCriterias)
                {
                    y.EligibilityCriteria.Lang = _Language;
                    x.EligibilityCriterias += y.EligibilityCriteria.Description + "\n \n";
                }
                foreach (var y in x.FundingOpportunityExpectedResults)
                {
                    y.ExpectedResult.Lang = _Language;
                    x.ExpectedResults += y.ExpectedResult.Description + "\n \n";
                }
                foreach (var y in x.FundingOpportunityObjectives)
                {
                    y.Objective.Lang = _Language;
                    x.Objectives += y.Objective.Description + "\n \n";
                }
            }

            return fos;
           
        }
    }
}
