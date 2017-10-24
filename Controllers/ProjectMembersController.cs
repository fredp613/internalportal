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
    [Route("api/ProjectMembers")]
    public class ProjectMembersController : Controller
    {
        private readonly PortalContext _context;

        public ProjectMembersController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectMembers
        [HttpGet]
        public IEnumerable<ProjectMember> GetProjectMember()
        {
            return _context.ProjectMember;
        }

        // GET: api/ProjectMembers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectMember), 200)]
        public async Task<IActionResult> GetProjectMember([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectMember = await _context.ProjectMember.SingleOrDefaultAsync(m => m.ProjectMemberId == id);

            if (projectMember == null)
            {
                return NotFound();
            }

            return Ok(projectMember);
        }

        // PUT: api/ProjectMembers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectMember([FromRoute] Guid id, [FromBody] ProjectMember projectMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectMember.ProjectMemberId)
            {
                return BadRequest();
            }

            _context.Entry(projectMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectMemberExists(id))
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

        // POST: api/ProjectMembers
        [HttpPost]
        [ProducesResponseType(typeof(ProjectMember), 200)]
        public async Task<IActionResult> PostProjectMember([FromBody] ProjectMember projectMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectMember.Add(projectMember);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectMember", new { id = projectMember.ProjectMemberId }, projectMember);
            return Ok(projectMember);
        }

        // DELETE: api/ProjectMembers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectMember), 200)]
        public async Task<IActionResult> DeleteProjectMember([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectMember = await _context.ProjectMember.SingleOrDefaultAsync(m => m.ProjectMemberId == id);
            if (projectMember == null)
            {
                return NotFound();
            }

            _context.ProjectMember.Remove(projectMember);
            await _context.SaveChangesAsync();

            return Ok(projectMember);
        }

        private bool ProjectMemberExists(Guid id)
        {
            return _context.ProjectMember.Any(e => e.ProjectMemberId == id);
        }
    }
}