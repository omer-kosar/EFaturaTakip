using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class InvoiceItemDeleteBehavior : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("44ece4d2-a52c-49fc-ac1f-96b5f7b8257c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("450f4ed6-289e-4a5c-aef2-9575647759b6"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("dc82a53d-bc30-4847-92f5-b24b4f601727"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("44ece4d2-a52c-49fc-ac1f-96b5f7b8257c"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("450f4ed6-289e-4a5c-aef2-9575647759b6"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("dc82a53d-bc30-4847-92f5-b24b4f601727"), "TaxPayer" });
        }
    }
}
