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
using InternalPortal.Models.Portal.Program;

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

        [HttpGet("GetInternalUsersExcludingRequester/{username}")]
        public IEnumerable<InternalUser> GetInternalUsersExcludingRequester([FromRoute] string userName)
        {
            var users = _context.InternalUser.Where(u => u.UserName != userName).OrderByDescending(u => u.UpdatedOn);

            return users;
        }

        // GET: api/InternalUsers
        [HttpGet("GetBusinessUsers")]
        public IEnumerable<InternalUser> GetBusinessUsers()
        {          
            return _context.InternalUser.Where(u => u.IsSubmissionReviewer).OrderByDescending(u => u.UpdatedOn);          
        }

        // GET: api/InternalUsers/CanBeDestroyed/1
        [HttpGet("CanBeDestroyed/{id}")]
        public bool CanBeDestroyed([FromRoute] Guid id)
        {

            //user has one or more apps assigned
            var projects = _context.Project.Where(c => c.CurrentOwner == id);

            if (projects.Count() > 0)
            {
                return false;
            }

            //user is the only wm on a F.O
            var currentUser = _context.InternalUser.Find(id); 

            if (currentUser.IsWorkloadManager)
            {
                //select FOs that current user is a wm
                var foid = _context.FundingOpportunityInternalUser.Where(x => x.InternalUserId == id);
                //for each FOs count the number of WM
                foreach (var f in foid)
                {
                    var foius = _context.FundingOpportunityInternalUser.Where(x => x.FundingOpportunityId == f.FundingOpportunityId);
                    if (foius.Count() == 1)
                    {

                        return false;

                    }
                }

            }

            return true;
            

            
        }

        // GET: api/InternalUsers
        [HttpGet("GetWorkloadManagers")]
        public IEnumerable<InternalUser> GetWorkloadManagers()
        {
            //var test = _context.FundingOpportunityInternalUser.Where(iu => _context.InternalUser.Any(i => i.IsWorkloadManager && i.InternalUserId == iu.InternalUserId)); //.Select(u => u.InternalUserId);
            //var wms = _context.InternalUser.Where(iu => test.Any(x => x.InternalUserId == iu.InternalUserId));

            //return wms; /*_context.InternalUser.Where(u => _context.FundingOpportunityInternalUser.Any(i => i.InternalUserId == u.InternalUserId) && u.IsWorkloadManager);*/
            return _context.InternalUser.Where(iu => iu.IsWorkloadManager);
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

                if (internalUser.DefaultFundingOpportunity != null)
                {

                    var foiu = new FundingOpportunityInternalUser
                    {
                        FundingOpportunityId = internalUser.DefaultFundingOpportunity,
                        InternalUserId = internalUser.InternalUserId

                    };

                    _context.FundingOpportunityInternalUser.Add(foiu);
                    await _context.SaveChangesAsync();

                }
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

            if (internalUser.DefaultFundingOpportunity != Guid.Empty && internalUser.IsWorkloadManager)
            {
                var foiu = new FundingOpportunityInternalUser
                {
                    FundingOpportunityId = internalUser.DefaultFundingOpportunity,
                    InternalUserId = internalUser.InternalUserId

                };

                _context.FundingOpportunityInternalUser.Add(foiu);
                await _context.SaveChangesAsync();

            }

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
