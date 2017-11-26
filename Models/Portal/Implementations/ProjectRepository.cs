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
        private string _Language;
        
        public ProjectRepository(PortalContext context, string Language) : base(context, Language)
        {
            _Language = Language;
           
        }

        public IEnumerable<Project> GetProjectsByUser(Guid UserId, int pageIndex, int pageSize)
        {
            var projects = PortalContext.Project
                .Where(p => p.CreatedByUserId == UserId)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            foreach (var p in projects)
            {
                p.Lang = _Language;
            }
            return projects;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjects()
        {
            var projs = PortalContext.Project.Where(p => p.ProjectStatus == Status.Submitted);
            foreach (var proj in projs)
            {
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
            }
            return projs;
        }

        public bool ProjectExists(Guid projectId)
        {
            return PortalContext.Project.Any(e => e.ProjectId == projectId);

        }

       
    }
}
