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
        public ClientType ClientType { get; set; }
        public Guid FundingOpportunityId { get; set; }
        public FundingOpportunity FundingOpportunity { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid CreatedByInternalUserId { get; set; }
        public Guid UpdatedByInternalUserId { get; set; }
        [ForeignKey("CreatedByInternalUserId")]
        public InternalUser CreatedBy { get; set; }
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser UpdatedBy { get; set; }
    }
}
