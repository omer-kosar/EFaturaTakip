using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class RemoveKdvColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Kdv",
                table: "Stock");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2a07801c-f350-4cdd-ba6a-f9d80de990f6"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9462f11c-fdd4-4b9d-a02c-a30b2ee3dac3"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d1a2d561-f68e-4df2-bbb5-bc7a735a8dc0"), "Accountant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2a07801c-f350-4cdd-ba6a-f9d80de990f6"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9462f11c-fdd4-4b9d-a02c-a30b2ee3dac3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d1a2d561-f68e-4df2-bbb5-bc7a735a8dc0"));

            migrationBuilder.AddColumn<int>(
                name: "Kdv",
                table: "Stock",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
