using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Heuristics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heuristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EntrySize = table.Column<int>(type: "integer", nullable: false),
                    FirstEntryValue = table.Column<decimal>(type: "numeric", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FuturesSymbolSymbol = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heuristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heuristics_FuturesSymbols_FuturesSymbolSymbol",
                        column: x => x.FuturesSymbolSymbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heuristics_FuturesSymbolSymbol",
                table: "Heuristics",
                column: "FuturesSymbolSymbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heuristics");
        }
    }
}
