using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class newDbSetForChef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chef_AspNetUsers_ApplicationUserId",
                table: "Chef");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Chef_ChefId",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chef",
                table: "Chef");

            migrationBuilder.RenameTable(
                name: "Chef",
                newName: "Chefs");

            migrationBuilder.RenameIndex(
                name: "IX_Chef_ApplicationUserId",
                table: "Chefs",
                newName: "IX_Chefs_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chefs",
                table: "Chefs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chefs_AspNetUsers_ApplicationUserId",
                table: "Chefs",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Chefs_ChefId",
                table: "Trainings",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chefs_AspNetUsers_ApplicationUserId",
                table: "Chefs");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainings_Chefs_ChefId",
                table: "Trainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chefs",
                table: "Chefs");

            migrationBuilder.RenameTable(
                name: "Chefs",
                newName: "Chef");

            migrationBuilder.RenameIndex(
                name: "IX_Chefs_ApplicationUserId",
                table: "Chef",
                newName: "IX_Chef_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chef",
                table: "Chef",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Chef_AspNetUsers_ApplicationUserId",
                table: "Chef",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trainings_Chef_ChefId",
                table: "Trainings",
                column: "ChefId",
                principalTable: "Chef",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
