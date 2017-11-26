using InternalPortal.Models.Portal;
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

        public async Task<tblProjects> CreateGCIMSproject()
        {
           // var clientId = CreateOrUpdateClient(_project.Account);
            var contactId = CreateOrUpdateContact(_project.Account,_project.PrimaryContact, _project.PrimaryContactAddress.Address, _project.Account.GcimsClientID);

            Random rnd = new Random();
            int projectId = rnd.Next(50000, 100000);

            var GCIMSUserName = new SqlParameter("@GCIMSUserName", _project.GCIMSUserName);
            var ClientID = new SqlParameter("@ClientID", _project.GcimsClientId);
            var ContactID = new SqlParameter("@ContactID", contactId);
            var Lang = new SqlParameter("@Lang", _project.Lang);
            var FiscalYear = new SqlParameter("@FiscalYear", _project.FiscalYear);
            var RequestedAmount = new SqlParameter("@RequestedAmount", _project.RequestedAmount);
            var CorporateFileNumber = new SqlParameter("@CorporateFileNumber", _project.CorporateFileNumber);
            var CommitmentItemID = new SqlParameter("@CommitmentItemID", _project.GCIMSCommitmentItemID);
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
        public string CreateOrUpdateClient(Account Account)
        {
            var GcimsClient = _context.tblClients.SingleOrDefault(c => c.ClientID == Account.GcimsClientID);
            //update
            if (ClientExists(GcimsClient.ClientID))
            {
                _context.Entry(GcimsClient).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else //create
            {
                //get next client id
                var clientId = new SqlParameter("@NextNum", "1");
                clientId.Direction = System.Data.ParameterDirection.Output;
                var newClientID = _context.Database.ExecuteSqlCommand("exec sp_GetNextClientID @NextNum OUT", clientId).ToString();
                Account.GcimsClientID = newClientID;
                //update account informaiton here. before creating new.

                tblClients newGcimsClient = new tblClients
                {
                    ClientName = Account.AccountName,
                    ClientID = newClientID,
                    ClientTypeID = 1                    
                };
                _context.tblClients.Add(newGcimsClient);
                _context.SaveChanges();
            }

            return Account.GcimsClientID;
        }
        public int CreateOrUpdateContact(Account Account, Contact Contact, Address Address, string ClientID)
        {
            var GcimsContact = _context.tblContacts.SingleOrDefault(c => c.ContactID == Contact.GcimsContactID);
            //update
            if (GcimsContact != null)
            {
                _context.Entry(GcimsContact).State = EntityState.Modified;
                _context.SaveChanges();
            }
            else //create
            {
                //get next client id
                var contactId = new SqlParameter("@NextNum", 1);
                contactId.Direction = System.Data.ParameterDirection.Output;
                contactId.SqlDbType = System.Data.SqlDbType.Int;
                var newContactID = _context.Database.ExecuteSqlCommand("exec sp_GetNextContactID @NextNum OUT", contactId);

                Contact.GcimsContactID = (int)contactId.Value;
                _context.Entry(Contact).State = EntityState.Modified;
                _context.SaveChanges();
                //Contact.GcimsClientID = ClientID;
                tblContacts newGcimsContact = new tblContacts
                {
                    Firstname = Contact.FirstName,
                    ContactID = newContactID,
                    Lastname = Contact.LastName,
                    SalutationID = Contact.SalutationID,
                    LanguageID = Contact.PreferredLanguageID,
                    ClientID = Account.GcimsClientID,
                    CityID = Address.GcimsCityID,
                    AddressLine1 = Address.AddressLine1,
                    AddressLine2 = Address.AddressLine2,
                    AddressLine3 = Address.AddressLine3,
                    AddressLine4 = Address.AddressLine4,
                    Email = Contact.Email,
                    PostalCode = Address.Postal,
                    CreatedBy = "GCIMSUnit",
                    UpdatedBy = "GCIMSUnit"
                };
                _context.tblContacts.Add(newGcimsContact);
                _context.SaveChanges();
            }

            return (int)Contact.GcimsContactID;
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
