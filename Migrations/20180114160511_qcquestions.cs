using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class qcquestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountSubType",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CharityRegistrationNumber",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PublicFunds",
                table: "Account",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PublicSectorMember",
                table: "Account",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PublicServiceAct",
                table: "Account",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountSubType",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CharityRegistrationNumber",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PublicFunds",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PublicSectorMember",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PublicServiceAct",
                table: "Account");
        }
    }
}
