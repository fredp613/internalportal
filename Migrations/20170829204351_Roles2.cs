using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class Roles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFundingOpportunityAdministrator",
                table: "InternalUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPortalAdministrator",
                table: "InternalUser",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFundingOpportunityAdministrator",
                table: "InternalUser");

            migrationBuilder.DropColumn(
                name: "IsPortalAdministrator",
                table: "InternalUser");
        }
    }
}
