using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoinLeopard.DB.Ticks.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Klines",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OpenPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    HighPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    LowPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<decimal>(type: "numeric", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuoteVolume = table.Column<decimal>(type: "numeric", nullable: false),
                    TradeCount = table.Column<int>(type: "integer", nullable: false),
                    TakerBuyBaseVolume = table.Column<decimal>(type: "numeric", nullable: false),
                    TakerBuyQuoteVolume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klines", x => new { x.Symbol, x.OpenTime });
                });

            migrationBuilder.CreateTable(
                name: "KlineTicks",
                columns: table => new
                {
                    Symbol = table.Column<string>(type: "text", nullable: false),
                    TickTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OpenTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OpenPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    HighPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    LowPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    ClosePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<decimal>(type: "numeric", nullable: false),
                    CloseTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuoteVolume = table.Column<decimal>(type: "numeric", nullable: false),
                    TradeCount = table.Column<int>(type: "integer", nullable: false),
                    TakerBuyBaseVolume = table.Column<decimal>(type: "numeric", nullable: false),
                    TakerBuyQuoteVolume = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KlineTicks", x => new { x.Symbol, x.TickTime });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Klines_Symbol_OpenTime",
                table: "Klines",
                columns: new[] { "Symbol", "OpenTime" });

            migrationBuilder.CreateIndex(
                name: "IX_KlineTicks_Symbol_TickTime",
                table: "KlineTicks",
                columns: new[] { "Symbol", "TickTime" });

            migrationBuilder.CreateHypertable(
                tableName: "Klines",
                timeColumnName: "OpenTime",
                schema: "public",
                chunkTimeInterval: "1 hour");

            migrationBuilder.CreateHypertable(
                tableName: "KlineTicks",
                timeColumnName: "TickTime",
                schema: "public",
                chunkTimeInterval: "1 hour");

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline10",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "10 minutes",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline1440",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "1 day",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline240",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "4 hours",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline30",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "30 minutes",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline5",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "5 minutes",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline60",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "1 hour",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.CreateContinuousAggregate(
                materializedViewName: "AggregateKline600",
                parentName: "Klines",
                schema: "public",
                chunkInterval: "1 hour",
                createGroupIndexes: true,
                timeBucketWidth: "10 hours",
                timeBucketSourceColumn: "OpenTime",
                aggregateFunctions: [
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "OpenTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("OpenPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.First, "OpenPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("HighPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "HighPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("LowPrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Min, "LowPrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("ClosePrice", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Last, "ClosePrice"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("Volume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "Volume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("CloseTime", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Max, "CloseTime"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("QuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "QuoteVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TradeCount", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TradeCount"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyBaseVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyBaseVolume"),
                    new CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.ContinuousAggregateFunction("TakerBuyQuoteVolume", CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions.EAggregateFunction.Sum, "TakerBuyQuoteVolume")
                ],
                groupByColumns: ["Symbol"]);

            migrationBuilder.AddRetentionPolicy(
                tableName: "Klines",
                schema: "public",
                dropAfter: "30 days",
                scheduleInterval: "1 day",
                maxRuntime: "00:00:00",
                maxRetries: -1,
                retryPeriod: "1 day");

            migrationBuilder.AddRetentionPolicy(
                tableName: "KlineTicks",
                schema: "public",
                dropAfter: "30 days",
                scheduleInterval: "1 day",
                maxRuntime: "00:00:00",
                maxRetries: -1,
                retryPeriod: "1 day");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropRetentionPolicy(
                tableName: "Klines",
                schema: "public");

            migrationBuilder.DropRetentionPolicy(
                tableName: "KlineTicks",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline10",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline1440",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline240",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline30",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline5",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline60",
                schema: "public");

            migrationBuilder.DropContinuousAggregate(
                materializedViewName: "AggregateKline600",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Klines");

            migrationBuilder.DropTable(
                name: "KlineTicks");
        }
    }
}
