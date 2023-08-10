using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class FixApplicationUserTraining : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTraining");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUserTraining",
                columns: table => new
                {
                    ParticipatorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTraining", x => new { x.ParticipatorsId, x.TrainingId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTraining_AspNetUsers_ParticipatorsId",
                        column: x => x.ParticipatorsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTraining_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTraining_TrainingId",
                table: "ApplicationUserTraining",
                column: "TrainingId");
        }
    }
}
