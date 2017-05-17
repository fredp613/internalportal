using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.GCIMS
{
    public class GCIMSHelper 
    {

        private  readonly GcimsContext _context;
        private readonly Project _project;
        public GCIMSHelper(GcimsContext context, Project project)
        {
            _context = context;
            _project = project;

        }

        public async Task<tblProjects> createGCIMSproject()
        {
            var clientId = CreateOrUpdateClient(_project.Client);
            var contactId = CreateOrUpdateContact(_project.Contact, _project.Client.ClientID);

            Random rnd = new Random();
            int projectId = rnd.Next(50000, 100000);

            var GCIMSUserName = new SqlParameter("@GCIMSUserName", _project.GCIMSUserName);
            var ClientID = new SqlParameter("@ClientID", clientId);
            var ContactID = new SqlParameter("@ContactID", contactId);
            var Lang = new SqlParameter("@Lang", _project.Lang);
            var FiscalYear = new SqlParameter("@FiscalYear", _project.FiscalYear);
            var RequestedAmount = new SqlParameter("@RequestedAmount", _project.RequestedAmount);
            var CorporateFileNumber = new SqlParameter("@CorporateFileNumber", _project.CorporateFileNumber);
            var CommitmentItemID = new SqlParameter("@CommitmentItemID", _project.CommitmentItemID);
            var Title = new SqlParameter("@Title", _project.Title);
            var Description = new SqlParameter("@Description", _project.Description);
            var StartDate = new SqlParameter("@StartDate", _project.StartDate);
            var EndDate = new SqlParameter("@EndDate", _project.EndDate);
            var projectID = new SqlParameter("@projectID", projectId);
            projectID.Direction = System.Data.ParameterDirection.Output;
            projectID.SqlDbType = System.Data.SqlDbType.Int;
            ContactID.SqlDbType = System.Data.SqlDbType.Int;
            var newproject = _context.Database.ExecuteSqlCommand("exec web_sp_createproject @GCIMSUserName,@ClientID,@ContactID,@Lang," +
                "@FiscalYear,@RequestedAmount,@CorporateFileNumber, @CommitmentItemID, @Title, " +
                "@Description, @StartDate, @EndDate, @projectID OUT",
             GCIMSUserName,
             ClientID,
             ContactID,
             Lang,
             FiscalYear,
             RequestedAmount,
             CorporateFileNumber,
             CommitmentItemID,
             Title,
             Description,
             StartDate,
             EndDate,
             projectID);


            if (projectID != null)
            {              
                var createdproject = await _context.tblProjects.SingleOrDefaultAsync(m => m.ProjectID == (int)projectID.Value);
                createdproject.tblApplication = await _context.tblApplications.SingleOrDefaultAsync(a => a.ProjectID == (int)projectID.Value);
                return createdproject;

            }

            return null;
        }

        public string GetProjectStatus()
        {
            var status = _context.tblProjects.SingleOrDefault(p => p.ProjectID == _project.GcimsProjectID);
            if (status != null)
            {
                return status.tblApplication.ApplicationStatusID;
            }
            return null;
        }
        public string CreateOrUpdateClient(tblClients Client)
        {
            Client = _context.tblClients.SingleOrDefault(c => c.ClientID == Client.ClientID);
            //update
            if (ClientExists(Client.ClientID))
            {

                _context.Entry(Client).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else //create
            {
                //get next client id
                var clientId = new SqlParameter("@NextNum", "1");
                clientId.Direction = System.Data.ParameterDirection.Output;
                var newClientID = _context.Database.ExecuteSqlCommand("exec sp_GetNextClientID @NextNum OUT", clientId).ToString();
                Client.ClientID = newClientID;
                _context.tblClients.Add(Client);
                _context.SaveChanges();
            }

            return Client.ClientID;
        }
        public int CreateOrUpdateContact(tblContacts Contact, string ClientID)
        {
            //update
            if (ContactExists(Contact.ContactID))
            {
                _context.Entry(Contact).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else //create
            {
                //get next client id
                var contactId = new SqlParameter("@NextNum", 1);
                contactId.Direction = System.Data.ParameterDirection.Output;
                contactId.SqlDbType = System.Data.SqlDbType.Int;
                var newContactID = _context.Database.ExecuteSqlCommand("exec sp_GetNextContactID @NextNum OUT", contactId);
                Contact.ContactID = (int)contactId.Value;
                Contact.ClientID = ClientID;
                _context.tblContacts.Add(Contact);
                _context.SaveChanges();
            }

            return Contact.ContactID;
        }

        private bool ContactExists(int id)
        {
            return _context.tblContacts.Any(c => c.ContactID == id);
        }
        private bool ClientExists(string id)
        {
            return _context.tblClients.Any(c => c.ClientID == id);
        }

    }
}
