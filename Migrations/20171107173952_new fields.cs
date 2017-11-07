using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class newfields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AssignedBy",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedTo",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CurrentOwner",
                table: "Project",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedBy",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AssignedTo",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "CurrentOwner",
                table: "Project");
        }
    }
}
