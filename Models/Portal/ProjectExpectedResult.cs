using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectExpectedResult
    {
        public Guid ID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid ExpectedResultID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}
