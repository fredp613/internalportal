using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class booltostr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IsWorkloadManager",
                table: "FundingOpportunityInternalUser",
                nullable: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "IsSubmissionReviewer",
                table: "FundingOpportunityInternalUser",
                nullable: true,
                oldClrType: typeof(bool));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsWorkloadManager",
                table: "FundingOpportunityInternalUser",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSubmissionReviewer",
                table: "FundingOpportunityInternalUser",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
