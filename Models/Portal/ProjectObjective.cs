using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectObjective
    {
        [Key]
        public Guid ID { get; set; }
        public Guid ProjectID { get; set; }
        public Guid ObjectiveID { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }

    }
}
