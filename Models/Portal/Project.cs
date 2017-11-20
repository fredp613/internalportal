using InternalPortal.Models.Helpers;
using InternalPortal.Models.Portal;
using InternalPortal.Models.Portal.Program;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public enum Status
    {
        Draft = 1,
        Submitted = 2,
        Approved = 3,
        NotApproved = 4,
        Incomplete = 5,
        Withdrawn = 6
    }
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        public int GcimsProjectID { get; set; } 
        public string GCIMSUserName { get; set; }
        public string Lang { get; set; }
        public string FiscalYear { get; set; }
        public double RequestedAmount { get; set; }
        public string CorporateFileNumber { get; set; }     
        public Guid? FundingOpportunityID { get; set; }
        [JsonIgnore]
        public FundingOpportunity Program { get; set; }
        public string GCIMSCommitmentItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime StartDate { get; set; }
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime EndDate { get; set; }    
        public bool SubmitGcims { get; set; }
        public bool UpdatePrimaryContactAddress { get; set; }
        public bool UpdatePrimaryClientAddress{ get; set; }
        public bool NewPrimaryContactAddress { get; set; }
        public bool NewPrimaryClientAddress { get; set; }  
        public string GcimsClientId { get; set; }
        public int GcimsContactId { get; set; }
        public string ProjectNeeded { get; set; }
        public string Objective1 { get; set; }
        public string Objective2 { get; set; }
        public string Objective3 { get; set; }
        public string ExpertiseJustificiation { get; set; }
        public string Diversity { get; set; }
        public string LanguageMinority { get; set; }
        public string Communication { get; set; }
        public string Evaluation { get; set; }
        public Status ProjectStatus { get; set; }   
        public string AdditionalInformation { get; set; }
        public bool Audited { get; set; }
        public bool TaxRebate { get; set; }
        public double TaxPercent { get; set; }
        [JsonIgnore]
        [NotMapped]
        public tblAddresses PrimaryClientAddress { get; set; }
        [JsonIgnore]
        public tblClients Client { get; set; }
        [JsonIgnore]
        [NotMapped]
        public tblContacts tblContact { get; set; }
        public Guid? PrimaryContactAddressId { get; set; }
        public Guid? PrimaryAccountAddressId { get; set; }
        [JsonIgnore]
        public ContactAddress PrimaryContactAddress { get; set; }
        [JsonIgnore]    
        public AccountAddress PrimaryAccountAddress { get; set; }
        public Guid? AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        public Guid? ContactId { get; set; }
        
        public Guid? PrimaryProjectContactId { get; set; }
      
        [JsonIgnore]
        public Contact PrimaryContact { get; set; }

        public IEnumerable<ProjectContact> ProjectContacts { get; set; }
        
        public IEnumerable<ProjectBudget> BudgetItems { get; set; }
        public IEnumerable<ProjectExpectedResult> ExpectedResults { get; set; }
        public IEnumerable<ProjectObjective> Objectives { get; set; }

        public DateTime ExternalCreatedOn { get; set; }
        public DateTime ExternalUpdatedOn { get; set; }      
        public DateTime InternalUpdatedOn { get; set; }
        public DateTime SubmittedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }

        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        public Guid? AssignedTo { get; set; }
        public Guid? AssignedBy { get; set; }
        public Guid? CurrentOwner { get; set; }

        //unmapped properties
        [NotMapped]
        public string ContactName { get; set; }
        [NotMapped]
        public string FundingOpportunityName { get; set; }
      

    }
}
