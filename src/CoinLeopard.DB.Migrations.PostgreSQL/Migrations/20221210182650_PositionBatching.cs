using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    public partial class PositionBatching : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuturesPositions_FuturesSymbols_Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropIndex(
                name: "IX_FuturesPositions_Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "BaseAssetAmount",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "ClosedDate",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "TestMode",
                table: "FuturesPositions");

            migrationBuilder.RenameColumn(
                name: "PNL",
                table: "FuturesPositions",
                newName: "Price");

            migrationBuilder.AddColumn<Guid>(
                name: "BatchId",
                table: "FuturesPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "OrderSide",
                table: "FuturesPositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositionSide",
                table: "FuturesPositions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "StopPrice",
                table: "FuturesPositions",
                type: "numeric",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FuturesPositionBatches",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    BaseAssetAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    PNL = table.Column<decimal>(type: "numeric", nullable: false),
                    TestMode = table.Column<bool>(type: "boolean", nullable: false),
                    Side = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ClosedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "OrderSide",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "PositionSide",
                table: "FuturesPositions");

            migrationBuilder.DropColumn(
                name: "StopPrice",
                table: "FuturesPositions");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "FuturesPositions",
                newName: "PNL");

            migrationBuilder.AddColumn<decimal>(
                name: "BaseAssetAmount",
                table: "FuturesPositions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedDate",
                table: "FuturesPositions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "FuturesPositions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                table: "FuturesPositions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TestMode",
                table: "FuturesPositions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
    }
}
