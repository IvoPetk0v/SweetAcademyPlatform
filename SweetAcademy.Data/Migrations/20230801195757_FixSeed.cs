using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class FixSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 2, 1 },
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 1 },
                column: "Quantity",
                value: 4);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantity",
                value: 5);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 2 },
                column: "Quantity",
                value: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 2, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 1 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 2 },
                column: "Quantity",
                value: 0);

            migrationBuilder.UpdateData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 2 },
                column: "Quantity",
                value: 0);
        }
    }
}
