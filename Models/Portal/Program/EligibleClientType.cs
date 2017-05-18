using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public Guid ID { get; set; }
        public ClientType ClientType { get; set; }
        public Guid FundingOpportunityID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public InternalUser CreatedBy { get; set; }
        public InternalUser UpdatedBy { get; set; }
    }
}
