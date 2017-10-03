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
    [Route("api/CostCategories")]
    public class CostCategoriesController : Controller
    {
        private readonly PortalContext _context;

        public CostCategoriesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/CostCategories
        [HttpGet]
        
        public IEnumerable<CostCategory> GetCostCategory()
        {
            return _context.CostCategory;
        }

        // GET: api/CostCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CostCategory), 200)]
        public async Task<IActionResult> GetCostCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var costCategory = await _context.CostCategory.SingleOrDefaultAsync(m => m.CostCategoryId == id);

            if (costCategory == null)
            {
                return NotFound();
            }

            return Ok(costCategory);
        }

        // PUT: api/CostCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCostCategory([FromRoute] Guid id, [FromBody] CostCategory costCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != costCategory.CostCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(costCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CostCategoryExists(id))
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

        // POST: api/CostCategories
        [HttpPost]
        public async Task<IActionResult> PostCostCategory([FromBody] CostCategory costCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CostCategory.Add(costCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCostCategory", new { id = costCategory.CostCategoryId }, costCategory);
        }

        // DELETE: api/CostCategories/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CostCategory), 200)]
        public async Task<IActionResult> DeleteCostCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var costCategory = await _context.CostCategory.SingleOrDefaultAsync(m => m.CostCategoryId == id);
            if (costCategory == null)
            {
                return NotFound();
            }

            _context.CostCategory.Remove(costCategory);
            await _context.SaveChangesAsync();

            return Ok(costCategory);
        }

        private bool CostCategoryExists(Guid id)
        {
            return _context.CostCategory.Any(e => e.CostCategoryId == id);
        }
    }
}