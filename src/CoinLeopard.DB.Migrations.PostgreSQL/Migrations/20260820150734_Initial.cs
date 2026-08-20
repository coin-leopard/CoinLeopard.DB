using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Migrations.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetValueEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MonthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetValueEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CryptoCurrencies",
                columns: table => new
                {
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoCurrencies", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "FuturesLimitOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    OrderSide = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Handled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuturesLimitOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuturesSymbols",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    BaseCrypto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuturesSymbols", x => x.Symbol);
                });

            migrationBuilder.CreateTable(
                name: "CryptoPairs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Left = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Right = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoPairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CryptoPairs_CryptoCurrencies_Left",
                        column: x => x.Left,
                        principalTable: "CryptoCurrencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CryptoPairs_CryptoCurrencies_Right",
                        column: x => x.Right,
                        principalTable: "CryptoCurrencies",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Analyses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Inclination = table.Column<decimal>(type: "numeric", nullable: false),
                    Low = table.Column<decimal>(type: "numeric", nullable: false),
                    High = table.Column<decimal>(type: "numeric", nullable: false),
                    LastMarketPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    InclinationDirectionFactor = table.Column<decimal>(type: "numeric", nullable: false),
                    PercentagePriceAction = table.Column<decimal>(type: "numeric", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Analyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Analyses_FuturesSymbols_Symbol",
                        column: x => x.Symbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "Heuristics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EntrySize = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heuristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Heuristics_FuturesSymbols_Symbol",
                        column: x => x.Symbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KlineEntries",
                columns: table => new
                {
                    Open = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Interval = table.Column<long>(type: "bigint", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Close = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OpenPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    HighPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    LowPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlineEntries", x => new { x.Open, x.Symbol, x.Interval });
                    table.ForeignKey(
                        name: "FK_KlineEntries_FuturesSymbols_Symbol",
                        column: x => x.Symbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CryptoPairTrends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrendValue = table.Column<decimal>(type: "numeric", nullable: false),
                    CryptoPairId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoPairTrends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CryptoPairTrends_CryptoPairs_CryptoPairId",
                        column: x => x.CryptoPairId,
                        principalTable: "CryptoPairs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuturesPositions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    Virtual = table.Column<bool>(type: "boolean", nullable: false),
                    EntryPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<decimal>(type: "numeric", nullable: false),
                    TakeProfitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    StopPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    StopLossOrderId = table.Column<long>(type: "bigint", nullable: true),
                    TakeProfitOrderId = table.Column<long>(type: "bigint", nullable: true),
                    Closed = table.Column<bool>(type: "boolean", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateClosed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OrderSide = table.Column<int>(type: "integer", nullable: false),
                    PositionSide = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    ClientOrderId = table.Column<string>(type: "text", nullable: false),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    PNL = table.Column<decimal>(type: "numeric", nullable: true),
                    Fees = table.Column<decimal>(type: "numeric", nullable: false),
                    AnalysisSnapshot = table.Column<string>(type: "text", nullable: true),
                    CryptoPairId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuturesPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuturesPositions_CryptoPairs_CryptoPairId",
                        column: x => x.CryptoPairId,
                        principalTable: "CryptoPairs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FuturesPositions_FuturesSymbols_Symbol",
                        column: x => x.Symbol,
                        principalTable: "FuturesSymbols",
                        principalColumn: "Symbol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Analyses_Symbol",
                table: "Analyses",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_ContractTrends_Symbol",
                table: "ContractTrends",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoPairs_Left",
                table: "CryptoPairs",
                column: "Left");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoPairs_Right",
                table: "CryptoPairs",
                column: "Right");

            migrationBuilder.CreateIndex(
                name: "IX_CryptoPairTrends_CryptoPairId",
                table: "CryptoPairTrends",
                column: "CryptoPairId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesLimitOrders_CreatedDate",
                table: "FuturesLimitOrders",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesLimitOrders_Handled",
                table: "FuturesLimitOrders",
                column: "Handled");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesPositions_CryptoPairId",
                table: "FuturesPositions",
                column: "CryptoPairId");

            migrationBuilder.CreateIndex(
                name: "IX_FuturesPositions_Symbol",
                table: "FuturesPositions",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_Heuristics_Symbol_Name",
                table: "Heuristics",
                columns: new[] { "Symbol", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_KlineEntries_Symbol",
                table: "KlineEntries",
                column: "Symbol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Analyses");

            migrationBuilder.DropTable(
                name: "AssetValueEntries");

            migrationBuilder.DropTable(
                name: "ContractTrends");

            migrationBuilder.DropTable(
                name: "CryptoPairTrends");

            migrationBuilder.DropTable(
                name: "FuturesLimitOrders");

            migrationBuilder.DropTable(
                name: "FuturesPositions");

            migrationBuilder.DropTable(
                name: "Heuristics");

            migrationBuilder.DropTable(
                name: "KlineEntries");

            migrationBuilder.DropTable(
                name: "CryptoPairs");

            migrationBuilder.DropTable(
                name: "FuturesSymbols");

            migrationBuilder.DropTable(
                name: "CryptoCurrencies");
        }
    }
}
