using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class projectcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "ProjectContact",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ProjectContact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ProjectContact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ProjectContact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ProjectContact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProjectContact",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isSigningAuthority",
                table: "ProjectContact",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_AddressId",
                table: "ProjectContact",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_Address_AddressId",
                table: "ProjectContact",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_Address_AddressId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_AddressId",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "isSigningAuthority",
                table: "ProjectContact");
        }
    }
}
