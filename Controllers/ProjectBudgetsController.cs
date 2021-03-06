using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.Portal;
using InternalPortal.Models.Helpers;

namespace InternalPortal.Controllers
{
    public class FiscalYears
    {
        public string FiscalYear { get; set; }
        public double Amount { get; set; }
    }
    [Produces("application/json")]
    [Route("api/ProjectBudgets")]   
    public class ProjectBudgetsController : Controller
    {
        private readonly PortalContext _context;

        public ProjectBudgetsController(PortalContext context)
        {
            _context = context;
        }

        // GET: api/ProjectBudgets
        [HttpGet]
        public IEnumerable<ProjectBudget> GetProjectBudget()
        {
            return _context.ProjectBudget;
        }

        // GET: api/ProjectBudgets/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProjectBudget), 200)]
        public async Task<IActionResult> GetProjectBudget([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectBudget = await _context.ProjectBudget.SingleOrDefaultAsync(m => m.ProjectBudgetId == id);

            if (projectBudget == null)
            {
                return NotFound();
            }

            return Ok(projectBudget);
        }

        [HttpPost("GetByProject")]
        public IEnumerable<ProjectBudget> GetByProject([FromBody] Project project)
        {
            return _context.ProjectBudget.Where(s => s.ProjectID == project.ProjectId);
        }
        [HttpPost("GetFiscalYears")]
        public IEnumerable<FiscalYears> GetFiscalYears([FromBody] Project project)
        {
            var fys = FiscalYear.GetFiscalYearByDateTimeRange(project.StartDate, project.EndDate);
            List<FiscalYears> fiscalYears = new List<FiscalYears>();
            foreach (var f in fys)
            {
                var fy = new FiscalYears
                {
                    FiscalYear = f
                };
                fiscalYears.Add(fy);
            }
            return fiscalYears;
        }
        [HttpPost("GetFiscalYearSummary")]
        public IEnumerable<FiscalYears> GetFiscalYearSummary([FromBody] Project project)
        {
            var fys = FiscalYear.GetFiscalYearByDateTimeRange(project.StartDate, project.EndDate);
            List<FiscalYears> fiscalYears = new List<FiscalYears>();
            foreach (var f in fys)
            {
                double amount = _context.ProjectBudget.
                    Where(p => p.FiscalYear == f && p.ProjectID == project.ProjectId && p.FundingOrganization == "Justice Canada")
                    .Sum(a=>a.Amount);
                var fy = new FiscalYears
                {
                    FiscalYear = f,
                    Amount = (double)amount
                };
                fiscalYears.Add(fy);
                
            }
            return fiscalYears;
        }

        // PUT: api/ProjectBudgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectBudget([FromRoute] Guid id, [FromBody] ProjectBudget projectBudget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != projectBudget.ProjectBudgetId)
            {
                return BadRequest();
            }

            _context.Entry(projectBudget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectBudgetExists(id))
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

        // POST: api/ProjectBudgets
        [HttpPost]
        [ProducesResponseType(typeof(ProjectBudget), 200)]
        public async Task<IActionResult> PostProjectBudget([FromBody] ProjectBudget projectBudget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProjectBudget.Add(projectBudget);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetProjectBudget", new { id = projectBudget.ProjectBudgetId }, projectBudget);
            return Ok(projectBudget);
        }

        // DELETE: api/ProjectBudgets/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProjectBudget), 200)]
        public async Task<IActionResult> DeleteProjectBudget([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var projectBudget = await _context.ProjectBudget.SingleOrDefaultAsync(m => m.ProjectBudgetId == id);
            if (projectBudget == null)
            {
                return NotFound();
            }

            _context.ProjectBudget.Remove(projectBudget);
            await _context.SaveChangesAsync();

            return Ok(projectBudget);
        }

        private bool ProjectBudgetExists(Guid id)
        {
            return _context.ProjectBudget.Any(e => e.ProjectBudgetId == id);
        }
    }
}