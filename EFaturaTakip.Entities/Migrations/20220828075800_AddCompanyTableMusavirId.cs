using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class AddCompanyTableMusavirId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("4631c0a5-31e1-45c6-a1ce-e2f7087937e3"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("7556aa15-e9de-44d4-a50b-4a87dad1d83e"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("f51fca63-b0bb-4ef8-8c39-536af8b438d0"));

            migrationBuilder.AddColumn<Guid>(
                name: "MusavirId",
                table: "Company",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("03a5441a-25b9-4714-9b9d-90b177567987"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3a3d3e1f-842c-4f4b-ab76-16ece6b6e3aa"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("52d44f49-5f11-4d74-a460-a467234ad5e1"), "Accountant" });

            migrationBuilder.CreateIndex(
                name: "IX_Company_MusavirId",
                table: "Company",
                column: "MusavirId");

            migrationBuilder.AddForeignKey(
                name: "FK_Company_User_MusavirId",
                table: "Company",
                column: "MusavirId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Company_User_MusavirId",
                table: "Company");

            migrationBuilder.DropIndex(
                name: "IX_Company_MusavirId",
                table: "Company");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("03a5441a-25b9-4714-9b9d-90b177567987"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3a3d3e1f-842c-4f4b-ab76-16ece6b6e3aa"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("52d44f49-5f11-4d74-a460-a467234ad5e1"));

            migrationBuilder.DropColumn(
                name: "MusavirId",
                table: "Company");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4631c0a5-31e1-45c6-a1ce-e2f7087937e3"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("7556aa15-e9de-44d4-a50b-4a87dad1d83e"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("f51fca63-b0bb-4ef8-8c39-536af8b438d0"), "Admin" });
        }
    }
}
