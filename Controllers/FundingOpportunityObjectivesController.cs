using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal.Program;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/FundingOpportunityObjectives")]
    public class FundingOpportunityObjectivesController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityObjectivesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityObjectives
        [HttpGet]
        public IEnumerable<FundingOpportunityObjective> GetFundingOpportunityObjective()
        {
            return _context.FundingOpportunityObjective;
        }

        // GET: api/FundingOpportunityObjectives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingOpportunityObjective([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityObjective = await _context.FundingOpportunityObjective.SingleOrDefaultAsync(m => m.FundingOpportunityObjectiveId == id);

            if (fundingOpportunityObjective == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityObjective);
        }

        // PUT: api/FundingOpportunityObjectives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityObjective([FromRoute] Guid id, [FromBody] FundingOpportunityObjective fundingOpportunityObjective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityObjective.FundingOpportunityObjectiveId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityObjective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityObjectiveExists(id))
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

        // POST: api/FundingOpportunityObjectives
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunityObjective([FromBody] FundingOpportunityObjective fundingOpportunityObjective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityObjective.Add(fundingOpportunityObjective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunityObjective", new { id = fundingOpportunityObjective.FundingOpportunityObjectiveId }, fundingOpportunityObjective);
        }

        // DELETE: api/FundingOpportunityObjectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunityObjective([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityObjective = await _context.FundingOpportunityObjective.SingleOrDefaultAsync(m => m.FundingOpportunityObjectiveId == id);
            if (fundingOpportunityObjective == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityObjective.Remove(fundingOpportunityObjective);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityObjective);
        }

        private bool FundingOpportunityObjectiveExists(Guid id)
        {
            return _context.FundingOpportunityObjective.Any(e => e.FundingOpportunityObjectiveId == id);
        }
    }
}