using InternalPortal.Models.Portal.Interfaces;
using InternalPortal.Models.Portal.Program;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Implementations
{
    public class ClientTypeStatic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleE { get; set; }
        public string TitleF { get; set; }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }
    }
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

        public IEnumerable<ClientTypeStatic> GetEligibleClientTypeList()
        {
            var objs = new List<ClientTypeStatic>();

            var ngo = new ClientTypeStatic
            {
                Id = 1,
                Title = "ngo / ngo",
                TitleE = "ngo",
                TitleF = "ngo",
                DescriptionE = "ngo",
                DescriptionF = "ngo"
            };
            var pt = new ClientTypeStatic
            {
                Id = 2,
                Title = "pt / pt",
                TitleE = "pt",
                TitleF = "pt",
                DescriptionE = "pt",
                DescriptionF = "pt"
            };
            var priv = new ClientTypeStatic
            {
                Id = 3,
                Title = "for profit / for profit",
                TitleE = "for profit",
                TitleF = "for profit",
                DescriptionE = "for profit",
                DescriptionF = "for profit"
            };
            var ind = new ClientTypeStatic
            {
                Id = 4,
                Title = "individual / individual",
                TitleE = "individual",
                TitleF = "individual",
                DescriptionE = "individual",
                DescriptionF = "individual"
            };
            var indig = new ClientTypeStatic
            {
                Id = 5,
                Title = "Indigenous / Indigenous",
                TitleE = "Indigenous",
                TitleF = "Indigenous",
                DescriptionE = "Indigenous",
                DescriptionF = "Indigenous"
            };
            objs.AddRange(new List<ClientTypeStatic>() { ngo, pt, priv, ind, indig });            
            return objs;
        }

        public ClientTypeStatic GetEligibleClientType(int id)
        {           
            return GetEligibleClientTypeList().FirstOrDefault(o => o.Id == id);       
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
