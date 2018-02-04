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
    [Route("api/LogoutSessions")]
    public class LogoutSessionsController : Controller
    {
        private readonly ExternalUserContext _context;

        public LogoutSessionsController(ExternalUserContext context)
        {
            _context = context;
        }

        // GET: api/LogoutSessions
        [HttpGet]
        public IEnumerable<LogoutSession> GetLogoutSession()
        {
            return _context.LogoutSession;
        }

        // POST: api/LogoutSessions/
        [HttpPost]
        public bool GetLogoutSession([FromBody] User user)
        {
           
            var logoutSessions = _context.LogoutSession.Where(m => m.NameId == user.PAI);


            if (logoutSessions.ToList().Count == 0)
            {
                return false;
            } else
            {
                if (logoutSessions.ToList().Count > 1)
                {
                    _context.LogoutSession.RemoveRange(logoutSessions);

                } else
                {
                    _context.LogoutSession.Remove(logoutSessions.First());
                }

                _context.SaveChanges();

                return true;
            } 
            
   
        }
        
        // DELETE: api/LogoutSessions/5
        [HttpDelete("{nameid}")]
        public async Task<IActionResult> DeleteLogoutSession([FromRoute] string nameid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var logoutSession = await _context.LogoutSession.SingleOrDefaultAsync(m => m.NameId == nameid);
            if (logoutSession == null)
            {
                return NotFound();
            }

            _context.LogoutSession.Remove(logoutSession);
            await _context.SaveChangesAsync();

            return Ok(logoutSession);
        }

        private bool LogoutSessionExists(string nameid)
        {
            return _context.LogoutSession.Any(e => e.NameId == nameid);
        }
    }
}