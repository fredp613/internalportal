﻿using InternalPortal.Models.Portal.Program;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class FundingProgramInternalUser
    {
        [Key]
        public Guid FundingProgramInternalUserId { get; set; }
        public Guid FundingProgramId { get; set; }
        [JsonIgnore]
        public FundingProgram FundingProgram { get; set; }
        public Guid InternalUserId { get; set; }
        [JsonIgnore]
        internal InternalUser InternalUser { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        //public Guid? CreatedByInternalUserId { get; set; }
        //public Guid? UpdatedByInternalUserId { get; set; }
        //
        //public InternalUser CreatedBy { get; set; }
        //
        //public InternalUser UpdatedBy { get; set; }
    }
}
