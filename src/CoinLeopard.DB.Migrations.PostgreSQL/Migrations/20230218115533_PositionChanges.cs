using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    public partial class PositionChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuturesPositions_FuturesPositionBatches_BatchId",
                table: "FuturesPositions");

            migrationBuilder.DropTable(
                name: "FuturesPositionBatches");

            migrationBuilder.DropIndex(
                name: "IX_FuturesPositions_BatchId",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "BatchId",
                table: "FuturesPositions");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "FuturesPositions",
                newName: "TakeProfitPrice");

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPrice",
                table: "FuturesPositions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EntryPrice",
                table: "FuturesPositions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PNL",
                table: "FuturesPositions",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "FuturesPositions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "StopLossOrderId",
                table: "FuturesPositions",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "FuturesPositions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "TakeProfitOrderId",
                table: "FuturesPositions",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuturesPositions_Symbol",
                table: "FuturesPositions",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_FuturesPositions_FuturesSymbols_Symbol",
                table: "FuturesPositions",
                column: "Symbol",
                principalTable: "FuturesSymbols",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuturesPositions_FuturesSymbols_Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropIndex(
                name: "IX_FuturesPositions_Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "EntryPrice",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "PNL",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "StopLossOrderId",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "TakeProfitOrderId",
                table: "FuturesPositions");

            migrationBuilder.RenameColumn(
                name: "TakeProfitPrice",
                table: "FuturesPositions",
                newName: "Price");

            migrationBuilder.AlterColumn<decimal>(
                name: "StopPrice",
                table: "FuturesPositions",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<Guid>(
                name: "BatchId",
                table: "FuturesPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "FuturesPositionBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    BaseAssetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PNL = table.Column<decimal>(type: "numeric", nullable: false),
                    Side = table.Column<int>(type: "integer", nullable: false),
                    TestMode = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuturesPositionBatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuturesPositionBatches_FuturesSymbols_Symbol",
                        column: x => x.Symbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuturesPositions_BatchId",
                table: "FuturesPositions",
                column: "BatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesPositionBatches_Symbol",
                table: "FuturesPositionBatches",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_FuturesPositions_FuturesPositionBatches_BatchId",
                table: "FuturesPositions",
                column: "BatchId",
                principalTable: "FuturesPositionBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
