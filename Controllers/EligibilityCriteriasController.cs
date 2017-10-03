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
    [Route("api/EligibilityCriterias")]
    public class EligibilityCriteriasController : Controller
    {
        private readonly PortalContext _context;

        public EligibilityCriteriasController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/EligibilityCriterias
        [HttpGet]
        public IEnumerable<EligibilityCriteria> GetEligibilityCriteria()
        {
            return _context.EligibilityCriteria;
        }

        // GET: api/EligibilityCriterias/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EligibilityCriteria), 200)]
        public async Task<IActionResult> GetEligibilityCriteria([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibilityCriteria = await _context.EligibilityCriteria.SingleOrDefaultAsync(m => m.EligibilityCriteriaId == id);

            if (eligibilityCriteria == null)
            {
                return NotFound();
            }

            return Ok(eligibilityCriteria);
        }

      

        // PUT: api/EligibilityCriterias/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEligibilityCriteria([FromRoute] Guid id, [FromBody] EligibilityCriteria eligibilityCriteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eligibilityCriteria.EligibilityCriteriaId)
            {
                return BadRequest();
            }

            _context.Entry(eligibilityCriteria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EligibilityCriteriaExists(id))
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

        // POST: api/EligibilityCriterias
        [HttpPost]
        [ProducesResponseType(typeof(EligibilityCriteria), 200)]
        public async Task<IActionResult> PostEligibilityCriteria([FromBody] EligibilityCriteria eligibilityCriteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.EligibilityCriteria.Add(eligibilityCriteria);
            await _context.SaveChangesAsync();

            return Ok(eligibilityCriteria);
        }

        // DELETE: api/EligibilityCriterias/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EligibilityCriteria), 200)]
        public async Task<IActionResult> DeleteEligibilityCriteria([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var eligibilityCriteria = await _context.EligibilityCriteria.SingleOrDefaultAsync(m => m.EligibilityCriteriaId == id);
            if (eligibilityCriteria == null)
            {
                return NotFound();
            }

            _context.EligibilityCriteria.Remove(eligibilityCriteria);
            await _context.SaveChangesAsync();

            return Ok(eligibilityCriteria);
        }

        private bool EligibilityCriteriaExists(Guid id)
        {
            return _context.EligibilityCriteria.Any(e => e.EligibilityCriteriaId == id);
        }
    }
}