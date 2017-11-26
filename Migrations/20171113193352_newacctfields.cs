using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class newacctfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BillingAddressLine1",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingAddressLine2",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCity",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingCountry",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingPostal",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillingState",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddressLine1",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryAddressLine2",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCity",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryCountry",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryPostal",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryState",
                table: "Account",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BillingAddressLine1",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingAddressLine2",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingCity",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingCountry",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingPostal",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BillingState",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryAddressLine1",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryAddressLine2",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryCity",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryCountry",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryPostal",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryState",
                table: "Account");
        }
    }
}
