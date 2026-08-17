using CmdScale.EntityFrameworkCore.TimescaleDB.Configuration.Hypertable;
using CmdScale.EntityFrameworkCore.TimescaleDB.Configuration.RetentionPolicy;
using CoinLeopard.DB.Ticks.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinLeopard.DB.Ticks.Configurations;

public class KlineTickConfiguration : IEntityTypeConfiguration<KlineTick>
{
	public void Configure(EntityTypeBuilder<KlineTick> builder)
	{
		builder.HasKey(row => new { row.Symbol, row.TickTime });

		builder.HasIndex(row => new { row.Symbol, row.TickTime });

		builder.IsHypertable(row => row.TickTime).WithChunkTimeInterval("1 hour").WithRetentionPolicy(dropAfter: "30 days");
	}
}
