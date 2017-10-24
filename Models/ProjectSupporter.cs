using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class ProjectSupporter
    {
        [Key]
        public Guid ProjectSupporterId { get; set; }
        public string Name { get; set; }
        public string Nature { get; set; }
        public Boolean IsConfirmed { get; set; }
        public Boolean IsOnGoingRelationship { get; set; }
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}
