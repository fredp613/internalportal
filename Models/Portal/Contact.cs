using InternalPortal.Models.Helpers;
using InternalPortal.Models.Portal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public int? GcimsContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName
        {
            get {
                return FirstName + " " + LastName;
            }
            set { }
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }     
        public string SalutationID { get; set; }
        public string PreferredLanguageID { get; set; }
        [JsonConverter(typeof(OnlyDateConverter))]
       // public DateTime DateOfBirth { get; set; }
       // public string ShareSecretQuestion { get; set; }
      //  public string SharedSecretAnswer { get; set; }
      //  public bool IsPrimary { get; set; }
      //  public int Attempts { get; set; }
        public Guid? PrimaryAccountAddressId { get; set; }
        public Guid? PaymentAccountAddressId { get; set; }
        public IEnumerable<ContactAddress> ContactAddresses { get; set; }
        public IEnumerable<AccountContact> ContactAccounts { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }

    }
}
