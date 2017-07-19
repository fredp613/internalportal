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
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        [ForeignKey("InternalUpdatedBy")]
        public Guid? UpdatedByInternalUserId { get; set; }        
        public virtual InternalUser InternalUpdatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public Guid? CreatedByUserId { get; set; }
        [ForeignKey("UpdatedBy")]
        public Guid? UpdatedByUserId { get; set; }        
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

    }
}
