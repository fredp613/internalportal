using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectContact
    {
        public Guid ID { get; set; }
        public Contact Contact { get; set; }
        public Project Project { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}
