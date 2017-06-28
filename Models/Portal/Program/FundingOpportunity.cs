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

        [NotMapped]
        public string Lang { get; set; }

        [NotMapped]
        public string Title
        {
            get { return Lang == "EN" ? TitleE : TitleF; }
            set { Title = Lang == "EN" ? TitleE : TitleF; }
        }

        [NotMapped]
        public string Description
        {
            get { return Lang == "EN" ? DescriptionE : DescriptionF; }
            set { Description = Lang == "EN" ? DescriptionE : DescriptionF; }
        }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }

        [NotMapped]
        public string Objectives { get; set; }
        [NotMapped]
        public string ExpectedResults { get; set; }
        [NotMapped]
        public string EligibilityCriterias { get; set; }

        public string AdditionalInformationE { get; set; }
        public string AdditionalInformationF { get; set; }
        public DateTime ActivationStartDate { get; set; }
        public DateTime ActivationEndDate { get; set; }
        public bool OnHold {get; set;}
        public IEnumerable<FundingOpportunityExpectedResult> FundingOpportunityExpectedResults { get; set;}
        public IEnumerable<FundingOpportunityObjective> FundingOpportunityObjectives { get; set; }
        public IEnumerable<FundingOpportunityEligibilityCriteria> FundingOpportunityEligibilityCriterias { get; set; }      
        public IEnumerable<EligibleClientType> EligibleClientTypes { get; set; }
        public IEnumerable<EligibleCostCategory> EligibleCostCategories { get; set; }

        public string GcimsCommitmentItemId { get; set; }
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
