using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class Account
    {
        [Key]
        public Guid ID { get; set; }
        public string GcimsClientID { get; set; }
        public string AccountName { get; set; }
        public string LegalName { get; set; }
        public AccountAddress primaryAddress { get; set; }
        public AccountAddress paymentAddress { get; set; }
        public IEnumerable<AccountAddress> AccountAdresses { get; set; }
        public IEnumerable<AccountContact> AccountContacts { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }

    }
}
