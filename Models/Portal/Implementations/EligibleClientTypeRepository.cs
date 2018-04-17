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
                Title = "Not-for-profit organization / Organismes à but non lucratif",
                TitleE = "Not-for-profit organization",
                TitleF = "Organismes à but non lucratif",
                DescriptionE = "Not-for-profit organization",
                DescriptionF = "Organismes à but non lucratif"
            };
            var pt = new ClientTypeStatic
            {
                Id = 2,
                Title = "Charity registered with the Canada Revenue Agency / Organismes de bienfaisance inscrits auprès de l'Agence du revenu du Canada",
                TitleE = "Charity registered with the Canada Revenue Agency",
                TitleF = "Organismes de bienfaisance inscrits auprès de l'Agence du revenu du Canada",
                DescriptionE = "Charity registered with the Canada Revenue Agency",
                DescriptionF = "Organismes de bienfaisance inscrits auprès de l'Agence du revenu du Canada"
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
                Title = "Individual or sole proprietorships / Particuliers ou entreprises à propriétaire unique",
                TitleE = "Individual or sole proprietorships",
                TitleF = "Particuliers ou entreprises à propriétaire unique",
                DescriptionE = "Individual or sole proprietorships",
                DescriptionF = "Particuliers ou entreprises à propriétaire unique"
            };
            var indig = new ClientTypeStatic
            {
                Id = 5,
                Title = "Band, First Nation, Tribal Council, or a local, regional or national Indigenous organization / Les bandes, les Premières Nations, les conseils tribaux et les organisations autochtones locales, régionales et nationales",
                TitleE = "Band, First Nation, Tribal Council, or a local, regional or national Indigenous organization",
                TitleF = "Les bandes, les Premières Nations, les conseils tribaux et les organisations autochtones locales, régionales et nationales",
                DescriptionE = "Band, First Nation, Tribal Council, or a local, regional or national Indigenous organization",
                DescriptionF = "Les bandes, les Premières Nations, les conseils tribaux et les organisations autochtones locales, régionales et nationales"
            };
            var Educ = new ClientTypeStatic
            {
                Id = 6,
                Title = "Education institution or School board / Établissements d’enseignement ou commissions scolaires",
                TitleE = "Education institution or School board",
                TitleF = "Établissements d’enseignement ou commissions scolaires",
                DescriptionE = "Education institution or School board",
                DescriptionF = "Établissements d’enseignement ou commissions scolaires"
            };
            var Gov = new ClientTypeStatic
            {
                Id = 7,
                Title = "Government (municipal, provincial, territorial or international) / Gouvernements (municipaux, provinciaux, territoriaux ou internationaux)",
                TitleE = "Government (municipal, provincial, territorial or international)",
                TitleF = "Gouvernements (municipaux, provinciaux, territoriaux ou internationaux)",
                DescriptionE = "Government (municipal, provincial, territorial or international)",
                DescriptionF = "Gouvernements (municipaux, provinciaux, territoriaux ou internationaux)"
            };
            var Inter = new ClientTypeStatic
            {
                Id = 8,
                Title = "International non-governmental organization / Gouvernements (municipaux, provinciaux, territoriaux ou internationaux)",
                TitleE = "International non-governmental organization",
                TitleF = "Organisations internationales non gouvernementales",
                DescriptionE = "International non-governmental organization",
                DescriptionF = "Organisations internationales non gouvernementales"
            };
            var Other = new ClientTypeStatic
            {
                Id = 9,
                Title = "Other / Autres",
                TitleE = "Other",
                TitleF = "Autres",
                DescriptionE = "Other",
                DescriptionF = "Autres"
            };
            objs.AddRange(new List<ClientTypeStatic>() { ngo, pt, priv, ind, indig, Educ,Gov,Inter, Other});            
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
