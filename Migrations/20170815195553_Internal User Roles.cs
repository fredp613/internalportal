using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class InternalUserRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "InternalUser",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "InternalUser",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "InternalUser",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "InternalUserRole",
                columns: table => new
                {
                    InternalUserRoleId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    InternalUserId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InternalUserRole", x => x.InternalUserRoleId);
                    table.ForeignKey(
                        name: "FK_InternalUserRole_InternalUser_InternalUserId",
                        column: x => x.InternalUserId,
                        principalTable: "InternalUser",
                        principalColumn: "InternalUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InternalUserRole_InternalUserId",
                table: "InternalUserRole",
                column: "InternalUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InternalUserRole");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "InternalUser");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "InternalUser");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "InternalUser",
                newName: "Role");
        }
    }
}
