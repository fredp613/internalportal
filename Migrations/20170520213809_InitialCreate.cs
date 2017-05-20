using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InternalUser",
                columns: table => new
                {
                    InternalUserId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUser", x => x.InternalUserId);
                    table.ForeignKey(
                        name: "FK_InternalUser_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InternalUser_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunity",
                columns: table => new
                {
                    FundingOpportunityId = table.Column<Guid>(nullable: false),
                    ActivationEndDate = table.Column<DateTime>(nullable: false),
                    ActivationStartDate = table.Column<DateTime>(nullable: false),
                    AdditionalInformationE = table.Column<string>(nullable: true),
                    AdditionalInformationF = table.Column<string>(nullable: true),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    DescriptionE = table.Column<string>(nullable: true),
                    DescriptionF = table.Column<string>(nullable: true),
                    OnHold = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunity", x => x.FundingOpportunityId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunity_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingOpportunity_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpectedResult",
                columns: table => new
                {
                    ExpectedResultId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    GcimsAttributeID = table.Column<string>(nullable: true),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpectedResult", x => x.ExpectedResultId);
                    table.ForeignKey(
                        name: "FK_ExpectedResult_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpectedResult_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EligibleCostCategory",
                columns: table => new
                {
                    EligibleCostCategoryId = table.Column<Guid>(nullable: false),
                    CostCategoryID = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityID = table.Column<Guid>(nullable: false),
                    FundingOpportunityId1 = table.Column<Guid>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibleCostCategory", x => x.EligibleCostCategoryId);
                    table.ForeignKey(
                        name: "FK_EligibleCostCategory_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EligibleCostCategory_FundingOpportunity_FundingOpportunityID",
                        column: x => x.FundingOpportunityID,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EligibleCostCategory_FundingOpportunity_FundingOpportunityId1",
                        column: x => x.FundingOpportunityId1,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EligibleCostCategory_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityObjective",
                columns: table => new
                {
                    FundingOpportunityObjectiveId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    FundingOpportunityId = table.Column<Guid>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityObjective", x => x.FundingOpportunityObjectiveId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityObjective_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityObjective_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityObjective_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundingOpportunityExpectedResult",
                columns: table => new
                {
                    FundingOpportunityExpectedResultId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ExpectedResultId = table.Column<Guid>(nullable: true),
                    FundingOpportunityId = table.Column<Guid>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundingOpportunityExpectedResult", x => x.FundingOpportunityExpectedResultId);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityExpectedResult_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityExpectedResult_ExpectedResult_ExpectedResultId",
                        column: x => x.ExpectedResultId,
                        principalTable: "ExpectedResult",
                        principalColumn: "ExpectedResultId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityExpectedResult_FundingOpportunity_FundingOpportunityId",
                        column: x => x.FundingOpportunityId,
                        principalTable: "FundingOpportunity",
                        principalColumn: "FundingOpportunityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FundingOpportunityExpectedResult_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    AccountName = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    GcimsClientID = table.Column<string>(nullable: true),
                    LegalName = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    table.ForeignKey(
                        name: "FK_Address_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GcimsContactID = table.Column<int>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PreferredLanguageID = table.Column<string>(nullable: true),
                    SalutationID = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contact_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    FundingOpportunityObjectiveId = table.Column<Guid>(nullable: false),
                    CreatedByInternalUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    GcimsAttributeID = table.Column<string>(nullable: true),
                    TitleE = table.Column<string>(nullable: true),
                    TitleF = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.FundingOpportunityObjectiveId);
                    table.ForeignKey(
                        name: "FK_Objective_InternalUser_CreatedByInternalUserId",
                        column: x => x.CreatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objective_FundingOpportunityObjective_FundingOpportunityObjectiveId",
                        column: x => x.FundingOpportunityObjectiveId,
                        principalTable: "FundingOpportunityObjective",
                        principalColumn: "FundingOpportunityObjectiveId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objective_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
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
                    table.ForeignKey(
                        name: "FK_AccountAddress_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountAddress_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountAddress_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_AccountContact_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountContact_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountContact_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    table.ForeignKey(
                        name: "FK_ContactAddress_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactAddress_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContactAddress_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    AccountId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: false),
                    CorporateFileNumber = table.Column<string>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: false),
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
                    NewPrimaryClientAddress = table.Column<bool>(nullable: false),
                    NewPrimaryContactAddress = table.Column<bool>(nullable: false),
                    PrimaryAccountAddressId = table.Column<Guid>(nullable: true),
                    PrimaryContactAddressId = table.Column<Guid>(nullable: true),
                    ProjectStatus = table.Column<int>(nullable: false),
                    RequestedAmount = table.Column<double>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    SubmitGcims = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    UpdatePrimaryClientAddress = table.Column<bool>(nullable: false),
                    UpdatePrimaryContactAddress = table.Column<bool>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Project_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Project_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
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
                    table.ForeignKey(
                        name: "FK_Project_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                    ProjectID = table.Column<Guid>(nullable: false),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectBudget", x => x.ProjectBudgetId);
                    table.ForeignKey(
                        name: "FK_ProjectBudget_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectBudget_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectBudget_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectBudget_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContact",
                columns: table => new
                {
                    ProjectContactId = table.Column<Guid>(nullable: false),
                    ContactId = table.Column<Guid>(nullable: true),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContact", x => x.ProjectContactId);
                    table.ForeignKey(
                        name: "FK_ProjectContact_Contact_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContact_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContact_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContact_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectContact_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ProjectExpectedResult_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectExpectedResult_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectExpectedResult_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectExpectedResult_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_ProjectObjective_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectObjective_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectObjective_InternalUser_UpdatedByInternalUserId",
                        column: x => x.UpdatedByInternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectObjective_User_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_CreatedByUserId",
                table: "Account",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdatedByInternalUserId",
                table: "Account",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdatedByUserId",
                table: "Account",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_AccountId",
                table: "AccountAddress",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_AddressId",
                table: "AccountAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_CreatedByUserId",
                table: "AccountAddress",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_UpdatedByInternalUserId",
                table: "AccountAddress",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_UpdatedByUserId",
                table: "AccountAddress",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_AccountId",
                table: "AccountContact",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_ContactId",
                table: "AccountContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_CreatedByUserId",
                table: "AccountContact",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_UpdatedByInternalUserId",
                table: "AccountContact",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_UpdatedByUserId",
                table: "AccountContact",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreatedByUserId",
                table: "Address",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpdatedByInternalUserId",
                table: "Address",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpdatedByUserId",
                table: "Address",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CreatedByUserId",
                table: "Contact",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedByInternalUserId",
                table: "Contact",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedByUserId",
                table: "Contact",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_AddressId",
                table: "ContactAddress",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_ContactId",
                table: "ContactAddress",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_CreatedByUserId",
                table: "ContactAddress",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_UpdatedByInternalUserId",
                table: "ContactAddress",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_UpdatedByUserId",
                table: "ContactAddress",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalUser_CreatedByInternalUserId",
                table: "InternalUser",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalUser_UpdatedByInternalUserId",
                table: "InternalUser",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunity_CreatedByInternalUserId",
                table: "FundingOpportunity",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunity_UpdatedByInternalUserId",
                table: "FundingOpportunity",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_CreatedByInternalUserId",
                table: "EligibleCostCategory",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_FundingOpportunityID",
                table: "EligibleCostCategory",
                column: "FundingOpportunityID");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_FundingOpportunityId1",
                table: "EligibleCostCategory",
                column: "FundingOpportunityId1");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_UpdatedByInternalUserId",
                table: "EligibleCostCategory",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpectedResult_CreatedByInternalUserId",
                table: "ExpectedResult",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpectedResult_UpdatedByInternalUserId",
                table: "ExpectedResult",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_CreatedByInternalUserId",
                table: "FundingOpportunityExpectedResult",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_ExpectedResultId",
                table: "FundingOpportunityExpectedResult",
                column: "ExpectedResultId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_FundingOpportunityId",
                table: "FundingOpportunityExpectedResult",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_UpdatedByInternalUserId",
                table: "FundingOpportunityExpectedResult",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_CreatedByInternalUserId",
                table: "FundingOpportunityObjective",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_FundingOpportunityId",
                table: "FundingOpportunityObjective",
                column: "FundingOpportunityId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_UpdatedByInternalUserId",
                table: "FundingOpportunityObjective",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_CreatedByInternalUserId",
                table: "Objective",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Objective_UpdatedByInternalUserId",
                table: "Objective",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_CreatedByUserId",
                table: "ProjectBudget",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_ProjectID",
                table: "ProjectBudget",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_UpdatedByInternalUserId",
                table: "ProjectBudget",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_UpdatedByUserId",
                table: "ProjectBudget",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_ContactId",
                table: "ProjectContact",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_CreatedByUserId",
                table: "ProjectContact",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_ProjectId",
                table: "ProjectContact",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_UpdatedByInternalUserId",
                table: "ProjectContact",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_UpdatedByUserId",
                table: "ProjectContact",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_CreatedByUserId",
                table: "ProjectExpectedResult",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_ProjectID",
                table: "ProjectExpectedResult",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_UpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_UpdatedByUserId",
                table: "ProjectExpectedResult",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_CreatedByUserId",
                table: "ProjectObjective",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_ProjectID",
                table: "ProjectObjective",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_UpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_UpdatedByUserId",
                table: "ProjectObjective",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_AccountId",
                table: "Project",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ContactId",
                table: "Project",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedByUserId",
                table: "Project",
                column: "CreatedByUserId");

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
                name: "IX_Project_UpdatedByInternalUserId",
                table: "Project",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UpdatedByUserId",
                table: "Project",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedByUserId",
                table: "User",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedByInternalUserId",
                table: "User",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedByUserId",
                table: "User",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountContact");

            migrationBuilder.DropTable(
                name: "EligibleCostCategory");

            migrationBuilder.DropTable(
                name: "FundingOpportunityExpectedResult");

            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "ProjectBudget");

            migrationBuilder.DropTable(
                name: "ProjectContact");

            migrationBuilder.DropTable(
                name: "ProjectExpectedResult");

            migrationBuilder.DropTable(
                name: "ProjectObjective");

            migrationBuilder.DropTable(
                name: "ExpectedResult");

            migrationBuilder.DropTable(
                name: "FundingOpportunityObjective");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "FundingOpportunity");

            migrationBuilder.DropTable(
                name: "AccountAddress");

            migrationBuilder.DropTable(
                name: "ContactAddress");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "InternalUser");
        }
    }
}
