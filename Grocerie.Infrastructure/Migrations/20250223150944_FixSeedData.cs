using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Grocerie.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroceryLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2025, 2, 23, 15, 3, 25, 977, DateTimeKind.Utc).AddTicks(5770));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "GroceryLists",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 2, 23, 15, 3, 25, 977, DateTimeKind.Utc).AddTicks(5770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 2, 23, 12, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
