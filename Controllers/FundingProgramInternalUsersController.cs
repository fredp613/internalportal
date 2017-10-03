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
    [Route("api/FundingProgramInternalUsers")]
    public class FundingProgramInternalUsersController : Controller
    {
        private readonly PortalContext _context;

        public FundingProgramInternalUsersController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingProgramInternalUsers
        [HttpGet]
        public IEnumerable<FundingProgramInternalUser> GetFundingProgramInternalUser()
        {
            return _context.FundingProgramInternalUser.Include(iu => iu.InternalUser).Include(fp => fp.FundingProgram);
        }



        // GET: api/FundingProgramInternalUsers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingProgramInternalUser), 200)]
        public async Task<IActionResult> GetFundingProgramInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingProgramInternalUser = await _context.FundingProgramInternalUser
                                                            .Include(iu => iu.InternalUser)
                                                            .Include(fp => fp.FundingProgram)
                                                            .SingleOrDefaultAsync(m => m.FundingProgramInternalUserId == id);

            if (fundingProgramInternalUser == null)
            {
                return NotFound();
            }

            return Ok(fundingProgramInternalUser);
        }

        // PUT: api/FundingProgramInternalUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingProgramInternalUser([FromRoute] Guid id, [FromBody] FundingProgramInternalUser fundingProgramInternalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingProgramInternalUser.FundingProgramInternalUserId)
            {
                return BadRequest();
            }

            _context.Entry(fundingProgramInternalUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingProgramInternalUserExists(id))
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

        // POST: api/FundingProgramInternalUsers
        [HttpPost]
        [ProducesResponseType(typeof(FundingProgramInternalUser), 201)]
        public async Task<IActionResult> PostFundingProgramInternalUser([FromBody] FundingProgramInternalUser fundingProgramInternalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingProgramInternalUser.Add(fundingProgramInternalUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingProgramInternalUser", new { id = fundingProgramInternalUser.FundingProgramInternalUserId }, fundingProgramInternalUser);
        }

        // DELETE: api/FundingProgramInternalUsers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FundingProgramInternalUser), 200)]
        public async Task<IActionResult> DeleteFundingProgramInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingProgramInternalUser = await _context.FundingProgramInternalUser.SingleOrDefaultAsync(m => m.FundingProgramInternalUserId == id);
            if (fundingProgramInternalUser == null)
            {
                return NotFound();
            }

            _context.FundingProgramInternalUser.Remove(fundingProgramInternalUser);
            await _context.SaveChangesAsync();

            return Ok(fundingProgramInternalUser);
        }

        private bool FundingProgramInternalUserExists(Guid id)
        {
            return _context.FundingProgramInternalUser.Any(e => e.FundingProgramInternalUserId == id);
        }
    }
}