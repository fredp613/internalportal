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
            var fundingPrograms = _context.FundingProgram.ToList();
                
                //.Include(c => c.FundingProgramInternalUsers)
                                            //.ThenInclude(ec => ec.InternalUser).ToList();

            foreach(var fp in fundingPrograms)
            {
                var relatedDraftFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fp.FundingProgramId && (p.Status == FOStatus.Draft));
                fp.DraftFundingOpportunities = relatedDraftFO.ToList();

                var relatedOpenFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fp.FundingProgramId && (p.Status == FOStatus.Published && p.ActivationStartDate <= DateTime.Now && p.ActivationEndDate >= DateTime.Now));
                fp.OpenFundingOpportunities = relatedOpenFO.ToList();

                var relatedScheduledFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fp.FundingProgramId && (p.Status == FOStatus.Published && p.ActivationStartDate > DateTime.Now));
                fp.ScheduledFundingOpportunities = relatedScheduledFO.ToList();

                var relatedClosedFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fp.FundingProgramId && (p.Status == FOStatus.Closed || (p.ActivationEndDate < DateTime.Now && p.Status != FOStatus.Archived)));
                fp.ClosedFundingOpportunities = relatedClosedFO.ToList();

                var relatedArchivedFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fp.FundingProgramId && (p.Status == FOStatus.Archived));
                fp.ArchivedFundingOpportunities = relatedArchivedFO.ToList();
            }

            return fundingPrograms;
        }

        // GET: api/FundingPrograms/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingProgram), 200)]
        public async Task<IActionResult> GetFundingProgram([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingProgram = await _context.FundingProgram.SingleOrDefaultAsync(p => p.FundingProgramId == id);
		    //.Include(c => c.FundingProgramInternalUsers)
                      //                      .ThenInclude(ec => ec.InternalUser).SingleOrDefaultAsync(m => m.FundingProgramId == id);

            if (fundingProgram == null)
            {
                return NotFound();
            }
            var relatedDraftFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fundingProgram.FundingProgramId && (p.Status == FOStatus.Draft));
            fundingProgram.DraftFundingOpportunities = relatedDraftFO;

            var relatedOpenFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fundingProgram.FundingProgramId && (p.Status == FOStatus.Published && p.ActivationStartDate <= DateTime.Now && p.ActivationEndDate >= DateTime.Now));
            fundingProgram.OpenFundingOpportunities = relatedOpenFO;

            var relatedScheduledFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fundingProgram.FundingProgramId && (p.Status == FOStatus.Published && p.ActivationStartDate > DateTime.Now));
            fundingProgram.ScheduledFundingOpportunities = relatedScheduledFO;

            var relatedClosedFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fundingProgram.FundingProgramId && (p.Status == FOStatus.Closed || (p.ActivationEndDate < DateTime.Now && p.Status != FOStatus.Archived)));
            fundingProgram.ClosedFundingOpportunities = relatedClosedFO;

            var relatedArchivedFO = _context.FundingOpportunity.Where(p => p.FundingProgramId == fundingProgram.FundingProgramId && (p.Status == FOStatus.Archived));
            fundingProgram.ArchivedFundingOpportunities = relatedArchivedFO;

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
        [ProducesResponseType(typeof(FundingProgram), 201)]
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
        [ProducesResponseType(typeof(FundingProgram), 200)]
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
