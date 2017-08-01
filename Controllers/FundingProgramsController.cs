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
    [Route("api/FundingPrograms")]
    public class FundingProgramsController : Controller
    {
        private readonly PortalContext _context;

        public FundingProgramsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingPrograms
        [HttpGet]
        public IEnumerable<FundingProgram> GetFundingProgram()
        {
            return _context.FundingProgram.Include(c => c.FundingProgramInternalUsers)
                                            .ThenInclude(ec => ec.InternalUser);
        }

        // GET: api/FundingPrograms/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFundingProgram([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingProgram = await _context.FundingProgram.Include(c => c.FundingProgramInternalUsers)
                                            .ThenInclude(ec => ec.InternalUser).SingleOrDefaultAsync(m => m.FundingProgramId == id);

            if (fundingProgram == null)
            {
                return NotFound();
            }

            return Ok(fundingProgram);
        }

        // PUT: api/FundingPrograms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingProgram([FromRoute] Guid id, [FromBody] FundingProgram fundingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingProgram.FundingProgramId)
            {
                return BadRequest();
            }

            _context.Entry(fundingProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingProgramExists(id))
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

        // POST: api/FundingPrograms
        [HttpPost]
        public async Task<IActionResult> PostFundingProgram([FromBody] FundingProgram fundingProgram)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FundingProgram.Add(fundingProgram);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFundingProgram", new { id = fundingProgram.FundingProgramId }, fundingProgram);
        }

        // DELETE: api/FundingPrograms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFundingProgram([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingProgram = await _context.FundingProgram.SingleOrDefaultAsync(m => m.FundingProgramId == id);
            if (fundingProgram == null)
            {
                return NotFound();
            }

            _context.FundingProgram.Remove(fundingProgram);
            await _context.SaveChangesAsync();

            return Ok(fundingProgram);
        }

        private bool FundingProgramExists(Guid id)
        {
            return _context.FundingProgram.Any(e => e.FundingProgramId == id);
        }
    }
}