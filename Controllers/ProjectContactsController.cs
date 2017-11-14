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
    [Route("api/ProjectContacts")]
    public class ProjectContactsController : Controller
    {
        private readonly PortalContext _context;

        public ProjectContactsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectContacts
        [HttpGet]
        public IEnumerable<ProjectContact> GetProjectContact()
        {
            return _context.ProjectContact;
        }

        // GET: api/ProjectContacts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectContact), 200)]
        public async Task<IActionResult> GetProjectContact([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectContact = await _context.ProjectContact.SingleOrDefaultAsync(m => m.ProjectContactId == id);

            if (projectContact == null)
            {
                return NotFound();
            }

            return Ok(projectContact);
        }

        [HttpPost("GetAdditionalContacts")]
        public IEnumerable<ProjectContact> GetContactProjects([FromBody] ProjectContact primaryProjectContact)
        {
            var primaryContact = _context.Project.SingleOrDefault(p => p.ProjectId == primaryProjectContact.ProjectId);
            var projectContacts = _context.ProjectContact.Where(c => c.ProjectId == primaryProjectContact.ProjectId && c.ProjectContactId != primaryContact.PrimaryProjectContactId).ToList();
            return projectContacts;
        }

        // PUT: api/ProjectContacts/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutProjectContact([FromRoute] Guid id, [FromBody] ProjectContact projectContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectContact.ProjectContactId)
            {
                return BadRequest();
            }

            _context.Entry(projectContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectContactExists(id))
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

        // POST: api/ProjectContacts
        [HttpPost]
        [ProducesResponseType(typeof(ProjectContact), 200)]
        public async Task<IActionResult> PostProjectContact([FromBody] ProjectContact projectContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectContact.Add(projectContact);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectContact", new { id = projectContact.ProjectContactId }, projectContact);
            return Ok(projectContact);
        }

        // DELETE: api/ProjectContacts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectContact), 200)]
        public async Task<IActionResult> DeleteProjectContact([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectContact = await _context.ProjectContact.SingleOrDefaultAsync(m => m.ProjectContactId == id);
            if (projectContact == null)
            {
                return NotFound();
            }

            _context.ProjectContact.Remove(projectContact);
            await _context.SaveChangesAsync();

            return Ok(projectContact);
        }

        private bool ProjectContactExists(Guid id)
        {
            return _context.ProjectContact.Any(e => e.ProjectContactId == id);
        }
    }
}