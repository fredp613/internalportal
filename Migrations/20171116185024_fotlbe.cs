using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class fotlbe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Audited",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Objective1",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objective2",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Objective3",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "TaxPercent",
                table: "Project",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "TaxRebate",
                table: "Project",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Audited",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Objective1",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Objective2",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Objective3",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TaxRebate",
                table: "Project");
        }
    }
}
