using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
	/// <inheritdoc />
	public partial class FeesField : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(name: "FK_Heuristics_FuturesSymbols_FuturesSymbolSymbol", table: "Heuristics");

			migrationBuilder.DropIndex(name: "IX_Heuristics_FuturesSymbolSymbol", table: "Heuristics");

			migrationBuilder.DropColumn(name: "FuturesSymbolSymbol", table: "Heuristics");

			migrationBuilder.AddColumn<decimal>(
				name: "Fees",
				table: "FuturesPositions",
				type: "numeric",
				nullable: false,
				defaultValue: 0m
			);

			migrationBuilder.CreateIndex(name: "IX_Heuristics_Symbol_Name", table: "Heuristics", columns: new[] { "Symbol", "Name" });

			migrationBuilder.AddForeignKey(
				name: "FK_Heuristics_FuturesSymbols_Symbol",
				table: "Heuristics",
				column: "Symbol",
				principalTable: "FuturesSymbols",
				principalColumn: "Symbol",
				onDelete: ReferentialAction.Cascade
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(name: "FK_Heuristics_FuturesSymbols_Symbol", table: "Heuristics");

			migrationBuilder.DropIndex(name: "IX_Heuristics_Symbol_Name", table: "Heuristics");

			migrationBuilder.DropColumn(name: "Fees", table: "FuturesPositions");

			migrationBuilder.AddColumn<string>(name: "FuturesSymbolSymbol", table: "Heuristics", type: "text", nullable: true);

			migrationBuilder.CreateIndex(name: "IX_Heuristics_FuturesSymbolSymbol", table: "Heuristics", column: "FuturesSymbolSymbol");

			migrationBuilder.AddForeignKey(
				name: "FK_Heuristics_FuturesSymbols_FuturesSymbolSymbol",
				table: "Heuristics",
				column: "FuturesSymbolSymbol",
				principalTable: "FuturesSymbols",
				principalColumn: "Symbol"
			);
		}
	}
}
