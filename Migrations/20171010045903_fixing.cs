using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
               name: "Attempts",
               table: "Contact",
               nullable: false,
               defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Contact",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "Attempts",
                 table: "Contact");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
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
        }
    }
}
