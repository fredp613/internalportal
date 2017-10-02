using InternalPortal.Models.Helpers;
using InternalPortal.Models.Portal.Program;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InternalPortal.Models.Portal.Program
{
    public enum FOStatus 
    {
        Draft = 0,
        Published = 1,
        Archived = 2,
        Closed = 3
    }
   
    public class FundingOpportunity
    {
        [Key]
        public Guid FundingOpportunityId { get; set; }
        public Guid FundingProgramId { get; set; }
        [JsonIgnore]
        public FundingProgram FundingProgram { get; set; }       
        public string TitleE { get; set; }
        public string TitleF { get; set; }
        [NotMapped]
        public string Lang { get; set; }
        [NotMapped]
        public string Title
        {
            get { return Lang == "EN" ? TitleE : TitleF; }
            set { Title = Lang == "EN" ? TitleE : TitleF; }
        }
        [NotMapped]
        public string Description
        {
            get { return Lang == "EN" ? DescriptionE : DescriptionF; }
            set { Description = Lang == "EN" ? DescriptionE : DescriptionF; }
        }
        public string DescriptionE { get; set; }
        public string DescriptionF { get; set; }
        [NotMapped]
        public string Objectives { get; set; }
        [NotMapped]
        public string ExpectedResults { get; set; }
        [NotMapped]
        public string EligibilityCriterias { get; set; }
        public string AdditionalInformationE { get; set; }
        public string AdditionalInformationF { get; set; }
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime ActivationStartDate { get; set; }
        [Column(TypeName = "Date")]
        [JsonConverter(typeof(OnlyDateConverter))]
        public DateTime ActivationEndDate { get; set; }
        public bool OnHold {get; set;}
        public FOStatus Status { get; set; }
        [NotMapped]
        public string StatusDesc { get {
                if (Status == FOStatus.Published && ActivationStartDate <= DateTime.Now && ActivationEndDate >= DateTime.Now)
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Active";
                    } 
                    return StatusDesc = "Actif";
                }
                else if (ActivationStartDate > DateTime.Now && Status == FOStatus.Published)
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Awaiting publish";
                    }
                    return StatusDesc = "En attente de publication";
                }
                else if (Status == FOStatus.Draft)
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Draft";
                    }
                    return StatusDesc = "Brouillon";
                }
                else if (Status == FOStatus.Closed && ActivationStartDate <= DateTime.Now && ActivationEndDate >= DateTime.Now)
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Closed";
                    }
                    return StatusDesc = "Fermé";
                }
                else if (Status == FOStatus.Closed && (ActivationStartDate > DateTime.Now || ActivationEndDate < DateTime.Now))
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Closed-Expired";
                    }
                    return StatusDesc = "Fermé-Expiré";
                }
                else if (Status == FOStatus.Published && (ActivationStartDate > DateTime.Now || ActivationEndDate < DateTime.Now))
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Closed-Expired";
                    }
                    return StatusDesc = "Fermé-Expiré";
                }
                else
                {
                    if (Lang == "EN")
                    {
                        return StatusDesc = "Archived";
                    }
                    return StatusDesc = "Expiré";
                }
            } set { }
        }
        public IEnumerable<FundingOpportunityExpectedResult> FundingOpportunityExpectedResults { get; set;}
        public IEnumerable<FundingOpportunityObjective> FundingOpportunityObjectives { get; set; }
        public IEnumerable<FundingOpportunityEligibilityCriteria> FundingOpportunityEligibilityCriterias { get; set; }      
        public IEnumerable<EligibleClientType> EligibleClientTypes { get; set; }
        public IEnumerable<EligibleCostCategory> EligibleCostCategories { get; set; }
        public IEnumerable<FundingOpportunityConsideration> FundingOpportunityConsiderations { get; set; }
        public IEnumerable<FundingOpportunityFrequentlyAskedQuestion> FundingOpportunityFrequentlyAskedQuestions { get; set; }
        public IEnumerable<FundingOpportunityResource> FundingOpportunityResources { get; set; }
        public IEnumerable<FundingOpportunityInternalUser> FundingOpportunityInternalUsers { get; set; }       
        public string GcimsCommitmentItemId { get; set; }
        public string FormName { get; set; }
        public string TermsConditionsUrlEN { get; set; }
        public string TermsConditionsUrlFR { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Guid? CreatedByInternalUserId { get; set; }
        public Guid? UpdatedByInternalUserId { get; set; }
        
       
        
       
     
        
    }
}
