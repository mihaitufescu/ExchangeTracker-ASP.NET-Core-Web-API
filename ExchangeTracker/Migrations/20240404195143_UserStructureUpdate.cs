using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExchangeTracker.Migrations
{
    /// <inheritdoc />
    public partial class UserStructureUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Verified",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Verified",
                table: "User");
        }
    }
}
