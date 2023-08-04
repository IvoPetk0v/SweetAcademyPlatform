using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Chef",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("21d6dffe-e209-4dcc-9fa9-08db92b169a9"), 0, "f420ec05-4560-49a1-a22a-3a7c6b0ffc9a", null, false, true, null, "IP@CUSTOMER.BG", null, "AQAAAAEAACcQAAAAEO1XTr6PzJ1+1+fdYOEB+Dq8GcV5kClGxOY90gYEs0MmzeRZA2G7eGL205oEaCYbcg==", null, false, "2WCQ3I2BZ2DU4YJT62ZMCHKVUCO2PKGL", false, "ip@customer.bg" },
                    { new Guid("5bfc2446-3fd2-4990-9265-08db8aad116c"), 0, "df94bcd6-62ee-46f1-a089-0576b12308bf", null, false, true, null, "ADMIN@ADMIN.BG", null, "AQAAAAEAACcQAAAAEHXuw6dYlxC8AEJ5dq817hzjCU/O72xLYs+NeKUXL/Rdikx4mt6Q3+3jzAhARG4NEA==", null, false, "EF2DAKHPWV6KTXCJF4JR2RQMHEXPPGQ3", false, "admin@admin.bg" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "Unit" },
                values: new object[,]
                {
                    { 1, "Sugar", 0.20m, "50 g." },
                    { 2, "Butter", 6.99m, "250 g." },
                    { 3, "Chocolate", 3.50m, "90 g." },
                    { 4, "Milk", 1.5m, "500 ml" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Active", "Description", "ImageUrl", "Name", "StepsJson" },
                values: new object[,]
                {
                    { 1, true, "Bake an impressive dinner party dessert with minimum fuss – these chocolate puddings, also known as chocolate fondant or lava cake, have a lovely gooey center", "https://img.freepik.com/free-vector/chocolate-lava-cake-with-raspberry-sticker-isolated-white-background_1308-65607.jpg?w=740&t=st=1690710465~exp=1690711065~hmac=c96a6d3712a020c5968f3facf16b2b30de62319e54a40295bdf134c02fef733a", "Lava Cake", "[\"Heat oven to 200C/180C fan/gas 6. Butter 6 dariole moulds or basins well and place on a baking tray.\",\"Carefully run a knife around the edge of each pudding, then turn out onto serving plates and serve with single cream.\"]" },
                    { 2, true, "Dairy-free and egg-free, this delicious ice cream is surprisingly rich and indulgent. Use whatever add-ins you like in this dairy-free ice cream; a fantastic base recipe that's super easy!", "https://img.freepik.com/free-vector/ice-cream-cone-cartoon-icon-illustration-sweet-food-icon-concept-isolated-flat-cartoon-style_138676-2924.jpg?w=740&t=st=1690915084~exp=1690915684~hmac=541a6d2f00afd0f44bf7033fbbb68151944f853d57559807362364812e0bef60", "VEGAN ICE CREAM", "[\"Blend: In a blender, add all ingredients and blend on high until thick and creamy, 1-2 min. Transfer mixture to an airtight container and chill 2-4 hours.\",\"Freeze: May serve immediately for a frozen custard-like texture that's ultra creamy, smooth, and soft. Otherwise, transfer ice cream to an airtight container and freeze 30-60 minutes for a firmer texture. If frozen much longer, it will need thaw time at room temp before serving (actual thaw time depends on your room temp.)\"]" }
                });

            migrationBuilder.InsertData(
                table: "Chef",
                columns: new[] { "Id", "Active", "ApplicationUserId", "FullName", "PhoneNumber", "TaxPerTrainingForStudent" },
                values: new object[] { new Guid("e7ecbfe6-be8c-4c46-ae6f-001bbd8a4182"), true, new Guid("5bfc2446-3fd2-4990-9265-08db8aad116c"), "Steffy Cheffy", 899999999, 30.50m });

            migrationBuilder.InsertData(
                table: "RecipesProducts",
                columns: new[] { "ProductId", "RecipeId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 1, 1 },
                    { 3, 1, 4 },
                    { 1, 2, 5 },
                    { 2, 2, 0 },
                    { 3, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Trainings",
                columns: new[] { "Id", "Active", "ChefId", "Name", "OpenSeats", "RecipeId", "StartDate" },
                values: new object[] { 1, true, new Guid("e7ecbfe6-be8c-4c46-ae6f-001bbd8a4182"), "Learn how to make Lava Cake like a pro with Stef", 1, 1, new DateTime(2024, 2, 12, 20, 30, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("21d6dffe-e209-4dcc-9fa9-08db92b169a9"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RecipesProducts",
                keyColumns: new[] { "ProductId", "RecipeId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Trainings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("e7ecbfe6-be8c-4c46-ae6f-001bbd8a4182"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5bfc2446-3fd2-4990-9265-08db8aad116c"));

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Products");

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "Chef",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }
    }
}
