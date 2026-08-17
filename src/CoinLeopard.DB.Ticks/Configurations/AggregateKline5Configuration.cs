using System;
using CoinLeopard.DB.Ticks.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinLeopard.DB.Ticks.Configurations;

public class AggregateKline5Configurations
	: IEntityTypeConfiguration<AggregateKline5>,
		IEntityTypeConfiguration<AggregateKline10>,
		IEntityTypeConfiguration<AggregateKline30>,
		IEntityTypeConfiguration<AggregateKline60>,
		IEntityTypeConfiguration<AggregateKline240>,
		IEntityTypeConfiguration<AggregateKline600>,
		IEntityTypeConfiguration<AggregateKline1440>
{
	public void Configure(EntityTypeBuilder<AggregateKline5> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline5), builder, "5 minutes");
	}

	public void Configure(EntityTypeBuilder<AggregateKline10> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline10), builder, "10 minutes");
	}

	public void Configure(EntityTypeBuilder<AggregateKline30> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline30), builder, "30 minutes");
	}

	public void Configure(EntityTypeBuilder<AggregateKline60> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline60), builder, "1 hour");
	}

	public void Configure(EntityTypeBuilder<AggregateKline240> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline240), builder, "4 hours");
	}

	public void Configure(EntityTypeBuilder<AggregateKline600> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline600), builder, "10 hours");
	}

	public void Configure(EntityTypeBuilder<AggregateKline1440> builder)
	{
		ConfigurationHelper.ConfigureAggregate(nameof(AggregateKline1440), builder, "1 day");
	}
}
