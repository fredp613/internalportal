using InternalPortal.Models.Portal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InternalPortal.Models.Portal.Program;

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

        public bool IsBucket(Guid Id)
        {
            var projectFo = PortalContext.Project.SingleOrDefault(p => p.ProjectId == Id);
            var foiu = PortalContext.FundingOpportunityInternalUser.Where(fo => fo.FundingOpportunityId == projectFo.FundingOpportunityID); 
            foreach(var iu in foiu)
            {
                var userId = iu.InternalUserId;
                var sub = PortalContext.InternalUser.SingleOrDefault(u => u.InternalUserId == userId);
                if (sub.IsSubmissionReviewer)
                {
                    return true;
                }

            }
          

            return false;

        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjects(string lang, Guid UserId)
        {
            var projs = PortalContext.Project.Where(p => p.ProjectStatus == Status.Submitted && p.GcimsProjectID == 0 && p.CurrentOwner == null);
            foreach (var proj in projs)
            {
                proj.Lang = lang;
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
            }
            return projs;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsNotAssigned(string lang, Guid UserId)
        {
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);

            List<Project> projects = new List<Project>();
            foreach (var fo in userFundingOpportunities)
            {
                var projs = PortalContext.Project.Where(p => p.FundingOpportunityID == fo.FundingOpportunityId && (p.ProjectStatus == Status.Submitted && p.GcimsProjectID == 0 && p.CurrentOwner == null));
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs.Where(x => !GetWorkloadManagerSubmittedProjectsNotClaimed("en", UserId).ToList().Select(p => p.ProjectId).Contains(x.ProjectId)));
            }
            return projects;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsNotClaimed(string lang, Guid UserId)
        {

            
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);
            List<Guid> BucketFOs = new List<Guid>();

            List<Project> projects = new List<Project>();
            foreach (var fo1 in userFundingOpportunities)
            {
                
                var submissionReviewers = PortalContext.InternalUser.Where(sr => sr.IsSubmissionReviewer == true).Select(i => i.InternalUserId);
                foreach (var sr in submissionReviewers)
                {
                    var foiu = PortalContext.FundingOpportunityInternalUser.SingleOrDefault(fo => fo.InternalUserId == sr && fo.FundingOpportunityId == fo1.FundingOpportunityId);

                    if (foiu != null)
                    {
                        BucketFOs.Add(foiu.FundingOpportunityId);

                    }
                  
                }
            }

            foreach (var fo in BucketFOs.Distinct())
            {
                var projs = PortalContext.Project.Where(p => p.ProjectStatus == Status.Submitted && p.GcimsProjectID == 0 && p.CurrentOwner == null && p.FundingOpportunityID == fo);
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }

            return projects;
            
        
        }


        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsAssigned(string lang, Guid UserId)
        {
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);
            List<Project> projects = new List<Project>();
            foreach (var fo in userFundingOpportunities)
            {
                var projs = PortalContext.Project.Where(p => p.ProjectStatus == Status.Submitted && p.GcimsProjectID == 0 && p.CurrentOwner != null && p.FundingOpportunityID == fo.FundingOpportunityId);
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.CurrentOwnerName = PortalContext.InternalUser.SingleOrDefault(u => u.InternalUserId == proj.CurrentOwner).FullName;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }
            
            return projects;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsIncomplete(string lang, Guid UserId)
        {
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);

            List<Project> projects = new List<Project>();
            foreach (var fo in userFundingOpportunities)
            {
                var projs = PortalContext.Project.Where(p => p.FundingOpportunityID == fo.FundingOpportunityId && (p.ProjectStatus == Status.Incomplete && p.GcimsProjectID == 0));
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }
            return projects;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsWithdrawn(string lang, Guid UserId)
        {
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);

            List<Project> projects = new List<Project>();
            foreach (var fo in userFundingOpportunities)
            {
                var projs = PortalContext.Project.Where(p => p.FundingOpportunityID == fo.FundingOpportunityId && (p.ProjectStatus == Status.Withdrawn && p.GcimsProjectID == 0));
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }
            return projects;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsPreScreened(string lang, Guid UserId)
        {
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);

            List<Project> projects = new List<Project>();
            foreach (var fo in userFundingOpportunities)
            {
                var projs = PortalContext.Project.Where(p => p.FundingOpportunityID == fo.FundingOpportunityId && (p.ProjectStatus == Status.Submitted && p.GcimsProjectID != 0));
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }
            return projects;
        }

        public IEnumerable<Project> GetWorkloadManagerSubmittedProjectsRejected(string lang, Guid UserId)
        {
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);

            List<Project> projects = new List<Project>();
            foreach (var fo in userFundingOpportunities)
            {
                var projs = PortalContext.Project.Where(p => p.FundingOpportunityID == fo.FundingOpportunityId && (p.ProjectStatus == Status.Rejected));
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }
            return projects;
        }



        public IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsNotClaimed(string lang, Guid UserId)
        {

          
            var userFundingOpportunities = PortalContext.FundingOpportunityInternalUser.Where(u => u.InternalUserId == UserId);
            List<Guid> BucketFOs = new List<Guid>();

            List<Project> projects = new List<Project>();
            foreach (var fo1 in userFundingOpportunities)
            {

                var submissionReviewers = PortalContext.InternalUser.Where(sr => sr.IsSubmissionReviewer == true).Select(i => i.InternalUserId);
                foreach (var sr in submissionReviewers)
                {
                    var foiu = PortalContext.FundingOpportunityInternalUser.SingleOrDefault(fo => fo.InternalUserId == sr && fo.FundingOpportunityId == fo1.FundingOpportunityId);

                    if (foiu != null)
                    {
                        BucketFOs.Add(foiu.FundingOpportunityId);

                    }

                }
            }

            foreach (var fo in BucketFOs.Distinct())
            {
                var projs = PortalContext.Project.Where(p => p.ProjectStatus == Status.Submitted && p.GcimsProjectID == 0 && p.CurrentOwner == null && p.FundingOpportunityID == fo);
                foreach (var proj in projs)
                {
                    proj.Lang = lang;
                    proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                    proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                    proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
                }
                projects.AddRange(projs);
            }

            return projects;


        }


        public IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsAssigned(string lang, Guid UserId)
        {
            
            var projects = PortalContext.Project.Where(u => u.CurrentOwner == UserId && u.ProjectStatus == Status.Submitted && u.GcimsProjectID == 0);

            foreach (var proj in projects)
            {
                proj.Lang = lang;
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
            }

            return projects;
        }

        public IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsIncomplete(string lang, Guid UserId)
        {
           
            var projects = PortalContext.Project.Where(u => u.CurrentOwner == UserId && u.ProjectStatus == Status.Incomplete);

            foreach (var proj in projects)
            {
                proj.Lang = lang;
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
            }

            return projects;
        }

        public IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsWithdrawn(string lang, Guid UserId)
        {
            var projects = PortalContext.Project.Where(p => p.CurrentOwner == UserId && p.ProjectStatus == Status.Withdrawn);

            foreach (var proj in projects)
            {
                proj.Lang = lang;
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
            }

            return projects;
        }

        public IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsPreScreened(string lang, Guid UserId)
        {     
            var projects = PortalContext.Project.Where(p => p.CurrentOwner == UserId && p.ProjectStatus == Status.Submitted && p.GcimsProjectID != 0);

            foreach (var proj in projects)
            {
                proj.Lang = lang;
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
            }

            return projects;            
        }

        public IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsRejected(string lang, Guid UserId)
        {
            var projects = PortalContext.Project.Where(p => p.CurrentOwner == UserId && p.ProjectStatus == Status.Rejected);
            foreach (var proj in projects)
            {
                proj.Lang = lang;
                proj.ContactName = PortalContext.Contact.SingleOrDefault(c => c.ContactId == proj.ContactId).FullName;
                proj.FundingOpportunityName = PortalContext.FundingOpportunity.SingleOrDefault(f => f.FundingOpportunityId == proj.FundingOpportunityID).TitleE;
                proj.Jurisdiction = PortalContext.Account.SingleOrDefault(j => j.AccountId == proj.AccountId).PrimaryState;
            }
            return projects;

        }

        public bool ProjectExists(Guid projectId)
        {
            return PortalContext.Project.Any(e => e.ProjectId == projectId);

        }

    }
}
