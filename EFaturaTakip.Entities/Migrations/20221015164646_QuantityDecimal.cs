using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class QuantityDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("6ceed15a-58a5-4b02-8bf3-ae6835cb1637"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f4975f00-da2c-4cae-aa80-02ddecf6cc69"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("fa312167-a08f-4f44-a24e-24fb9412f379"));

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "InvoiceItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("41ce26cd-afca-49bd-8a11-fd79a049d87a"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("523e697d-cf89-4b4f-8405-e28f8f71fd88"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a4eb0d28-e6cc-4acb-a44c-a8b952cfd353"), "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("41ce26cd-afca-49bd-8a11-fd79a049d87a"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("523e697d-cf89-4b4f-8405-e28f8f71fd88"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a4eb0d28-e6cc-4acb-a44c-a8b952cfd353"));

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "InvoiceItem",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("6ceed15a-58a5-4b02-8bf3-ae6835cb1637"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f4975f00-da2c-4cae-aa80-02ddecf6cc69"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("fa312167-a08f-4f44-a24e-24fb9412f379"), "TaxPayer" });
        }
    }
}
