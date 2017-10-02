using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InternalPortal.Models.Portal.Program;
using Newtonsoft.Json;

/**
  1.FP manager
  2.SR
  3.FO Admin
  4.Portal Admin
  **/

namespace InternalPortal.Models.Portal
{
    public class InternalUserRole
    {
        [Key]
	    public Guid InternalUserRoleId {get; set;}
        public Guid InternalUserId { get; set; }    
        [JsonIgnore]
	    public InternalUser InternalUser {get; set;}
        public string Role { get; set; }
        [NotMapped]
        public string RoleDesc { get {
                if (Role == "1")
                {
                    return "Workload Manager";
                }
                else if (Role == "2")
                {
                    return "Submission Reviewer";
                }
                else if (Role == "3")
                {
                    return "Funding Opportunities Administrator";
                }
                else {
                    return "Portal Administrator";
                }
            } set { } }
        public DateTime CreatedOn { get; set; }
        
    }
}
