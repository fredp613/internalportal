using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal
{
    public class LogoutSession
    {
        //public Guid Id { get; set; }
        [Key]
        public string SessionIndex { get; set; }
        public string NameId { get; set; }
        
    }
}
