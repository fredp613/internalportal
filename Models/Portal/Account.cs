using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public string GcimsClientID { get; set; }
        public string AccountName { get; set; }
        public string LegalName { get; set; }
        public AccountAddress primaryAddress { get; set; }
        public AccountAddress paymentAddress { get; set; }
        public IEnumerable<AccountAddress> AccountAdresses { get; set; }
        public IEnumerable<AccountContact> AccountContacts { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }     
        public Guid UpdatedByInternalUserId { get; set; }        
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser InternalUpdatedBy { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid UpdatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public User CreatedBy { get; set; }        
        [ForeignKey("UpdatedByUserId")]
        public User UpdatedBy { get; set; }

    }
}
