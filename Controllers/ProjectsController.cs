using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using InternalPortal.Models.GCIMS;
using InternalPortal.Models.Helpers;
using InternalPortal.Models.Portal.Implementations;
using InternalPortal.Models.Portal.Interfaces;
using InternalPortal.Models.Portal;
using System.Linq;

namespace InternalPortal.Controllers
{
    public struct Calcs
    {
        public int Count;
    }
  
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly PortalContext _context;
        private readonly GcimsContext _gcimsContext;
        private UnitOfWork _unitOfWork;
       

        //public ProjectsController(PortalContext context, GcimsContext gcimsContext)
        //{
        //    _context = context;
        //    _gcimsContext = gcimsContext;
        //    _unitOfWork = new UnitOfWork(_context);
        //}
        public ProjectsController(PortalContext context)
        {
            _context = context;
            
          //  _Language = this.RouteData.Values["lang"].ToString().ToUpper();
            _unitOfWork = new UnitOfWork(_context, "EN");

        }

        // GET: api/Projects
        [HttpGet]
        public IEnumerable<Project> GetProject()
        {
            return _unitOfWork.Projects.GetAll();
        }
        [HttpGet("GetProjectsByContact")]
        public IEnumerable<Project> GetProjectsByContact([FromBody] User user)
        {
            return _context.Project.Where(c => c.ContactId == user.ContactId).OrderByDescending(c => c.ExternalUpdatedOn);

        }


        [HttpPost("GetContactProjects")]
        public IEnumerable<Project> GetContactProjects([FromBody] User user)
        {

            return _context.Project.Where(c => c.ContactId == user.ContactId).OrderByDescending(c => c.ExternalUpdatedOn);
        }

        [HttpPost("GetContactProjectsCount")]
        public Calcs GetContactProjectsCount([FromBody] User user)
        {
            var calc = new Calcs();
            calc.Count = 0;
            var projects =  _context.Project.Where(c => c.ContactId == user.ContactId);
            if (projects != null)
            {
                calc.Count = projects.Count();
            }
            return calc;          
        }

