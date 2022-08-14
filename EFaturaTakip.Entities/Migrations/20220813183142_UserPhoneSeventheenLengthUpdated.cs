using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class UserPhoneSeventheenLengthUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("44814c84-cf85-4096-b246-769753ec3bae"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("52425fbf-9e2d-48d3-86e6-e5ffe4de413c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("79c51d41-a44e-442c-b6a8-0c07834c96a7"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "User",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(14)",
                oldMaxLength: 14);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("644bace0-ccfb-42e5-b221-66b0725bf8f1"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7da2b7dc-5086-403f-afb7-b9b91b7419b1"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("c4b10318-d550-4f66-ae69-1097b7d9aa6a"), "Accountant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("644bace0-ccfb-42e5-b221-66b0725bf8f1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7da2b7dc-5086-403f-afb7-b9b91b7419b1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("c4b10318-d550-4f66-ae69-1097b7d9aa6a"));

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "User",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("44814c84-cf85-4096-b246-769753ec3bae"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("52425fbf-9e2d-48d3-86e6-e5ffe4de413c"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("79c51d41-a44e-442c-b6a8-0c07834c96a7"), "TaxPayer" });
        }
    }
}
