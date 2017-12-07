using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InternalPortal.Migrations
{
    public partial class feedbacktypebool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAddresses");

            migrationBuilder.DropTable(
                name: "tblContacts");

            migrationBuilder.AddColumn<bool>(
                name: "IsRejection",
                table: "Feedback",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRejection",
                table: "Feedback");

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
        }
    }
}
