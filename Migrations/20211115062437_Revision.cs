using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesApp.Migrations
{
    public partial class Revision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "SalesDb",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 1,
                column: "Amount",
                value: 375987.0);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 2,
                column: "Amount",
                value: 420357.0);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 3,
                column: "Amount",
                value: 741258.0);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 4,
                column: "Amount",
                value: 529183.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "SalesDb",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 1,
                column: "Amount",
                value: 375987m);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 2,
                column: "Amount",
                value: 420357m);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 3,
                column: "Amount",
                value: 741258m);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 4,
                column: "Amount",
                value: 529183m);
        }
    }
}
