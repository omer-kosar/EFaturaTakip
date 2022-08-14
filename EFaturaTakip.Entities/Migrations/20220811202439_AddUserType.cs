using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0930f7a6-d1ae-42bd-8b55-5097003cc526"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("27d7f636-62a8-4f2f-8cfe-974e80877146"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dedd336-4a4b-471b-85c3-a4766cd37109"));

            migrationBuilder.DropColumn(
                name: "TaxNumber",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "Company",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FaxNumber",
                table: "Company",
                type: "nvarchar(17)",
                maxLength: 17,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Type",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "MobilePhone",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17);

            migrationBuilder.AlterColumn<string>(
                name: "FaxNumber",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(17)",
                oldMaxLength: 17,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxNumber",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0930f7a6-d1ae-42bd-8b55-5097003cc526"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("27d7f636-62a8-4f2f-8cfe-974e80877146"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9dedd336-4a4b-471b-85c3-a4766cd37109"), "TaxPayer" });
        }
    }
}
