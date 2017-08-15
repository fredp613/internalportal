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
    [Route("api/InternalUserRoles")]
    public class InternalUserRolesController : Controller
    {
        private readonly PortalContext _context;

        public InternalUserRolesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/InternalUserRoles
        [HttpGet]
        public IEnumerable<InternalUserRole> GetInternalUserRole()
        {
            return _context.InternalUserRole;
        }

        // GET: api/InternalUserRoles/5
        [HttpGet("{id}")]        
        public async Task<IActionResult> GetInternalUserRole([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalUserRole = await _context.InternalUserRole.SingleOrDefaultAsync(m => m.InternalUserRoleId == id);

            if (internalUserRole == null)
            {
                return NotFound();
            }

            return Ok(internalUserRole);
        }

        // PUT: api/InternalUserRoles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInternalUserRole([FromRoute] Guid id, [FromBody] InternalUserRole internalUserRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internalUserRole.InternalUserRoleId)
            {
                return BadRequest();
            }

            _context.Entry(internalUserRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternalUserRoleExists(id))
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

        // POST: api/InternalUserRoles
        [HttpPost]
        public async Task<IActionResult> PostInternalUserRole([FromBody] InternalUserRole internalUserRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.InternalUserRole.Add(internalUserRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInternalUserRole", new { id = internalUserRole.InternalUserRoleId }, internalUserRole);
        }

        // DELETE: api/InternalUserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInternalUserRole([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalUserRole = await _context.InternalUserRole.SingleOrDefaultAsync(m => m.InternalUserId == id);
            if (internalUserRole == null)
            {
                return NotFound();
            }

            _context.InternalUserRole.Remove(internalUserRole);
            await _context.SaveChangesAsync();

            return Ok(internalUserRole);
        }

        private bool InternalUserRoleExists(Guid id)
        {
            return _context.InternalUserRole.Any(e => e.InternalUserId == id);
        }
    }
}
