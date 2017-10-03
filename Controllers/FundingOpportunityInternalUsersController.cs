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
    [Route("api/FundingOpportunityInternalUsers")]
    public class FundingOpportunityInternalUsersController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityInternalUsersController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityInternalUsers
        [HttpGet]
        public IEnumerable<FundingOpportunityInternalUser> GetFundingOpportunityInternalUser()
        {

            return _context.FundingOpportunityInternalUser.Include(iu => iu.InternalUser).Include(fo => fo.FundingOpportunity);
        }

        // GET: api/FundingOpportunityInternalUsers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityInternalUser), 200)]
        public async Task<IActionResult> GetFundingOpportunityInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityInternalUser = await _context.FundingOpportunityInternalUser.Include(iu => iu.InternalUser).Include(fo => fo.FundingOpportunity).SingleOrDefaultAsync(m => m.FundingOpportunityInternalUserId == id);

            if (fundingOpportunityInternalUser == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityInternalUser);
        }

        // PUT: api/FundingOpportunityInternalUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityInternalUser([FromRoute] Guid id, [FromBody] FundingOpportunityInternalUser fundingOpportunityInternalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityInternalUser.FundingOpportunityInternalUserId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityInternalUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityInternalUserExists(id))
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

        // POST: api/FundingOpportunityInternalUsers
        [HttpPost]
        public async Task<IActionResult> PostFundingOpportunityInternalUser([FromBody] FundingOpportunityInternalUser fundingOpportunityInternalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingOpportunityInternalUser.Add(fundingOpportunityInternalUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingOpportunityInternalUser", new { id = fundingOpportunityInternalUser.FundingOpportunityInternalUserId }, fundingOpportunityInternalUser);
        }

        // DELETE: api/FundingOpportunityInternalUsers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityInternalUser), 200)]
        public async Task<IActionResult> DeleteFundingOpportunityInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityInternalUser = await _context.FundingOpportunityInternalUser.SingleOrDefaultAsync(m => m.FundingOpportunityInternalUserId == id);
            if (fundingOpportunityInternalUser == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityInternalUser.Remove(fundingOpportunityInternalUser);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityInternalUser);
        }

        private bool FundingOpportunityInternalUserExists(Guid id)
        {
            return _context.FundingOpportunityInternalUser.Any(e => e.FundingOpportunityInternalUserId == id);
        }
    }
}