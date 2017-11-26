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
    [Route("api/tblClients")]
    public class tblClientsController : Controller
    {
        private readonly GcimsContext _context;

        public tblClientsController(GcimsContext context)
        {
            _context = context;
        }

        // GET: api/tblClients
        [HttpGet]
        public IEnumerable<tblClients> GettblClients()
        {
            return _context.tblClients;
        }

        // GET: api/tblClients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettblClients([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblClients = await _context.tblClients.SingleOrDefaultAsync(m => m.ClientID == id);

            if (tblClients == null)
            {
                return NotFound();
            }

            return Ok(tblClients);
        }

        //// PUT: api/tblClients/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PuttblClients([FromRoute] string id, [FromBody] tblClients tblClients)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != tblClients.ClientID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblClients).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!tblClientsExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/tblClients
        //[HttpPost]
        //public async Task<IActionResult> PosttblClients([FromBody] tblClients tblClients)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.tblClients.Add(tblClients);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GettblClients", new { id = tblClients.ClientID }, tblClients);
        //}

        //// DELETE: api/tblClients/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletetblClients([FromRoute] string id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var tblClients = await _context.tblClients.SingleOrDefaultAsync(m => m.ClientID == id);
        //    if (tblClients == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.tblClients.Remove(tblClients);
        //    await _context.SaveChangesAsync();

        //    return Ok(tblClients);
        //}

        private bool tblClientsExists(string id)
        {
            return _context.tblClients.Any(e => e.ClientID == id);
        }
    }
}