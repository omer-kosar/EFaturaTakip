using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddCompanySaveType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CompanySaveType",
                table: "Company",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("922ff554-6fe8-456a-8974-ac392ddc49b4"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e063c4e1-573c-42b6-a47b-87bcdc4341b2"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fbb2a6f2-9cb9-4f95-aec5-2309e5217ec0"), "Accountant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("922ff554-6fe8-456a-8974-ac392ddc49b4"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e063c4e1-573c-42b6-a47b-87bcdc4341b2"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fbb2a6f2-9cb9-4f95-aec5-2309e5217ec0"));

            migrationBuilder.DropColumn(
                name: "CompanySaveType",
                table: "Company");

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
    }
}
