using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "SalesDb",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesDb", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_SalesDb_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "FirstName", "HireDate", "LastName", "ManagerId" },
                values: new object[] { 1, new DateTime(1979, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Katie", new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Travis", 0 });

            migrationBuilder.InsertData(
                table: "SalesDb",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[,]
                {
                    { 1, 375987m, 1, 1, 2020 },
                    { 2, 420357m, 1, 2, 2020 },
                    { 3, 741258m, 1, 3, 2020 },
                    { 4, 529183m, 1, 4, 2020 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesDb_EmployeeId",
                table: "SalesDb",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesDb");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
