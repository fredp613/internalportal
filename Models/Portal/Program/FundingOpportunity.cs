using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class FundingOpportunity
    {
        [Key]
        public Guid FundingOpportunityId { get; set; }
        public string TitleE { get; set; }
        public string TitleF { get; set; }
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
        public IEnumerable<EligibleClientType> EligibleClientTypes { get; set; }
        public IEnumerable<EligibilityCriteria> EligilityCriterias{ get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        [ForeignKey("CreatedByInternalUserId")]
        public InternalUser CreatedBy { get; set; }
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser UpdatedBy { get; set; }

    }
}
