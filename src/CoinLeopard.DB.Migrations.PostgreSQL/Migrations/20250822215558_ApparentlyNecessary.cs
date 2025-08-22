using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
	/// <inheritdoc />
	public partial class ApparentlyNecessary : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(name: "FK_Heuristics_FuturesSymbols_FuturesSymbolSymbol", table: "Heuristics");

			migrationBuilder.DropPrimaryKey(name: "PK_Heuristics", table: "Heuristics");

			migrationBuilder.RenameTable(name: "Heuristics", newName: "Heuristic");

			migrationBuilder.AddPrimaryKey(name: "PK_Heuristic", table: "Heuristic", column: "Id");

			migrationBuilder.CreateIndex(name: "IX_Heuristic_FuturesSymbolSymbol", table: "Heuristic", column: "FuturesSymbolSymbol");

			migrationBuilder.AddForeignKey(
				name: "FK_Heuristic_FuturesSymbols_FuturesSymbolSymbol",
				table: "Heuristic",
				column: "FuturesSymbolSymbol",
				principalTable: "FuturesSymbols",
				principalColumn: "Symbol"
			);
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropForeignKey(name: "FK_Heuristic_FuturesSymbols_FuturesSymbolSymbol", table: "Heuristic");

			migrationBuilder.DropPrimaryKey(name: "PK_Heuristic", table: "Heuristic");

			migrationBuilder.DropIndex(name: "IX_Heuristic_FuturesSymbolSymbol", table: "Heuristic");

			migrationBuilder.RenameTable(name: "Heuristic", newName: "Heuristics");

			migrationBuilder.AddPrimaryKey(name: "PK_Heuristics", table: "Heuristics", column: "Id");

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
