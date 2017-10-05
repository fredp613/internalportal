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
    public class AccountContact
    {
        [Key]
        public Guid AccountContactId { get; set; }
        public Guid AccountId { get; set; }
        [JsonIgnore]
        public Account Account { get; set; }
        public Guid ContactId { get; set; }
        [JsonIgnore]
        public Contact Contact { get; set; }    
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }        
       
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
     
    }
}
