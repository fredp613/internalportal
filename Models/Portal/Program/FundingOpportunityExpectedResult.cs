using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class FundingOpportunityExpectedResult
    {
        [Key]
        public Guid FundingOpportunityExpectedResultId { get; set; }
        public Guid ExpectedResultId { get; set; }
        public Guid FundingOpportunityId { get; set; }
        public ExpectedResult ExpectedResult { get; set; }
        public FundingOpportunity FundingOpportunity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
       
    }
}
