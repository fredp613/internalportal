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
    [Route("api/AccountContacts")]
    public class AccountContactsController : Controller
    {
        private readonly PortalContext _context;

        public AccountContactsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/AccountContacts
        [HttpGet]
        public IEnumerable<AccountContact> GetAccountContact()
        {
            return _context.AccountContact;
        }

        // GET: api/AccountContacts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AccountContact), 200)]
        public async Task<IActionResult> GetAccountContact([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountContact = await _context.AccountContact.SingleOrDefaultAsync(m => m.AccountContactId == id);

            if (accountContact == null)
            {
                return NotFound();
            }

            return Ok(accountContact);
        }

        // GET: api/AccountContacts/GetAccountsByContact/5
        [HttpGet("/GetAccountsByContact/{contactId}")]
       
        public IEnumerable<Account> GetAccountsByContact([FromRoute] Guid contactId)
        {
           
            return _context.AccountContact.Where(m => m.ContactId == contactId).Select(a => a.Account);
            
        }

        // PUT: api/AccountContacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountContact([FromRoute] Guid id, [FromBody] AccountContact accountContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accountContact.AccountContactId)
            {
                return BadRequest();
            }

            _context.Entry(accountContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountContactExists(id))
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

        // POST: api/AccountContacts
        [HttpPost]
        [ProducesResponseType(typeof(AccountContact), 200)]
        public async Task<IActionResult> PostAccountContact([FromBody] AccountContact accountContact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AccountContact.Add(accountContact);
            await _context.SaveChangesAsync();

            return Ok(accountContact);
        }

        // DELETE: api/AccountContacts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(AccountContact), 200)]
        public async Task<IActionResult> DeleteAccountContact([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountContact = await _context.AccountContact.SingleOrDefaultAsync(m => m.AccountContactId == id);
            if (accountContact == null)
            {
                return NotFound();
            }

            _context.AccountContact.Remove(accountContact);
            await _context.SaveChangesAsync();

            return Ok(accountContact);
        }

        private bool AccountContactExists(Guid id)
        {
            return _context.AccountContact.Any(e => e.AccountContactId == id);
        }
    }
}