using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class InternalUser
    {
        [Key]
        public Guid InternalUserId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedByInternalUserId { get; set; }
        [ForeignKey("CreatedByInternalUserId")]
        public InternalUser InternalCreatedBy { get; set; }
        public Guid UpdatedByInternalUserId { get; set; }
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser InternalUpdatedBy { get; set; }
        
    }
}
