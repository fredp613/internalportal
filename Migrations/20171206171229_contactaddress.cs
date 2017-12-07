using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class contactaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddressLine1",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddressLine2",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCity",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCountry",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryPostal",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryState",
                table: "Contact",
                nullable: true);

         
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.DropColumn(
                name: "PrimaryAddressLine1",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PrimaryAddressLine2",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PrimaryCity",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PrimaryCountry",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PrimaryPostal",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "PrimaryState",
                table: "Contact");
        }
    }
}
