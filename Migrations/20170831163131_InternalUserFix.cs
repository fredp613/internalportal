using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class InternalUserFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubmissionReviewer",
                table: "FundingOpportunityInternalUser");

            migrationBuilder.RenameColumn(
                name: "IsWorkloadManager",
                table: "FundingOpportunityInternalUser",
                newName: "HasFullAccess");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmissionReviewer",
                table: "InternalUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWorkloadManager",
                table: "InternalUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubmissionReviewer",
                table: "InternalUser");

            migrationBuilder.DropColumn(
                name: "IsWorkloadManager",
                table: "InternalUser");

            migrationBuilder.RenameColumn(
                name: "HasFullAccess",
                table: "FundingOpportunityInternalUser",
                newName: "IsWorkloadManager");

            migrationBuilder.AddColumn<bool>(
                name: "IsSubmissionReviewer",
                table: "FundingOpportunityInternalUser",
                nullable: false,
                defaultValue: false);
        }
    }
}
