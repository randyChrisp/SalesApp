using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesApp.Migrations
{
    public partial class Revised2nd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "FirstName", "HireDate", "LastName", "ManagerId" },
                values: new object[] { 2, new DateTime(1982, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stan", new DateTime(1996, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Smith", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "FirstName", "HireDate", "LastName", "ManagerId" },
                values: new object[] { 3, new DateTime(2000, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sue", new DateTime(1999, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chen", 2 });

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 1,
                column: "EmployeeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 2,
                column: "EmployeeId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 3,
                column: "EmployeeId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 4,
                column: "EmployeeId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 1,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 2,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 3,
                column: "EmployeeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "SalesDb",
                keyColumn: "SalesId",
                keyValue: 4,
                column: "EmployeeId",
                value: 1);
        }
    }
}
