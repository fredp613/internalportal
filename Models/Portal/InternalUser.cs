using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InternalPortal.Models.Portal.Program;

/**
  1.FP manager
  2.SR
  3.FO Admin
  4.Portal Admin
  **/

namespace InternalPortal.Models.Portal
{
    public class InternalUser
    {
        [Key]
        public Guid InternalUserId { get; set; }      
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } set { } }
	    public IEnumerable<InternalUserRole> InternalUserRoles {get; set;}
        public IEnumerable<FundingProgramInternalUser> FundingProgramInternalUsers { get; set; }
        public IEnumerable<FundingOpportunityInternalUser> FundingOpportunityInternalUsers { get; set; }
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
