using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class contacts11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Contact_PrimaryContactId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_PrimaryContactId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "PrimaryContactId",
                table: "Project",
                newName: "PrimaryProjectContactId");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Contact_ContactId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ContactId",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "PrimaryProjectContactId",
                table: "Project",
                newName: "PrimaryContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PrimaryContactId",
                table: "Project",
                column: "PrimaryContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Contact_PrimaryContactId",
                table: "Project",
                column: "PrimaryContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
