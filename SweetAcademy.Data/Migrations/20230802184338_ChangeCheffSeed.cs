using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SweetAcademy.Data.Migrations
{
    public partial class ChangeCheffSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("544b4c23-1f5e-4614-9fa8-08db92b169a9"));

            migrationBuilder.UpdateData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("e7ecbfe6-be8c-4c46-ae6f-001bbd8a4182"),
                column: "ApplicationUserId",
                value: new Guid("5bfc2446-3fd2-4990-9265-08db8aad116c"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("544b4c23-1f5e-4614-9fa8-08db92b169a9"), 0, "820ac633-56a5-408a-817f-fcad2a56dcf6", null, false, true, null, "STEFFY@CHEF.BG", null, "AQAAAAEAACcQAAAAEHTEsAJqxRwBnCrc+BtqPTZ1jrQT4yynAbmVOziB0EWfWW/n+iCtwh3LNsa4TXLxmQ==", null, false, "AAIANXMF3LVQYKLZ2QDICYEV3LUFTG5E", false, "steffy@chef.bg" });

            migrationBuilder.UpdateData(
                table: "Chef",
                keyColumn: "Id",
                keyValue: new Guid("e7ecbfe6-be8c-4c46-ae6f-001bbd8a4182"),
                column: "ApplicationUserId",
                value: new Guid("544b4c23-1f5e-4614-9fa8-08db92b169a9"));
        }
    }
}
