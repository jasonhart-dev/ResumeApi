using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ResumeApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VisitCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalVisits = table.Column<long>(type: "bigint", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitCounters", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "VisitCounters",
                columns: new[] { "Id", "LastUpdated", "TotalVisits" },
                values: new object[] { 1, new DateTime(2026, 2, 1, 16, 0, 0, 0, DateTimeKind.Utc), 0L });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VisitCounters");
        }
    }
}
