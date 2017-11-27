using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




public class luExpenseCategories
{
    [Key]
    public int ExpenseCategoryID { get; set; }

    public string ExpenseCategoryDescriptionE { get; set; }

    public string ExpenseCategoryDescriptionF { get; set; }
    [NotMapped]
    public string ExpenseCategoryBillingual
    {
        get { return ExpenseCategoryBillingual = (ExpenseCategoryDescriptionE + " - " + ExpenseCategoryDescriptionF); }
        set { }
    }

    public short? Active { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}

public class tblContacts
{
    [Key]
    public int ContactID { get; set; }

    public string ClientID { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Title { get; set; }

    public string Initials { get; set; }

    public string SalutationID { get; set; }

    public string LanguageID { get; set; }

    public bool Historical { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string AddressLine3 { get; set; }

    public string AddressLine4 { get; set; }

    public string OldProvinceID { get; set; }

    public string OldCityID { get; set; }

    public string PostalCode { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public bool Disabled { get; set; }

    public int? CityID { get; set; }

}

public class tblProjects
{
    [Key]
    public int ProjectID { get; set; }

    public string ClientID { get; set; }

    public string ProjectFiscalYearID { get; set; }

    public int ProjectNumber { get; set; }

    public string ProjectName { get; set; }

    public string ProjectDescription { get; set; }

    public string FundingTypeID { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string ProjectComments { get; set; }

    public string FileRegistryNumber { get; set; }

    public string CreatorProvinceID { get; set; }

    public string CreatorRegionID { get; set; }

    public string DepartmentID { get; set; }

    public string BusinessLineID { get; set; }

    public string ProductLineID { get; set; }

    public decimal? ProjectRequestedAmount { get; set; }

    public decimal? ProjectRecommendedAmount { get; set; }

    public decimal? ProjectApprovedAmount { get; set; }

    public decimal? ProjectAllocatedAmount { get; set; }

    public decimal? ProjectPaidAmount { get; set; }

    public bool LazyExpenses { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string LogicalUpdatedBy { get; set; }

    public DateTime? LogicalUpdatedDate { get; set; }

    public bool IsWebProject { get; set; }

    public string PostalCode { get; set; }

    public int? OriginalElectoralRidingID { get; set; }

    public string ProjectDescriptionE { get; set; }

    public string ProjectDescriptionF { get; set; }

    public string ProjectDescriptionLanguageID { get; set; }

    public int? ProjectTypeID { get; set; }

    public tblApplications tblApplication { get; set; }
}

public class tblApplications
{
    [Key]
    public int ApplicationID { get; set; }

    public int ProjectID { get; set; }

    public string ApplicationFiscalYearID { get; set; }

    public string DepartmentID { get; set; }

    public string BusinessLineID { get; set; }

    public string ProductLineID { get; set; }

    public string SubServiceLineID { get; set; }

    public string SummaryCommitmentID { get; set; }

    public string CommitmentItemID { get; set; }

    public string RegionID { get; set; }

    public string FundCentreID { get; set; }

    public string ProvinceID { get; set; }

    public short? ApplicationNumber { get; set; }

    public string FundingMethodID { get; set; }

    public string FundingAttributeID { get; set; }

    public string ApplicationStatusID { get; set; }

    public string ApprovalTypeID { get; set; }

    public DateTime? RecievedDate { get; set; }

    public DateTime? CompletedDate { get; set; }

    public decimal? RequestedAmount { get; set; }

    public decimal? RecommendedAmount { get; set; }

    public DateTime? RecommendedDate { get; set; }

    public decimal? ApprovedAmount { get; set; }

    public decimal? ApplicationAllocatedAmount { get; set; }

    public decimal? ApplicationPaidAmount { get; set; }

    public string ApplicationComments { get; set; }

    public string AssessmentComments { get; set; }

    public string ChequeName { get; set; }

    public int ContactID { get; set; }

    public DateTime? MinisterialApprovalDate { get; set; }

    public short OnHold { get; set; }

    public int? CurrentOwnerID { get; set; }

    public int? PreviousOwnerID { get; set; }

    public int? OfficerOfRecordID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? EligibilityDataHeaderID { get; set; }

    public int? UnOfficiallyEligible { get; set; }

    public string LogicalUpdatedBy { get; set; }

    public DateTime? LogicalUpdatedDate { get; set; }

    public int? IndicatorTemplateID { get; set; }

    public Guid? AmendmentID { get; set; }

    public string ProgramFileNumber { get; set; }

    public int? ProjectTypeID { get; set; }

    public int? AddressID { get; set; }

    public DateTime? AcknowledgmentDate { get; set; }

}

public class luApplicationStatuses
{
    [Key]
    public string ApplicationStatusID { get; set; }

    public string ApplicationStatusDescriptionE { get; set; }

    public string ApplicationStatusDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luApprovalTypes
{
    [Key]
    public string ApprovalTypeID { get; set; }

    public string ApprovalTypeDescriptionE { get; set; }

    public string ApprovalTypeDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luBusinessLines
{
    [Key]
    public string BusinessLineID { get; set; }

    public string BusinessLineDescriptionE { get; set; }

    public string BusinessLineDescriptionF { get; set; }

    public string DepartmentID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luCommitmentItems
{
    [Key]
    public string CommitmentItemID { get; set; }

    public string CommitmentItemDescriptionE { get; set; }

    public string CommitmentItemDescriptionF { get; set; }
    
    [NotMapped]
    public string CommitmentItemBillingual
    {
        get { return CommitmentItemBillingual = (CommitmentItemDescriptionE + " - "  + CommitmentItemDescriptionF); }
        set { }
    }
    [NotMapped]
    public string CommitmentItemID_DescriptionBilingual
    {
        get { return CommitmentItemID_DescriptionBilingual = (CommitmentItemID + " - " + (CommitmentItemDescriptionE + "/" + CommitmentItemDescriptionF)); }
        set { }
    }

    public string SummaryCommitmentID { get; set; }

    public string SAPCommitmentItemID { get; set; }

    public string FundingMethodID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luDepartments
{
    [Key]
    public string DepartmentID { get; set; }

    public string DepartmentDescriptionE { get; set; }

    public string DepartmentDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luFiscalYears
{
    [Key]
    public string FiscalYearID { get; set; }

    public string FiscalYearDescription { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luFundCentres
{
    [Key]
    public string FundCentreID { get; set; }

    public string FundCentreDescriptionE { get; set; }

    public string FundCentreDescriptionF { get; set; }

    public string SAPFundCentreID { get; set; }

    public string RegionID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string AddressLine1E { get; set; }

    public string AddressLine2E { get; set; }

    public string AddressLine3E { get; set; }

    public string AddressLine4E { get; set; }

    public string OldProvinceID { get; set; }

    public string OldCityID { get; set; }

    public string PostalCode { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string Email { get; set; }

    public int? CityID { get; set; }

    public string AddressLine1F { get; set; }

    public string AddressLine2F { get; set; }

    public string AddressLine3F { get; set; }

    public string AddressLine4F { get; set; }

}
public class luFundingAttributes
{
    [Key]
    public string FundingAttributeID { get; set; }

    public string FundingAttributeDescriptionE { get; set; }

    public string FundingAttributeDescriptionF { get; set; }

    public string IncludeFundingMethodID { get; set; }

    public string IncludeFundingTypeID { get; set; }

    public string ExcludeFundingTypeID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luFundingMethods
{
    [Key]
    public string FundingMethodID { get; set; }

    public string FundingMethodDescriptionE { get; set; }

    public string FundingMethodDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luProductLines
{
    [Key]
    public string ProductLineID { get; set; }

    public string ProductLineDescriptionE { get; set; }

    public string ProductLineDescriptionF { get; set; }

    public string BusinessLineID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luProjectTypes
{
    [Key]
    public int ProjectTypeID { get; set; }

    public string ProjectTypeShortDescriptionE { get; set; }

    public string ProjectTypeShortDescriptionF { get; set; }

    public string ProjectTypeDescriptionE { get; set; }

    public string ProjectTypeDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool Active { get; set; }

}
public class luProvinces
{
    [Key]
    public string ProvinceID { get; set; }

    public string ProvinceDescriptionE { get; set; }

    public string ProvinceDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int CountryID { get; set; }

}
public class luRegions
{
    [Key]
    public string RegionID { get; set; }

    public string RegionDescriptionE { get; set; }

    public string RegionDescriptionF { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luSubServiceLines
{
    [Key]
    public string SubServiceLineID { get; set; }

    public string SubServiceLineDescriptionE { get; set; }

    public string SubServiceLineDescriptionF { get; set; }

    public string ProductLineID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class luSummaryCommitments
{
    [Key]
    public string SummaryCommitmentID { get; set; }

    public string SummaryCommitmentDescriptionE { get; set; }

    public string SummaryCommitmentDescriptionF { get; set; }

    public string SubServiceLineID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}
public class tblClients
{
    [Key]
    public string ClientID { get; set; }

    public string ClientName { get; set; }

    public string TranslatedName { get; set; }

    public string PreviousName { get; set; }

    public string Scope { get; set; }

    public string Mandate { get; set; }

    public string LanguageID { get; set; }

    public string ClientComments { get; set; }

    public string CharityTypeID { get; set; }

    public string CharityNumber { get; set; }

    public DateTime? CharityDate { get; set; }

    public bool CharityInProcess { get; set; }

    public DateTime? CharityAppliedDate { get; set; }

    public string IncorporationTypeID { get; set; }

    public string IncorporationNumber { get; set; }

    public string IncorporationName { get; set; }

    public bool IncorporationInProcess { get; set; }

    public DateTime? IncorporationDate { get; set; }

    public DateTime? IncorporationAppliedDate { get; set; }

    public string SAPVendorCode { get; set; }

    public string CitizenshipTypeID { get; set; }

    public string SalutationID { get; set; }

    public string Title { get; set; }

    public string WebSiteAddress { get; set; }

    public string History { get; set; }

    public bool PreviousGrant { get; set; }

    public bool OtherFunding { get; set; }

    public string CreatorProvinceID { get; set; }

    public string CreatorRegionID { get; set; }

    public string DepartmentID { get; set; }

    public string BusinessLineID { get; set; }

    public string ProductLineID { get; set; }

    public decimal? ClientRequestedAmount { get; set; }

    public decimal? ClientRecommendedAmount { get; set; }

    public decimal? ClientApprovedAmount { get; set; }

    public decimal? ClientAllocatedAmount { get; set; }

    public decimal? ClientPaidAmount { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string Email { get; set; }

    public int? PrimaryContact { get; set; }

    public string LogicalUpdatedBy { get; set; }

    public DateTime? LogicalUpdatedDate { get; set; }

    public string SportCode { get; set; }

    public string GeographicScopeID { get; set; }

    public int ClientTypeID { get; set; }

}

public class tblAddresses
{
    [Key]
    public int AddressID { get; set; }

    public string AddressLine1 { get; set; }

    public string AddressLine2 { get; set; }

    public string AddressLine3 { get; set; }

    public string AddressLine4 { get; set; }

    public string OldProvinceID { get; set; }

    public string OldCityID { get; set; }

    public string PostalCode { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public string ClientID { get; set; }

    public int AddressTypeID { get; set; }

    public bool Historical { get; set; }

    public int CityID { get; set; }

}
public class tblAmendments
{
    [Key]
    public Guid AmendmentID { get; set; }

    public int ProjectID { get; set; }

    public int AmendmentNumber { get; set; }

    public int AmendmentStatusID { get; set; }

    public int AmendmentReasonID { get; set; }

    public string Rational { get; set; }

    public string Comments { get; set; }

    public string SignedOffBy { get; set; }

    public DateTime? SignedOffDate { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? ApprovalDate { get; set; }

}

public class tblEligibilityDataHeader
{
    [Key]
    public int EligibilityDataHeaderID { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

}

public class tblUsers
{
    [Key]
    public int UserID { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Firstname { get; set; }

    public string Lastname { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Fax { get; set; }

    public int? DelegateID { get; set; }

    public string LanguageID { get; set; }

    public string RegionID { get; set; }

    public string ProvinceID { get; set; }

    public int UserTypeID { get; set; }

    public bool Active { get; set; }

    public int? UserRoleID { get; set; }

    public string UserTitleDescription { get; set; }

    public string FundingTypeID { get; set; }

    public bool FinancialCodingPrefered { get; set; }

    public DateTime? LastLogin { get; set; }

    public string CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool AutoCheckSpelling { get; set; }

    public int? WorkOfficeID { get; set; }

    public DateTime PasswordModifiedDate { get; set; }

    public bool MustChangePassword { get; set; }

    public bool PasswordDoesNotExpire { get; set; }

}

