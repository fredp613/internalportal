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
                TitleE = currentFO.TitleE + " - Copy",
                TitleF = currentFO.TitleF + " - Copie",
                ActivationEndDate = currentFO.ActivationEndDate,
                ActivationStartDate = currentFO.ActivationStartDate,
                FundingProgramId = currentFO.FundingProgramId

            };

            _context.Add(newFO);
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
