using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class CostCategory
    {
        [Key]
        public Guid ID { get; set; }
        public string GcimsCostCategoryID { get; set; }
        public string TitleE { get; set; }
        public string TitleF { get; set; }
        public string ToolTipE { get; set; }
        public string ToolTipF { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public InternalUser CreatedBy { get; set; }
        public InternalUser UpdatedBy { get; set; }

    }
}
