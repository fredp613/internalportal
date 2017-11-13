using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public string GcimsClientID { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public string LegalName { get; set; }
        public Guid PrimaryAccountAddressId { get; set; }
        public Guid PaymentAccountAddressId { get; set; }
        public IEnumerable<AccountAddress> AccountAddresses { get; set; }
        public IEnumerable<AccountContact> AccountContacts { get; set; }  
 
        public string BandNumber { get; set; }

        public string IncorporationLevel { get; set; }
        public DateTime DateRegistered { get; set; }
        public string Website { get; set; }

        public string PrimaryWork { get; set; }
        public string Mandate { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }     
        public Guid? UpdatedByInternalUserId { get; set; }   
        
        public string PrimaryAddressLine1 { get; set; }
        public string PrimaryAddressLine2 { get; set; }
        public string PrimaryCity { get; set; }
        public string PrimaryState { get; set; }
        public string PrimaryPostal { get; set; }
        public string PrimaryCountry { get; set; }

        public string BillingAddressLine1 { get; set; }
        public string BillingAddressLine2 { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostal { get; set; }
        public string BillingCountry { get; set; }

        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
       

    }
}
