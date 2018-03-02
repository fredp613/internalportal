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
using System.Diagnostics;

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
        public ProjectsController(PortalContext context, GcimsContext gcimsContext)
        {
            _context = context;
            _gcimsContext = gcimsContext;
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
        [HttpGet("IsBucket/{id}")]
        public bool IsBucket([FromRoute] Guid Id)
        {
            return _unitOfWork.Projects.IsBucket(Id);
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

        [HttpGet("GetUserNotClaimedProjects/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserNotClaimedProjects([FromRoute] string username, [FromRoute] string lang)
        {

            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);
            return _unitOfWork.Projects.GetSubmissionReviewerSubmittedProjectsNotClaimed(lang, currentUser.InternalUserId);

        }

        [HttpGet("GetUserOwnerProjects/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserOwnerProjects([FromRoute] string username, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);
            return _unitOfWork.Projects.GetSubmissionReviewerSubmittedProjectsAssigned(lang, currentUser.InternalUserId);
           
        }

        [HttpGet("GetUserIncompleteProjects/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserIncompleteProjects([FromRoute] string username, [FromRoute] string lang)
        {

            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);
            return _unitOfWork.Projects.GetSubmissionReviewerSubmittedProjectsIncomplete(lang, currentUser.InternalUserId);

        }

        [HttpGet("GetUserWithdrawnProjects/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserWithdrawnProjects([FromRoute] string username, [FromRoute] string lang)
        {

            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);
            return _unitOfWork.Projects.GetSubmissionReviewerSubmittedProjectsWithdrawn(lang, currentUser.InternalUserId);

        }
        [HttpGet("GetUserPreScreenedProjects/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserPreScreenedProjects([FromRoute] string username, [FromRoute] string lang)
        {

            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);
            return _unitOfWork.Projects.GetSubmissionReviewerSubmittedProjectsPreScreened(lang, currentUser.InternalUserId);

        }

        [HttpGet("GetUserRejectedProjects/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetUserRejectedProjects([FromRoute] string username, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == username);
            return _unitOfWork.Projects.GetSubmissionReviewerSubmittedProjectsRejected(lang, currentUser.InternalUserId);
        }
        
        [HttpGet("GetWorkloadManagerSubmissions/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissions([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
              
                   return  _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsNotAssigned(lang, currentUser.InternalUserId);

            
            }

            return Enumerable.Empty<Project>();
           
        }

        [HttpGet("GetWorkloadManagerSubmissionsNotClaimed/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissionsNotClaimed([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
              
                    return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsNotClaimed(lang, currentUser.InternalUserId);

               
            }

            return Enumerable.Empty<Project>();

        }

        [HttpGet("GetWorkloadManagerSubmissionsAssigned/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissionsAssigned([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {               
                return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsAssigned(lang, currentUser.InternalUserId);               
            }

            return null;

        }

        [HttpGet("GetWorkloadManagerSubmissionsIncomplete/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissionsIncomplete([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
                return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsIncomplete(lang, currentUser.InternalUserId);
            }

            return null;

        }

        [HttpGet("GetWorkloadManagerSubmissionsWithdrawn/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissionsWithdrawn([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
                return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsWithdrawn(lang, currentUser.InternalUserId);
            }

            return null;

        }

        [HttpGet("GetWorkloadManagerSubmissionsPreScreened/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissionsPreScreened([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
                return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsPreScreened(lang, currentUser.InternalUserId);
            }

            return null;

        }

        [HttpGet("GetWorkloadManagerSubmissionsRejected/{lang}/{username}")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IEnumerable<Project> GetWorkloadManagerSubmissionsRejected([FromRoute] string userName, [FromRoute] string lang)
        {
            var currentUser = _context.InternalUser.SingleOrDefault(u => u.UserName == userName);
            if (currentUser != null)
            {
                return _unitOfWork.Projects.GetWorkloadManagerSubmittedProjectsRejected(lang, currentUser.InternalUserId);
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
                GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, _context, project);
                var status = gcimsHelper.GetProjectStatus();
                if (status.Equals(2))
                {
                    if (status == "Approved")
                    {
                        project.ProjectStatus = Status.Approved;
                    }
                    if (status == "Not Approved")
                    {
                        project.ProjectStatus = Status.Rejected;
                    }                                      
                }
                
            }

            return Ok(project.ProjectStatus);
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
            project.ExternalUpdatedOn = DateTime.Now;

            if (project.ProjectStatus == Status.Submitted)
            {

                project.SubmittedOn = DateTime.Now;

            }

            _context.Entry(project).State = EntityState.Modified;

            

            if (project.SubmitGcims)
            {
                GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, _context, project);
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


            _context.Entry(project).Property(s => s.ExternalUpdatedOn).IsModified = true;
            _context.Entry(project).Property(s => s.SubmittedOn).IsModified = true;
            _context.Entry(project).Property(s => s.ProjectStatus).IsModified = true;
           
            
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

        [HttpPost("SetPrimaryContact")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> SetPrimaryContact([FromBody] Project proj)
        {

            var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == proj.ProjectId);
            project.ExternalUpdatedOn = DateTime.Now;
            project.PrimaryProjectContactId = proj.PrimaryProjectContactId;

            _context.Entry(project).Property(s => s.ExternalUpdatedOn).IsModified = true;
            _context.Entry(project).Property(s => s.PrimaryProjectContactId).IsModified = true;



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

        [HttpPost("SetOwner")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> SetOwner([FromBody] Project proj)
        {

            var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == proj.ProjectId);
            project.ExternalUpdatedOn = DateTime.Now;            
            project.CurrentOwner = proj.CurrentOwner;
 
            _context.Entry(project).Property(s => s.ExternalUpdatedOn).IsModified = true;
            _context.Entry(project).Property(s => s.CurrentOwner).IsModified = true;
           
          

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
        [HttpPost("SetOwnerByName")]
        [ProducesResponseType(typeof(Project), 200)]
        public async Task<IActionResult> SetOwnerByName([FromBody] Project proj)
        {

            var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == proj.ProjectId);
            project.ExternalUpdatedOn = DateTime.Now;
            var user = _context.InternalUser.SingleOrDefault(u => u.UserName == proj.GCIMSUserName);
            project.CurrentOwner = user.InternalUserId;

            _context.Entry(project).Property(s => s.ExternalUpdatedOn).IsModified = true;
            _context.Entry(project).Property(s => s.CurrentOwner).IsModified = true;



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
            project.ProjectStatus = Status.Withdrawn;


            _context.Entry(project).Property(s => s.ProjectStatus).IsModified = true;
            _context.Entry(project).Property(s => s.ExternalUpdatedOn).IsModified = true;
           

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
            var fy = FiscalYear.GetFiscalYearByDateTime(DateTime.Now);
            Random rnd = new Random();
            int randomNo = rnd.Next(10000000, 99999999);

            string randomNumber = "APP-" + randomNo;
            project.CorporateFileNumber = randomNumber;
            project.ExternalCreatedOn = DateTime.Now;
            project.ExternalUpdatedOn = DateTime.Now;
            project.FiscalYear = fy;

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
      
        [HttpPost("PostGCIMS")]
        [ProducesResponseType(typeof(tblProjects), 200)]
        public async Task<IActionResult> PostGCIMS([FromBody] Project proj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           var project = await _context.Project.SingleOrDefaultAsync(p => p.ProjectId == proj.ProjectId);
          //  var project = await _context.Project.FindAsync(proj.ProjectId);
            var fo = await _context.FundingOpportunity.FindAsync(project.FundingOpportunityID);
            project.GCIMSCommitmentItemID = fo.GcimsCommitmentItemId;
            project.Lang = "EN";
            project.FiscalYear = FiscalYear.GetFiscalYearByDateTime(DateTime.Now);
            project.GcimsClientId = proj.GcimsClientId;
            

            GCIMSHelper gcimsHelper = new GCIMSHelper(_gcimsContext, _context, project);
            var newGCIMSProject = gcimsHelper.CreateGCIMSproject();

            project.GcimsProjectID = newGCIMSProject.Result.ProjectID;

            _context.Entry(project).Property(x => x.GcimsClientId).IsModified = true;
            _context.Entry(project).Property(x => x.Lang).IsModified = true;
            _context.Entry(project).Property(x => x.FiscalYear).IsModified = true;
            _context.Entry(project).Property(x => x.GCIMSCommitmentItemID).IsModified = true;
            _context.Entry(project).Property(x => x.GcimsProjectID).IsModified = true;
            _context.SaveChanges();

            //_context.Entry(project).State = EntityState.Modified;
            // _context.SaveChanges();

            //return CreatedAtAction("GetProject", new { id = project.ProjectId }, project);
            return Ok(newGCIMSProject.Result);
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