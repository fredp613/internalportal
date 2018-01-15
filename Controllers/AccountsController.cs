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
    [Route("api/Accounts")]
    public class AccountsController : Controller
    {
        private readonly PortalContext _context;

        public AccountsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<Account> GetAccount()
        {
            return _context.Account;
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Account), 200)]
        public async Task<IActionResult> GetAccount([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.Account.SingleOrDefaultAsync(m => m.AccountId == id);

            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // GET: api/Accounts/5
        [HttpGet("AccountsByContact/{contactid}")]      
        public IEnumerable<Account> GetAccountsByContact([FromRoute] Guid contactid)
        {

            var accountIds = _context.Project.Where(c => c.ContactId == contactid).Select(c => c.AccountId).Distinct();
            List<Account> accounts = new List<Account>();
            foreach (var a in accountIds)
            {
                var account = _context.Account.SingleOrDefault(x => x.AccountId == (Guid)a);
                if (account != null)
                {
                    accounts.Add(account);
                }
               
            }
            return accounts;
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount([FromRoute] Guid id, [FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.AccountId)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        [HttpPost]
        [ProducesResponseType(typeof(Account), 200)]
        public async Task<IActionResult> PostAccount([FromBody] Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Account.Add(account);
            await _context.SaveChangesAsync();

            return Ok( account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Account), 200)]
        public async Task<IActionResult> DeleteAccount([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = await _context.Account.SingleOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Account.Remove(account);
            await _context.SaveChangesAsync();

            return Ok(account);
        }

        private bool AccountExists(Guid id)
        {
            return _context.Account.Any(e => e.AccountId == id);
        }
    }
}