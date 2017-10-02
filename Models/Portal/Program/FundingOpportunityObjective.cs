using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class FundingOpportunityObjective
    {
        [Key]
        public Guid FundingOpportunityObjectiveId { get; set; }
        [Required]
        public Guid FundingOpportunityId { get; set; }
        [Required]
        public Guid ObjectiveId { get; set; }
        [JsonIgnore]
        public Objective Objective { get; set; }
        [JsonIgnore]
        public FundingOpportunity FundingOpportunity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        
       
        
       
        
    }
}
