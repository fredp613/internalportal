using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public class Objective
    {
        [Key]
        public Guid ObjectiveId { get; set; }
        public string GcimsAttributeID { get; set; }
        [NotMapped]
        public string Lang { get; set; }
       
        [NotMapped]
        public string Description
        {
            get { return Lang == "EN" ? DescriptionE : DescriptionF; }
            set { Description = Lang == "EN" ? DescriptionE : DescriptionF; }
        }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        [ForeignKey("CreatedByInternalUserId")]
        public InternalUser CreatedBy { get; set; }
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser UpdatedBy { get; set; }
    }
}
