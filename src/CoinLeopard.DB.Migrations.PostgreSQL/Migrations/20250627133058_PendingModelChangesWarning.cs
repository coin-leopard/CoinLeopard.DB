using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class PendingModelChangesWarning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FuturesLimitOrder",
                table: "FuturesLimitOrder");

            migrationBuilder.RenameTable(
                name: "FuturesLimitOrder",
                newName: "FuturesLimitOrders");

            migrationBuilder.RenameIndex(
                name: "IX_FuturesLimitOrder_Handled",
                table: "FuturesLimitOrders",
                newName: "IX_FuturesLimitOrders_Handled");

            migrationBuilder.RenameIndex(
                name: "IX_FuturesLimitOrder_CreatedDate",
                table: "FuturesLimitOrders",
                newName: "IX_FuturesLimitOrders_CreatedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuturesLimitOrders",
                table: "FuturesLimitOrders",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FuturesLimitOrders",
                table: "FuturesLimitOrders");

            migrationBuilder.RenameTable(
                name: "FuturesLimitOrders",
                newName: "FuturesLimitOrder");

            migrationBuilder.RenameIndex(
                name: "IX_FuturesLimitOrders_Handled",
                table: "FuturesLimitOrder",
                newName: "IX_FuturesLimitOrder_Handled");

            migrationBuilder.RenameIndex(
                name: "IX_FuturesLimitOrders_CreatedDate",
                table: "FuturesLimitOrder",
                newName: "IX_FuturesLimitOrder_CreatedDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FuturesLimitOrder",
                table: "FuturesLimitOrder",
                column: "Id");
        }
    }
}
