using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalInterviewDayforce.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaySummaries",
                columns: table => new
                {
                    EmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Job = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dept = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EarningsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalHours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPayAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RateOfPay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaySummaries", x => new { x.EmployeeNumber, x.Job, x.Dept });
                });

            migrationBuilder.CreateTable(
                name: "RateTable",
                columns: table => new
                {
                    Job = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Dept = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EffectiveStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RateTable", x => new { x.Job, x.Dept, x.EffectiveStart });
                });

            migrationBuilder.CreateTable(
                name: "Timecards",
                columns: table => new
                {
                    EmployeeNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateWorked = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EarningsCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobWorked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptWorked = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bonus = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timecards", x => new { x.EmployeeNumber, x.DateWorked });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaySummaries");

            migrationBuilder.DropTable(
                name: "RateTable");

            migrationBuilder.DropTable(
                name: "Timecards");
        }
    }
}
