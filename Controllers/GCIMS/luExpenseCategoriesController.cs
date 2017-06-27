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
    [Route("api/luExpenseCategories")]
    public class luExpenseCategoriesController : Controller
    {
        private readonly GcimsContext _context;

        public luExpenseCategoriesController(GcimsContext context)
        {
            _context = context;
        }

        // GET: api/luExpenseCategories
        [HttpGet]
        public IEnumerable<luExpenseCategories> GetluExpenseCategories()
        {
            return _context.luExpenseCategories;
        }

        // GET: api/luExpenseCategories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetluExpenseCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var luExpenseCategories = await _context.luExpenseCategories.SingleOrDefaultAsync(m => m.ExpenseCategoryID == id);

            if (luExpenseCategories == null)
            {
                return NotFound();
            }

            return Ok(luExpenseCategories);
        }

        // PUT: api/luExpenseCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutluExpenseCategories([FromRoute] int id, [FromBody] luExpenseCategories luExpenseCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != luExpenseCategories.ExpenseCategoryID)
            {
                return BadRequest();
            }

            _context.Entry(luExpenseCategories).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!luExpenseCategoriesExists(id))
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

        // POST: api/luExpenseCategories
        [HttpPost]
        public async Task<IActionResult> PostluExpenseCategories([FromBody] luExpenseCategories luExpenseCategories)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.luExpenseCategories.Add(luExpenseCategories);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetluExpenseCategories", new { id = luExpenseCategories.ExpenseCategoryID }, luExpenseCategories);
        }

        // DELETE: api/luExpenseCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteluExpenseCategories([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var luExpenseCategories = await _context.luExpenseCategories.SingleOrDefaultAsync(m => m.ExpenseCategoryID == id);
            if (luExpenseCategories == null)
            {
                return NotFound();
            }

            _context.luExpenseCategories.Remove(luExpenseCategories);
            await _context.SaveChangesAsync();

            return Ok(luExpenseCategories);
        }

        private bool luExpenseCategoriesExists(int id)
        {
            return _context.luExpenseCategories.Any(e => e.ExpenseCategoryID == id);
        }
    }
}