using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectExpectedResult
    {
        public Guid ProjectExpectedResultId { get; set; }
        public Guid ProjectID { get; set; }
        public Guid ExpectedResultID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
     
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
     
    }
}
