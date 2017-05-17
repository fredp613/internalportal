using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        AwaitingReview = 5
    }
    public class Project
    {
        [Key]
        public Guid ProjectID { get; set; }
        public int GcimsProjectID { get; set; } 
        public string GCIMSUserName { get; set; }
        public string Lang { get; set; }
        public string FiscalYear { get; set; }
        public double RequestedAmount { get; set; }
        public string CorporateFileNumber { get; set; }
        public string CommitmentItemID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }    
        public bool SubmitGcims { get; set; }
        public bool UpdatePrimaryContactAddress { get; set; }
        public bool UpdatePrimaryClientAddress{ get; set; }
        public bool NewPrimaryContactAddress { get; set; }
        public bool NewPrimaryClientAddress { get; set; }  
        public string GcimsClientId { get; set; }
        public int GcimsContactId { get; set; }
        public Status ProjectStatus { get; set; }
        public tblAddresses PrimaryContactAddress { get; set; }
        public tblAddresses PrimaryClientAddress { get; set; }
        public tblClients Client { get; set; }
        public tblContacts Contact { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}
