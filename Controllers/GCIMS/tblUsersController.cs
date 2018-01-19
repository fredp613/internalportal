using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;

namespace InternalPortal.Controllers.GCIMS
{
    [Produces("application/json")]
    [Route("api/tblUsers")]
    public class tblUsersController : Controller
    {
        private readonly GcimsContext _context;

        public tblUsersController(GcimsContext context)
        {
            _context = context;
        }

        // GET: api/tblUsers
        [HttpGet]
        public IEnumerable<tblUsers> GettblUsers()
        {
            return _context.tblUsers.Where(u => u.Active);
        }

        // GET: api/tblUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettblUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblUsers = await _context.tblUsers.SingleOrDefaultAsync(m => m.UserID == id);

            if (tblUsers == null)
            {
                return NotFound();
            }

            return Ok(tblUsers);
        }
        /**
        // PUT: api/tblUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblUsers([FromRoute] int id, [FromBody] tblUsers tblUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblUsers.UserID)
            {
                return BadRequest();
            }

            _context.Entry(tblUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblUsersExists(id))
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

        // POST: api/tblUsers
        [HttpPost]
        public async Task<IActionResult> PosttblUsers([FromBody] tblUsers tblUsers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.tblUsers.Add(tblUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettblUsers", new { id = tblUsers.UserID }, tblUsers);
        }

        // DELETE: api/tblUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblUsers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblUsers = await _context.tblUsers.SingleOrDefaultAsync(m => m.UserID == id);
            if (tblUsers == null)
            {
                return NotFound();
            }

            _context.tblUsers.Remove(tblUsers);
            await _context.SaveChangesAsync();

            return Ok(tblUsers);
        }

        private bool tblUsersExists(int id)
        {
            return _context.tblUsers.Any(e => e.UserID == id);
        } **/
    }
}