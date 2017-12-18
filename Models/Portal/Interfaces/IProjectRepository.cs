using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsByUser(Guid UserId, int pageIndex, int pageSize);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsNotAssigned(string lang, Guid UserId);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsNotClaimed(string lang, Guid UserId);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsAssigned(string lang, Guid UserId);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsIncomplete(string lang, Guid UserId);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsPreScreened(string lang, Guid UserId);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsWithdrawn(string lang, Guid UserId);
        IEnumerable<Project> GetWorkloadManagerSubmittedProjectsRejected(string lang, Guid UserId);

        IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsNotClaimed(string lang, Guid UserId);
        IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsAssigned(string lang, Guid UserId);
        IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsIncomplete(string lang, Guid UserId);
        IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsPreScreened(string lang, Guid UserId);
        IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsWithdrawn(string lang, Guid UserId);
        IEnumerable<Project> GetSubmissionReviewerSubmittedProjectsRejected(string lang, Guid UserId);
        bool ProjectExists(Guid projectId);

      

    }
}
