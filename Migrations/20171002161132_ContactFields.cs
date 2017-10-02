using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
//test
namespace InternalPortal.Migrations
{
    public partial class ContactFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAddress_InternalUser_UpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountContact_InternalUser_UpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_InternalUser_UpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternalUser_UpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactAddress_InternalUser_UpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_InternalUser_UpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalUserRole_InternalUser_InternalUserId",
                table: "InternalUserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_Consideration_InternalUser_CreatedByInternalUserId",
                table: "Consideration");

            migrationBuilder.DropForeignKey(
                name: "FK_Consideration_InternalUser_UpdatedByInternalUserId",
                table: "Consideration");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCategory_InternalUser_CreatedByInternalUserId",
                table: "CostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_CostCategory_InternalUser_UpdatedByInternalUserId",
                table: "CostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibilityCriteria_InternalUser_CreatedByInternalUserId",
                table: "EligibilityCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibilityCriteria_InternalUser_UpdatedByInternalUserId",
                table: "EligibilityCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibleClientType_InternalUser_CreatedByInternalUserId",
                table: "EligibleClientType");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibleClientType_InternalUser_UpdatedByInternalUserId",
                table: "EligibleClientType");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibleCostCategory_InternalUser_CreatedByInternalUserId",
                table: "EligibleCostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_EligibleCostCategory_InternalUser_UpdatedByInternalUserId",
                table: "EligibleCostCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedResult_InternalUser_CreatedByInternalUserId",
                table: "ExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpectedResult_InternalUser_UpdatedByInternalUserId",
                table: "ExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_FrequentlyAskedQuestion_InternalUser_CreatedByInternalUserId",
                table: "FrequentlyAskedQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FrequentlyAskedQuestion_InternalUser_UpdatedByInternalUserId",
                table: "FrequentlyAskedQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunity_CostCategory_CostCategoryId",
                table: "FundingOpportunity");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunity_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunity");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunity_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunity");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityConsideration_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityConsideration");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityConsideration_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityConsideration");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityEligibilityCriteria_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityEligibilityCriteria_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityExpectedResult_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityExpectedResult_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityFrequentlyAskedQuestion_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityFrequentlyAskedQuestion_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityObjective_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityObjective_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityResource_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityResource");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingOpportunityResource_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityResource");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingProgram_InternalUser_CreatedByInternalUserId",
                table: "FundingProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_FundingProgram_InternalUser_UpdatedByInternalUserId",
                table: "FundingProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_Objective_InternalUser_CreatedByInternalUserId",
                table: "Objective");

            migrationBuilder.DropForeignKey(
                name: "FK_Objective_InternalUser_UpdatedByInternalUserId",
                table: "Objective");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudget_InternalUser_UpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_InternalUser_UpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectExpectedResult_InternalUser_UpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectObjective_InternalUser_UpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_InternalUser_UpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_UpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_ProjectObjective_UpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropIndex(
                name: "IX_ProjectExpectedResult_UpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_UpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBudget_UpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropIndex(
                name: "IX_Objective_CreatedByInternalUserId",
                table: "Objective");

            migrationBuilder.DropIndex(
                name: "IX_Objective_UpdatedByInternalUserId",
                table: "Objective");

            migrationBuilder.DropIndex(
                name: "IX_FundingProgram_CreatedByInternalUserId",
                table: "FundingProgram");

            migrationBuilder.DropIndex(
                name: "IX_FundingProgram_UpdatedByInternalUserId",
                table: "FundingProgram");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityResource_CreatedByInternalUserId",
                table: "FundingOpportunityResource");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityResource_UpdatedByInternalUserId",
                table: "FundingOpportunityResource");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityObjective_CreatedByInternalUserId",
                table: "FundingOpportunityObjective");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityObjective_UpdatedByInternalUserId",
                table: "FundingOpportunityObjective");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityFrequentlyAskedQuestion_CreatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityFrequentlyAskedQuestion_UpdatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityExpectedResult_CreatedByInternalUserId",
                table: "FundingOpportunityExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityExpectedResult_UpdatedByInternalUserId",
                table: "FundingOpportunityExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityEligibilityCriteria_CreatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityEligibilityCriteria_UpdatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityConsideration_CreatedByInternalUserId",
                table: "FundingOpportunityConsideration");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunityConsideration_UpdatedByInternalUserId",
                table: "FundingOpportunityConsideration");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunity_CostCategoryId",
                table: "FundingOpportunity");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunity_CreatedByInternalUserId",
                table: "FundingOpportunity");

            migrationBuilder.DropIndex(
                name: "IX_FundingOpportunity_UpdatedByInternalUserId",
                table: "FundingOpportunity");

            migrationBuilder.DropIndex(
                name: "IX_FrequentlyAskedQuestion_CreatedByInternalUserId",
                table: "FrequentlyAskedQuestion");

            migrationBuilder.DropIndex(
                name: "IX_FrequentlyAskedQuestion_UpdatedByInternalUserId",
                table: "FrequentlyAskedQuestion");

            migrationBuilder.DropIndex(
                name: "IX_ExpectedResult_CreatedByInternalUserId",
                table: "ExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_ExpectedResult_UpdatedByInternalUserId",
                table: "ExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_EligibleCostCategory_CreatedByInternalUserId",
                table: "EligibleCostCategory");

            migrationBuilder.DropIndex(
                name: "IX_EligibleCostCategory_UpdatedByInternalUserId",
                table: "EligibleCostCategory");

            migrationBuilder.DropIndex(
                name: "IX_EligibleClientType_CreatedByInternalUserId",
                table: "EligibleClientType");

            migrationBuilder.DropIndex(
                name: "IX_EligibleClientType_UpdatedByInternalUserId",
                table: "EligibleClientType");

            migrationBuilder.DropIndex(
                name: "IX_EligibilityCriteria_CreatedByInternalUserId",
                table: "EligibilityCriteria");

            migrationBuilder.DropIndex(
                name: "IX_EligibilityCriteria_UpdatedByInternalUserId",
                table: "EligibilityCriteria");

            migrationBuilder.DropIndex(
                name: "IX_CostCategory_CreatedByInternalUserId",
                table: "CostCategory");

            migrationBuilder.DropIndex(
                name: "IX_CostCategory_UpdatedByInternalUserId",
                table: "CostCategory");

            migrationBuilder.DropIndex(
                name: "IX_Consideration_CreatedByInternalUserId",
                table: "Consideration");

            migrationBuilder.DropIndex(
                name: "IX_Consideration_UpdatedByInternalUserId",
                table: "Consideration");

            migrationBuilder.DropIndex(
                name: "IX_InternalUserRole_InternalUserId",
                table: "InternalUserRole");

            migrationBuilder.DropIndex(
                name: "IX_Account_UpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_ContactAddress_UpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropIndex(
                name: "IX_Contact_UpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Address_UpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AccountContact_UpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropIndex(
                name: "IX_AccountAddress_UpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.DropColumn(
                name: "CostCategoryId",
                table: "FundingOpportunity");

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectObjective",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectContact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectBudget",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "ContactAddress",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Contact",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Contact",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ShareSecretQuestion",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SharedSecretAnswer",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "Address",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "AccountContact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
                table: "AccountAddress",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_InternalUpdatedByInternalUserId",
                table: "Project",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_InternalUpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_InternalUpdatedByInternalUserId",
                table: "ProjectContact",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_InternalUpdatedByInternalUserId",
                table: "ProjectBudget",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_InternalUpdatedByInternalUserId",
                table: "Account",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_InternalUpdatedByInternalUserId",
                table: "ContactAddress",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_InternalUpdatedByInternalUserId",
                table: "Contact",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_InternalUpdatedByInternalUserId",
                table: "Address",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_InternalUpdatedByInternalUserId",
                table: "AccountContact",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_InternalUpdatedByInternalUserId",
                table: "AccountAddress",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountAddress",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountContact",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_InternalUser_InternalUpdatedByInternalUserId",
                table: "Address",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_InternalUser_InternalUpdatedByInternalUserId",
                table: "Contact",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "ContactAddress",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_InternalUser_InternalUpdatedByInternalUserId",
                table: "Account",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudget_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectBudget",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectContact",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectExpectedResult_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectObjective_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_InternalUser_InternalUpdatedByInternalUserId",
                table: "Project",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_InternalUser_InternalUpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternalUser_InternalUpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_InternalUser_InternalUpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudget_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectExpectedResult_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectObjective_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_InternalUser_InternalUpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_InternalUpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_ProjectObjective_InternalUpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropIndex(
                name: "IX_ProjectExpectedResult_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_InternalUpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBudget_InternalUpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropIndex(
                name: "IX_Account_InternalUpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_ContactAddress_InternalUpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropIndex(
                name: "IX_Contact_InternalUpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Address_InternalUpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AccountContact_InternalUpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropIndex(
                name: "IX_AccountAddress_InternalUpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ShareSecretQuestion",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "SharedSecretAnswer",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropColumn(
                name: "InternalUpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.AddColumn<Guid>(
                name: "CostCategoryId",
                table: "FundingOpportunity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_UpdatedByInternalUserId",
                table: "Project",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_UpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_UpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_UpdatedByInternalUserId",
                table: "ProjectContact",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_UpdatedByInternalUserId",
                table: "ProjectBudget",
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
                name: "IX_FundingProgram_CreatedByInternalUserId",
                table: "FundingProgram",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingProgram_UpdatedByInternalUserId",
                table: "FundingProgram",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityResource_CreatedByInternalUserId",
                table: "FundingOpportunityResource",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityResource_UpdatedByInternalUserId",
                table: "FundingOpportunityResource",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_CreatedByInternalUserId",
                table: "FundingOpportunityObjective",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityObjective_UpdatedByInternalUserId",
                table: "FundingOpportunityObjective",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityFrequentlyAskedQuestion_CreatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityFrequentlyAskedQuestion_UpdatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_CreatedByInternalUserId",
                table: "FundingOpportunityExpectedResult",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityExpectedResult_UpdatedByInternalUserId",
                table: "FundingOpportunityExpectedResult",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityEligibilityCriteria_CreatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityEligibilityCriteria_UpdatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityConsideration_CreatedByInternalUserId",
                table: "FundingOpportunityConsideration",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunityConsideration_UpdatedByInternalUserId",
                table: "FundingOpportunityConsideration",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunity_CostCategoryId",
                table: "FundingOpportunity",
                column: "CostCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunity_CreatedByInternalUserId",
                table: "FundingOpportunity",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FundingOpportunity_UpdatedByInternalUserId",
                table: "FundingOpportunity",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrequentlyAskedQuestion_CreatedByInternalUserId",
                table: "FrequentlyAskedQuestion",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FrequentlyAskedQuestion_UpdatedByInternalUserId",
                table: "FrequentlyAskedQuestion",
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
                name: "IX_EligibleCostCategory_CreatedByInternalUserId",
                table: "EligibleCostCategory",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleCostCategory_UpdatedByInternalUserId",
                table: "EligibleCostCategory",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleClientType_CreatedByInternalUserId",
                table: "EligibleClientType",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibleClientType_UpdatedByInternalUserId",
                table: "EligibleClientType",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibilityCriteria_CreatedByInternalUserId",
                table: "EligibilityCriteria",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EligibilityCriteria_UpdatedByInternalUserId",
                table: "EligibilityCriteria",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCategory_CreatedByInternalUserId",
                table: "CostCategory",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CostCategory_UpdatedByInternalUserId",
                table: "CostCategory",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Consideration_CreatedByInternalUserId",
                table: "Consideration",
                column: "CreatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Consideration_UpdatedByInternalUserId",
                table: "Consideration",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRole_InternalUserId",
                table: "InternalUserRole",
                column: "InternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdatedByInternalUserId",
                table: "Account",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_UpdatedByInternalUserId",
                table: "ContactAddress",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedByInternalUserId",
                table: "Contact",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpdatedByInternalUserId",
                table: "Address",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_UpdatedByInternalUserId",
                table: "AccountContact",
                column: "UpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_UpdatedByInternalUserId",
                table: "AccountAddress",
                column: "UpdatedByInternalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAddress_InternalUser_UpdatedByInternalUserId",
                table: "AccountAddress",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContact_InternalUser_UpdatedByInternalUserId",
                table: "AccountContact",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_InternalUser_UpdatedByInternalUserId",
                table: "Address",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_InternalUser_UpdatedByInternalUserId",
                table: "Contact",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactAddress_InternalUser_UpdatedByInternalUserId",
                table: "ContactAddress",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_InternalUser_UpdatedByInternalUserId",
                table: "Account",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalUserRole_InternalUser_InternalUserId",
                table: "InternalUserRole",
                column: "InternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consideration_InternalUser_CreatedByInternalUserId",
                table: "Consideration",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consideration_InternalUser_UpdatedByInternalUserId",
                table: "Consideration",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCategory_InternalUser_CreatedByInternalUserId",
                table: "CostCategory",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CostCategory_InternalUser_UpdatedByInternalUserId",
                table: "CostCategory",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EligibilityCriteria_InternalUser_CreatedByInternalUserId",
                table: "EligibilityCriteria",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EligibilityCriteria_InternalUser_UpdatedByInternalUserId",
                table: "EligibilityCriteria",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleClientType_InternalUser_CreatedByInternalUserId",
                table: "EligibleClientType",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleClientType_InternalUser_UpdatedByInternalUserId",
                table: "EligibleClientType",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleCostCategory_InternalUser_CreatedByInternalUserId",
                table: "EligibleCostCategory",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EligibleCostCategory_InternalUser_UpdatedByInternalUserId",
                table: "EligibleCostCategory",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedResult_InternalUser_CreatedByInternalUserId",
                table: "ExpectedResult",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpectedResult_InternalUser_UpdatedByInternalUserId",
                table: "ExpectedResult",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FrequentlyAskedQuestion_InternalUser_CreatedByInternalUserId",
                table: "FrequentlyAskedQuestion",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FrequentlyAskedQuestion_InternalUser_UpdatedByInternalUserId",
                table: "FrequentlyAskedQuestion",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunity_CostCategory_CostCategoryId",
                table: "FundingOpportunity",
                column: "CostCategoryId",
                principalTable: "CostCategory",
                principalColumn: "CostCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunity_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunity",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunity_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunity",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityConsideration_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityConsideration",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityConsideration_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityConsideration",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityEligibilityCriteria_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityEligibilityCriteria_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityEligibilityCriteria",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityExpectedResult_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityExpectedResult",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityExpectedResult_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityExpectedResult",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityFrequentlyAskedQuestion_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityFrequentlyAskedQuestion_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityFrequentlyAskedQuestion",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityObjective_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityObjective",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityObjective_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityObjective",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityResource_InternalUser_CreatedByInternalUserId",
                table: "FundingOpportunityResource",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingOpportunityResource_InternalUser_UpdatedByInternalUserId",
                table: "FundingOpportunityResource",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingProgram_InternalUser_CreatedByInternalUserId",
                table: "FundingProgram",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundingProgram_InternalUser_UpdatedByInternalUserId",
                table: "FundingProgram",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Objective_InternalUser_CreatedByInternalUserId",
                table: "Objective",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Objective_InternalUser_UpdatedByInternalUserId",
                table: "Objective",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudget_InternalUser_UpdatedByInternalUserId",
                table: "ProjectBudget",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_InternalUser_UpdatedByInternalUserId",
                table: "ProjectContact",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectExpectedResult_InternalUser_UpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectObjective_InternalUser_UpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_InternalUser_UpdatedByInternalUserId",
                table: "Project",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
