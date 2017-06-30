using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Interfaces
{
    public interface IEligibleClientType : IRepository<EligibleClientType>
    {
        IEnumerable<object> GetEligibleClientTypeList(); 
    }
}
