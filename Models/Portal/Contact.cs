using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class Contact
    {
        [Key]
        public Guid ID { get; set; }
        public int GcimsContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SalutationID { get; set; }
        public string PreferredLanguageID { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address PaymentAddress { get; set; }
        public IEnumerable<ContactAddress> ContactAddresses { get; set; }
        public IEnumerable<AccountContact> ContactAccounts { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}
