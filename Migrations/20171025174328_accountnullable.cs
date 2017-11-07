using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InternalPortal.Migrations
{
    public partial class accountnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Account_AccountId",
                table: "Project");



            migrationBuilder.AlterColumn<Guid>(
                name: "ContactId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Project",
                nullable: true,
                oldClrType: typeof(Guid));

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Account_AccountId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Contact_ContactId",
                table: "Project");

            migrationBuilder.AlterColumn<Guid>(
                name: "ContactId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AccountId",
                table: "Project",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrimaryClientAddressAddressID",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblContactContactID",
                table: "Project",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblAddresses",
                columns: table => new
                {
                    AddressID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    AddressLine4 = table.Column<string>(nullable: true),
                    AddressTypeID = table.Column<int>(nullable: false),
                    CityID = table.Column<int>(nullable: false),
                    ClientID = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Historical = table.Column<bool>(nullable: false),
                    OldCityID = table.Column<string>(nullable: true),
                    OldProvinceID = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddresses", x => x.AddressID);
                });

            migrationBuilder.CreateTable(
                name: "tblContacts",
                columns: table => new
                {
                    ContactID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    AddressLine3 = table.Column<string>(nullable: true),
                    AddressLine4 = table.Column<string>(nullable: true),
                    CityID = table.Column<int>(nullable: true),
                    ClientID = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    Disabled = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Firstname = table.Column<string>(nullable: true),
                    Historical = table.Column<bool>(nullable: false),
                    Initials = table.Column<string>(nullable: true),
                    LanguageID = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    OldCityID = table.Column<string>(nullable: true),
                    OldProvinceID = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    SalutationID = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblContacts", x => x.ContactID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_PrimaryClientAddressAddressID",
                table: "Project",
                column: "PrimaryClientAddressAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_tblContactContactID",
                table: "Project",
                column: "tblContactContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Account_AccountId",
                table: "Project",
                column: "AccountId",
                principalTable: "Account",
                principalColumn: "AccountId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Contact_ContactId",
                table: "Project",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_tblAddresses_PrimaryClientAddressAddressID",
                table: "Project",
                column: "PrimaryClientAddressAddressID",
                principalTable: "tblAddresses",
                principalColumn: "AddressID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_tblContacts_tblContactContactID",
                table: "Project",
                column: "tblContactContactID",
                principalTable: "tblContacts",
                principalColumn: "ContactID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
