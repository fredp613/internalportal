using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InternalPortal.Models;
using InternalPortal.Models.Portal.Program;

namespace InternalPortal.Migrations
{
    [DbContext(typeof(PortalContext))]
    [Migration("20180114173221_qcquestionsetcx")]
    partial class qcquestionsetcx
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternalPortal.Models.AccountAddress", b =>
                {
                    b.Property<Guid>("AccountAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("AddressId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("AccountAddressId");

                    b.HasIndex("AccountId");

                    b.HasIndex("AddressId");

                    b.ToTable("AccountAddress");
                });

            modelBuilder.Entity("InternalPortal.Models.AccountContact", b =>
                {
                    b.Property<Guid>("AccountContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("ContactId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("AccountContactId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ContactId");

                    b.ToTable("AccountContact");
                });

            modelBuilder.Entity("InternalPortal.Models.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AddressLine1");

                    b.Property<string>("AddressLine2");

                    b.Property<string>("AddressLine3");

                    b.Property<string>("AddressLine4");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int>("GcimsAddressId");

                    b.Property<int>("GcimsCityID");

                    b.Property<int>("GcimsCountryID");

                    b.Property<int>("GcimsProvinceID");

                    b.Property<string>("Postal");

                    b.Property<string>("Province");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("InternalPortal.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Attempts");

                    b.Property<string>("BlockJustification");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int?>("GcimsContactID");

                    b.Property<bool>("IsBlocked");

                    b.Property<bool>("IsPrimary");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("PaymentAccountAddressId");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PreferredLanguageID");

                    b.Property<Guid?>("PrimaryAccountAddressId");

                    b.Property<string>("PrimaryAddressLine1");

                    b.Property<string>("PrimaryAddressLine2");

                    b.Property<string>("PrimaryCity");

                    b.Property<string>("PrimaryCountry");

                    b.Property<string>("PrimaryPostal");

                    b.Property<string>("PrimaryState");

                    b.Property<string>("SalutationID");

                    b.Property<string>("ShareSecretQuestion");

                    b.Property<string>("SharedSecretAnswer");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime?>("UpdatedOn");

                    b.HasKey("ContactId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("InternalPortal.Models.ContactAddress", b =>
                {
                    b.Property<Guid>("ContactAddressId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid?>("ContactId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ContactAddressId");

                    b.HasIndex("AddressId");

                    b.HasIndex("ContactId");

                    b.ToTable("ContactAddress");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<string>("AccountSubType");

                    b.Property<string>("AccountType");

                    b.Property<string>("BandNumber");

                    b.Property<string>("BillingAddressLine1");

                    b.Property<string>("BillingAddressLine2");

                    b.Property<string>("BillingCity");

                    b.Property<string>("BillingCountry");

                    b.Property<string>("BillingPostal");

                    b.Property<string>("BillingState");

                    b.Property<string>("CharityRegistrationNumber");

                    b.Property<Guid?>("CreatedByContactId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("DateRegistered");

                    b.Property<string>("GcimsClientID");

                    b.Property<string>("IncorporationLevel");

                    b.Property<string>("IncorporationNumber");

                    b.Property<string>("LegalName");

                    b.Property<string>("Mandate");

                    b.Property<Guid>("PaymentAccountAddressId");

                    b.Property<Guid>("PrimaryAccountAddressId");

                    b.Property<string>("PrimaryAddressLine1");

                    b.Property<string>("PrimaryAddressLine2");

                    b.Property<string>("PrimaryCity");

                    b.Property<string>("PrimaryCountry");

                    b.Property<string>("PrimaryPostal");

                    b.Property<string>("PrimaryState");

                    b.Property<string>("PrimaryWork");

                    b.Property<bool>("PublicFunds");

                    b.Property<bool>("PublicSectorMember");

                    b.Property<bool>("PublicServiceAct");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("Website");

                    b.HasKey("AccountId");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Country", b =>
                {
                    b.Property<string>("code")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name_en");

                    b.Property<string>("name_fr");

                    b.HasKey("code");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Feedback", b =>
                {
                    b.Property<Guid>("FeedbackId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<bool>("IsRejection");

                    b.Property<Guid>("ProjectId");

                    b.Property<Guid>("UpdatedBy");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FeedbackId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.FundingProgramInternalUser", b =>
                {
                    b.Property<Guid>("FundingProgramInternalUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingProgramId");

                    b.Property<Guid>("InternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingProgramInternalUserId");

                    b.HasIndex("FundingProgramId");

                    b.HasIndex("InternalUserId");

                    b.ToTable("FundingProgramInternalUser");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.InternalUser", b =>
                {
                    b.Property<Guid>("InternalUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsFundingOpportunityAdministrator");

                    b.Property<bool>("IsPortalAdministrator");

                    b.Property<bool>("IsSubmissionReviewer");

                    b.Property<bool>("IsWorkloadManager");

                    b.Property<string>("Language");

                    b.Property<string>("LastName");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("UserName");

                    b.HasKey("InternalUserId");

                    b.ToTable("InternalUser");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.InternalUserRole", b =>
                {
                    b.Property<Guid>("InternalUserRoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("InternalUserId");

                    b.Property<string>("Role");

                    b.HasKey("InternalUserRoleId");

                    b.HasIndex("InternalUserId");

                    b.ToTable("InternalUserRole");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.Consideration", b =>
                {
                    b.Property<Guid>("ConsiderationId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ConsiderationId");

                    b.ToTable("Consideration");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.CostCategory", b =>
                {
                    b.Property<Guid>("CostCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("GcimsCostCategoryID");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<string>("ToolTipE");

                    b.Property<string>("ToolTipF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("CostCategoryId");

                    b.ToTable("CostCategory");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibilityCriteria", b =>
                {
                    b.Property<Guid>("EligibilityCriteriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("EligibilityCriteriaId");

                    b.ToTable("EligibilityCriteria");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibleClientType", b =>
                {
                    b.Property<Guid>("EligibleClientTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<string>("EligibleClientTypeBilingualTitle");

                    b.Property<int>("EligibleClientTypeStaticId");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("EligibleClientTypeId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("EligibleClientType");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibleCostCategory", b =>
                {
                    b.Property<Guid>("EligibleCostCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CostCategoryId");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<string>("TooltipE");

                    b.Property<string>("TooltipF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("EligibleCostCategoryId");

                    b.HasIndex("CostCategoryId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("EligibleCostCategory");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.ExpectedResult", b =>
                {
                    b.Property<Guid>("ExpectedResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<string>("GcimsAttributeID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ExpectedResultId");

                    b.ToTable("ExpectedResult");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FrequentlyAskedQuestion", b =>
                {
                    b.Property<Guid>("FrequentlyAskedQuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerE");

                    b.Property<string>("AnswerF");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FrequentlyAskedQuestionId");

                    b.ToTable("FrequentlyAskedQuestion");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunity", b =>
                {
                    b.Property<Guid>("FundingOpportunityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivationEndDate")
                        .HasColumnType("Date");

                    b.Property<DateTime>("ActivationStartDate")
                        .HasColumnType("Date");

                    b.Property<string>("AdditionalInformationE");

                    b.Property<string>("AdditionalInformationF");

                    b.Property<string>("ContactEmail");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<string>("FormName");

                    b.Property<Guid>("FundingProgramId");

                    b.Property<string>("GcimsCommitmentItemId");

                    b.Property<bool>("OnHold");

                    b.Property<int>("Status");

                    b.Property<string>("TermsConditionsUrlEN");

                    b.Property<string>("TermsConditionsUrlFR");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityId");

                    b.HasIndex("FundingProgramId");

                    b.ToTable("FundingOpportunity");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityConsideration", b =>
                {
                    b.Property<Guid>("FundingOpportunityConsiderationId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConsiderationId");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityConsiderationId");

                    b.HasIndex("ConsiderationId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("FundingOpportunityConsideration");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityEligibilityCriteria", b =>
                {
                    b.Property<Guid>("FundingOpportunityEligibilityCriteriaId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("EligibilityCriteriaId");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityEligibilityCriteriaId");

                    b.HasIndex("EligibilityCriteriaId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("FundingOpportunityEligibilityCriteria");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityExpectedResult", b =>
                {
                    b.Property<Guid>("FundingOpportunityExpectedResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("ExpectedResultId");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityExpectedResultId");

                    b.HasIndex("ExpectedResultId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("FundingOpportunityExpectedResult");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityFrequentlyAskedQuestion", b =>
                {
                    b.Property<Guid>("FundingOpportunityFrequentlyAskedQuestionId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FrequentlyAskedQuestionId");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityFrequentlyAskedQuestionId");

                    b.HasIndex("FrequentlyAskedQuestionId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("FundingOpportunityFrequentlyAskedQuestion");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityInternalUser", b =>
                {
                    b.Property<Guid>("FundingOpportunityInternalUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<bool>("HasFullAccess");

                    b.Property<Guid>("InternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityInternalUserId");

                    b.HasIndex("FundingOpportunityId");

                    b.HasIndex("InternalUserId");

                    b.ToTable("FundingOpportunityInternalUser");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityObjective", b =>
                {
                    b.Property<Guid>("FundingOpportunityObjectiveId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<Guid>("ObjectiveId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityObjectiveId");

                    b.HasIndex("FundingOpportunityId");

                    b.HasIndex("ObjectiveId");

                    b.ToTable("FundingOpportunityObjective");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityResource", b =>
                {
                    b.Property<Guid>("FundingOpportunityResourceId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingOpportunityId");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<string>("UrlE");

                    b.Property<string>("UrlF");

                    b.HasKey("FundingOpportunityResourceId");

                    b.HasIndex("FundingOpportunityId");

                    b.ToTable("FundingOpportunityResource");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingProgram", b =>
                {
                    b.Property<Guid>("FundingProgramId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Status");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingProgramId");

                    b.ToTable("FundingProgram");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.Objective", b =>
                {
                    b.Property<Guid>("ObjectiveId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE")
                        .IsRequired();

                    b.Property<string>("DescriptionF")
                        .IsRequired();

                    b.Property<string>("GcimsAttributeID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ObjectiveId");

                    b.ToTable("Objective");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectActivity", b =>
                {
                    b.Property<Guid>("ProjectActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Output");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("ResponsibleParty");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectActivityId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectActivity");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectBudget", b =>
                {
                    b.Property<Guid>("ProjectBudgetId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<Guid>("CostCategoryID");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("FiscalYear");

                    b.Property<string>("FundingOrganization");

                    b.Property<Guid>("ProjectID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectBudgetId");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectBudget");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectContact", b =>
                {
                    b.Property<Guid>("ProjectContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("GCIMSContactID");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.Property<bool>("isSigningAuthority");

                    b.HasKey("ProjectContactId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectContact");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectExpectedResult", b =>
                {
                    b.Property<Guid>("ProjectExpectedResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("ExpectedResultID");

                    b.Property<Guid>("ProjectID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectExpectedResultId");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectExpectedResult");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectFederalDepartment", b =>
                {
                    b.Property<Guid>("ProjectFederalDepartmentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactInformation");

                    b.Property<string>("Name");

                    b.Property<Guid>("ProjectId");

                    b.HasKey("ProjectFederalDepartmentId");

                    b.ToTable("ProjectFederalDepartment");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectObjective", b =>
                {
                    b.Property<Guid>("ProjectObjectiveId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<Guid>("ObjectiveID");

                    b.Property<Guid>("ProjectID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectObjectiveId");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectObjective");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectTargetPopulation", b =>
                {
                    b.Property<Guid>("ProjectTargetPopulationId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn");

                    b.Property<bool>("IsOther");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("TargetPopulationEn");

                    b.Property<string>("TargetPopulationFr");

                    b.Property<string>("TargetPopulationOther");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectTargetPopulationId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTargetPopulation");
                });

            modelBuilder.Entity("InternalPortal.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AccountId");

                    b.Property<string>("AdditionalInformation");

                    b.Property<Guid?>("AssignedBy");

                    b.Property<Guid?>("AssignedTo");

                    b.Property<bool>("Audited");

                    b.Property<string>("ClientID");

                    b.Property<string>("Communication");

                    b.Property<Guid?>("ContactId");

                    b.Property<string>("CorporateFileNumber");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<Guid?>("CurrentOwner");

                    b.Property<string>("Description");

                    b.Property<string>("Diversity");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Evaluation");

                    b.Property<string>("ExpertiseJustificiation");

                    b.Property<DateTime>("ExternalCreatedOn");

                    b.Property<DateTime>("ExternalUpdatedOn");

                    b.Property<string>("FiscalYear");

                    b.Property<Guid?>("FundingOpportunityID");

                    b.Property<string>("GCIMSCommitmentItemID");

                    b.Property<string>("GCIMSUserName");

                    b.Property<string>("GcimsClientId");

                    b.Property<int>("GcimsContactId");

                    b.Property<int>("GcimsProjectID");

                    b.Property<DateTime>("InternalUpdatedOn");

                    b.Property<string>("Lang");

                    b.Property<string>("LanguageMinority");

                    b.Property<bool>("NewPrimaryClientAddress");

                    b.Property<bool>("NewPrimaryContactAddress");

                    b.Property<string>("Objective1");

                    b.Property<string>("Objective2");

                    b.Property<string>("Objective3");

                    b.Property<Guid?>("PrimaryAccountAddressId");

                    b.Property<Guid?>("PrimaryContactAddressId");

                    b.Property<Guid?>("PrimaryProjectContactId");

                    b.Property<string>("ProjectNeeded");

                    b.Property<int>("ProjectStatus");

                    b.Property<double>("RequestedAmount");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("SubmitGcims");

                    b.Property<DateTime>("SubmittedOn");

                    b.Property<double>("TaxPercent");

                    b.Property<bool>("TaxRebate");

                    b.Property<string>("Title");

                    b.Property<bool>("UpdatePrimaryClientAddress");

                    b.Property<bool>("UpdatePrimaryContactAddress");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("ProjectId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ClientID");

                    b.HasIndex("ContactId");

                    b.HasIndex("FundingOpportunityID");

                    b.HasIndex("PrimaryAccountAddressId");

                    b.HasIndex("PrimaryContactAddressId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("InternalPortal.Models.ProjectMember", b =>
                {
                    b.Property<Guid>("ProjectMemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NamePosition");

                    b.Property<Guid>("ProjectId");

                    b.Property<string>("Role");

                    b.HasKey("ProjectMemberId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectMember");
                });

            modelBuilder.Entity("InternalPortal.Models.ProjectSupporter", b =>
                {
                    b.Property<Guid>("ProjectSupporterId")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsConfirmed");

                    b.Property<bool>("IsOnGoingRelationship");

                    b.Property<string>("Name");

                    b.Property<string>("Nature");

                    b.Property<Guid>("ProjectId");

                    b.HasKey("ProjectSupporterId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectSupporter");
                });

            modelBuilder.Entity("InternalPortal.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ContactId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("PAI");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("tblClients", b =>
                {
                    b.Property<string>("ClientID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusinessLineID");

                    b.Property<DateTime?>("CharityAppliedDate");

                    b.Property<DateTime?>("CharityDate");

                    b.Property<bool>("CharityInProcess");

                    b.Property<string>("CharityNumber");

                    b.Property<string>("CharityTypeID");

                    b.Property<string>("CitizenshipTypeID");

                    b.Property<decimal?>("ClientAllocatedAmount");

                    b.Property<decimal?>("ClientApprovedAmount");

                    b.Property<string>("ClientComments");

                    b.Property<string>("ClientName");

                    b.Property<decimal?>("ClientPaidAmount");

                    b.Property<decimal?>("ClientRecommendedAmount");

                    b.Property<decimal?>("ClientRequestedAmount");

                    b.Property<int>("ClientTypeID");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<string>("CreatorProvinceID");

                    b.Property<string>("CreatorRegionID");

                    b.Property<string>("DepartmentID");

                    b.Property<string>("Email");

                    b.Property<string>("GeographicScopeID");

                    b.Property<string>("History");

                    b.Property<DateTime?>("IncorporationAppliedDate");

                    b.Property<DateTime?>("IncorporationDate");

                    b.Property<bool>("IncorporationInProcess");

                    b.Property<string>("IncorporationName");

                    b.Property<string>("IncorporationNumber");

                    b.Property<string>("IncorporationTypeID");

                    b.Property<string>("LanguageID");

                    b.Property<string>("LogicalUpdatedBy");

                    b.Property<DateTime?>("LogicalUpdatedDate");

                    b.Property<string>("Mandate");

                    b.Property<bool>("OtherFunding");

                    b.Property<bool>("PreviousGrant");

                    b.Property<string>("PreviousName");

                    b.Property<int?>("PrimaryContact");

                    b.Property<string>("ProductLineID");

                    b.Property<string>("SAPVendorCode");

                    b.Property<string>("SalutationID");

                    b.Property<string>("Scope");

                    b.Property<string>("SportCode");

                    b.Property<string>("Title");

                    b.Property<string>("TranslatedName");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("WebSiteAddress");

                    b.HasKey("ClientID");

                    b.ToTable("tblClients");
                });

            modelBuilder.Entity("InternalPortal.Models.AccountAddress", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Account", "Account")
                        .WithMany("AccountAddresses")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.AccountContact", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Account", "Account")
                        .WithMany("AccountContacts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Contact", "Contact")
                        .WithMany("ContactAccounts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.ContactAddress", b =>
                {
                    b.HasOne("InternalPortal.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("InternalPortal.Models.Contact", "Contact")
                        .WithMany("ContactAddresses")
                        .HasForeignKey("ContactId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Feedback", b =>
                {
                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("Feedbacks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.FundingProgramInternalUser", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FundingProgram", "FundingProgram")
                        .WithMany("FundingProgramInternalUsers")
                        .HasForeignKey("FundingProgramId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.InternalUser")
                        .WithMany("FundingProgramInternalUsers")
                        .HasForeignKey("InternalUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.InternalUserRole", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.InternalUser", "InternalUser")
                        .WithMany()
                        .HasForeignKey("InternalUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibleClientType", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("EligibleClientTypes")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibleCostCategory", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.CostCategory", "CostCategory")
                        .WithMany()
                        .HasForeignKey("CostCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("EligibleCostCategories")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunity", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FundingProgram", "FundingProgram")
                        .WithMany("FundingOpportunities")
                        .HasForeignKey("FundingProgramId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityConsideration", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.Consideration", "Consideration")
                        .WithMany()
                        .HasForeignKey("ConsiderationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityConsiderations")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityEligibilityCriteria", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.EligibilityCriteria", "EligibilityCriteria")
                        .WithMany("FundingOpportunityEligibilityCriterias")
                        .HasForeignKey("EligibilityCriteriaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityEligibilityCriterias")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityExpectedResult", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.ExpectedResult", "ExpectedResult")
                        .WithMany()
                        .HasForeignKey("ExpectedResultId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityExpectedResults")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityFrequentlyAskedQuestion", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FrequentlyAskedQuestion", "FrequentlyAskedQuestion")
                        .WithMany()
                        .HasForeignKey("FrequentlyAskedQuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityFrequentlyAskedQuestions")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityInternalUser", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityInternalUsers")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.InternalUser")
                        .WithMany("FundingOpportunityInternalUsers")
                        .HasForeignKey("InternalUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityObjective", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityObjectives")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.Program.Objective", "Objective")
                        .WithMany()
                        .HasForeignKey("ObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityResource", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "FundingOpportunity")
                        .WithMany("FundingOpportunityResources")
                        .HasForeignKey("FundingOpportunityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectActivity", b =>
                {
                    b.HasOne("InternalPortal.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectBudget", b =>
                {
                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("BudgetItems")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectContact", b =>
                {
                    b.HasOne("InternalPortal.Models.Project", "Project")
                        .WithMany("ProjectContacts")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectExpectedResult", b =>
                {
                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("ExpectedResults")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectObjective", b =>
                {
                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("Objectives")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectTargetPopulation", b =>
                {
                    b.HasOne("InternalPortal.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.Project", b =>
                {
                    b.HasOne("InternalPortal.Models.Portal.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.HasOne("tblClients", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID");

                    b.HasOne("InternalPortal.Models.Contact", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunity", "Program")
                        .WithMany()
                        .HasForeignKey("FundingOpportunityID");

                    b.HasOne("InternalPortal.Models.AccountAddress", "PrimaryAccountAddress")
                        .WithMany()
                        .HasForeignKey("PrimaryAccountAddressId");

                    b.HasOne("InternalPortal.Models.ContactAddress", "PrimaryContactAddress")
                        .WithMany()
                        .HasForeignKey("PrimaryContactAddressId");
                });

            modelBuilder.Entity("InternalPortal.Models.ProjectMember", b =>
                {
                    b.HasOne("InternalPortal.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternalPortal.Models.ProjectSupporter", b =>
                {
                    b.HasOne("InternalPortal.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
