using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class FundingOpportunityConsideration
    {
        [Key]
        public Guid FundingOpportunityConsiderationId { get; set; }
        public Guid ConsiderationId { get; set; }
        public Guid FundingOpportunityId { get; set; }
        [JsonIgnore]
        public Consideration Consideration { get; set; }
        [JsonIgnore]
        public FundingOpportunity FundingOpportunity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        
       
        
       
    }
}
