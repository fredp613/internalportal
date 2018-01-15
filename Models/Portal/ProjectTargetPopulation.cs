using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectTargetPopulation
    {
        [Key]
        public Guid ProjectTargetPopulationId { get; set; }
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
        public string TargetPopulationEn { get; set; }
        public string TargetPopulationFr { get; set; }
        public bool IsOther { get; set; }
        public string TargetPopulationOther { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

    }
}
