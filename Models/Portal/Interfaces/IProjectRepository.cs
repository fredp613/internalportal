using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        IEnumerable<Project> GetProjectsByUser(Guid UserId, int pageIndex, int pageSize);
        bool ProjectExists(Guid projectId);

    }
}
