using System;
using CmdScale.EntityFrameworkCore.TimescaleDB.Configuration.Hypertable;
using CmdScale.EntityFrameworkCore.TimescaleDB.Configuration.RetentionPolicy;
using CoinLeopard.DB.Ticks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinLeopard.DB.Ticks.Configurations;

public class KlineConfiguration : IEntityTypeConfiguration<Kline>
{
	public void Configure(EntityTypeBuilder<Kline> builder)
	{
		builder.HasKey(row => new { row.Symbol, row.OpenTime });

		builder.HasIndex(row => new { row.Symbol, row.OpenTime });

		builder.IsHypertable(row => row.OpenTime).WithChunkTimeInterval("1 hour").WithRetentionPolicy(dropAfter: "30 days");
	}
}
