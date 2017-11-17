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
    [Route("api/ProjectActivities")]
    public class ProjectActivitiesController : Controller
    {
        private readonly PortalContext _context;

        public ProjectActivitiesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectActivities
        [HttpGet]
        public IEnumerable<ProjectActivity> GetProjectActivity()
        {
            return _context.ProjectActivity;
        }

        // GET: api/ProjectActivities/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectActivity), 200)]
        public async Task<IActionResult> GetProjectActivity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectActivity = await _context.ProjectActivity.SingleOrDefaultAsync(m => m.ProjectActivityId == id);

            if (projectActivity == null)
            {
                return NotFound();
            }

            return Ok(projectActivity);
        }
        [HttpPost("GetByProject")]
        public IEnumerable<ProjectActivity> GetByProject([FromBody] Project project)
        {
            return _context.ProjectActivity.Where(s => s.ProjectId == project.ProjectId);
        }
        // PUT: api/ProjectActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectActivity([FromRoute] Guid id, [FromBody] ProjectActivity projectActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectActivity.ProjectActivityId)
            {
                return BadRequest();
            }

            _context.Entry(projectActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectActivityExists(id))
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

        // POST: api/ProjectActivities
        [HttpPost]
        [ProducesResponseType(typeof(ProjectActivity), 200)]
        public async Task<IActionResult> PostProjectActivity([FromBody] ProjectActivity projectActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectActivity.Add(projectActivity);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectActivity", new { id = projectActivity.ProjectActivityId }, projectActivity);
            return Ok(projectActivity);
        }

        // DELETE: api/ProjectActivities/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectActivity), 200)]
        public async Task<IActionResult> DeleteProjectActivity([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectActivity = await _context.ProjectActivity.SingleOrDefaultAsync(m => m.ProjectActivityId == id);
            if (projectActivity == null)
            {
                return NotFound();
            }

            _context.ProjectActivity.Remove(projectActivity);
            await _context.SaveChangesAsync();

            return Ok(projectActivity);
        }

        private bool ProjectActivityExists(Guid id)
        {
            return _context.ProjectActivity.Any(e => e.ProjectActivityId == id);
        }
    }
}