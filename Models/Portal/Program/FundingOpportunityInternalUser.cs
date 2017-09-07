using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class FundingOpportunityInternalUser
    {

        [Key]
        public Guid FundingOpportunityInternalUserId { get; set; }
        public Guid FundingOpportunityId { get; set; }
        internal FundingOpportunity FundingOpportunity { get; set; }
        public Guid InternalUserId { get; set; }
        public bool HasFullAccess { get; set; }
        public InternalUser InternalUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        //public Guid? CreatedByInternalUserId { get; set; }
        //public Guid? UpdatedByInternalUserId { get; set; }
        //
        //public InternalUser CreatedBy { get; set; }
        //
        //public InternalUser UpdatedBy { get; set; }
    }

}
