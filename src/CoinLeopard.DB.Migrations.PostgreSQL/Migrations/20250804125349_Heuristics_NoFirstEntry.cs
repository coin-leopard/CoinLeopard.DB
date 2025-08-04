using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Heuristics_NoFirstEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstEntryValue",
                table: "Heuristics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "FirstEntryValue",
                table: "Heuristics",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
