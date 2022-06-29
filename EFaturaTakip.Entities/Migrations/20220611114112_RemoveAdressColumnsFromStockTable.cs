using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class RemoveAdressColumnsFromStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2b476aff-df2c-47b5-a688-50b817be64ca"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4ad52d45-88a1-4bdb-94ab-f37545f17f29"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("944931a9-faae-4ef1-8d21-a0b4079c18ee"));

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CentralRegistrationNumber",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CommercialRegistrationNumber",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "District",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "Stock");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CentralRegistrationNumber",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommercialRegistrationNumber",
                table: "User",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlatNumber",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("69e05a15-e57e-4431-9de9-9eff5c9676cb"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9bc98f2d-00a8-47bd-a0d3-f95336de64b5"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e741b641-8fbb-4712-add8-2f32d537f0fc"), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("69e05a15-e57e-4431-9de9-9eff5c9676cb"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9bc98f2d-00a8-47bd-a0d3-f95336de64b5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e741b641-8fbb-4712-add8-2f32d537f0fc"));

            migrationBuilder.DropColumn(
                name: "ApartmentNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CentralRegistrationNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CommercialRegistrationNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "User");

            migrationBuilder.DropColumn(
                name: "District",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FlatNumber",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Province",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "ApartmentNumber",
                table: "Stock",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CentralRegistrationNumber",
                table: "Stock",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommercialRegistrationNumber",
                table: "Stock",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Stock",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "Stock",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FlatNumber",
                table: "Stock",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "Stock",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2b476aff-df2c-47b5-a688-50b817be64ca"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4ad52d45-88a1-4bdb-94ab-f37545f17f29"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("944931a9-faae-4ef1-8d21-a0b4079c18ee"), "Accountant" });
        }
    }
}
