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
    public class ContactAddress
    {
        [Key]
        public Guid ContactAddressId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }
        [JsonIgnore]
        public Address Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }

        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
    
       
    }
}
