using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddUserCompanyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "User",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("14b47dd5-73f4-4c09-a98e-d1732fdd529d"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a513bf44-7e12-4a2e-b62b-6776197a4ea1"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a82e3d9f-48e5-4766-a406-36f1dcaeae4f"), "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_User_CompanyId",
                table: "User",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Company_CompanyId",
                table: "User",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Company_CompanyId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_CompanyId",
                table: "User");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("14b47dd5-73f4-4c09-a98e-d1732fdd529d"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a513bf44-7e12-4a2e-b62b-6776197a4ea1"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("a82e3d9f-48e5-4766-a406-36f1dcaeae4f"));

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "User");

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
    }
}
