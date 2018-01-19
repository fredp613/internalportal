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
using Microsoft.AspNetCore.Cors;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/FundingOpportunityInternalUsers")]
   [EnableCors("CorsPolicy")]
    
    public class FundingOpportunityInternalUsersController : Controller
    {
        private readonly PortalContext _context;

        public FundingOpportunityInternalUsersController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/FundingOpportunityInternalUsers
        [HttpGet]
        public IEnumerable<FundingOpportunityInternalUser> GetFundingOpportunityInternalUser()
        {

            return _context.FundingOpportunityInternalUser.Include(iu => iu.InternalUser).Include(fo => fo.FundingOpportunity);
        }

        [HttpGet("GetByFundingOpportunityID/{id}")]
        public IEnumerable<FundingOpportunityInternalUser> GetByFundingOpportunityID([FromRoute] Guid id)
        {

            return _context.FundingOpportunityInternalUser.Include(iu => iu.InternalUser).Include(fo => fo.FundingOpportunity).Where(f=>f.FundingOpportunityId == id);
        }

      
        [HttpGet("GetWorkloadManagersForFundingOpportunity/{id}")]
        public IEnumerable<FundingOpportunityInternalUser> GetWorkloadManagersForFundingOpportunity([FromRoute] Guid id)
        {
            return _context.FundingOpportunityInternalUser.Where(u => _context.InternalUser.Any(x => x.InternalUserId == u.InternalUserId && x.IsWorkloadManager) && u.FundingOpportunityId == id);
        }



        [HttpGet]
        [Route("GetWorkloadManagerFundingOpportunities/{username}")]
        [ProducesResponseType(typeof(IEnumerable<FundingOpportunityInternalUser>), 200)]
        public async Task<IActionResult> GetWorkloadManagerFundingOpportunities([FromRoute] string username)
        //public IEnumerable<FundingOpportunity> GetWorkloadManagerFundingOpportunities([FromRoute] string username)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);

            var fos = _context.FundingOpportunityInternalUser.Where(u => u.InternalUserId == currentUser.InternalUserId).Select(x=>x.FundingOpportunityId);
            return Ok(_context.FundingOpportunity.Where(x => fos.Contains(x.FundingOpportunityId)));

        }
      
       
        [HttpGet]
        [Route("GetWorkloadManagerSubmissionReviewers/{username}")]
        public IEnumerable<Object> GetWorkloadManagerSubmissionReviewers([FromRoute] string username)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);

            var fos = _context.FundingOpportunityInternalUser.Where(u => u.InternalUserId == currentUser.InternalUserId);
            List<Object> foiu = new List<Object>(); 
            
            foreach (var fo in fos)
            {
                var foRec = _context.FundingOpportunity.SingleOrDefault(x => x.FundingOpportunityId == fo.FundingOpportunityId);
                var foName = foRec.TitleE + " - " + foRec.TitleF;

                var foids = _context.FundingOpportunityInternalUser.Where(f => f.FundingOpportunityId == fo.FundingOpportunityId);
                foreach (var foid in foids)
                {
                    var user = _context.InternalUser.SingleOrDefault(x => x.InternalUserId == foid.InternalUserId);
                    var userName = user.UserName;
                    if (userName != username && user.IsSubmissionReviewer)
                    {
                        var record = new
                        {
                            foid = foid.FundingOpportunityInternalUserId,
                            username = userName,
                            fundingOpportunityName = foName
                        };
                        foiu.Add(record);
                    }
                   
                    
                }
            }

            

            return foiu;
        }

    
        // GET: api/FundingOpportunityInternalUsers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityInternalUser), 200)]
        public async Task<IActionResult> GetFundingOpportunityInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityInternalUser = await _context.FundingOpportunityInternalUser.Include(iu => iu.InternalUser).Include(fo => fo.FundingOpportunity).SingleOrDefaultAsync(m => m.FundingOpportunityInternalUserId == id);

            if (fundingOpportunityInternalUser == null)
            {
                return NotFound();
            }

            return Ok(fundingOpportunityInternalUser);
        }

        // PUT: api/FundingOpportunityInternalUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFundingOpportunityInternalUser([FromRoute] Guid id, [FromBody] FundingOpportunityInternalUser fundingOpportunityInternalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fundingOpportunityInternalUser.FundingOpportunityInternalUserId)
            {
                return BadRequest();
            }

            _context.Entry(fundingOpportunityInternalUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FundingOpportunityInternalUserExists(id))
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

        // POST: api/FundingOpportunityInternalUsers
        [HttpPost]
        [ProducesResponseType(typeof(FundingOpportunityInternalUser), 200)]
        public async Task<IActionResult> PostFundingOpportunityInternalUser([FromBody] FundingOpportunityInternalUser fundingOpportunityInternalUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!FundingOpportunityInternalUserExistsWithoutId(fundingOpportunityInternalUser.InternalUserId, fundingOpportunityInternalUser.FundingOpportunityId))
            {
                _context.FundingOpportunityInternalUser.Add(fundingOpportunityInternalUser);
                await _context.SaveChangesAsync();
            }
           

            return Ok(fundingOpportunityInternalUser);
        }

        // DELETE: api/FundingOpportunityInternalUsers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(FundingOpportunityInternalUser), 200)]
        public async Task<IActionResult> DeleteFundingOpportunityInternalUser([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fundingOpportunityInternalUser = await _context.FundingOpportunityInternalUser.SingleOrDefaultAsync(m => m.FundingOpportunityInternalUserId == id);
            if (fundingOpportunityInternalUser == null)
            {
                return NotFound();
            }

            _context.FundingOpportunityInternalUser.Remove(fundingOpportunityInternalUser);
            await _context.SaveChangesAsync();

            return Ok(fundingOpportunityInternalUser);
        }

        private bool FundingOpportunityInternalUserExists(Guid id)
        {
            return _context.FundingOpportunityInternalUser.Any(e => e.FundingOpportunityInternalUserId == id);
        }
        private bool FundingOpportunityInternalUserExistsWithoutId(Guid internalUserId, Guid fundingOpportunityId)
        {
            return _context.FundingOpportunityInternalUser.Any(e => e.InternalUserId == internalUserId && e.FundingOpportunityId == fundingOpportunityId);
        }
    }
}