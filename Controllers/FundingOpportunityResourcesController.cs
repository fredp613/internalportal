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
    [Route("api/FundingOpportunityResources")]
    public class FundingOpportunityResourcesController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityResourcesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityResources
        [HttpGet]
        public IEnumerable<FundingOpportunityResource> GetFundingOpportunityResource()
        {
            return _context.FundingOpportunityResource;
        }

        // GET: api/FundingOpportunityResources/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingOpportunityResource([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityResource = await _context.FundingOpportunityResource.SingleOrDefaultAsync(m => m.FundingOpportunityResourceId == id);

            if (fundingOpportunityResource == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityResource);
        }

        // PUT: api/FundingOpportunityResources/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityResource([FromRoute] Guid id, [FromBody] FundingOpportunityResource fundingOpportunityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityResource.FundingOpportunityResourceId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityResource).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityResourceExists(id))
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

        // POST: api/FundingOpportunityResources
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunityResource([FromBody] FundingOpportunityResource fundingOpportunityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityResource.Add(fundingOpportunityResource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunityResource", new { id = fundingOpportunityResource.FundingOpportunityResourceId }, fundingOpportunityResource);
        }

        // DELETE: api/FundingOpportunityResources/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingOpportunityResource([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityResource = await _context.FundingOpportunityResource.SingleOrDefaultAsync(m => m.FundingOpportunityResourceId == id);
            if (fundingOpportunityResource == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityResource.Remove(fundingOpportunityResource);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityResource);
        }

        private bool FundingOpportunityResourceExists(Guid id)
        {
            return _context.FundingOpportunityResource.Any(e => e.FundingOpportunityResourceId == id);
        }
    }
}