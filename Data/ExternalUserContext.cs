using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models.Portal;
using InternalPortal.Models.Portal.Program;
using InternalPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InternalPortal.Models
{
    public class ExternalUserContext : DbContext
    {

        public ExternalUserContext(DbContextOptions<ExternalUserContext> options)
            : base(options)
        {
        }
        public ExternalUserContext()
        {

        }

        //public ExternalUserContext(DbContextOptions options) : base(options)
        //{
        //}


        //public DbSet<InternalPortal.Models.User> User { get; set; }
        public DbSet<InternalPortal.Models.Portal.LogoutSession> LogoutSession { get; set; }

    }
}

