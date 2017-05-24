using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal.Program;
using System.Diagnostics;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/FundingOpportunityEligibilityCriterias")]
    public class FundingOpportunityEligibilityCriteriasController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityEligibilityCriteriasController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityEligibilityCriterias
        [HttpGet]
        public IEnumerable<FundingOpportunityEligibilityCriteria> GetFundingOpportunityEligibilityCriteria()
        {
            return _context.FundingOpportunityEligibilityCriteria;
        }

        // GET: api/FundingOpportunityEligibilityCriterias/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingOpportunityEligibilityCriteria([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityEligibilityCriteria = await _context.FundingOpportunityEligibilityCriteria.SingleOrDefaultAsync(m => m.FundingOpportunityEligibilityCriteriaId == id);

            if (fundingOpportunityEligibilityCriteria == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityEligibilityCriteria);
        }

        // GET: api/FundingOpportunityEligibilityCriterias/GetByFundingOpportunityId/5
        //[HttpGet("{id}")]
        [Route("GetByFundingOpportunity/{FundingOpportunityId}")]
        [HttpGet]
        public async Task<IEnumerable<FundingOpportunityEligibilityCriteria>> GetByFundingOpportunity(Guid FundingOpportunityId)
        {

            IList<FundingOpportunityEligibilityCriteria> fundingOpportunityEligibilityCriterias = await _context.
                FundingOpportunityEligibilityCriteria.Where(m => m.FundingOpportunityId == FundingOpportunityId).Include(ec => ec.EligibilityCriteria).Include(fo => fo.FundingOpportunity).ToListAsync();         

            return fundingOpportunityEligibilityCriterias;
        }

        // PUT: api/FundingOpportunityEligibilityCriterias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityEligibilityCriteria([FromRoute] Guid id, [FromBody] FundingOpportunityEligibilityCriteria fundingOpportunityEligibilityCriteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityEligibilityCriteria.FundingOpportunityEligibilityCriteriaId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityEligibilityCriteria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityEligibilityCriteriaExists(id))
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

        // POST: api/FundingOpportunityEligibilityCriterias
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunityEligibilityCriteria([FromBody] FundingOpportunityEligibilityCriteria fundingOpportunityEligibilityCriteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityEligibilityCriteria.Add(fundingOpportunityEligibilityCriteria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunityEligibilityCriteria", new { id = fundingOpportunityEligibilityCriteria.FundingOpportunityEligibilityCriteriaId }, fundingOpportunityEligibilityCriteria);
        }

        // DELETE: api/FundingOpportunityEligibilityCriterias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunityEligibilityCriteria([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityEligibilityCriteria = await _context.FundingOpportunityEligibilityCriteria.SingleOrDefaultAsync(m => m.FundingOpportunityEligibilityCriteriaId == id);
            if (fundingOpportunityEligibilityCriteria == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityEligibilityCriteria.Remove(fundingOpportunityEligibilityCriteria);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityEligibilityCriteria);
        }

        private bool FundingOpportunityEligibilityCriteriaExists(Guid id)
        {
            return _context.FundingOpportunityEligibilityCriteria.Any(e => e.FundingOpportunityEligibilityCriteriaId == id);
        }
    }
}