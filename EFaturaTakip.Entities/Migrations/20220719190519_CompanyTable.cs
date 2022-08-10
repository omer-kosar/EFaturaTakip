using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class CompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("69e05a15-e57e-4431-9de9-9eff5c9676cb"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9bc98f2d-00a8-47bd-a0d3-f95336de64b5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("e741b641-8fbb-4712-add8-2f32d537f0fc"));

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TcknVkn = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TaxOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    District = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FaxNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMailAdress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FlatNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("0930f7a6-d1ae-42bd-8b55-5097003cc526"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("27d7f636-62a8-4f2f-8cfe-974e80877146"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9dedd336-4a4b-471b-85c3-a4766cd37109"), "TaxPayer" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0930f7a6-d1ae-42bd-8b55-5097003cc526"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("27d7f636-62a8-4f2f-8cfe-974e80877146"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("9dedd336-4a4b-471b-85c3-a4766cd37109"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("69e05a15-e57e-4431-9de9-9eff5c9676cb"), "Accountant" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("9bc98f2d-00a8-47bd-a0d3-f95336de64b5"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("e741b641-8fbb-4712-add8-2f32d537f0fc"), "Admin" });
        }
    }
}
