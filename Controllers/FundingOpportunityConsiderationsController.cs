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
    [Route("api/FundingOpportunityConsiderations")]
    public class FundingOpportunityConsiderationsController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityConsiderationsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityConsiderations
        [HttpGet]
        public IEnumerable<FundingOpportunityConsideration> GetFundingOpportunityConsideration()
        {
            return _context.FundingOpportunityConsideration;
        }

        // GET: api/FundingOpportunityConsiderations/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityConsideration), 200)]
        public async Task<IActionResult> GetFundingOpportunityConsideration([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityConsideration = await _context.FundingOpportunityConsideration.SingleOrDefaultAsync(m => m.FundingOpportunityConsiderationId == id);

            if (fundingOpportunityConsideration == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityConsideration);
        }

        // PUT: api/FundingOpportunityConsiderations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityConsideration([FromRoute] Guid id, [FromBody] FundingOpportunityConsideration fundingOpportunityConsideration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityConsideration.FundingOpportunityConsiderationId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityConsideration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityConsiderationExists(id))
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

        // POST: api/FundingOpportunityConsiderations
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunityConsideration([FromBody] FundingOpportunityConsideration fundingOpportunityConsideration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityConsideration.Add(fundingOpportunityConsideration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunityConsideration", new { id = fundingOpportunityConsideration.FundingOpportunityConsiderationId }, fundingOpportunityConsideration);
        }

        // DELETE: api/FundingOpportunityConsiderations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityConsideration), 200)]
        public async Task<IActionResult> DeleteFundingOpportunityConsideration([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityConsideration = await _context.FundingOpportunityConsideration.SingleOrDefaultAsync(m => m.FundingOpportunityConsiderationId == id);
            if (fundingOpportunityConsideration == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityConsideration.Remove(fundingOpportunityConsideration);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityConsideration);
        }

        private bool FundingOpportunityConsiderationExists(Guid id)
        {
            return _context.FundingOpportunityConsideration.Any(e => e.FundingOpportunityConsiderationId == id);
        }
    }
}