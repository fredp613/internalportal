using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace InternalPortal.Models.Portal
{
    public class InternalUser
    {
        [Key]
        public Guid InternalUserId { get; set; }      
        public string UserName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
	    [ForeignKey("CreatedBy")]
        public Guid? CreatedByInternalUserId { get; set; }
	    [ForeignKey("UpdatedBy")]
	    public Guid? UpdatedByInternalUserId { get; set; }
        public virtual InternalUser CreatedBy { get; set; }
        public virtual InternalUser UpdatedBy { get; set; }
        
    }
}
