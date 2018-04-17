using InternalPortal.Models.Portal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using InternalPortal.Models;

namespace InternalPortal.Models.GCIMS
{
    public class GCIMSHelper
    {

        private readonly GcimsContext _context;
        private readonly PortalContext _portalContext;
        private readonly Project _project;
      
        
        public GCIMSHelper(GcimsContext context, PortalContext portalContext, Project project)
        {
            _portalContext = portalContext;
            _context = context;
            _project = project;
           
            
        }

        public async Task<tblProjects> CreateGCIMSproject(string gcimsClientId)
        {
            // var clientId = CreateOrUpdateClient(_project.Account);
            //var contactId = CreateOrUpdateContact(_project.Account,_project.PrimaryContact, _project.PrimaryContactAddress.Address, _project.Account.GcimsClientID);
            var primaryContact = _portalContext.ProjectContact.SingleOrDefault(c => c.ProjectContactId == _project.PrimaryProjectContactId);
            var contactId = CreateOrUpdateContact(primaryContact);
            var currentOwner = _portalContext.InternalUser.Find(_project.CurrentOwner);
            var gcimsUserName = currentOwner.gcimsUserName;

            Random rnd = new Random();
            int projectId = rnd.Next(50000, 100000);

            var GCIMSUserName = new SqlParameter("@GCIMSUserName", gcimsUserName);
            var ClientID = new SqlParameter("@ClientID", gcimsClientId);
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
            var newproject = _context.Database.ExecuteSqlCommand("exec web_sp_createProject @GCIMSUserName,@ClientID,@ContactID,@Lang," +
                "@FiscalYear,@RequestedAmount,@CorporateFileNumber, @CommitmentItemID, @Title, " +
                "@Description, @StartDate, @EndDate, @ProjectID OUT",
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
                CreateExpenseItems((int)projectID.Value);
                CreateRevenueItems((int)projectID.Value);
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
        //public string CreateOrUpdateClient(Account Account)
        //{
        //    var GcimsClient = _context.tblClients.SingleOrDefault(c => c.ClientID == Account.GcimsClientID);
        //    //update
        //    if (ClientExists(GcimsClient.ClientID))
        //    {
        //        _context.Entry(GcimsClient).State = EntityState.Modified;
        //        _context.SaveChanges();
        //    }
        //    else //create
        //    {
        //        //get next client id
        //        var clientId = new SqlParameter("@NextNum", "1");
        //        clientId.Direction = System.Data.ParameterDirection.Output;
        //        var newClientID = _context.Database.ExecuteSqlCommand("exec sp_GetNextClientID @NextNum OUT", clientId).ToString();
        //        Account.GcimsClientID = newClientID;
        //        //update account informaiton here. before creating new.

        //        tblClients newGcimsClient = new tblClients
        //        {
        //            ClientName = Account.AccountName,
        //            ClientID = newClientID,
        //            ClientTypeID = 1                    
        //        };
        //        _context.tblClients.Add(newGcimsClient);
        //        _context.SaveChanges();
        //    }

        //    return Account.GcimsClientID;
        //}
        public int CreateOrUpdateContact(ProjectContact projectContact)
        {

            var GcimsContact = _context.tblContacts.Find(projectContact.GCIMSContactID);

            var currentOwner = _portalContext.InternalUser.Find(_project.CurrentOwner);
            var gcimsUserName = currentOwner.gcimsUserName;
            //update
            if (GcimsContact != null)
            {
                // _context.Entry(GcimsContact).State = EntityState.Modified;
                // _context.SaveChanges();
                return projectContact.GCIMSContactID;
            }
            else //create
            {
                //get next client id
                var contactId = new SqlParameter("@NextNum", 1);
                contactId.Direction = System.Data.ParameterDirection.Output;
                contactId.SqlDbType = System.Data.SqlDbType.Int;


                var newContactID = _context.Database.ExecuteSqlCommand("exec sp_GetNextContactID @NextNum OUT", contactId);

                projectContact.GCIMSContactID = (int)contactId.Value;
                _portalContext.Entry(projectContact).Property(p => p.GCIMSContactID).IsModified = true;
                _portalContext.SaveChanges();


                tblContacts newGcimsContact = new tblContacts
                {
                    Firstname = projectContact.FirstName,
                    ContactID = (int)contactId.Value,
                    Lastname = projectContact.LastName,
                    SalutationID = "Unkn",
                    LanguageID = "E",
                    ClientID = _project.GcimsClientId,
                    //CityID = Address.GcimsCityID,
                    //AddressLine1 = Address.AddressLine1,
                    //AddressLine2 = Address.AddressLine2,
                    //AddressLine3 = Address.AddressLine3,
                    //AddressLine4 = Address.AddressLine4,
                    Email = projectContact.Email,
                    Phone = (projectContact.PhoneNumber == null ? "6132222222" : new String(projectContact.PhoneNumber.Where(Char.IsDigit).ToArray())),
                    // PostalCode = projectContact.Pos,
                    CreatedBy = gcimsUserName,
                    UpdatedBy = gcimsUserName,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                };
                _context.tblContacts.Add(newGcimsContact);
                _context.SaveChanges();
                return newContactID;
            }

        }

        public void CreateExpenseItems(int projectId)
        {
            var budgetItems = _portalContext.ProjectBudget.Where(p => p.ProjectID == _project.ProjectId);
            var gcimsApplication = _context.tblApplications.SingleOrDefault(p => p.ProjectID == projectId);
            var currentOwner = _portalContext.InternalUser.Find(_project.CurrentOwner);
            var gcimsUserName = currentOwner.gcimsUserName;

            for (var i = 0; i <= budgetItems.Count() - 1; i ++)
            {
                var bi = budgetItems.ToList()[i];
                var eligibleCostCategory = _portalContext.EligibleCostCategory.SingleOrDefault(e => e.EligibleCostCategoryId == bi.CostCategoryID);
                var gcimsCostCategoryId = _portalContext.CostCategory.SingleOrDefault(c => c.CostCategoryId == eligibleCostCategory.CostCategoryId).GcimsCostCategoryID;

                string expDescription = "";
                if (bi.Description.Length > 59 && bi.FiscalYear != null)
                {
                    expDescription = bi.FiscalYear + " - " + bi.Description.Substring(0, 59);
                } else if (bi.Description.Length < 59 && bi.FiscalYear != null)
                {
                    expDescription = bi.FiscalYear + " - " + bi.Description;
                } else
                {
                    expDescription = bi.FiscalYear;
                }



                if (gcimsCostCategoryId != null)
                {
                    var tblProjectExpenseLineItem = new tblProjectExpenseLineItems
                    {
                        
                        ExpenseLineItemDescription = expDescription,
                        ExpenseLineItemID = i,                         
                        ProjectID = projectId, 
                        ExpenseCategoryID = int.Parse(gcimsCostCategoryId),
                        CreatedDate = DateTime.Now, 
                        CreatedBy = gcimsUserName
                       
                    };
                    //create gcims expense item
                    var tblApplicationExpense = new tblApplicationExpenses
                    {
                        ProjectID = projectId,
                        ApplicationID = gcimsApplication.ApplicationID,                        
                        CreatedBy = gcimsUserName,
                        CreatedDate = DateTime.Now,
                        ExpenseAmount = (decimal)bi.Amount,
                        ExpenseLineItemID = i,  //int.Parse(gcimsCostCategoryId), 
                        RequestedAmount = bi.FundingOrganization == "Justice Canada" ? (decimal)bi.Amount : 0
                    };
                    _context.Add(tblProjectExpenseLineItem);
                    _context.SaveChanges();
                    _context.Add(tblApplicationExpense);
                    _context.SaveChanges();

                }

            }
            
           

        }

        public void CreateRevenueItems(int projectId)
        {

            var currentOwner = _portalContext.InternalUser.Find(_project.CurrentOwner);
            var gcimsUserName = currentOwner.gcimsUserName;

            var revenueItems = _portalContext.ProjectBudget.Where(p => p.ProjectID == _project.ProjectId).GroupBy(x => x.FundingOrganization).Select(s => new
            {
                Item = s.Key, 
                Amount = s.Sum(si => si.Amount)
            }); 
            var gcimsApplication = _context.tblApplications.SingleOrDefault(p => p.ProjectID == projectId);


            for (var i = 0; i <= revenueItems.Count() - 1; i++)
            {
                var ri = revenueItems.ToList()[i];

                var tblProjectRevenueLineItem = new tblProjectRevenueLineItems
                {
                    ProjectID = projectId,
                    RevenueLineItemID = i,
                    CreatedBy = gcimsUserName,
                    CreatedDate = DateTime.Now, 
                    RevenueCategoryID = ri.Item == "Justice Canada" ? 10 : 34, 
                    RevenueLineItemDescription = ri.Item
                };
                var tblRevenueLineItem = new tblApplicationRevenues
                {
                    ProjectID = projectId,
                    ApplicationID = gcimsApplication.ApplicationID,
                    RevenueLineItemID = i,
                    CashRevenueAmount = (decimal)ri.Amount,
                    RevenueAmount = (decimal)ri.Amount,
                    CreatedBy = gcimsUserName,
                    CreatedDate = DateTime.Now
                };
                _context.Add(tblProjectRevenueLineItem);
                _context.SaveChanges();
                _context.Add(tblRevenueLineItem);
                _context.SaveChanges();

            }

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
