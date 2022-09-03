using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class CompanyTableAddCompanyIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("04b8549e-dc7d-45b1-8ead-69c4c3921fde"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("5047bbdd-1dc7-4fe6-9df6-82207ccd9000"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("51b89105-12f0-4cfc-8050-b43a85a9f62c"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Company",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("2325a6f8-0202-45fd-904b-2954282eaaec"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("287ab94c-1197-45bb-99cf-b2a972ad9273"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("36ae4f0d-c771-4c04-86a1-e0272b65fdbb"), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_CompanyId",
                table: "Company",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_Company_CompanyId",
                table: "Company",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_Company_CompanyId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_CompanyId",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("2325a6f8-0202-45fd-904b-2954282eaaec"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("287ab94c-1197-45bb-99cf-b2a972ad9273"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("36ae4f0d-c771-4c04-86a1-e0272b65fdbb"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Company");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("04b8549e-dc7d-45b1-8ead-69c4c3921fde"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5047bbdd-1dc7-4fe6-9df6-82207ccd9000"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("51b89105-12f0-4cfc-8050-b43a85a9f62c"), "Accountant" });
        }
    }
}
