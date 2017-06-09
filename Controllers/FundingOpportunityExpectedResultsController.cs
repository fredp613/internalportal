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
    [Route("api/FundingOpportunityExpectedResults")]
    public class FundingOpportunityExpectedResultsController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityExpectedResultsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityExpectedResults
        [HttpGet]
        public IEnumerable<FundingOpportunityExpectedResult> GetFundingOpportunityExpectedResult()
        {
            return _context.FundingOpportunityExpectedResult;
        }

        // GET: api/FundingOpportunityExpectedResults/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingOpportunityExpectedResult([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityExpectedResult = await _context.FundingOpportunityExpectedResult.SingleOrDefaultAsync(m => m.FundingOpportunityExpectedResultId == id);

            if (fundingOpportunityExpectedResult == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityExpectedResult);
        }

        // PUT: api/FundingOpportunityExpectedResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityExpectedResult([FromRoute] Guid id, [FromBody] FundingOpportunityExpectedResult fundingOpportunityExpectedResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityExpectedResult.FundingOpportunityExpectedResultId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityExpectedResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityExpectedResultExists(id))
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

        // POST: api/FundingOpportunityExpectedResults
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunityExpectedResult([FromBody] FundingOpportunityExpectedResult fundingOpportunityExpectedResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityExpectedResult.Add(fundingOpportunityExpectedResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunityExpectedResult", new { id = fundingOpportunityExpectedResult.FundingOpportunityExpectedResultId }, fundingOpportunityExpectedResult);
        }

        // DELETE: api/FundingOpportunityExpectedResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunityExpectedResult([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityExpectedResult = await _context.FundingOpportunityExpectedResult.SingleOrDefaultAsync(m => m.FundingOpportunityExpectedResultId == id);
            if (fundingOpportunityExpectedResult == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityExpectedResult.Remove(fundingOpportunityExpectedResult);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityExpectedResult);
        }

        private bool FundingOpportunityExpectedResultExists(Guid id)
        {
            return _context.FundingOpportunityExpectedResult.Any(e => e.FundingOpportunityExpectedResultId == id);
        }
    }
}