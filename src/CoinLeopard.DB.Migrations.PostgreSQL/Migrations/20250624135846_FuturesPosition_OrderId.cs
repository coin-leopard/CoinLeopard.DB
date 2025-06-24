using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class FuturesPosition_OrderId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrderId",
                table: "FuturesPositions",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "FuturesPositions");
        }
    }
}
