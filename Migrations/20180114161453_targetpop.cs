using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InternalPortal.Migrations
{
    public partial class targetpop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectTargetPopulation",
                columns: table => new
                {
                    ProjectTargetPopulationId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    IsOther = table.Column<bool>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    TargetPopulationEn = table.Column<string>(nullable: true),
                    TargetPopulationFr = table.Column<string>(nullable: true),
                    TargetPopulationOther = table.Column<string>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTargetPopulation", x => x.ProjectTargetPopulationId);
                    table.ForeignKey(
                        name: "FK_ProjectTargetPopulation_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectTargetPopulation_ProjectId",
                table: "ProjectTargetPopulation",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectTargetPopulation");
        }
    }
}
