using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class removedcontactdep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_Address_AddressId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_Contact_ContactId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_AddressId",
                table: "ProjectContact");

            migrationBuilder.DropIndex(
                name: "IX_ProjectContact_ContactId",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "ProjectContact");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "ProjectContact");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "ProjectContact",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ContactId",
                table: "ProjectContact",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_AddressId",
                table: "ProjectContact",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContact_ContactId",
                table: "ProjectContact",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_Address_AddressId",
                table: "ProjectContact",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_Contact_ContactId",
                table: "ProjectContact",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
