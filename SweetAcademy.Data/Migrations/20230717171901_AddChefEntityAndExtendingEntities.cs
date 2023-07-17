using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class AddChefEntityAndExtendingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChefId",
                table: "Trainings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "RecipesProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Chef",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TaxPerTrainingForStudent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chef_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_ChefId",
                table: "Trainings",
                column: "ChefId");

            migrationBuilder.CreateIndex(
                name: "IX_Chef_ApplicationUserId",
                table: "Chef",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Chef_ChefId",
                table: "Trainings",
                column: "ChefId",
                principalTable: "Chef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Chef_ChefId",
                table: "Trainings");

            migrationBuilder.DropTable(
                name: "Chef");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_ChefId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Trainings");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "RecipesProducts");
        }
    }
}
