using InternalPortal.Models.Portal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class User
    {
        
        [Key]
        public Guid UserId { get; set; }
        public string PAI { get; set; } 
        //stores the contact reference to be used in the portal
        public Guid ContactId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }        

        //public virtual InternalUser InternalUpdatedBy { get; set; }
        public Guid? CreatedByUserId { get; set; }
       
        public Guid? UpdatedByUserId { get; set; }        
       

      

    }
}
