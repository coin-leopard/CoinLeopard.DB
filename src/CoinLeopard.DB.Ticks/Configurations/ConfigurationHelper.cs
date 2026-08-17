using CmdScale.EntityFrameworkCore.TimescaleDB.Abstractions;
using CmdScale.EntityFrameworkCore.TimescaleDB.Configuration.ContinuousAggregate;
using CmdScale.EntityFrameworkCore.TimescaleDB.Configuration.ContinuousAggregatePolicy;
using CoinLeopard.DB.Ticks.Aggregates;
using CoinLeopard.DB.Ticks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinLeopard.DB.Ticks.Configurations;

public static class ConfigurationHelper
{
	public static void ConfigureAggregate<T>(string viewName, EntityTypeBuilder<T> builder, string interval) where T : AggregateBase
	{
		builder.HasNoKey();

		builder
			.IsContinuousAggregate<T, Kline>(viewName, interval, k => k.OpenTime, true, "1 hour")
			.AddGroupByColumn(k => k.Symbol)
			.AddAggregateFunction(k => k.OpenTime, k => k.OpenTime, EAggregateFunction.Min)
			.AddAggregateFunction(k => k.OpenPrice, k => k.OpenPrice, EAggregateFunction.First)
			.AddAggregateFunction(k => k.HighPrice, k => k.HighPrice, EAggregateFunction.Max)
			.AddAggregateFunction(k => k.LowPrice, k => k.LowPrice, EAggregateFunction.Min)
			.AddAggregateFunction(k => k.ClosePrice, k => k.ClosePrice, EAggregateFunction.Last)
			.AddAggregateFunction(k => k.Volume, k => k.Volume, EAggregateFunction.Sum)
			.AddAggregateFunction(k => k.CloseTime, k => k.CloseTime, EAggregateFunction.Max)
			.AddAggregateFunction(k => k.QuoteVolume, k => k.QuoteVolume, EAggregateFunction.Sum)
			.AddAggregateFunction(k => k.TradeCount, k => k.TradeCount, EAggregateFunction.Sum)
			.AddAggregateFunction(k => k.TakerBuyBaseVolume, k => k.TakerBuyBaseVolume, EAggregateFunction.Sum)
			.AddAggregateFunction(k => k.TakerBuyQuoteVolume, k => k.TakerBuyQuoteVolume, EAggregateFunction.Sum)
			.CreateGroupIndexes()
			.MaterializedOnly(false);

		builder.Property(e => e.TimeBucket).HasColumnName("time_bucket");
	}
}
