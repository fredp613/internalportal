using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.GCIMS;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly PortalContext _context;
        private readonly GcimsContext _gcimsContext;

        public ProjectsController(PortalContext context, GcimsContext gcimsContext)
        {
            _context = context;
            _gcimsContext = gcimsContext;
        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> GetProject()
        {
            return _context.Project;
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }
            if (project.ProjectStatus.Equals(1))
            {
                GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, project);
                var status = gcimsHelper.GetProjectStatus();
                if (status.Equals(2))
                {
                    if (status == "Approved")
                    {
                        project.ProjectStatus = Status.Approved;
                    }
                    if (status == "Not Approved")
                    {
                        project.ProjectStatus = Status.NotApproved;
                    }                                      
                }
                
            }

            return Ok(project.ProjectStatus);
        }

        public async Task<Project> UpdateProject(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return project;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(project.ProjectId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProject([FromRoute] Guid id, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != project.ProjectId)
            {
                return BadRequest();
            }

            _context.Entry(project).State = EntityState.Modified;

            if (project.SubmitGcims)
            {
                GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, project);
                var newGCIMSProject = gcimsHelper.CreateGCIMSproject();
                project.GcimsProjectID = newGCIMSProject.Result.ProjectID;
                project.GcimsClientId = newGCIMSProject.Result.ClientID;
                project.GcimsContactId = newGCIMSProject.Result.tblApplication.ContactID;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
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

        // POST: api/Projects 
        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Project.Add(project);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
        }

        // POST: api/Projects/PostGCIMS 
        [HttpPost]
        [Route("PostGCIMS")]
        public async Task<IActionResult> PostGCIMS([FromBody] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = _context.Project.SingleOrDefault(p => p.ProjectId == id);

            GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, project);
            var newGCIMSProject = gcimsHelper.CreateGCIMSproject();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
           // return Ok(newGCIMSProject.Result);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            _context.Project.Remove(project);
            await _context.SaveChangesAsync();

            return Ok(project);
        }

        private bool ProjectExists(Guid id)
        {
            return _context.Project.Any(e => e.ProjectId == id);
        }
    }
}