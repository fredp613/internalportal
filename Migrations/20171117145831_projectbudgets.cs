using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class projectbudgets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ProjectBudget",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiscalYear",
                table: "ProjectBudget",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FundingOrganization",
                table: "ProjectBudget",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ProjectBudget");

            migrationBuilder.DropColumn(
                name: "FiscalYear",
                table: "ProjectBudget");

            migrationBuilder.DropColumn(
                name: "FundingOrganization",
                table: "ProjectBudget");
        }
    }
}
