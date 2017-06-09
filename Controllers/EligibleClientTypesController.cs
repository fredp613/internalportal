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
    [Route("api/EligibleClientTypes")]
    public class EligibleClientTypesController : Controller
    {
        private readonly PortalContext _context;

        public EligibleClientTypesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/EligibleClientTypes
        [HttpGet]
        public IEnumerable<EligibleClientType> GetEligibleClientType()
        {
            return _context.EligibleClientType;
        }

        // GET: api/EligibleClientTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEligibleClientType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibleClientType = await _context.EligibleClientType.SingleOrDefaultAsync(m => m.EligibleClientTypeId == id);

            if (eligibleClientType == null)
            {
                return NotFound();
            }

            return Ok(eligibleClientType);
        }

        // PUT: api/EligibleClientTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEligibleClientType([FromRoute] Guid id, [FromBody] EligibleClientType eligibleClientType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eligibleClientType.EligibleClientTypeId)
            {
                return BadRequest();
            }

            _context.Entry(eligibleClientType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EligibleClientTypeExists(id))
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

        // POST: api/EligibleClientTypes
        [HttpPost]
        public async Task<IActionResult> PostEligibleClientType([FromBody] EligibleClientType eligibleClientType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EligibleClientType.Add(eligibleClientType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEligibleClientType", new { id = eligibleClientType.EligibleClientTypeId }, eligibleClientType);
        }

        // DELETE: api/EligibleClientTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEligibleClientType([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibleClientType = await _context.EligibleClientType.SingleOrDefaultAsync(m => m.EligibleClientTypeId == id);
            if (eligibleClientType == null)
            {
                return NotFound();
            }

            _context.EligibleClientType.Remove(eligibleClientType);
            await _context.SaveChangesAsync();

            return Ok(eligibleClientType);
        }

        private bool EligibleClientTypeExists(Guid id)
        {
            return _context.EligibleClientType.Any(e => e.EligibleClientTypeId == id);
        }
    }
}