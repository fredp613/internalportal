using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class AccountContact
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public Account Account { get; set; }
        [Required]
        public Contact Contact { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public User CreatedBy { get; set; }
        public User UpdatedBy { get; set; }
    }
}
