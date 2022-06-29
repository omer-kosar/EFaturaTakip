using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddStockNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("631c1d4e-8b6f-42b3-96b5-96142fc5c253"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("66d3fb83-edca-4416-8be4-dd40c6921e71"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("75e85c3b-e11a-465e-af7d-4ef9b86db9cd"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stock",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("127f8629-08ca-4b5e-8ff3-15191ab13746"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e267bb34-d52b-4d64-a4c7-2709d8d90588"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f9d67d5f-b6be-4bc5-8b47-ed64044f76b3"), "Accountant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("127f8629-08ca-4b5e-8ff3-15191ab13746"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e267bb34-d52b-4d64-a4c7-2709d8d90588"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f9d67d5f-b6be-4bc5-8b47-ed64044f76b3"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stock");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("631c1d4e-8b6f-42b3-96b5-96142fc5c253"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("66d3fb83-edca-4416-8be4-dd40c6921e71"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("75e85c3b-e11a-465e-af7d-4ef9b86db9cd"), "Admin" });
        }
    }
}
