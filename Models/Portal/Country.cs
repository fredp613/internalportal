using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class Country
    {
        [Key]
        public string code { get; set; }
        public string name_en { get; set; }
        public string name_fr { get; set; }
    }
}
