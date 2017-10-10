using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class contactchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountAddress_User_CreatedByUserId",
                table: "AccountAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountAddress_User_UpdatedByUserId",
                table: "AccountAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountContact_User_CreatedByUserId",
                table: "AccountContact");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountContact_User_UpdatedByUserId",
                table: "AccountContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_CreatedByUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_InternalUser_InternalUpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_User_UpdatedByUserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_CreatedByUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_InternalUser_InternalUpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_UpdatedByUserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactAddress_User_CreatedByUserId",
                table: "ContactAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactAddress_User_UpdatedByUserId",
                table: "ContactAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_CreatedByUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_InternalUser_InternalUpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Account_User_UpdatedByUserId",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalUser_InternalUser_CreatedByInternalUserId",
                table: "InternalUser");

            migrationBuilder.DropForeignKey(
                name: "FK_InternalUser_InternalUser_UpdatedByInternalUserId",
                table: "InternalUser");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudget_User_CreatedByUserId",
                table: "ProjectBudget");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudget_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectBudget_User_UpdatedByUserId",
                table: "ProjectBudget");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_User_CreatedByUserId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_User_UpdatedByUserId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectExpectedResult_User_CreatedByUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectExpectedResult_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectExpectedResult_User_UpdatedByUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectObjective_User_CreatedByUserId",
                table: "ProjectObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectObjective_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectObjective_User_UpdatedByUserId",
                table: "ProjectObjective");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_CreatedByUserId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_InternalUser_InternalUpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_UpdatedByUserId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedByUserId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_InternalUser_UpdatedByInternalUserId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_UpdatedByUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CreatedByUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UpdatedByInternalUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UpdatedByUserId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Project_CreatedByUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_InternalUpdatedByInternalUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_UpdatedByUserId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_ProjectObjective_CreatedByUserId",
                table: "ProjectObjective");

            migrationBuilder.DropIndex(
                name: "IX_ProjectObjective_InternalUpdatedByInternalUserId",
                table: "ProjectObjective");

            migrationBuilder.DropIndex(
                name: "IX_ProjectObjective_UpdatedByUserId",
                table: "ProjectObjective");

            migrationBuilder.DropIndex(
                name: "IX_ProjectExpectedResult_CreatedByUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_ProjectExpectedResult_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_ProjectExpectedResult_UpdatedByUserId",
                table: "ProjectExpectedResult");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_CreatedByUserId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_InternalUpdatedByInternalUserId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_UpdatedByUserId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBudget_CreatedByUserId",
                table: "ProjectBudget");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBudget_InternalUpdatedByInternalUserId",
                table: "ProjectBudget");

            migrationBuilder.DropIndex(
                name: "IX_ProjectBudget_UpdatedByUserId",
                table: "ProjectBudget");

            migrationBuilder.DropIndex(
                name: "IX_InternalUser_CreatedByInternalUserId",
                table: "InternalUser");

            migrationBuilder.DropIndex(
                name: "IX_InternalUser_UpdatedByInternalUserId",
                table: "InternalUser");

            migrationBuilder.DropIndex(
                name: "IX_Account_CreatedByUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_InternalUpdatedByInternalUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_UpdatedByUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_ContactAddress_CreatedByUserId",
                table: "ContactAddress");

            migrationBuilder.DropIndex(
                name: "IX_ContactAddress_InternalUpdatedByInternalUserId",
                table: "ContactAddress");

            migrationBuilder.DropIndex(
                name: "IX_ContactAddress_UpdatedByUserId",
                table: "ContactAddress");

            migrationBuilder.DropIndex(
                name: "IX_Contact_CreatedByUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_InternalUpdatedByInternalUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_UpdatedByUserId",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Address_CreatedByUserId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_InternalUpdatedByInternalUserId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_UpdatedByUserId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_AccountContact_CreatedByUserId",
                table: "AccountContact");

            migrationBuilder.DropIndex(
                name: "IX_AccountContact_InternalUpdatedByInternalUserId",
                table: "AccountContact");

            migrationBuilder.DropIndex(
                name: "IX_AccountContact_UpdatedByUserId",
                table: "AccountContact");

            migrationBuilder.DropIndex(
                name: "IX_AccountAddress_CreatedByUserId",
                table: "AccountAddress");

            migrationBuilder.DropIndex(
                name: "IX_AccountAddress_InternalUpdatedByInternalUserId",
                table: "AccountAddress");

            migrationBuilder.DropIndex(
                name: "IX_AccountAddress_UpdatedByUserId",
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
                name: "InternalUpdatedByInternalUserId",
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

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryAccountAddressId",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentAccountAddressId",
                table: "Contact",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "Contact",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRole_InternalUserId",
                table: "InternalUserRole",
                column: "InternalUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_InternalUserRole_InternalUser_InternalUserId",
                table: "InternalUserRole",
                column: "InternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InternalUserRole_InternalUser_InternalUserId",
                table: "InternalUserRole");

            migrationBuilder.DropIndex(
                name: "IX_InternalUserRole_InternalUserId",
                table: "InternalUserRole");

            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "Contact");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "PrimaryAccountAddressId",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PaymentAccountAddressId",
                table: "Contact",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "InternalUpdatedByInternalUserId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedByUserId",
                table: "Project",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_InternalUpdatedByInternalUserId",
                table: "Project",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UpdatedByUserId",
                table: "Project",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_CreatedByUserId",
                table: "ProjectObjective",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_InternalUpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectObjective_UpdatedByUserId",
                table: "ProjectObjective",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_CreatedByUserId",
                table: "ProjectExpectedResult",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectExpectedResult_UpdatedByUserId",
                table: "ProjectExpectedResult",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_CreatedByUserId",
                table: "ProjectContact",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_InternalUpdatedByInternalUserId",
                table: "ProjectContact",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_UpdatedByUserId",
                table: "ProjectContact",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_CreatedByUserId",
                table: "ProjectBudget",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_InternalUpdatedByInternalUserId",
                table: "ProjectBudget",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectBudget_UpdatedByUserId",
                table: "ProjectBudget",
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
                name: "IX_Account_CreatedByUserId",
                table: "Account",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_InternalUpdatedByInternalUserId",
                table: "Account",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_UpdatedByUserId",
                table: "Account",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_CreatedByUserId",
                table: "ContactAddress",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_InternalUpdatedByInternalUserId",
                table: "ContactAddress",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactAddress_UpdatedByUserId",
                table: "ContactAddress",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CreatedByUserId",
                table: "Contact",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_InternalUpdatedByInternalUserId",
                table: "Contact",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedByUserId",
                table: "Contact",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CreatedByUserId",
                table: "Address",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_InternalUpdatedByInternalUserId",
                table: "Address",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_UpdatedByUserId",
                table: "Address",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_CreatedByUserId",
                table: "AccountContact",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_InternalUpdatedByInternalUserId",
                table: "AccountContact",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountContact_UpdatedByUserId",
                table: "AccountContact",
                column: "UpdatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_CreatedByUserId",
                table: "AccountAddress",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_InternalUpdatedByInternalUserId",
                table: "AccountAddress",
                column: "InternalUpdatedByInternalUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddress_UpdatedByUserId",
                table: "AccountAddress",
                column: "UpdatedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAddress_User_CreatedByUserId",
                table: "AccountAddress",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountAddress",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountAddress_User_UpdatedByUserId",
                table: "AccountAddress",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContact_User_CreatedByUserId",
                table: "AccountContact",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "AccountContact",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountContact_User_UpdatedByUserId",
                table: "AccountContact",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_CreatedByUserId",
                table: "Address",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_InternalUser_InternalUpdatedByInternalUserId",
                table: "Address",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_User_UpdatedByUserId",
                table: "Address",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_CreatedByUserId",
                table: "Contact",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_InternalUser_InternalUpdatedByInternalUserId",
                table: "Contact",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_UpdatedByUserId",
                table: "Contact",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactAddress_User_CreatedByUserId",
                table: "ContactAddress",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactAddress_InternalUser_InternalUpdatedByInternalUserId",
                table: "ContactAddress",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactAddress_User_UpdatedByUserId",
                table: "ContactAddress",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_CreatedByUserId",
                table: "Account",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_InternalUser_InternalUpdatedByInternalUserId",
                table: "Account",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_User_UpdatedByUserId",
                table: "Account",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalUser_InternalUser_CreatedByInternalUserId",
                table: "InternalUser",
                column: "CreatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InternalUser_InternalUser_UpdatedByInternalUserId",
                table: "InternalUser",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudget_User_CreatedByUserId",
                table: "ProjectBudget",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudget_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectBudget",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectBudget_User_UpdatedByUserId",
                table: "ProjectBudget",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_User_CreatedByUserId",
                table: "ProjectContact",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectContact",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_User_UpdatedByUserId",
                table: "ProjectContact",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectExpectedResult_User_CreatedByUserId",
                table: "ProjectExpectedResult",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectExpectedResult_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectExpectedResult",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectExpectedResult_User_UpdatedByUserId",
                table: "ProjectExpectedResult",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectObjective_User_CreatedByUserId",
                table: "ProjectObjective",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectObjective_InternalUser_InternalUpdatedByInternalUserId",
                table: "ProjectObjective",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectObjective_User_UpdatedByUserId",
                table: "ProjectObjective",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_CreatedByUserId",
                table: "Project",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_InternalUser_InternalUpdatedByInternalUserId",
                table: "Project",
                column: "InternalUpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_UpdatedByUserId",
                table: "Project",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedByUserId",
                table: "User",
                column: "CreatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_InternalUser_UpdatedByInternalUserId",
                table: "User",
                column: "UpdatedByInternalUserId",
                principalTable: "InternalUser",
                principalColumn: "InternalUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_UpdatedByUserId",
                table: "User",
                column: "UpdatedByUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
