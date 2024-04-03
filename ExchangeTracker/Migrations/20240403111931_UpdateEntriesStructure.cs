using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeTracker.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntriesStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMultiplied",
                table: "CurrencyEntry",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMultiplied",
                table: "CurrencyEntry");
        }
    }
}
