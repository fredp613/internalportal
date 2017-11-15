using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/ProjectSupporters")]
    public class ProjectSupportersController : Controller
    {
        private readonly PortalContext _context;

        public ProjectSupportersController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectSupporters
        [HttpGet]        
        public IEnumerable<ProjectSupporter> GetProjectSupporter()
        {
            return _context.ProjectSupporter;
        }

        // GET: api/ProjectSupporters/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectSupporter), 200)]
        public async Task<IActionResult> GetProjectSupporter([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectSupporter = await _context.ProjectSupporter.SingleOrDefaultAsync(m => m.ProjectSupporterId == id);

            if (projectSupporter == null)
            {
                return NotFound();
            }

            return Ok(projectSupporter);
        }
        [HttpPost("GetByProject")]
        public IEnumerable<ProjectSupporter> GetByProject([FromBody] Project project)
        {
            return _context.ProjectSupporter.Where(s => s.ProjectId == project.ProjectId);
        }

        // PUT: api/ProjectSupporters/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectSupporter([FromRoute] Guid id, [FromBody] ProjectSupporter projectSupporter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectSupporter.ProjectSupporterId)
            {
                return BadRequest();
            }

            _context.Entry(projectSupporter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectSupporterExists(id))
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

        // POST: api/ProjectSupporters
        [HttpPost]
        [ProducesResponseType(typeof(ProjectSupporter), 200)]
        public async Task<IActionResult> PostProjectSupporter([FromBody] ProjectSupporter projectSupporter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectSupporter.Add(projectSupporter);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectSupporter", new { id = projectSupporter.ProjectSupporterId }, projectSupporter);
            return Ok(projectSupporter);
        }

        // DELETE: api/ProjectSupporters/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectSupporter), 200)]
        public async Task<IActionResult> DeleteProjectSupporter([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectSupporter = await _context.ProjectSupporter.SingleOrDefaultAsync(m => m.ProjectSupporterId == id);
            if (projectSupporter == null)
            {
                return NotFound();
            }

            _context.ProjectSupporter.Remove(projectSupporter);
            await _context.SaveChangesAsync();

            return Ok(projectSupporter);
        }

        private bool ProjectSupporterExists(Guid id)
        {
            return _context.ProjectSupporter.Any(e => e.ProjectSupporterId == id);
        }
    }
}