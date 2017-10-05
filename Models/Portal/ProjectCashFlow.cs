using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectCashFlow
    {
        [Key]
        public Guid ProjectCashFlowId {get; set;}
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
        public string FiscalYear { get; set; }
        public double Amount { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
     
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
     
    }
}
