using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class All : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressId = table.Column<Guid>(nullable: false),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    AddressLine4 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    GcimsAddressId = table.Column<int>(nullable: false),
                    GcimsCityID = table.Column<int>(nullable: false),
                    GcimsCountryID = table.Column<int>(nullable: false),
                    GcimsProvinceID = table.Column<int>(nullable: false),
                    Postal = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressId);
                }); 

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false),
                    AboutMe = table.Column<string>(nullable: true),
                    Attempts = table.Column<int>(nullable: false),
                    BlockJustification = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GcimsContactID = table.Column<int>(nullable: true),
                    IsBlocked = table.Column<bool>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    MemorableDate = table.Column<DateTime>(nullable: false),
                    PaymentAccountAddressId = table.Column<Guid>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PreferredLanguageID = table.Column<string>(nullable: true),
                    PrimaryAccountAddressId = table.Column<Guid>(nullable: true),
                    PrimaryAddressLine1 = table.Column<string>(nullable: true),
                    PrimaryAddressLine2 = table.Column<string>(nullable: true),
                    PrimaryCity = table.Column<string>(nullable: true),
                    PrimaryCountry = table.Column<string>(nullable: true),
                    PrimaryPostal = table.Column<string>(nullable: true),
                    PrimaryState = table.Column<string>(nullable: true),
                    SalutationID = table.Column<string>(nullable: true),
                    ShareSecretQuestion = table.Column<string>(nullable: true),
                    SharedSecretAnswer = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    AccountSubType = table.Column<string>(nullable: true),
                    AccountType = table.Column<string>(nullable: true),
                    BandNumber = table.Column<string>(nullable: true),
                    BillingAddressLine1 = table.Column<string>(nullable: true),
                    BillingAddressLine2 = table.Column<string>(nullable: true),
                    BillingCity = table.Column<string>(nullable: true),
                    BillingCountry = table.Column<string>(nullable: true),
                    BillingPostal = table.Column<string>(nullable: true),
                    BillingState = table.Column<string>(nullable: true),
                    CharityRegistrationNumber = table.Column<string>(nullable: true),
                    CreatedByContactId = table.Column<Guid>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: true),
                    GcimsClientID = table.Column<string>(nullable: true),
                    IncorporationLevel = table.Column<string>(nullable: true),
                    IncorporationNumber = table.Column<string>(nullable: true),
                    LegalName = table.Column<string>(nullable: true),
                    Mandate = table.Column<string>(nullable: true),
                    PaymentAccountAddressId = table.Column<Guid>(nullable: false),
                    PrimaryAccountAddressId = table.Column<Guid>(nullable: false),
                    PrimaryAddressLine1 = table.Column<string>(nullable: true),
                    PrimaryAddressLine2 = table.Column<string>(nullable: true),
                    PrimaryCity = table.Column<string>(nullable: true),
                    PrimaryCountry = table.Column<string>(nullable: true),
                    PrimaryPostal = table.Column<string>(nullable: true),
                    PrimaryState = table.Column<string>(nullable: true),
                    PrimaryWork = table.Column<string>(nullable: true),
                    PublicFunds = table.Column<bool>(nullable: false),
                    PublicSectorMember = table.Column<bool>(nullable: false),
                    PublicServiceAct = table.Column<bool>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    Website = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    code = table.Column<string>(nullable: false),
                    name_en = table.Column<string>(nullable: true),
                    name_fr = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "InternalUser",
                columns: table => new
                {
                    InternalUserId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    IsFundingOpportunityAdministrator = table.Column<bool>(nullable: false),
                    IsPortalAdministrator = table.Column<bool>(nullable: false),
                    IsSubmissionReviewer = table.Column<bool>(nullable: false),
                    IsWorkloadManager = table.Column<bool>(nullable: false),
                    Language = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    gcimsUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUser", x => x.InternalUserId);
                });

            migrationBuilder.CreateTable(
                name: "Consideration",
                columns: table => new
                {
                    ConsiderationId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consideration", x => x.ConsiderationId);
                });

            migrationBuilder.CreateTable(
                name: "CostCategory",
                columns: table => new
                {
                    CostCategoryId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    GcimsCostCategoryID = table.Column<string>(nullable: true),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    ToolTipE = table.Column<string>(nullable: true),
                    ToolTipF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCategory", x => x.CostCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "EligibilityCriteria",
                columns: table => new
                {
                    EligibilityCriteriaId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilityCriteria", x => x.EligibilityCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "ExpectedResult",
                columns: table => new
                {
                    ExpectedResultId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    GcimsAttributeID = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpectedResult", x => x.ExpectedResultId);
                });

            migrationBuilder.CreateTable(
                name: "FrequentlyAskedQuestion",
                columns: table => new
                {
                    FrequentlyAskedQuestionId = table.Column<Guid>(nullable: false),
                    AnswerE = table.Column<string>(nullable: true),
                    AnswerF = table.Column<string>(nullable: true),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrequentlyAskedQuestion", x => x.FrequentlyAskedQuestionId);
                });

            migrationBuilder.CreateTable(
                name: "FundingProgram",
                columns: table => new
                {
                    FundingProgramId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingProgram", x => x.FundingProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    ObjectiveId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: false),
                    DescriptionF = table.Column<string>(nullable: false),
                    GcimsAttributeID = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.ObjectiveId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFederalDepartment",
                columns: table => new
                {
                    ProjectFederalDepartmentId = table.Column<Guid>(nullable: false),
                    ContactInformation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFederalDepartment", x => x.ProjectFederalDepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    PAI = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "tblClients",
                columns: table => new
                {
                    ClientID = table.Column<string>(nullable: false),
                    BusinessLineID = table.Column<string>(nullable: true),
                    CharityAppliedDate = table.Column<DateTime>(nullable: true),
                    CharityDate = table.Column<DateTime>(nullable: true),
                    CharityInProcess = table.Column<bool>(nullable: false),
                    CharityNumber = table.Column<string>(nullable: true),
                    CharityTypeID = table.Column<string>(nullable: true),
                    CitizenshipTypeID = table.Column<string>(nullable: true),
                    ClientAllocatedAmount = table.Column<decimal>(nullable: true),
                    ClientApprovedAmount = table.Column<decimal>(nullable: true),
                    ClientComments = table.Column<string>(nullable: true),
                    ClientName = table.Column<string>(nullable: true),
                    ClientPaidAmount = table.Column<decimal>(nullable: true),
                    ClientRecommendedAmount = table.Column<decimal>(nullable: true),
                    ClientRequestedAmount = table.Column<decimal>(nullable: true),
                    ClientTypeID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatorProvinceID = table.Column<string>(nullable: true),
                    CreatorRegionID = table.Column<string>(nullable: true),
                    DepartmentID = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GeographicScopeID = table.Column<string>(nullable: true),
                    History = table.Column<string>(nullable: true),
                    IncorporationAppliedDate = table.Column<DateTime>(nullable: true),
                    IncorporationDate = table.Column<DateTime>(nullable: true),
                    IncorporationInProcess = table.Column<bool>(nullable: false),
                    IncorporationName = table.Column<string>(nullable: true),
                    IncorporationNumber = table.Column<string>(nullable: true),
                    IncorporationTypeID = table.Column<string>(nullable: true),
                    LanguageID = table.Column<string>(nullable: true),
                    LogicalUpdatedBy = table.Column<string>(nullable: true),
                    LogicalUpdatedDate = table.Column<DateTime>(nullable: true),
                    Mandate = table.Column<string>(nullable: true),
                    OtherFunding = table.Column<bool>(nullable: false),
                    PreviousGrant = table.Column<bool>(nullable: false),
                    PreviousName = table.Column<string>(nullable: true),
                    PrimaryContact = table.Column<int>(nullable: true),
                    ProductLineID = table.Column<string>(nullable: true),
                    SAPVendorCode = table.Column<string>(nullable: true),
                    SalutationID = table.Column<string>(nullable: true),
                    Scope = table.Column<string>(nullable: true),
                    SportCode = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TranslatedName = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    WebSiteAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblClients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "ContactAddress",
                columns: table => new
                {
                    ContactAddressId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactAddress", x => x.ContactAddressId);
                    table.ForeignKey(
                        name: "FK_ContactAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactAddress_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountAddress",
                columns: table => new
                {
                    AccountAddressId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    AddressId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAddress", x => x.AccountAddressId);
                    table.ForeignKey(
                        name: "FK_AccountAddress_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAddress_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountContact",
                columns: table => new
                {
                    AccountContactId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountContact", x => x.AccountContactId);
                    table.ForeignKey(
                        name: "FK_AccountContact_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountContact_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InternalUserRole",
                columns: table => new
                {
                    InternalUserRoleId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    InternalUserId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUserRole", x => x.InternalUserRoleId);
                    table.ForeignKey(
                        name: "FK_InternalUserRole_InternalUser_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingProgramInternalUser",
                columns: table => new
                {
                    FundingProgramInternalUserId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingProgramId = table.Column<Guid>(nullable: false),
                    InternalUserId = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingProgramInternalUser", x => x.FundingProgramInternalUserId);
                    table.ForeignKey(
                        name: "FK_FundingProgramInternalUser_FundingProgram_FundingProgramId",
                        column: x => x.FundingProgramId,
                        principalTable: "FundingProgram",
                        principalColumn: "FundingProgramId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingProgramInternalUser_InternalUser_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunity",
                columns: table => new
                {
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    ActivationEndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ActivationStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    AdditionalInformationE = table.Column<string>(nullable: true),
                    AdditionalInformationF = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    FormName = table.Column<string>(nullable: true),
                    FundingProgramId = table.Column<Guid>(nullable: false),
                    GcimsCommitmentItemId = table.Column<string>(nullable: true),
                    OnHold = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TermsConditionsUrlEN = table.Column<string>(nullable: true),
                    TermsConditionsUrlFR = table.Column<string>(nullable: true),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunity", x => x.FundingOpportunityId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunity_FundingProgram_FundingProgramId",
                        column: x => x.FundingProgramId,
                        principalTable: "FundingProgram",
                        principalColumn: "FundingProgramId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EligibleClientType",
                columns: table => new
                {
                    EligibleClientTypeId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    EligibleClientTypeBilingualTitle = table.Column<string>(nullable: true),
                    EligibleClientTypeStaticId = table.Column<int>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleClientType", x => x.EligibleClientTypeId);
                    table.ForeignKey(
                        name: "FK_EligibleClientType_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EligibleCostCategory",
                columns: table => new
                {
                    EligibleCostCategoryId = table.Column<Guid>(nullable: false),
                    CostCategoryId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    TooltipE = table.Column<string>(nullable: true),
                    TooltipF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleCostCategory", x => x.EligibleCostCategoryId);
                    table.ForeignKey(
                        name: "FK_EligibleCostCategory_CostCategory_CostCategoryId",
                        column: x => x.CostCategoryId,
                        principalTable: "CostCategory",
                        principalColumn: "CostCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EligibleCostCategory_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityConsideration",
                columns: table => new
                {
                    FundingOpportunityConsiderationId = table.Column<Guid>(nullable: false),
                    ConsiderationId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityConsideration", x => x.FundingOpportunityConsiderationId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityConsideration_Consideration_ConsiderationId",
                        column: x => x.ConsiderationId,
                        principalTable: "Consideration",
                        principalColumn: "ConsiderationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityConsideration_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityEligibilityCriteria",
                columns: table => new
                {
                    FundingOpportunityEligibilityCriteriaId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EligibilityCriteriaId = table.Column<Guid>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityEligibilityCriteria", x => x.FundingOpportunityEligibilityCriteriaId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityEligibilityCriteria_EligibilityCriteria_EligibilityCriteriaId",
                        column: x => x.EligibilityCriteriaId,
                        principalTable: "EligibilityCriteria",
                        principalColumn: "EligibilityCriteriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityEligibilityCriteria_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityExpectedResult",
                columns: table => new
                {
                    FundingOpportunityExpectedResultId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ExpectedResultId = table.Column<Guid>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityExpectedResult", x => x.FundingOpportunityExpectedResultId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityExpectedResult_ExpectedResult_ExpectedResultId",
                        column: x => x.ExpectedResultId,
                        principalTable: "ExpectedResult",
                        principalColumn: "ExpectedResultId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityExpectedResult_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityFrequentlyAskedQuestion",
                columns: table => new
                {
                    FundingOpportunityFrequentlyAskedQuestionId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FrequentlyAskedQuestionId = table.Column<Guid>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityFrequentlyAskedQuestion", x => x.FundingOpportunityFrequentlyAskedQuestionId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityFrequentlyAskedQuestion_FrequentlyAskedQuestion_FrequentlyAskedQuestionId",
                        column: x => x.FrequentlyAskedQuestionId,
                        principalTable: "FrequentlyAskedQuestion",
                        principalColumn: "FrequentlyAskedQuestionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityFrequentlyAskedQuestion_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityInternalUser",
                columns: table => new
                {
                    FundingOpportunityInternalUserId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    HasFullAccess = table.Column<bool>(nullable: false),
                    InternalUserId = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityInternalUser", x => x.FundingOpportunityInternalUserId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityInternalUser_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityInternalUser_InternalUser_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityObjective",
                columns: table => new
                {
                    FundingOpportunityObjectiveId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    ObjectiveId = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityObjective", x => x.FundingOpportunityObjectiveId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityObjective_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityObjective_Objective_ObjectiveId",
                        column: x => x.ObjectiveId,
                        principalTable: "Objective",
                        principalColumn: "ObjectiveId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityResource",
                columns: table => new
                {
                    FundingOpportunityResourceId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    UrlE = table.Column<string>(nullable: true),
                    UrlF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityResource", x => x.FundingOpportunityResourceId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityResource_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: true),
                    AdditionalInformation = table.Column<string>(nullable: true),
                    AssignedBy = table.Column<Guid>(nullable: true),
                    AssignedTo = table.Column<Guid>(nullable: true),
                    Audited = table.Column<bool>(nullable: false),
                    ClientID = table.Column<string>(nullable: true),
                    Communication = table.Column<string>(nullable: true),
                    ContactId = table.Column<Guid>(nullable: true),
                    CorporateFileNumber = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CurrentOwner = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Diversity = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Evaluation = table.Column<string>(nullable: true),
                    ExpertiseJustificiation = table.Column<string>(nullable: true),
                    ExternalCreatedOn = table.Column<DateTime>(nullable: false),
                    ExternalUpdatedOn = table.Column<DateTime>(nullable: false),
                    FiscalYear = table.Column<string>(nullable: true),
                    FundingOpportunityID = table.Column<Guid>(nullable: true),
                    GCIMSCommitmentItemID = table.Column<string>(nullable: true),
                    GCIMSUserName = table.Column<string>(nullable: true),
                    GcimsClientId = table.Column<string>(nullable: true),
                    GcimsContactId = table.Column<int>(nullable: false),
                    GcimsProjectID = table.Column<int>(nullable: false),
                    InternalUpdatedOn = table.Column<DateTime>(nullable: false),
                    Lang = table.Column<string>(nullable: true),
                    LanguageMinority = table.Column<string>(nullable: true),
                    NewPrimaryClientAddress = table.Column<bool>(nullable: false),
                    NewPrimaryContactAddress = table.Column<bool>(nullable: false),
                    Objective1 = table.Column<string>(nullable: true),
                    Objective2 = table.Column<string>(nullable: true),
                    Objective3 = table.Column<string>(nullable: true),
                    PrimaryAccountAddressId = table.Column<Guid>(nullable: true),
                    PrimaryContactAddressId = table.Column<Guid>(nullable: true),
                    PrimaryProjectContactId = table.Column<Guid>(nullable: true),
                    ProjectNeeded = table.Column<string>(nullable: true),
                    ProjectStatus = table.Column<int>(nullable: false),
                    RequestedAmount = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    SubmitGcims = table.Column<bool>(nullable: false),
                    SubmittedOn = table.Column<DateTime>(nullable: false),
                    TaxPercent = table.Column<double>(nullable: false),
                    TaxRebate = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatePrimaryClientAddress = table.Column<bool>(nullable: false),
                    UpdatePrimaryContactAddress = table.Column<bool>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    targetPopulations = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_tblClients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "tblClients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_FundingOpportunity_FundingOpportunityID",
                        column: x => x.FundingOpportunityID,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_AccountAddress_PrimaryAccountAddressId",
                        column: x => x.PrimaryAccountAddressId,
                        principalTable: "AccountAddress",
                        principalColumn: "AccountAddressId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_ContactAddress_PrimaryContactAddressId",
                        column: x => x.PrimaryContactAddressId,
                        principalTable: "ContactAddress",
                        principalColumn: "ContactAddressId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    FeedbackId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsRejection = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    UpdatedBy = table.Column<Guid>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.FeedbackId);
                    table.ForeignKey(
                        name: "FK_Feedback_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectActivity",
                columns: table => new
                {
                    ProjectActivityId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Output = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    ResponsibleParty = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectActivity", x => x.ProjectActivityId);
                    table.ForeignKey(
                        name: "FK_ProjectActivity_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectBudget",
                columns: table => new
                {
                    ProjectBudgetId = table.Column<Guid>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    CostCategoryID = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(nullable: true),
                    FundingOrganization = table.Column<string>(nullable: true),
                    ProjectID = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBudget", x => x.ProjectBudgetId);
                    table.ForeignKey(
                        name: "FK_ProjectBudget_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContact",
                columns: table => new
                {
                    ProjectContactId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GCIMSContactID = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    isSigningAuthority = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContact", x => x.ProjectContactId);
                    table.ForeignKey(
                        name: "FK_ProjectContact_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectExpectedResult",
                columns: table => new
                {
                    ProjectExpectedResultId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ExpectedResultID = table.Column<Guid>(nullable: false),
                    ProjectID = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectExpectedResult", x => x.ProjectExpectedResultId);
                    table.ForeignKey(
                        name: "FK_ProjectExpectedResult_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectObjective",
                columns: table => new
                {
                    ProjectObjectiveId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ObjectiveID = table.Column<Guid>(nullable: false),
                    ProjectID = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectObjective", x => x.ProjectObjectiveId);
                    table.ForeignKey(
                        name: "FK_ProjectObjective_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTargetPopulation",
                columns: table => new
                {
                    ProjectTargetPopulationId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsOther = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    TargetPopulationEn = table.Column<string>(nullable: true),
                    TargetPopulationFr = table.Column<string>(nullable: true),
                    TargetPopulationOther = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTargetPopulation", x => x.ProjectTargetPopulationId);
                    table.ForeignKey(
                        name: "FK_ProjectTargetPopulation_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMember",
                columns: table => new
                {
                    ProjectMemberId = table.Column<Guid>(nullable: false),
                    NamePosition = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMember", x => x.ProjectMemberId);
                    table.ForeignKey(
                        name: "FK_ProjectMember_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSupporter",
                columns: table => new
                {
                    ProjectSupporterId = table.Column<Guid>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsOnGoingRelationship = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nature = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSupporter", x => x.ProjectSupporterId);
                    table.ForeignKey(
                        name: "FK_ProjectSupporter_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_AccountId",
                table: "AccountAddress",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_AddressId",
                table: "AccountAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_AccountId",
                table: "AccountContact",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_ContactId",
                table: "AccountContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_AddressId",
                table: "ContactAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_ContactId",
                table: "ContactAddress",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_ProjectId",
                table: "Feedback",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingProgramInternalUser_FundingProgramId",
                table: "FundingProgramInternalUser",
                column: "FundingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingProgramInternalUser_InternalUserId",
                table: "FundingProgramInternalUser",
                column: "InternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRole_InternalUserId",
                table: "InternalUserRole",
                column: "InternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleClientType_FundingOpportunityId",
                table: "EligibleClientType",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_CostCategoryId",
                table: "EligibleCostCategory",
                column: "CostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_FundingOpportunityId",
                table: "EligibleCostCategory",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunity_FundingProgramId",
                table: "FundingOpportunity",
                column: "FundingProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityConsideration_ConsiderationId",
                table: "FundingOpportunityConsideration",
                column: "ConsiderationId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityConsideration_FundingOpportunityId",
                table: "FundingOpportunityConsideration",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityEligibilityCriteria_EligibilityCriteriaId",
                table: "FundingOpportunityEligibilityCriteria",
                column: "EligibilityCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityEligibilityCriteria_FundingOpportunityId",
                table: "FundingOpportunityEligibilityCriteria",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_ExpectedResultId",
                table: "FundingOpportunityExpectedResult",
                column: "ExpectedResultId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_FundingOpportunityId",
                table: "FundingOpportunityExpectedResult",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityFrequentlyAskedQuestion_FrequentlyAskedQuestionId",
                table: "FundingOpportunityFrequentlyAskedQuestion",
                column: "FrequentlyAskedQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityFrequentlyAskedQuestion_FundingOpportunityId",
                table: "FundingOpportunityFrequentlyAskedQuestion",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityInternalUser_FundingOpportunityId",
                table: "FundingOpportunityInternalUser",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityInternalUser_InternalUserId",
                table: "FundingOpportunityInternalUser",
                column: "InternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_FundingOpportunityId",
                table: "FundingOpportunityObjective",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_ObjectiveId",
                table: "FundingOpportunityObjective",
                column: "ObjectiveId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityResource_FundingOpportunityId",
                table: "FundingOpportunityResource",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectActivity_ProjectId",
                table: "ProjectActivity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_ProjectID",
                table: "ProjectBudget",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_ProjectId",
                table: "ProjectContact",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_ProjectID",
                table: "ProjectExpectedResult",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_ProjectID",
                table: "ProjectObjective",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTargetPopulation_ProjectId",
                table: "ProjectTargetPopulation",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AccountId",
                table: "Project",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientID",
                table: "Project",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ContactId",
                table: "Project",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_FundingOpportunityID",
                table: "Project",
                column: "FundingOpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PrimaryAccountAddressId",
                table: "Project",
                column: "PrimaryAccountAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PrimaryContactAddressId",
                table: "Project",
                column: "PrimaryContactAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_ProjectId",
                table: "ProjectMember",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSupporter_ProjectId",
                table: "ProjectSupporter",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountContact");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "FundingProgramInternalUser");

            migrationBuilder.DropTable(
                name: "InternalUserRole");

            migrationBuilder.DropTable(
                name: "EligibleClientType");

            migrationBuilder.DropTable(
                name: "EligibleCostCategory");

            migrationBuilder.DropTable(
                name: "FundingOpportunityConsideration");

            migrationBuilder.DropTable(
                name: "FundingOpportunityEligibilityCriteria");

            migrationBuilder.DropTable(
                name: "FundingOpportunityExpectedResult");

            migrationBuilder.DropTable(
                name: "FundingOpportunityFrequentlyAskedQuestion");

            migrationBuilder.DropTable(
                name: "FundingOpportunityInternalUser");

            migrationBuilder.DropTable(
                name: "FundingOpportunityObjective");

            migrationBuilder.DropTable(
                name: "FundingOpportunityResource");

            migrationBuilder.DropTable(
                name: "ProjectActivity");

            migrationBuilder.DropTable(
                name: "ProjectBudget");

            migrationBuilder.DropTable(
                name: "ProjectContact");

            migrationBuilder.DropTable(
                name: "ProjectExpectedResult");

            migrationBuilder.DropTable(
                name: "ProjectFederalDepartment");

            migrationBuilder.DropTable(
                name: "ProjectObjective");

            migrationBuilder.DropTable(
                name: "ProjectTargetPopulation");

            migrationBuilder.DropTable(
                name: "ProjectMember");

            migrationBuilder.DropTable(
                name: "ProjectSupporter");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CostCategory");

            migrationBuilder.DropTable(
                name: "Consideration");

            migrationBuilder.DropTable(
                name: "EligibilityCriteria");

            migrationBuilder.DropTable(
                name: "ExpectedResult");

            migrationBuilder.DropTable(
                name: "FrequentlyAskedQuestion");

            migrationBuilder.DropTable(
                name: "InternalUser");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "tblClients");

            migrationBuilder.DropTable(
                name: "FundingOpportunity");

            migrationBuilder.DropTable(
                name: "AccountAddress");

            migrationBuilder.DropTable(
                name: "ContactAddress");

            migrationBuilder.DropTable(
                name: "FundingProgram");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
