using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Helpers
{
   
    public class InternalUserRequirement : IAuthorizationRequirement
    {
        public string UserRole { get; set; }
        public InternalUserRequirement()
        {

        }
    }
}
