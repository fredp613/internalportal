using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace InternalPortal.Models.Helpers
{
    public class InternalUserHandler : AuthorizationHandler<InternalUserRequirement>
    {
        private readonly PortalContext _context;

        public InternalUserHandler(PortalContext context)
        {            
            _context = context;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, InternalUserRequirement requirement)
        {
            //var username = context.User.Identity.Name.Substring(context.User.Identity.Name.IndexOf(@"\") + 1);           
	    var username = "fpearson";
            if (_context.InternalUser.Any(u => u.UserName == username))
            {       
                context.Succeed(requirement);
            }                      
            return Task.CompletedTask;            
        }
    }
}
