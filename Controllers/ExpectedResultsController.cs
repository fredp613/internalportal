using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal.Program;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/ExpectedResults")]
    public class ExpectedResultsController : Controller
    {
        private readonly PortalContext _context;

        public ExpectedResultsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ExpectedResults
        [HttpGet]
        public IEnumerable<ExpectedResult> GetExpectedResult()
        {
       
            return _context.ExpectedResult;
        }

        // GET: api/ExpectedResults/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpectedResult([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expectedResult = await _context.ExpectedResult.SingleOrDefaultAsync(m => m.ExpectedResultId == id);

            if (expectedResult == null)
            {
                return NotFound();
            }

            return Ok(expectedResult);
        }

        // PUT: api/ExpectedResults/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpectedResult([FromRoute] Guid id, [FromBody] ExpectedResult expectedResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != expectedResult.ExpectedResultId)
            {
                return BadRequest();
            }

            _context.Entry(expectedResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpectedResultExists(id))
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

        // POST: api/ExpectedResults
        [HttpPost]
        public async Task<IActionResult> PostExpectedResult([FromBody] ExpectedResult expectedResult)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ExpectedResult.Add(expectedResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpectedResult", new { id = expectedResult.ExpectedResultId }, expectedResult);
        }

        // DELETE: api/ExpectedResults/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpectedResult([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var expectedResult = await _context.ExpectedResult.SingleOrDefaultAsync(m => m.ExpectedResultId == id);
            if (expectedResult == null)
            {
                return NotFound();
            }

            _context.ExpectedResult.Remove(expectedResult);
            await _context.SaveChangesAsync();

            return Ok(expectedResult);
        }

        private bool ExpectedResultExists(Guid id)
        {
            return _context.ExpectedResult.Any(e => e.ExpectedResultId == id);
        }
    }
}