using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class FundingOpportunityObjective
    {
        [Key]
        public Guid ID { get; set; }
        public Objective ExpectedResult { get; set; }
        public FundingOpportunity FundingOpportunity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public InternalUser CreatedBy { get; set; }
        public InternalUser UpdatedBy { get; set; }
    }
}
