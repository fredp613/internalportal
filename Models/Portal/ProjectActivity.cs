using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class ProjectActivity
    {
        [Key]
        public Guid ProjectActivityId { get; set; }
        public Guid ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Output { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }


    }
}
