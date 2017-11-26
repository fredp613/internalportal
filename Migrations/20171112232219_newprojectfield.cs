using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class newprojectfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          

            migrationBuilder.AddColumn<Guid>(
                name: "PrimaryContactId",
                table: "Project",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Contact_PrimaryContactId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_PrimaryContactId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "PrimaryContactId",
                table: "Project");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ContactId",
                table: "Project",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Contact_ContactId",
                table: "Project",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
