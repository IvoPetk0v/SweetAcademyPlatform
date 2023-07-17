using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class FixRelationUserChef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chef_ApplicationUserId",
                table: "Chef");

            migrationBuilder.CreateIndex(
                name: "IX_Chef_ApplicationUserId",
                table: "Chef",
                column: "ApplicationUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chef_ApplicationUserId",
                table: "Chef");

            migrationBuilder.CreateIndex(
                name: "IX_Chef_ApplicationUserId",
                table: "Chef",
                column: "ApplicationUserId");
        }
    }
}
