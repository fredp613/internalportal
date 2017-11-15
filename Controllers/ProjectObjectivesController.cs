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
    [Route("api/ProjectObjectives")]
    public class ProjectObjectivesController : Controller
    {
        private readonly PortalContext _context;

        public ProjectObjectivesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectObjectives
        [HttpGet]
        public IEnumerable<ProjectObjective> GetProjectObjective()
        {
            return _context.ProjectObjective;
        }

        // GET: api/ProjectObjectives/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectObjective), 200)]
        public async Task<IActionResult> GetProjectObjective([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectObjective = await _context.ProjectObjective.SingleOrDefaultAsync(m => m.ProjectObjectiveId == id);

            if (projectObjective == null)
            {
                return NotFound();
            }

            return Ok(projectObjective);
        }
        [HttpPost("GetByProject")]
        public IEnumerable<ProjectObjective> GetByProject([FromBody] Project project)
        {
            return _context.ProjectObjective.Where(s => s.ProjectID == project.ProjectId);
        }

        // PUT: api/ProjectObjectives/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectObjective([FromRoute] Guid id, [FromBody] ProjectObjective projectObjective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectObjective.ProjectObjectiveId)
            {
                return BadRequest();
            }

            _context.Entry(projectObjective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectObjectiveExists(id))
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

        // POST: api/ProjectObjectives
        [HttpPost]
        [ProducesResponseType(typeof(ProjectObjective), 200)]
        public async Task<IActionResult> PostProjectObjective([FromBody] ProjectObjective projectObjective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectObjective.Add(projectObjective);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectObjective", new { id = projectObjective.ProjectObjectiveId }, projectObjective);
            return Ok(projectObjective);
        }

        // DELETE: api/ProjectObjectives/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectObjective), 200)]
        public async Task<IActionResult> DeleteProjectObjective([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectObjective = await _context.ProjectObjective.SingleOrDefaultAsync(m => m.ProjectObjectiveId == id);
            if (projectObjective == null)
            {
                return NotFound();
            }

            _context.ProjectObjective.Remove(projectObjective);
            await _context.SaveChangesAsync();

            return Ok(projectObjective);
        }

        private bool ProjectObjectiveExists(Guid id)
        {
            return _context.ProjectObjective.Any(e => e.ProjectObjectiveId == id);
        }
    }
}