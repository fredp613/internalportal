using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/FundingOpportunities")]
    public class FundingOpportunitiesController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunitiesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunities
        [HttpGet]
        public IEnumerable<FundingOpportunity> GetFundingOpportunity()
        {
            return _context.FundingOpportunity;
        }

        // GET: api/FundingOpportunities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunity = await _context.FundingOpportunity.SingleOrDefaultAsync(m => m.FundingOpportunityId == id);

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

            _context.Entry(fundingOpportunity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityExists(id))
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
        public async Task<IActionResult> PostFundingOpportunity([FromBody] FundingOpportunity fundingOpportunity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunity.Add(fundingOpportunity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunity", new { id = fundingOpportunity.FundingOpportunityId }, fundingOpportunity);
        }

        // DELETE: api/FundingOpportunities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunity = await _context.FundingOpportunity.SingleOrDefaultAsync(m => m.FundingOpportunityId == id);
            if (fundingOpportunity == null)
            {
                return NotFound();
            }

            _context.FundingOpportunity.Remove(fundingOpportunity);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunity);
        }

        private bool FundingOpportunityExists(Guid id)
        {
            return _context.FundingOpportunity.Any(e => e.FundingOpportunityId == id);
        }
    }
}