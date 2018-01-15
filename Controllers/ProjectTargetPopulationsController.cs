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
    [Route("api/ProjectTargetPopulations")]
    public class ProjectTargetPopulationsController : Controller
    {
        private readonly PortalContext _context;

        public ProjectTargetPopulationsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectTargetPopulations
        [HttpGet]
        public IEnumerable<ProjectTargetPopulation> GetProjectTargetPopulation()
        {
            return _context.ProjectTargetPopulation;
        }

        // GET: api/ProjectTargetPopulations/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectTargetPopulation), 200)]
        public async Task<IActionResult> GetProjectTargetPopulation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTargetPopulation = await _context.ProjectTargetPopulation.SingleOrDefaultAsync(m => m.ProjectTargetPopulationId == id);

            if (projectTargetPopulation == null)
            {
                return NotFound();
            }

            return Ok(projectTargetPopulation);
        }

        // PUT: api/ProjectTargetPopulations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectTargetPopulation([FromRoute] Guid id, [FromBody] ProjectTargetPopulation projectTargetPopulation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectTargetPopulation.ProjectTargetPopulationId)
            {
                return BadRequest();
            }

            _context.Entry(projectTargetPopulation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectTargetPopulationExists(id))
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

        // POST: api/ProjectTargetPopulations
        [HttpPost]
        [ProducesResponseType(typeof(ProjectTargetPopulation), 200)]
        public async Task<IActionResult> PostProjectTargetPopulation([FromBody] ProjectTargetPopulation projectTargetPopulation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectTargetPopulation.Add(projectTargetPopulation);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProjectTargetPopulation", new { id = projectTargetPopulation.ProjectTargetPopulationId }, projectTargetPopulation);
            return Ok(projectTargetPopulation);
        }

        // DELETE: api/ProjectTargetPopulations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectTargetPopulation), 200)]
        public async Task<IActionResult> DeleteProjectTargetPopulation([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectTargetPopulation = await _context.ProjectTargetPopulation.SingleOrDefaultAsync(m => m.ProjectTargetPopulationId == id);
            if (projectTargetPopulation == null)
            {
                return NotFound();
            }

            _context.ProjectTargetPopulation.Remove(projectTargetPopulation);
            await _context.SaveChangesAsync();

            return Ok(projectTargetPopulation);
        }

        private bool ProjectTargetPopulationExists(Guid id)
        {
            return _context.ProjectTargetPopulation.Any(e => e.ProjectTargetPopulationId == id);
        }
    }
}