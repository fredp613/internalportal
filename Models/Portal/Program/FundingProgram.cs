using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class FundingProgram
    {
        [Key]
        public Guid FundingProgramId { get; set; }

        [NotMapped]
        public string Lang { get; set; }
        [NotMapped]
        public string Title
        {
            get { return Lang == "EN" ? TitleE : TitleF; }
            set { Description = Lang == "EN" ? TitleE : TitleF; }
        }
        public string TitleE { get; set; }
        public string TitleF { get; set; }

        [NotMapped]
        public string Description
        {
            get { return Lang == "EN" ? DescriptionE : DescriptionF; }
            set { Description = Lang == "EN" ? DescriptionE : DescriptionF; }
        }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        [ForeignKey("CreatedByInternalUserId")]
        public InternalUser CreatedBy { get; set; }
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser UpdatedBy { get; set; }
        public IEnumerable<FundingOpportunity> FundingOpportunities { get; set; }
        public IEnumerable<FundingProgramInternalUser> FundingProgramInternalUsers { get; set; }
    }
}
