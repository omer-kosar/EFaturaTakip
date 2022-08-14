using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class RemoveUserAddressAndAddServiceInfoToCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ServicePassword",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ServiceUserName",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "CentralRegistrationNumber",
                table: "Company",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CommercialRegistrationNumber",
                table: "Company",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServicePassword",
                table: "Company",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceUserName",
                table: "Company",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0a17d5ea-4b3b-4fed-b2f5-fec6f7dfb933"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("518abc2d-f957-4729-833d-c106091ae126"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ef7ce1c5-2912-41f5-9574-b9ee13a9d2c9"), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0a17d5ea-4b3b-4fed-b2f5-fec6f7dfb933"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("518abc2d-f957-4729-833d-c106091ae126"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ef7ce1c5-2912-41f5-9574-b9ee13a9d2c9"));

            migrationBuilder.DropColumn(
                name: "CentralRegistrationNumber",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "CommercialRegistrationNumber",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ServicePassword",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ServiceUserName",
                table: "Company");

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

            migrationBuilder.AddColumn<string>(
                name: "ServicePassword",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ServiceUserName",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

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
    }
}
