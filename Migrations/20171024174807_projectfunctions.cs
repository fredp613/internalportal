using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InternalPortal.Migrations
{
    public partial class projectfunctions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "ClientID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Communication",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diversity",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Evaluation",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpertiseJustificiation",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageMinority",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryClientAddressAddressID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectNeeded",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblContactContactID",
                table: "Project",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "ProjectContact",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactId",
                table: "ProjectContact",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccountType",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BandNumber",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRegistered",
                table: "Account",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IncorporationLevel",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mandate",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimaryWork",
                table: "Account",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Account",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectFederalDepartment",
                columns: table => new
                {
                    ProjectFederalDepartmentId = table.Column<Guid>(nullable: false),
                    ContactInformation = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFederalDepartment", x => x.ProjectFederalDepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectMember",
                columns: table => new
                {
                    ProjectMemberId = table.Column<Guid>(nullable: false),
                    NamePosition = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectMember", x => x.ProjectMemberId);
                    table.ForeignKey(
                        name: "FK_ProjectMember_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSupporter",
                columns: table => new
                {
                    ProjectSupporterId = table.Column<Guid>(nullable: false),
                    IsConfirmed = table.Column<bool>(nullable: false),
                    IsOnGoingRelationship = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nature = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSupporter", x => x.ProjectSupporterId);
                    table.ForeignKey(
                        name: "FK_ProjectSupporter_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientID",
                table: "Project",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_PrimaryClientAddressAddressID",
                table: "Project",
                column: "PrimaryClientAddressAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_tblContactContactID",
                table: "Project",
                column: "tblContactContactID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectMember_ProjectId",
                table: "ProjectMember",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSupporter_ProjectId",
                table: "ProjectSupporter",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_Contact_ContactId",
                table: "ProjectContact",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_Contact_ContactId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectContact_Project_ProjectId",
                table: "ProjectContact");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_tblClients_ClientID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_tblAddresses_PrimaryClientAddressAddressID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_tblContacts_tblContactContactID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "ProjectFederalDepartment");

            migrationBuilder.DropTable(
                name: "ProjectMember");

            migrationBuilder.DropTable(
                name: "ProjectSupporter");

            migrationBuilder.DropTable(
                name: "tblAddresses");

            migrationBuilder.DropTable(
                name: "tblClients");

            migrationBuilder.DropTable(
                name: "tblContacts");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_PrimaryClientAddressAddressID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_tblContactContactID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Communication",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Diversity",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Evaluation",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ExpertiseJustificiation",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "LanguageMinority",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "PrimaryClientAddressAddressID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectNeeded",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "tblContactContactID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "BandNumber",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "DateRegistered",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "IncorporationLevel",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Mandate",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "PrimaryWork",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Account");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjectId",
                table: "ProjectContact",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactId",
                table: "ProjectContact",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_Contact_ContactId",
                table: "ProjectContact",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectContact_Project_ProjectId",
                table: "ProjectContact",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
