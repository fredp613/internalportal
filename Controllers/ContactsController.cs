using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using System.Collections;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Contacts")]
    //[Authorize]
    public class ContactsController : Controller
    {
        private readonly PortalContext _context;

        public ContactsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public IEnumerable<Contact> GetContact()
        {
            return _context.Contact;
        }
        [HttpGet("getbyemail/{email}")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> GetContactEmail([FromRoute] string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var existingContact = await _context.Contact.SingleOrDefaultAsync(m => m.Email == email);
            if (existingContact == null)
            {
                return NotFound();
            }
            return Ok(existingContact);
        }

        [HttpGet("getbyuserid/{userid}")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> GetContactByUserId([FromRoute] Guid userid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.CreatedByUserId == userid);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPost("getbypai")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> GetContactByPAI([FromBody] User user1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _context.User.SingleOrDefaultAsync(u => u.PAI == user1.PAI);
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == user.ContactId);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }


        [HttpPost("ConfirmSecret")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> ConfirmSecret([FromBody] Contact contact1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contact = await _context.Contact.SingleOrDefaultAsync(c => c.ContactId == contact1.ContactId);

            if (contact == null)
            {
                return NotFound();
            }

            if (contact.SharedSecretAnswer == contact1.SharedSecretAnswer && contact.MemorableDate == (DateTime)contact1.MemorableDate)
            {
                var user = await _context.User.SingleOrDefaultAsync(u => u.UserId == contact1.UpdatedByUserId);
                user.ContactId = contact.ContactId;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }
        //later, destroy this route
        [HttpGet("dob/{id}/{dob}")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> ConfirmDob([FromRoute] Guid id, [FromRoute] DateTime dob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contact = await _context.Contact.SingleOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            if (contact.MemorableDate == dob)
            {
                return Ok(contact);
            }
            return NotFound();
        }

        [HttpGet("memorabledate/{id}/{memorabledate}")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> ConfirmMemorableDate([FromRoute] Guid id, [FromRoute] DateTime memorableDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var contact = await _context.Contact.SingleOrDefaultAsync(c => c.ContactId == id);

            if (contact == null)
            {
                return NotFound();
            }

            if (contact.MemorableDate == memorableDate)
            {
                return Ok(contact);
            }
            return NotFound();
        }


        // GET: api/Contacts/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> GetContact([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            var pais = _context.User.Where(c => c.ContactId == id).Select(c => c.PAI);
            var paiStr = ""; 
            foreach (var pai in pais)
            {
                paiStr += (pai + " ");
            }

            contact.PAI = paiStr;

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(contact);
        }




        // PUT: api/Contacts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact([FromRoute] Guid id, [FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contact.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
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

        // POST: api/Contacts
        [HttpPost]
        [ProducesResponseType(typeof(Contact), 200)]

        public async Task<IActionResult> PostContact([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Contact.Add(contact);
            

            User user = _context.User.SingleOrDefault(u => u.UserId == contact.CreatedByUserId);
            user.ContactId = contact.ContactId;
            _context.Entry(user).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Contact), 200)]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.ContactId == id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contact);
            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        private bool ContactExists(Guid id)
        {
            return _context.Contact.Any(e => e.ContactId == id);
        }
    }
}