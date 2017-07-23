using InternalPortal.Models.Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models.Helpers;
using System.Reflection;
using InternalPortal.Models.Portal.Program;

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
            var fos = PortalContext.FundingOpportunity.Where(f => f.ActivationStartDate <= DateTime.Now.Date && f.Status == FOStatus.Published)
                                   .Include(o => o.FundingOpportunityObjectives)
                                           .ThenInclude(fo => fo.Objective)
                                   .Include(foer => foer.FundingOpportunityExpectedResults)
                                            .ThenInclude(er => er.ExpectedResult)
                                   .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                            .ThenInclude(ec => ec.EligibilityCriteria)
                                   .Include(fas => fas.EligibleClientTypes)
                                   .Include(c => c.EligibleCostCategories)
                                            .ThenInclude(cc => cc.CostCategory)
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
                foreach (var y in x.EligibleCostCategories)
                {
                    y.CostCategory.Lang = _Language;
                    y.Lang = _Language;
                }
                foreach (var y in x.EligibleClientTypes)
                {
                    y.Lang = _Language;
                }
            }

            return fos;
        }

        public IEnumerable<FundingOpportunity> GetAwaitingPublishedFundingOpportunities()
        {
            var fos = PortalContext.FundingOpportunity.Where(f => f.ActivationStartDate >= DateTime.Now.Date && f.Status == FOStatus.Published)
                                   .Include(o => o.FundingOpportunityObjectives)
                                           .ThenInclude(fo => fo.Objective)
                                   .Include(foer => foer.FundingOpportunityExpectedResults)
                                            .ThenInclude(er => er.ExpectedResult)
                                   .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                            .ThenInclude(ec => ec.EligibilityCriteria)
                                   .Include(fas => fas.EligibleClientTypes)
                                   .Include(c => c.EligibleCostCategories)
                                            .ThenInclude(cc => cc.CostCategory)
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
                foreach (var y in x.EligibleCostCategories)
                {
                    y.CostCategory.Lang = _Language;
                    y.Lang = _Language;
                }
                foreach (var y in x.EligibleClientTypes)
                {
                    y.Lang = _Language;
                }
            }

            return fos;
        }

        public IEnumerable<FundingOpportunity> GetDraftFundingOpportunities()
        {
            var fos = PortalContext.FundingOpportunity.Where(f => f.Status == FOStatus.Draft)
                                   .Include(o => o.FundingOpportunityObjectives)
                                           .ThenInclude(fo => fo.Objective)
                                   .Include(foer => foer.FundingOpportunityExpectedResults)
                                            .ThenInclude(er => er.ExpectedResult)
                                   .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                            .ThenInclude(ec => ec.EligibilityCriteria)
                                   .Include(fas => fas.EligibleClientTypes)
                                   .Include(c => c.EligibleCostCategories)
                                            .ThenInclude(cc => cc.CostCategory)
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
                foreach (var y in x.EligibleCostCategories)
                {
                    y.CostCategory.Lang = _Language;
                    y.Lang = _Language;
                }
                foreach (var y in x.EligibleClientTypes)
                {
                    y.Lang = _Language;
                }
            }

            return fos;
        }

        public IEnumerable<FundingOpportunity> GetInactiveFundingOpportunities()
        {
            var fos = PortalContext.FundingOpportunity.Where(f => f.ActivationEndDate < DateTime.Now.Date && f.Status == FOStatus.Published || (f.Status == FOStatus.Closed))
                                   .Include(o => o.FundingOpportunityObjectives)
                                           .ThenInclude(fo => fo.Objective)
                                   .Include(foer => foer.FundingOpportunityExpectedResults)
                                            .ThenInclude(er => er.ExpectedResult)
                                   .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                            .ThenInclude(ec => ec.EligibilityCriteria)
                                   .Include(fas => fas.EligibleClientTypes)
                                   .Include(c => c.EligibleCostCategories)
                                            .ThenInclude(cc => cc.CostCategory)
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
                foreach (var y in x.EligibleCostCategories)
                {
                    y.CostCategory.Lang = _Language;
                    y.Lang = _Language;
                }
                foreach (var y in x.EligibleClientTypes)
                {
                    y.Lang = _Language;
                }
            }

            return fos;
        }

        public IEnumerable<FundingOpportunity> GetArchivedFundingOpportunities()
        {
            var fos = PortalContext.FundingOpportunity.Where(x => x.ActivationEndDate <= DateTime.Now || (x.Status == FOStatus.Archived))
                                   .Include(o => o.FundingOpportunityObjectives)
                                           .ThenInclude(fo => fo.Objective)
                                   .Include(foer => foer.FundingOpportunityExpectedResults)
                                            .ThenInclude(er => er.ExpectedResult)
                                   .Include(foec => foec.FundingOpportunityEligibilityCriterias)
                                            .ThenInclude(ec => ec.EligibilityCriteria)
                                   .Include(fas => fas.EligibleClientTypes)
                                   .Include(c => c.EligibleCostCategories)
                                            .ThenInclude(cc => cc.CostCategory)
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
                foreach (var y in x.EligibleCostCategories)
                {
                    y.CostCategory.Lang = _Language;
                    y.Lang = _Language;
                }
                foreach (var y in x.EligibleClientTypes)
                {
                    y.Lang = _Language;
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
               .Include(c => c.EligibleCostCategories)
               .SingleOrDefaultAsync(i => i.FundingOpportunityId == id);

            entity.Lang = _Language;
            foreach (var x in entity.FundingOpportunityEligibilityCriterias)
            {
                x.EligibilityCriteria.Lang = _Language;
                entity.EligibilityCriterias += x.EligibilityCriteria.Description + "\n \n";
            }
            foreach (var x in entity.FundingOpportunityExpectedResults)
            {
                x.ExpectedResult.Lang = _Language;
                entity.ExpectedResults += x.ExpectedResult.Description + "\n \n";
            }
            foreach (var x in entity.FundingOpportunityObjectives)
            {
                x.Objective.Lang = _Language;
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
                                  .Include(c => c.EligibleCostCategories)
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
