using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddPersonNameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "TcknVkn",
                table: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Company",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Company",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Company",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TcKimlikNo",
                table: "Company",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VergiNo",
                table: "Company",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3fc30c56-e360-47c3-82db-3591983ae0ea"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5cdcaf89-8a2f-43aa-a535-dd734e334936"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8a38321c-59b0-4cff-9d9a-910dbf55475c"), "TaxPayer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3fc30c56-e360-47c3-82db-3591983ae0ea"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5cdcaf89-8a2f-43aa-a535-dd734e334936"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8a38321c-59b0-4cff-9d9a-910dbf55475c"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "TcKimlikNo",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "VergiNo",
                table: "Company");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Company",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TcknVkn",
                table: "Company",
                type: "nvarchar(11)",
                maxLength: 11,
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
    }
}
