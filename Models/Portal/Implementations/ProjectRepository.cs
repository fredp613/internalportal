using InternalPortal.Models.Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InternalPortal.Models.Portal.Implementations
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public PortalContext PortalContext
        {
            get { return Context as PortalContext; }
        }
        public ProjectRepository(PortalContext context) : base(context)
        {
        }

        public IEnumerable<Project> GetProjectsByUser(Guid UserId, int pageIndex, int pageSize)
        {
            return PortalContext.Project
                .Where(p=>p.CreatedByUserId == UserId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public bool ProjectExists(Guid projectId)
        {
            return PortalContext.Project.Any(e => e.ProjectId == projectId);

        }

       
    }
}
