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
    [Route("api/ProjectFederalDepartments")]
    public class ProjectFederalDepartmentsController : Controller
    {
        private readonly PortalContext _context;

        public ProjectFederalDepartmentsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectFederalDepartments
        [HttpGet]
        public IEnumerable<ProjectFederalDepartment> GetProjectFederalDepartment()
        {
            return _context.ProjectFederalDepartment;
        }

        // GET: api/ProjectFederalDepartments/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectFederalDepartment), 200)]
        public async Task<IActionResult> GetProjectFederalDepartment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectFederalDepartment = await _context.ProjectFederalDepartment.SingleOrDefaultAsync(m => m.ProjectFederalDepartmentId == id);

            if (projectFederalDepartment == null)
            {
                return NotFound();
            }

            return Ok(projectFederalDepartment);
        }

        // PUT: api/ProjectFederalDepartments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectFederalDepartment([FromRoute] Guid id, [FromBody] ProjectFederalDepartment projectFederalDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectFederalDepartment.ProjectFederalDepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(projectFederalDepartment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectFederalDepartmentExists(id))
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

        // POST: api/ProjectFederalDepartments
        [HttpPost]
        [ProducesResponseType(typeof(ProjectFederalDepartment), 200)]
        public async Task<IActionResult> PostProjectFederalDepartment([FromBody] ProjectFederalDepartment projectFederalDepartment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectFederalDepartment.Add(projectFederalDepartment);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectFederalDepartment", new { id = projectFederalDepartment.ProjectFederalDepartmentId }, projectFederalDepartment);
            return Ok(projectFederalDepartment);
        }

        // DELETE: api/ProjectFederalDepartments/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectFederalDepartment), 200)]
        public async Task<IActionResult> DeleteProjectFederalDepartment([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectFederalDepartment = await _context.ProjectFederalDepartment.SingleOrDefaultAsync(m => m.ProjectFederalDepartmentId == id);
            if (projectFederalDepartment == null)
            {
                return NotFound();
            }

            _context.ProjectFederalDepartment.Remove(projectFederalDepartment);
            await _context.SaveChangesAsync();

            return Ok(projectFederalDepartment);
        }

        private bool ProjectFederalDepartmentExists(Guid id)
        {
            return _context.ProjectFederalDepartment.Any(e => e.ProjectFederalDepartmentId == id);
        }
    }
}