using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class ProjectMember
    {
        [Key]
        public Guid ProjectMemberId { get; set; }
        public string NamePosition { get; set; }
        public string Role { get; set; }
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
    }
}
