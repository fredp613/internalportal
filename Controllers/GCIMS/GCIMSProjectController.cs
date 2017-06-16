using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models;
using System.Data.SqlClient;
using System.Diagnostics;

namespace InternalPortal.Controllers
{
    [Produces("application/json")]
    [Route("api/GCIMSProject")]
    public class GCIMSProjectController : Controller
    {
        private readonly GcimsContext _context;

        public GCIMSProjectController(GcimsContext context)
        {
            _context = context;
        }


        [HttpGet("GetContactByID/{id}")]    
        public async Task<IActionResult> GetGCIMSContactByID([FromRoute] int id)
        {            
            var contact = await _context.tblContacts.SingleOrDefaultAsync(c => c.ContactID == id);
            if (contact != null)
            {               
                return Ok(contact);
            }            
            return NoContent();
        }

       

        //[HttpPost]
        //public async Task<IActionResult> PostProjects([FromBody] Project Project)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
            
        //    var clientId = CreateOrUpdateClient(Project.Client);
        //    var contactId = CreateOrUpdateContact(Project.Contact, Project.Client.ClientID);

        //    Random rnd = new Random();
        //    int projectId = rnd.Next(50000, 100000);

        //    var GCIMSUserName = new SqlParameter("@GCIMSUserName", Project.GCIMSUserName);
        //    var ClientID = new SqlParameter("@ClientID", clientId);
        //    var ContactID = new SqlParameter("@ContactID",contactId);
        //    var Lang = new SqlParameter("@Lang", Project.Lang);
        //    var FiscalYear = new SqlParameter("@FiscalYear", Project.FiscalYear);
        //    var RequestedAmount = new SqlParameter("@RequestedAmount", Project.RequestedAmount);
        //    var CorporateFileNumber = new SqlParameter("@CorporateFileNumber", Project.CorporateFileNumber);
        //    var CommitmentItemID = new SqlParameter("@CommitmentItemID", Project.CommitmentItemID);
        //    var Title = new SqlParameter("@Title", Project.Title);
        //    var Description = new SqlParameter("@Description", Project.Description);
        //    var StartDate = new SqlParameter("@StartDate", Project.StartDate);
        //    var EndDate = new SqlParameter("@EndDate", Project.EndDate);
        //    var ProjectID = new SqlParameter("@ProjectID", projectId);              
        //    ProjectID.Direction = System.Data.ParameterDirection.Output;
        //    ProjectID.SqlDbType = System.Data.SqlDbType.Int;
        //    ContactID.SqlDbType = System.Data.SqlDbType.Int;
        //    var newProject = _context.Database.ExecuteSqlCommand("exec web_sp_createProject @GCIMSUserName,@ClientID,@ContactID,@Lang," +
        //        "@FiscalYear,@RequestedAmount,@CorporateFileNumber, @CommitmentItemID, @Title, " +
        //        "@Description, @StartDate, @EndDate, @ProjectID OUT",             
        //     GCIMSUserName,
        //     ClientID,
        //     ContactID,
        //     Lang,
        //     FiscalYear,
        //     RequestedAmount,
        //     CorporateFileNumber, 
        //     CommitmentItemID,
        //     Title, 
        //     Description,
        //     StartDate,
        //     EndDate,
        //     ProjectID);


        //    if (ProjectID != null)
        //    {
        //        var createdProject = await _context.tblProjects.SingleOrDefaultAsync(m => m.ProjectID == (int)ProjectID.Value);                
        //        createdProject.tblApplication = await _context.tblApplications.SingleOrDefaultAsync(a => a.ProjectID == (int)ProjectID.Value);                                  
        //        return Ok(createdProject);

        //    }

        //    return NoContent();
            
        //    //if (!ModelState.IsValid)
        //    //{
        //    //    return BadRequest(ModelState);
        //    //}

        //    //_context.tblProjects.Add(tblProjects);
        //    //await _context.SaveChangesAsync();


        //   // return CreatedAtAction("GettblProjects", new { id = tblProjects.ProjectID }, tblProjects);
        //}

        private bool ContactExists(int id)
        {
            return _context.tblContacts.Any(c => c.ContactID == id);
        }
        private bool ClientExists(string id)
        {
            return _context.tblClients.Any(c => c.ClientID == id);
        }



        /**
        // GET: api/GCIMSProject
        [HttpGet]
        public IEnumerable<tblProjects> GettblProjects()
        {
            return _context.tblProjects;
        }

        // GET: api/GCIMSProject/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GettblProjects([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblProjects = await _context.tblProjects.SingleOrDefaultAsync(m => m.ProjectID == id);

            if (tblProjects == null)
            {
                return NotFound();
            }

            return Ok(tblProjects);
        }

        // PUT: api/GCIMSProject/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttblProjects([FromRoute] int id, [FromBody] tblProjects tblProjects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblProjects.ProjectID)
            {
                return BadRequest();
            }

            _context.Entry(tblProjects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblProjectsExists(id))
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
            // DELETE: api/GCIMSProject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetblProjects([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tblProjects = await _context.tblProjects.SingleOrDefaultAsync(m => m.ProjectID == id);
            if (tblProjects == null)
            {
                return NotFound();
            }

            _context.tblProjects.Remove(tblProjects);
            await _context.SaveChangesAsync();

            return Ok(tblProjects);
        }

        private bool tblProjectsExists(int id)
        {
            return _context.tblProjects.Any(e => e.ProjectID == id);
        }
        **/
        // POST: api/GCIMSProject



    }
}
