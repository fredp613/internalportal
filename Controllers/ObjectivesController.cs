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
    [Route("api/Objectives")]
    public class ObjectivesController : Controller
    {
        private readonly PortalContext _context;

        public ObjectivesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Objectives
        [HttpGet]
        public IEnumerable<Objective> GetObjective()
        {
            return _context.Objective;
        }

        // GET: api/Objectives/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetObjective([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objective = await _context.Objective.SingleOrDefaultAsync(m => m.ObjectiveId == id);

            if (objective == null)
            {
                return NotFound();
            }

            return Ok(objective);
        }

        // PUT: api/Objectives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjective([FromRoute] Guid id, [FromBody] Objective objective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objective.ObjectiveId)
            {
                return BadRequest();
            }

            _context.Entry(objective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(id))
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

        // POST: api/Objectives
        [HttpPost]
        public async Task<IActionResult> PostObjective([FromBody] Objective objective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Objective.Add(objective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjective", new { id = objective.ObjectiveId }, objective);
        }

        // DELETE: api/Objectives/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjective([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var objective = await _context.Objective.SingleOrDefaultAsync(m => m.ObjectiveId == id);
            if (objective == null)
            {
                return NotFound();
            }

            _context.Objective.Remove(objective);
            await _context.SaveChangesAsync();

            return Ok(objective);
        }

        private bool ObjectiveExists(Guid id)
        {
            return _context.Objective.Any(e => e.ObjectiveId == id);
        }
    }
}