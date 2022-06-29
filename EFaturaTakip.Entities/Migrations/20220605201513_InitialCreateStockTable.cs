using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFaturaTakip.Entities.Migrations
{
    public partial class InitialCreateStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("031ec04e-49b5-4bde-b9d2-00bf51bf6268"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("0907996f-08d6-49d7-80c3-a4c19ab24375"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("741bf250-5860-4f13-b90e-e1dc00120dd5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("8e13df41-bda2-4da7-b45d-8ad88b5d22ab"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("adc752cf-c9a6-49ac-b2a9-590fa6b23528"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("bb0fb673-acd4-4b6a-ba27-550a92c7b1d5"));

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    Kdv = table.Column<int>(type: "int", nullable: false),
                    ValueAddedTax = table.Column<int>(type: "int", nullable: false),
                    CommercialRegistrationNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CentralRegistrationNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    District = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ApartmentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FlatNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("3198a000-7812-4417-b910-fff356838940"), "Admin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("34c07c56-1a4b-436b-ad33-49bad62febd5"), "TaxPayer" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("eb4ca272-b689-4057-ba9a-4569270d125d"), "Accountant" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("3198a000-7812-4417-b910-fff356838940"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("34c07c56-1a4b-436b-ad33-49bad62febd5"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("eb4ca272-b689-4057-ba9a-4569270d125d"));

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("031ec04e-49b5-4bde-b9d2-00bf51bf6268"), "TaxPayer" },
                    { new Guid("0907996f-08d6-49d7-80c3-a4c19ab24375"), "TaxPayer" },
                    { new Guid("741bf250-5860-4f13-b90e-e1dc00120dd5"), "Admin" },
                    { new Guid("8e13df41-bda2-4da7-b45d-8ad88b5d22ab"), "Accountant" },
                    { new Guid("adc752cf-c9a6-49ac-b2a9-590fa6b23528"), "Accountant" },
                    { new Guid("bb0fb673-acd4-4b6a-ba27-550a92c7b1d5"), "Admin" }
                });
        }
    }
}
