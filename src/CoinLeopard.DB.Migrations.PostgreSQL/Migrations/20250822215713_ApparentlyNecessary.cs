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
            migrationBuilder.DropForeignKey(
                name: "FK_Heuristics_FuturesSymbols_FuturesSymbolSymbol",
                table: "Heuristics");

            migrationBuilder.DropColumn(
                name: "FuturesSymbolSymbol",
                table: "Heuristics");

            migrationBuilder.CreateIndex(
                name: "IX_Heuristics_Symbol_Name",
                table: "Heuristics",
                columns: new[] { "Symbol", "Name" });

            migrationBuilder.AddForeignKey(
                name: "FK_Heuristics_FuturesSymbols_Symbol",
                table: "Heuristics",
                column: "Symbol",
                principalTable: "FuturesSymbols",
                principalColumn: "Symbol",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heuristics_FuturesSymbols_Symbol",
                table: "Heuristics");

            migrationBuilder.DropIndex(
                name: "IX_Heuristics_Symbol_Name",
                table: "Heuristics");

            migrationBuilder.AddColumn<string>(
                name: "FuturesSymbolSymbol",
                table: "Heuristics",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Heuristics_FuturesSymbols_FuturesSymbolSymbol",
                table: "Heuristics",
                column: "FuturesSymbolSymbol",
                principalTable: "FuturesSymbols",
                principalColumn: "Symbol");
        }
    }
}
