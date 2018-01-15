using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal;
using System.Diagnostics;
using InternalPortal.Models.Portal.Program;
using InternalPortal.Models.Portal.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/{lang}/FundingOpportunities")]
    public class FundingOpportunitiesController : Controller
    {
        private readonly PortalContext _context;
        private UnitOfWork _unitOfWork;

     
        public FundingOpportunitiesController(PortalContext context)
        {
            _context = context;
           
            
            _unitOfWork = new UnitOfWork(_context, "FR");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var currentLang = RouteData.Values["lang"].ToString();
            _unitOfWork = new UnitOfWork(_context, currentLang);
            base.OnActionExecuting(context);

        }
      

        [HttpGet("GetByNameAsync/{title}")]
        public Task<FundingOpportunity> GetByNameAsync([FromRoute] string title)
        {
            return _unitOfWork.FundingOpportunities.GetByNameAsync(title);
        }

        // GET: api/FundingOpportunities
        [HttpGet]
        public IEnumerable<FundingOpportunity> GetFundingOpportunity()
        {
            var Lang = RouteData.Values["lang"].ToString();
           
            return _unitOfWork.FundingOpportunities.GetAll();
        }

        // GET: api/FundingOpportunities
        [HttpGet("CanBeDestroyed/{id}")]
        public bool CanBeDestroyed([FromRoute] Guid id)
        {
            var projects = _context.Project.Where(f => f.FundingOpportunityID == id); 

            if (projects.Count() > 0)
            {
                return false;
            }

            return true;
        }

        [HttpGet]
        [Route("GetAllFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetAllFundingOpportunities()
        {
            return _unitOfWork.FundingOpportunities.GetAllFundingOpportunities();
        }

        [HttpGet]
        [Route("GetUnmappedFundingOpportunities/{internaluserid}")]
        public IEnumerable<FundingOpportunity> GetUnmappedFundingOpportunities([FromRoute] Guid internaluserid)
        {
            var foiu = _context.FundingOpportunityInternalUser.Where(i => i.InternalUserId == internaluserid).Select(x => x.FundingOpportunityId).ToList();
            return _unitOfWork.FundingOpportunities.GetAllFundingOpportunities().Where(x => !foiu.Contains(x.FundingOpportunityId));
        }
        // GET: api/FundingOpportunities/GetOpenClosedFundingOpportunities
        [HttpGet]
        [Route("GetOpenClosedFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetOpenClosedFundingOpportunities()
        {
           
          //  var currentLang = RouteData.Values["lang"].ToString();
            return _unitOfWork.FundingOpportunities.GetOpenClosedFundingOpportunities();
        }

        // GET: api/FundingOpportunities/GetActiveFundingOpportunities
        [HttpGet]
        [Route("GetActiveFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunities()
        {
            //this.Response.Cookies.Append("asdf", "asdf");
            return _unitOfWork.FundingOpportunities.GetActiveFundingOpportunities();
        }
        [HttpGet]
        [Route("GetAwaitingPublishedFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetAwaitingPublishedFundingOpportunities()
        {
            return _unitOfWork.FundingOpportunities.GetAwaitingPublishedFundingOpportunities();
        }
        [HttpGet]
        [Route("GetDraftFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetDraftFundingOpportunities()
        {
            return _unitOfWork.FundingOpportunities.GetDraftFundingOpportunities();
        }
        [HttpGet]
        [Route("GetInactiveFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetInactiveFundingOpportunities()
        {
            return _unitOfWork.FundingOpportunities.GetInactiveFundingOpportunities();
        }
        [HttpGet]
        [Route("GetArchivedFundingOpportunities")]
        public IEnumerable<FundingOpportunity> GetArchivedFundingOpportunities()
        {
            return _unitOfWork.FundingOpportunities.GetArchivedFundingOpportunities();
        }

        [HttpGet("GetAllFundingOpportunitiesByProgram/{programId}")]
        public IEnumerable<FundingOpportunity> GetAllFundingOpportunitiesByProgram([FromRoute] Guid programId)
        {
            return _unitOfWork.FundingOpportunities.GetAllFundingOpportunitiesByProgram(programId);
        }
        // GET: api/FundingOpportunities/GetActiveFundingOpportunities
        [HttpGet("GetActiveFundingOpportunitiesByProgram/{programId}")]
        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesByProgram([FromRoute] Guid programId)
        {
            return _unitOfWork.FundingOpportunities.GetActiveFundingOpportunitiesByProgram(programId);
        }
        [HttpGet("GetAwaitingPublishedFundingOpportunitiesByProgram/{programId}")]
        public IEnumerable<FundingOpportunity> GetAwaitingPublishedFundingOpportunitiesByProgram([FromRoute] Guid programId)
        {
            return _unitOfWork.FundingOpportunities.GetAwaitingPublishedFundingOpportunitiesByProgram(programId);
        }
        [HttpGet("GetDraftFundingOpportunitiesByProgram/{programId}")]
        public IEnumerable<FundingOpportunity> GetDraftFundingOpportunitiesByProgram([FromRoute] Guid programId)
        {
            return _unitOfWork.FundingOpportunities.GetDraftFundingOpportunitiesByProgram(programId);
        }
        [HttpGet("GetInactiveFundingOpportunitiesByProgram/{programId}")]
        public IEnumerable<FundingOpportunity> GetInactiveFundingOpportunitiesByProgram([FromRoute] Guid programId)
        {
            return _unitOfWork.FundingOpportunities.GetInactiveFundingOpportunitiesByProgram(programId);
        }
        [HttpGet("GetArchivedFundingOpportunitiesByProgra/{programId}")]
        public IEnumerable<FundingOpportunity> GetArchivedFundingOpportunitiesByProgram([FromRoute] Guid programId)
        {
            return _unitOfWork.FundingOpportunities.GetArchivedFundingOpportunitiesByProgram(programId);
        }


        [HttpGet]
        [Route("GetActiveFundingOpportunitiesWithRelationshipsCollapsed")]
        public IEnumerable<FundingOpportunity> GetActiveFundingOpportunitiesWithRelationshipsCollapsed()
        {
            return _unitOfWork.FundingOpportunities.GetActiveFundingOpportunitiesCollapsedRelationships();

        }

        // GET: api/en/FundingOpportunities/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingOpportunity), 200)]
        public async Task<IActionResult> GetFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var fundingOpportunity = await _unitOfWork.FundingOpportunities.GetAsync(id);
            var fundingOpportunity = await _unitOfWork.FundingOpportunities.GetAsync(id);

            if (fundingOpportunity == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunity);
        }

        // PUT: api/FundingOpportunities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunity([FromRoute] Guid id, [FromBody] FundingOpportunity fundingOpportunity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunity.FundingOpportunityId)
            {
                return BadRequest();
            }

            _unitOfWork.FundingOpportunities.Update(fundingOpportunity);
           

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.FundingOpportunities.FundingOpportunityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FundingOpportunities
        [HttpPost]
        [ProducesResponseType(typeof(FundingOpportunity), 200)]
        public async Task<IActionResult> PostFundingOpportunity([FromBody] FundingOpportunity fundingOpportunity)
        {
                      
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _unitOfWork.FundingOpportunities.Add(fundingOpportunity);
            await _unitOfWork.SaveChangesAsync();

           
            // return CreatedAtAction("GetFundingOpportunity", new { id = fundingOpportunity.FundingOpportunityId }, fundingOpportunity);
            return Ok(fundingOpportunity);
          
        }
        // POST: api/FundingOpportunities
        [HttpPost("copy/{id}")]
        [ProducesResponseType(typeof(FundingOpportunity), 200)]
        public async Task<IActionResult> CopyFundingOpportunity([FromRoute] Guid id)
        {

            
            FundingOpportunity currentFO = _unitOfWork.FundingOpportunities.Get(id);

            FundingOpportunity newFO = new FundingOpportunity
            {
                FundingOpportunityId = new Guid(),
                TitleE = currentFO.TitleE + " - Copy",
                TitleF = currentFO.TitleF + " - Copie",
                DescriptionE = currentFO.DescriptionE, 
                DescriptionF = currentFO.DescriptionF, 
                ActivationEndDate = currentFO.ActivationEndDate,
                ActivationStartDate = currentFO.ActivationStartDate,
                FundingProgramId = currentFO.FundingProgramId, 
                GcimsCommitmentItemId = currentFO.GcimsCommitmentItemId, 
                FormName = currentFO.FormName,
                ContactEmail = currentFO.ContactEmail
                
            };
            
            _context.Add(newFO);

            var considerations = _context.FundingOpportunityConsideration.Where(f => f.FundingOpportunityId == currentFO.FundingOpportunityId);
            var objectives = _context.FundingOpportunityObjective.Where(f => f.FundingOpportunityId == currentFO.FundingOpportunityId);
            var ecs = _context.FundingOpportunityEligibilityCriteria.Where(f => f.FundingOpportunityId == currentFO.FundingOpportunityId);
            var faqs = _context.FundingOpportunityFrequentlyAskedQuestion.Where(faq => faq.FundingOpportunityId == currentFO.FundingOpportunityId);
            var ius = _context.FundingOpportunityInternalUser.Where(iu => iu.FundingOpportunityId == currentFO.FundingOpportunityId);
            var eccs = _context.EligibleCostCategory.Where(ec => ec.FundingOpportunityId == currentFO.FundingOpportunityId);
            var ers = _context.FundingOpportunityExpectedResult.Where(er => er.FundingOpportunityId == currentFO.FundingOpportunityId);
            var ects = _context.EligibleClientType.Where(f => f.FundingOpportunityId == currentFO.FundingOpportunityId);
           

            foreach (var ect in ects)
            {
                EligibleClientType fo = new EligibleClientType
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    EligibleClientTypeStaticId = ect.EligibleClientTypeStaticId,
                    TitleE = ect.TitleE,
                    TitleF = ect.TitleF, 
                    DescriptionE = ect.DescriptionE, 
                    DescriptionF = ect.DescriptionF
                };
                _context.Add(fo);

            }

            foreach (var er in ers)
            {
                FundingOpportunityExpectedResult fo = new FundingOpportunityExpectedResult
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    ExpectedResultId = er.ExpectedResultId
                };
                _context.Add(fo);

            }

            foreach (var ecc in eccs)
            {
                EligibleCostCategory fo = new EligibleCostCategory
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    CostCategoryId = ecc.CostCategoryId, 
                    TitleE = ecc.TitleE, 
                    TitleF = ecc.TitleF, 
                    TooltipE = ecc.TooltipE, 
                    TooltipF = ecc.TooltipF
                };
                _context.Add(fo);

            }


            foreach (var iu in ius)
            {
                FundingOpportunityInternalUser fo = new FundingOpportunityInternalUser
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    InternalUserId = iu.InternalUserId
                };
                _context.Add(fo);
            }

            foreach (var faq in faqs)
            {
                FundingOpportunityFrequentlyAskedQuestion fo = new FundingOpportunityFrequentlyAskedQuestion
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    FrequentlyAskedQuestionId = faq.FrequentlyAskedQuestionId
                };
                _context.Add(fo);
            }

            foreach (var ec in ecs)
            {
                FundingOpportunityEligibilityCriteria fo = new FundingOpportunityEligibilityCriteria
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    EligibilityCriteriaId = ec.EligibilityCriteriaId
                };
                _context.Add(fo);
            }
            foreach (var o in objectives)
            {
                FundingOpportunityObjective fo = new FundingOpportunityObjective
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    ObjectiveId = o.ObjectiveId
                };
                _context.Add(fo);
            }

            foreach (var c in considerations)
            {
                FundingOpportunityConsideration fo = new FundingOpportunityConsideration
                {
                    FundingOpportunityId = newFO.FundingOpportunityId,
                    ConsiderationId = c.ConsiderationId
                };
                _context.Add(fo);
            }

            await _context.SaveChangesAsync();
            // return CreatedAtAction("GetFundingOpportunity", new { id = fundingOpportunity.FundingOpportunityId }, fundingOpportunity);
            return Ok(newFO);

        }

        // DELETE: api/FundingOpportunities/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FundingOpportunity), 200)]
        public async Task<IActionResult> DeleteFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunity = await _unitOfWork.FundingOpportunities.GetAsync(id);
            if (fundingOpportunity == null)
            {
                return NotFound();
            }

            _context.FundingOpportunity.Remove(fundingOpportunity);
            await _unitOfWork.SaveChangesAsync();

            return Ok(fundingOpportunity);
        }

      
    }
}