        [HttpPost("GetUserAssignedBucketsProjects")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserAssignedBucketsProjects([FromBody] InternalUser internalUser)
        {
           
            var foiu = _context.FundingOpportunityInternalUser.Where(u => u.InternalUserId == internalUser.InternalUserId);
            List<Project> projects = new List<Project>();
            foreach (var fo in foiu)
            {
                List<Project> projs = _context.Project.Where(f => f.FundingOpportunityID == fo.FundingOpportunityId).ToList();
                projects = projs;
            }

            
            return projects;
        }

        [HttpPost("GetUserOwnerProjects")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserOwnerProjects([FromBody] InternalUser internalUser)
        {
          
            return _context.Project.Where(u => u.CurrentOwner == internalUser.InternalUserId);
           
        }

        [HttpPost("GetUserIncompleteProjects")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserIncompleteProjects([FromBody] InternalUser internalUser)
        {
           
            return _context.Project.Where(u => u.CurrentOwner == internalUser.InternalUserId && u.ProjectStatus == Status.Incomplete);
 
        }

        [HttpPost("GetUserWithdrawnProjects")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserWithdrawnProjects([FromBody] InternalUser internalUser)
        {
          
            return _context.Project.Where(u => u.CurrentOwner == internalUser.InternalUserId && u.ProjectStatus == Status.Withdrawn);
            
        }

        [HttpGet("GetWorkloadManagerSubmissions/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissions([FromRoute] string userName)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
                if (currentUser.IsPortalAdministrator)
                {
                   return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjects();

                }
                else if (currentUser.IsWorkloadManager)
                {
                    var userFundingOpportunities = _context.FundingOpportunityInternalUser.Where(u => u.InternalUserId == currentUser.InternalUserId);
                    List<Project> projects = new List<Project>();
                    foreach (var fo in userFundingOpportunities)
                    {
                        var foProjects = _context.Project.Where(f => f.FundingOpportunityID == fo.FundingOpportunityId && f.ProjectStatus == Status.Submitted);
                        foreach (var proj in foProjects)
                        {
                            proj.ContactName = _context.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                            proj.FundingOpportunityName = _context.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                        }
                        projects.AddRange(foProjects);

                    }
                    return projects;
                }
            }                                           
            return null;           
        }


        // GET: api/Projects/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> GetProject([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var project = await _unitOfWork.Project.SingleOrDefaultAsync(m => m.ProjectId == id);
            var project = await _unitOfWork.Projects.GetAsync(id);
         

            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // GET: api/Projects/GetProjectStatus5
        [HttpGet("GetProjectStatus/{id}")]
        public async Task<IActionResult> GetProjectStatus([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _unitOfWork.Projects.GetAsync(id);

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

        //public async Task<Project> UpdateProject(Project project)
        //{
        //    _context.Entry(project).State = EntityState.Modified;

        //    try
        //    {
        //        await _unitOfWork.SaveChangesAsync();
        //        return project;
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!_unitOfWork.Projects.ProjectExists(project.ProjectId))
        //        {
        //            return null;
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //}

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

            project.ExternalUpdatedOn = DateTime.Now;

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
                if (!_unitOfWork.Projects.ProjectExists(id))
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


       
        [HttpPost("Submit")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> SubmitProject([FromBody] Project proj)
        {

            var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == proj.ProjectId);
            project.ExternalUpdatedOn = DateTime.Now;
            project.SubmittedOn = DateTime.Now;
            project.ProjectStatus = Status.Submitted;
            
            _context.Entry(project).State = EntityState.Modified;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Projects.ProjectExists(proj.ProjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(project);
        }

        [HttpPost("Withdraw")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> WithdrawProject([FromBody] Project proj)
        {

            var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == proj.ProjectId);
            project.ExternalUpdatedOn = DateTime.Now;
            project.SubmittedOn = DateTime.Now;
            project.ProjectStatus = Status.Withdrawn;

            _context.Entry(project).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_unitOfWork.Projects.ProjectExists(proj.ProjectId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(project);
        }

        // POST: api/Projects 
        [HttpPost]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> PostProject([FromBody] Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }           
            FiscalYear.GetFiscalYearByDateTime(project.ExternalCreatedOn);
            Random rnd = new Random();
            int randomNo = rnd.Next(10000000, 99999999);

            string randomNumber = "APP-" + randomNo;
            project.CorporateFileNumber = randomNumber;
            project.ExternalUpdatedOn = DateTime.Now;

            _context.Project.Add(project);

            var relatedObjectives = _context.FundingOpportunityObjective.Where(fo => fo.FundingOpportunityId == project.FundingOpportunityID); 
            if (relatedObjectives != null)
            {
                foreach (var o in relatedObjectives)
                {
                    ProjectObjective newObj = new ProjectObjective
                    {
                        ProjectID = project.ProjectId,
                        ObjectiveID = o.ObjectiveId
                    };
                    _context.ProjectObjective.Add(newObj);
                }
            }


            await _context.SaveChangesAsync();

            return Ok(project);
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

           // var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == id);
            var project = await _unitOfWork.Projects.GetAsync(id);

            GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, project);
            var newGCIMSProject = gcimsHelper.CreateGCIMSproject();

            return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
           // return Ok(newGCIMSProject.Result);
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _unitOfWork.Projects.GetAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            var projectContacts = _context.ProjectContact.Where(p => p.ProjectId == id);
            var projectBudgets = _context.ProjectBudget.Where(p => p.ProjectID == id);
            var projectMembers = _context.ProjectMember.Where(p => p.ProjectId == id);
            var projectSupporters = _context.ProjectSupporter.Where(p => p.ProjectId == id);
            var projectObjectives = _context.ProjectObjective.Where(p => p.ProjectID == id);
            var projectActivities = _context.ProjectActivity.Where(p => p.ProjectId == id);
            var projectFederalDepartments = _context.ProjectFederalDepartment.Where(p => p.ProjectId == id);

            _context.RemoveRange(projectContacts);
            _context.RemoveRange(projectBudgets);       
            _context.RemoveRange(projectMembers);
            _context.RemoveRange(projectSupporters);
            _context.RemoveRange(projectObjectives);
            _context.RemoveRange(projectActivities);
            _context.RemoveRange(projectFederalDepartments);
           // await _context.SaveChangesAsync();

            _context.Project.Remove(project);

            await _context.SaveChangesAsync();

            return Ok(project);
        }

      
    }
}