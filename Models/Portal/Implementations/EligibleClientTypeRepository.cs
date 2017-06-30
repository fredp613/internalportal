using InternalPortal.Models.Portal.Interfaces;
using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Implementations
{
    public class EligibleClientTypeRepository : Repository<EligibleClientType>, IEligibleClientType
    {

        public PortalContext PortalContext
        {
            get { return Context as PortalContext; }
        }
        private string _Language;
        public EligibleClientTypeRepository(PortalContext context, string language) : base(context, language)
        {
            _Language = language;
        }

        public IEnumerable<object> GetEligibleClientTypeList()
        {
            var objs = new List<object>();

            var ngo = new
            {
                Title = "f / f",
                TitleE = "f",
                TitleF = "f",
                DescriptionE = "f",
                DescriptionF = "f"
            };
            var pt = new
            {
                Title = "f / f",
                TitleE = "f",
                TitleF = "f",
                DescriptionE = "f",
                DescriptionF = "f"
            };
            var priv = new
            {
                Title = "f / f",
                TitleE = "f",
                TitleF = "f",
                DescriptionE = "f",
                DescriptionF = "f"
            };
            var ind = new
            {
                Title = "f / f",
                TitleE = "f",
                TitleF = "f",
                DescriptionE = "f",
                DescriptionF = "f"
            };
            var indig = new
            {
                Title = "f / f",
                TitleE = "f",
                TitleF = "f",
                DescriptionE = "f",
                DescriptionF = "f"
            };
            objs.AddRange(new List<object>() { ngo, pt, priv, ind, indig });            
            return objs;
        }

        //public enum ClientType
        //{
        //    NGO = 1,
        //    Province = 2,
        //    Municipality = 3,
        //    ForProfit = 4,
        //    Individual = 5
        //}



    }
}
