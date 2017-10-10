using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class test4322 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(nullable: false),
                    CreatedByUserId = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable:true),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    GcimsContactID = table.Column<int>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    PaymentAccountAddressId = table.Column<Guid>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PreferredLanguageID = table.Column<string>(nullable: true),
                    PrimaryAccountAddressId = table.Column<Guid>(nullable: true),
                    SalutationID = table.Column<string>(nullable: true),
                    UpdatedByInternalUserId = table.Column<Guid>(nullable: true),
                    UpdatedByUserId = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
