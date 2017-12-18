using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal;
using System.Diagnostics;
using InternalPortal.Models.Helpers;

namespace InternalPortal.Controllers
{
  
    [Produces("application/json")]
    [Route("api/InternalUsers")]
    public class InternalUsersController : Controller
    {
        private readonly PortalContext _context;

        public InternalUsersController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/InternalUsers
        [HttpGet]
        public IEnumerable<InternalUser> GetInternalUser()
        {
            var users = _context.InternalUser.OrderByDescending(u => u.UpdatedOn);
             
            return users;           
        }
        // GET: api/InternalUsers
        [HttpGet("GetBusinessUsers")]
        public IEnumerable<InternalUser> GetBusinessUsers()
        {
          
            return _context.InternalUser.Where(u => u.IsSubmissionReviewer).OrderByDescending(u => u.UpdatedOn);          
        }
        // GET: api/InternalUsers
        [HttpGet("GetAssignmentList/{username}")]
        public IEnumerable<InternalUser> GetAssignmentList([FromRoute] string username)
        {
            List<InternalUser> users = new List<InternalUser>();
            users.AddRange(_context.InternalUser.Where(u => u.IsSubmissionReviewer).OrderByDescending(u => u.UpdatedOn));
            users.Add(_context.InternalUser.SingleOrDefault(u => u.UserName == username));
           
            return users;
        }

        // GET: api/InternalUsers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InternalUser), 200)]
        public async Task<IActionResult> GetInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalUser = await _context.InternalUser
                                           .Include(iu => iu.FundingOpportunityInternalUsers)                                             
                                            .SingleOrDefaultAsync(m => m.InternalUserId == id);
          
            if (internalUser == null)
            {
                return NotFound();
            }

            return Ok(internalUser);
        }

        // GET: api/InternalUsers/GetByUserName/admin
    
        [HttpGet]
        [Route("GetByUserName/{username}")]
        [ProducesResponseType(typeof(InternalUser), 200)]
        public async Task<IActionResult> GetByUserName([FromRoute] string username)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalUser = await  _context.InternalUser                                           
                                           .Include(iu => iu.FundingOpportunityInternalUsers)                                           
                                            .SingleOrDefaultAsync(m => m.UserName == username);
         

            if (internalUser == null)
            {
                return NotFound();
            }

            return Ok(internalUser);
        }

        // PUT: api/InternalUsers/5
        [HttpPut("{id}")]

        public async Task<IActionResult> PutInternalUser([FromRoute] Guid id, [FromBody] InternalUser internalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != internalUser.InternalUserId)
            {
                return BadRequest();
            }
            internalUser.UpdatedOn = DateTime.Now;

            _context.Entry(internalUser).State = EntityState.Modified;
           
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InternalUserExists(id))
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
      
        // POST: api/InternalUsers
        [HttpPost]
        [ProducesResponseType(typeof(InternalUser), 200)]
        public async Task<IActionResult> PostInternalUser([FromBody] InternalUser internalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            internalUser.UpdatedOn = DateTime.Now;
            internalUser.CreatedOn = DateTime.Now;

            _context.InternalUser.Add(internalUser);
           
            await _context.SaveChangesAsync();

            return Ok(internalUser);
        }

        // DELETE: api/InternalUsers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(InternalUser), 200)]
        public async Task<IActionResult> DeleteInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var internalUser = await _context.InternalUser.SingleOrDefaultAsync(m => m.InternalUserId == id);
            if (internalUser == null)
            {
                return NotFound();
            }

            _context.InternalUser.Remove(internalUser);
            await _context.SaveChangesAsync();

            return Ok(internalUser);
        }

        private bool InternalUserExists(Guid id)
        {
            return _context.InternalUser.Any(e => e.InternalUserId == id);
        }
    }
}
