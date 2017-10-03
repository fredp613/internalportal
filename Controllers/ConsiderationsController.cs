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
    [Route("api/Considerations")]
    public class ConsiderationsController : Controller
    {
        private readonly PortalContext _context;

        public ConsiderationsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Considerations
        [HttpGet]
        public IEnumerable<Consideration> GetConsideration()
        {
            return _context.Consideration;
        }

        // GET: api/Considerations/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Consideration), 200)]
        public async Task<IActionResult> GetConsideration([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consideration = await _context.Consideration.SingleOrDefaultAsync(m => m.ConsiderationId == id);

            if (consideration == null)
            {
                return NotFound();
            }

            return Ok(consideration);
        }

        // PUT: api/Considerations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsideration([FromRoute] Guid id, [FromBody] Consideration consideration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != consideration.ConsiderationId)
            {
                return BadRequest();
            }

            _context.Entry(consideration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsiderationExists(id))
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

        // POST: api/Considerations
        [HttpPost]
        [ProducesResponseType(typeof(Consideration), 201)]
        public async Task<IActionResult> PostConsideration([FromBody] Consideration consideration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Consideration.Add(consideration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsideration", new { id = consideration.ConsiderationId }, consideration);
        }

        // DELETE: api/Considerations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Consideration), 200)]
        public async Task<IActionResult> DeleteConsideration([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var consideration = await _context.Consideration.SingleOrDefaultAsync(m => m.ConsiderationId == id);
            if (consideration == null)
            {
                return NotFound();
            }

            _context.Consideration.Remove(consideration);
            await _context.SaveChangesAsync();

            return Ok(consideration);
        }

        private bool ConsiderationExists(Guid id)
        {
            return _context.Consideration.Any(e => e.ConsiderationId == id);
        }
    }
}