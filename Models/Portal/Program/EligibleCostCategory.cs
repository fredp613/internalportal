using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class EligibleCostCategory
    {
        [Key]
        public Guid EligibleCostCategoryId { get; set; }
        public Guid CostCategoryId { get; set; }
        public Guid FundingOpportunityId { get; set; }
        public CostCategory CostCategory { get; set; }

        public string TitleE { get; set; }
        public string TitleF { get; set; }
        public string TooltipE { get; set; }
        public string TooltipF { get; set; }
        [NotMapped]
        public string Lang { get; set; }
        [NotMapped]
        public string Title
        {
            get { return Lang == "EN" ? TitleE : TitleF; }
            set { Title = Lang == "EN" ? TitleE : TitleF; }
        }
        [NotMapped]
        public string ToolTip
        {
            get { return Lang == "EN" ? TooltipE : TooltipF; }
            set { ToolTip = Lang == "EN" ? TooltipE : TooltipF; }
        }
        public FundingOpportunity FundingOpportunity { get; set; }
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
