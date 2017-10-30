using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using System.Collections;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Contacts")]
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
            var user = _context.User.SingleOrDefault(u => u.PAI == user1.PAI);
            var contact = await _context.Contact.SingleOrDefaultAsync(m => m.CreatedByUserId == user.UserId);
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

            if (contact.SharedSecretAnswer == contact1.SharedSecretAnswer && contact.DateOfBirth == contact1.DateOfBirth)
            {
                var user = await _context.User.SingleOrDefaultAsync(u => u.UserId == contact1.UpdatedByUserId);
                user.ContactId = contact.ContactId;
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(contact);
            }
            return NotFound();
        }
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

            if (contact.DateOfBirth == dob)
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