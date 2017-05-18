using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class FundingOpportunity
    {
        [Key]
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }
        public string AdditionalInformationE { get; set; }
        public string AdditionalInformationF { get; set; }
        public DateTime ActivationStartDate { get; set; }
        public DateTime ActivationEndDate { get; set; }
        public bool OnHold {get; set;}
        public IEnumerable<FundingOpportunityExpectedResult> ExpectedResults { get; set;}
        public IEnumerable<FundingOpportunityObjective> Objectives { get; set; }
        public IEnumerable<EligibleCostCategory> EligibleCostCategories { get; set; }
        public IEnumerable<EligibleCostCategory> EligibleClientTypes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public InternalUser CreatedBy { get; set; }
        public InternalUser UpdatedBy { get; set; }

    }
}
