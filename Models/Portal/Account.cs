﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models
{
    public class Account
    {
        [Key]
        public Guid AccountId { get; set; }
        public string GcimsClientID { get; set; }
        public string AccountName { get; set; }
        public string LegalName { get; set; }
        //public Guid? PrimaryAddressId { get; set; }
        //public Guid? PaymentAddressId { get; set; }
        //[ForeignKey("PrimaryAddressId")]
        //public virtual AccountAddress PrimaryAddress { get; set; }
        //[ForeignKey("PaymentAddressId")]
        //public virtual AccountAddress PaymentAddress { get; set; }
        //public List<AccountAddress> AccountAdresses { get; set; }
        public List<AccountContact> AccountContacts { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }     
        public Guid? UpdatedByInternalUserId { get; set; }        
        [ForeignKey("UpdatedByInternalUserId")]
        public InternalUser InternalUpdatedBy { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public Guid? UpdatedByUserId { get; set; }
        [ForeignKey("CreatedByUserId")]
        public User CreatedBy { get; set; }        
        [ForeignKey("UpdatedByUserId")]
        public User UpdatedBy { get; set; }

    }
}
