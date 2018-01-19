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
                Title = "Non-Governmental Organizations / Organisations non gouvernementales",
                TitleE = "Non-Governmental Organizations",
                TitleF = "Organisations non gouvernementales",
                DescriptionE = "Organisations non gouvernementales ",
                DescriptionF = "Organisations non gouvernementales"
            };
            var pt = new ClientTypeStatic
            {
                Id = 2,
                Title = "Provincial and Territorial Governments / Gouvernements provinciaux et territoriaux",
                TitleE = "Provincial and Territorial Governments",
                TitleF = "Gouvernements provinciaux et territoriaux",
                DescriptionE = "Provincial and Territorial Governments",
                DescriptionF = "Gouvernements provinciaux et territoriaux"
            };
            var priv = new ClientTypeStatic
            {
                Id = 3,
                Title = "For Profit Organizations / Organisations à but lucratif",
                TitleE = "For Profit Organizations",
                TitleF = "Organisations à but lucratif",
                DescriptionE = "For Profit Organizations",
                DescriptionF = "Organisations à but lucratif"
            };
            var ind = new ClientTypeStatic
            {
                Id = 4,
                Title = "Individuals / Individus",
                TitleE = "Individuals",
                TitleF = "Individus",
                DescriptionE = "Individuals",
                DescriptionF = "Individus"
            };
            var indig = new ClientTypeStatic
            {
                Id = 5,
                Title = "Indigenous Organizations / Organisations indigène",
                TitleE = "Indigenous Organizations",
                TitleF = "Organisations indigène",
                DescriptionE = "Indigenous Organizations",
                DescriptionF = "Organisations indigène"
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
