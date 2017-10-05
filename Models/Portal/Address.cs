using InternalPortal.Models.Portal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public int GcimsAddressId { get; set; }
        public string AddressLine1 {get; set;}
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string City { get; set; }
        public int GcimsCityID { get; set; }
        public string Province { get; set; }
        public int GcimsProvinceID { get; set; }
        public string Country { get; set; }
        public int GcimsCountryID { get; set; }
        public string Postal { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
  
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
      
      
    }
}
