using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddCompanyIdStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("431fa2e9-0508-4f05-a6fd-44c36ab933f7"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("d6ff39bc-6a5b-4cb5-9266-c040cb77076c"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ec2bb709-87d1-4da7-a40c-8fb8178082a7"));

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Stock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("8f9a6a5b-554e-427b-8418-f1f65788d2db"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("b042a99d-01f1-4083-b017-59998efcbdd9"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ca1d674c-0bbe-4192-bb17-75a4cc99ee2d"), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Stock_CompanyId",
                table: "Stock",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_Company_CompanyId",
                table: "Stock",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stock_Company_CompanyId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Stock_CompanyId",
                table: "Stock");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8f9a6a5b-554e-427b-8418-f1f65788d2db"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("b042a99d-01f1-4083-b017-59998efcbdd9"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("ca1d674c-0bbe-4192-bb17-75a4cc99ee2d"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Stock");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("431fa2e9-0508-4f05-a6fd-44c36ab933f7"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("d6ff39bc-6a5b-4cb5-9266-c040cb77076c"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("ec2bb709-87d1-4da7-a40c-8fb8178082a7"), "Admin" });
        }
    }
}
