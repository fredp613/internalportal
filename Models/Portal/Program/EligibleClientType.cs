using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public enum ClientType
    {
        NGO = 1,
        Province = 2,
        Municipality = 3,
        ForProfit = 4,
        Individual = 5
    }
    public class EligibleClientType
    {
        [Key]
        public Guid EligibleClientTypeId { get; set; }        
        public Guid FundingOpportunityId { get; set; }
        public FundingOpportunity FundingOpportunity { get; set; }
        public string TitleE { get; set; }
        public string TitleF { get; set; }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }
        [NotMapped]
        public string Lang { get; set; }
        [NotMapped]
        public string Description { get {
                return Lang == "EN" ? DescriptionE : DescriptionF;
        } set { } }
        [NotMapped]
        public string Title
        {
            get
            {
                return Lang == "EN" ? TitleE : TitleE;
            }
            set { }
        }

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
