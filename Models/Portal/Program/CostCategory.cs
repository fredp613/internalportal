using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class CostCategory
    {
        [Key]
        public Guid CostCategoryId { get; set; }
        public string GcimsCostCategoryID { get; set; }
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
        public string ToolTip
        {
            get { return Lang == "EN" ? ToolTipE : ToolTipF; }
            set { ToolTip = Lang == "EN" ? ToolTipE : ToolTipF; }
        }
        public string ToolTipE { get; set; }
        public string ToolTipF { get; set; }
        public IEnumerable<FundingOpportunity> FundingOpportunities { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        
       
        
       

    }
}
