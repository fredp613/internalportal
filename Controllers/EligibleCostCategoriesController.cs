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
    [Route("api/EligibleCostCategories")]
    public class EligibleCostCategoriesController : Controller
    {
        private readonly PortalContext _context;

        public EligibleCostCategoriesController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/EligibleCostCategories
        [HttpGet]
        public IEnumerable<EligibleCostCategory> GetEligibleCostCategory()
        {
            return _context.EligibleCostCategory;
        }

        // GET: api/EligibleCostCategories/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EligibleCostCategory), 200)]
        public async Task<IActionResult> GetEligibleCostCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibleCostCategory = await _context.EligibleCostCategory.SingleOrDefaultAsync(m => m.EligibleCostCategoryId == id);

            if (eligibleCostCategory == null)
            {
                return NotFound();
            }

            return Ok(eligibleCostCategory);
        }

        // PUT: api/EligibleCostCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEligibleCostCategory([FromRoute] Guid id, [FromBody] EligibleCostCategory eligibleCostCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eligibleCostCategory.EligibleCostCategoryId)
            {
                return BadRequest();
            }

            _context.Entry(eligibleCostCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EligibleCostCategoryExists(id))
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

        // POST: api/EligibleCostCategories
        [HttpPost]
        [ProducesResponseType(typeof(EligibleCostCategory), 200)]
        public async Task<IActionResult> PostEligibleCostCategory([FromBody] EligibleCostCategory eligibleCostCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EligibleCostCategory.Add(eligibleCostCategory);
            await _context.SaveChangesAsync();

            return Ok(eligibleCostCategory);
        }

        // DELETE: api/EligibleCostCategories/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EligibleCostCategory), 200)]
        public async Task<IActionResult> DeleteEligibleCostCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibleCostCategory = await _context.EligibleCostCategory.SingleOrDefaultAsync(m => m.EligibleCostCategoryId == id);
            if (eligibleCostCategory == null)
            {
                return NotFound();
            }

            _context.EligibleCostCategory.Remove(eligibleCostCategory);
            await _context.SaveChangesAsync();

            return Ok(eligibleCostCategory);
        }

        private bool EligibleCostCategoryExists(Guid id)
        {
            return _context.EligibleCostCategory.Any(e => e.EligibleCostCategoryId == id);
        }
    }
}