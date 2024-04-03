using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeTracker.Migrations
{
    /// <inheritdoc />
    public partial class ModifyEntries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                table: "CurrencyEntry",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "CurrencyEntry",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
