using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InternalPortal.Models;

namespace InternalPortal.Migrations
{
    [DbContext(typeof(PortalContext))]
    partial class PortalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternalPortal.Models.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("GcimsClientID");

                    b.Property<string>("LegalName");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("AccountId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("Account");
                });

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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("InternalPortal.Models.Contact", b =>
                {
                    b.Property<Guid>("ContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<int>("GcimsContactID");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<string>("PreferredLanguageID");

                    b.Property<string>("SalutationID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ContactId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("ContactAddress");
                });

            modelBuilder.Entity("InternalPortal.Models.InternalUser", b =>
                {
                    b.Property<Guid>("InternalUserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Email");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("InternalUserId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("InternalUser");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.FundingOpportunity", b =>
                {
                    b.Property<Guid>("FundingOpportunityId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ActivationEndDate");

                    b.Property<DateTime>("ActivationStartDate");

                    b.Property<string>("AdditionalInformationE");

                    b.Property<string>("AdditionalInformationF");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("DescriptionE");

                    b.Property<string>("DescriptionF");

                    b.Property<bool>("OnHold");

                    b.Property<string>("Title");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("FundingOpportunity");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibleCostCategory", b =>
                {
                    b.Property<Guid>("EligibleCostCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CostCategoryID");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("FundingOpportunityID");

                    b.Property<Guid?>("FundingOpportunityId1");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("EligibleCostCategoryId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("FundingOpportunityID");

                    b.HasIndex("FundingOpportunityId1");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("EligibleCostCategory");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.ExpectedResult", b =>
                {
                    b.Property<Guid>("ExpectedResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("GcimsAttributeID");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ExpectedResultId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("ExpectedResult");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityExpectedResult", b =>
                {
                    b.Property<Guid>("FundingOpportunityExpectedResultId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("ExpectedResultId");

                    b.Property<Guid?>("FundingOpportunityId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityExpectedResultId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("ExpectedResultId");

                    b.HasIndex("FundingOpportunityId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("FundingOpportunityExpectedResult");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityObjective", b =>
                {
                    b.Property<Guid>("FundingOpportunityObjectiveId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("FundingOpportunityId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityObjectiveId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("FundingOpportunityId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("FundingOpportunityObjective");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.Objective", b =>
                {
                    b.Property<Guid>("FundingOpportunityObjectiveId");

                    b.Property<Guid?>("CreatedByInternalUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("GcimsAttributeID");

                    b.Property<string>("TitleE");

                    b.Property<string>("TitleF");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("FundingOpportunityObjectiveId");

                    b.HasIndex("CreatedByInternalUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.ToTable("Objective");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectBudget", b =>
                {
                    b.Property<Guid>("ProjectBudgetId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<Guid>("CostCategoryID");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid>("ProjectID");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectBudgetId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("ProjectBudget");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectContact", b =>
                {
                    b.Property<Guid>("ProjectContactId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("ContactId");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("ProjectId");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("ProjectContactId");

                    b.HasIndex("ContactId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("ProjectExpectedResult");
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

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ProjectID");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("ProjectObjective");
                });

            modelBuilder.Entity("InternalPortal.Models.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccountId");

                    b.Property<Guid>("ContactId");

                    b.Property<string>("CorporateFileNumber");

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndDate");

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

                    b.Property<bool>("NewPrimaryClientAddress");

                    b.Property<bool>("NewPrimaryContactAddress");

                    b.Property<Guid?>("PrimaryAccountAddressId");

                    b.Property<Guid?>("PrimaryContactAddressId");

                    b.Property<int>("ProjectStatus");

                    b.Property<double>("RequestedAmount");

                    b.Property<DateTime>("StartDate");

                    b.Property<bool>("SubmitGcims");

                    b.Property<string>("Title");

                    b.Property<bool>("UpdatePrimaryClientAddress");

                    b.Property<bool>("UpdatePrimaryContactAddress");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.HasKey("ProjectId");

                    b.HasIndex("AccountId");

                    b.HasIndex("ContactId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("FundingOpportunityID");

                    b.HasIndex("PrimaryAccountAddressId");

                    b.HasIndex("PrimaryContactAddressId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("InternalPortal.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CreatedByUserId");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<Guid?>("UpdatedByInternalUserId");

                    b.Property<Guid?>("UpdatedByUserId");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("UserId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("UpdatedByInternalUserId");

                    b.HasIndex("UpdatedByUserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("InternalPortal.Models.Account", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.AccountAddress", b =>
                {
                    b.HasOne("InternalPortal.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.AccountContact", b =>
                {
                    b.HasOne("InternalPortal.Models.Account", "Account")
                        .WithMany("AccountContacts")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Contact", "Contact")
                        .WithMany("ContactAccounts")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Address", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Contact", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.ContactAddress", b =>
                {
                    b.HasOne("InternalPortal.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("InternalPortal.Models.Contact", "Contact")
                        .WithMany("ContactAddresses")
                        .HasForeignKey("ContactId");

                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.InternalUser", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.FundingOpportunity", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.EligibleCostCategory", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.Portal.FundingOpportunity")
                        .WithMany("EligibleClientTypes")
                        .HasForeignKey("FundingOpportunityID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Portal.FundingOpportunity")
                        .WithMany("EligibleCostCategories")
                        .HasForeignKey("FundingOpportunityId1");

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.ExpectedResult", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityExpectedResult", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.Portal.Program.ExpectedResult", "ExpectedResult")
                        .WithMany()
                        .HasForeignKey("ExpectedResultId");

                    b.HasOne("InternalPortal.Models.Portal.FundingOpportunity", "FundingOpportunity")
                        .WithMany("ExpectedResults")
                        .HasForeignKey("FundingOpportunityId");

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.FundingOpportunityObjective", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.Portal.FundingOpportunity", "FundingOpportunity")
                        .WithMany("Objectives")
                        .HasForeignKey("FundingOpportunityId");

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.Program.Objective", b =>
                {
                    b.HasOne("InternalPortal.Models.InternalUser", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.Portal.Program.FundingOpportunityObjective")
                        .WithOne("ExpectedResult")
                        .HasForeignKey("InternalPortal.Models.Portal.Program.Objective", "FundingOpportunityObjectiveId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.InternalUser", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectBudget", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("BudgetItems")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectContact", b =>
                {
                    b.HasOne("InternalPortal.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.Project", "Project")
                        .WithMany("ProjectContacts")
                        .HasForeignKey("ProjectId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectExpectedResult", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("ExpectedResults")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Portal.ProjectObjective", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.Project")
                        .WithMany("Objectives")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.Project", b =>
                {
                    b.HasOne("InternalPortal.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.Contact", "PrimaryContact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.Portal.FundingOpportunity", "Program")
                        .WithMany()
                        .HasForeignKey("FundingOpportunityID");

                    b.HasOne("InternalPortal.Models.AccountAddress", "PrimaryAccountAddress")
                        .WithMany()
                        .HasForeignKey("PrimaryAccountAddressId");

                    b.HasOne("InternalPortal.Models.ContactAddress", "PrimaryContactAddress")
                        .WithMany()
                        .HasForeignKey("PrimaryContactAddressId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });

            modelBuilder.Entity("InternalPortal.Models.User", b =>
                {
                    b.HasOne("InternalPortal.Models.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId");

                    b.HasOne("InternalPortal.Models.InternalUser", "InternalUpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByInternalUserId");

                    b.HasOne("InternalPortal.Models.User", "UpdatedBy")
                        .WithMany()
                        .HasForeignKey("UpdatedByUserId");
                });
        }
    }
}
