using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    public partial class FuturesEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FuturesPositions_CryptoPairs_CryptoPairId",
                table: "FuturesPositions");

            migrationBuilder.RenameColumn(
                name: "Capital",
                table: "FuturesPositions",
                newName: "ProfitLoss");

            migrationBuilder.AlterColumn<Guid>(
                name: "CryptoPairId",
                table: "FuturesPositions",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

            migrationBuilder.AlterColumn<string>(
                name: "Right",
                table: "CryptoPairs",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Left",
                table: "CryptoPairs",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CryptoCurrencies",
                type: "character varying(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(4)",
                oldMaxLength: 4);

            migrationBuilder.CreateTable(
                name: "FuturesSymbols",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuturesSymbols", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "ContractTrends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<long>(type: "bigint", nullable: false),
                    MarkPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    IndexPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    EstimatedSettlePrice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractTrends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractTrends_FuturesSymbols_Symbol",
                        column: x => x.Symbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuturesPositions_Symbol",
                table: "FuturesPositions",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTrends_Symbol",
                table: "ContractTrends",
                column: "Symbol");

            migrationBuilder.AddForeignKey(
                name: "FK_FuturesPositions_CryptoPairs_CryptoPairId",
                table: "FuturesPositions",
                column: "CryptoPairId",
                principalTable: "CryptoPairs",
                principalColumn: "Id");

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
                name: "FK_FuturesPositions_CryptoPairs_CryptoPairId",
                table: "FuturesPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_FuturesPositions_FuturesSymbols_Symbol",
                table: "FuturesPositions");

            migrationBuilder.DropTable(
                name: "ContractTrends");

            migrationBuilder.DropTable(
                name: "FuturesSymbols");

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

            migrationBuilder.RenameColumn(
                name: "ProfitLoss",
                table: "FuturesPositions",
                newName: "Capital");

            migrationBuilder.AlterColumn<Guid>(
                name: "CryptoPairId",
                table: "FuturesPositions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Right",
                table: "CryptoPairs",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Left",
                table: "CryptoPairs",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "CryptoCurrencies",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(6)",
                oldMaxLength: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_FuturesPositions_CryptoPairs_CryptoPairId",
                table: "FuturesPositions",
                column: "CryptoPairId",
                principalTable: "CryptoPairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
