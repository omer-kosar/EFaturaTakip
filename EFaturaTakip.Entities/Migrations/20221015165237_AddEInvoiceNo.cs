using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddEInvoiceNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "EInvoiceNumber",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8d4b2d04-abc9-4a99-9e6a-c7b94b23e5c4"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b91b11ac-379a-4246-a9f5-cb05469b1b91"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d901eb93-f0a1-4f14-ae37-ce6198acfae0"), "Accountant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8d4b2d04-abc9-4a99-9e6a-c7b94b23e5c4"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b91b11ac-379a-4246-a9f5-cb05469b1b91"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d901eb93-f0a1-4f14-ae37-ce6198acfae0"));

            migrationBuilder.DropColumn(
                name: "EInvoiceNumber",
                table: "Invoice");

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
    }
}
