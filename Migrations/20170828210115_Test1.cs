using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class Test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.DropColumn(
           //     name: "IsSubmissionReviewer",
           //     table: "FundingOpportunityInternalUser");
/*
            migrationBuilder.DropColumn(
                name: "IsWorkloadManager",
  table: "FundingOpportunityInternalUser");
  */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
		/*
            migrationBuilder.AddColumn<bool>(
                name: "IsSubmissionReviewer",
                table: "FundingOpportunityInternalUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWorkloadManager",
                table: "FundingOpportunityInternalUser",
                nullable: false,
                defaultValue: false);
		*/
        }
    }
}
