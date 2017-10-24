using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectFederalDepartment
    {
        [Key]
        public Guid ProjectFederalDepartmentId { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public Guid ProjectId { get; set; }
        //[JsonIgnore]
        //public Project Project { get; set; }
    }
}
