using System;
using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class KlineEntryConfiguration
{
	public static ModelBuilder ConfigureKlineEntryEntity(this ModelBuilder builder)
	{
		builder.Entity<KlineEntry>().HasKey(ke => new { ke.Open, ke.Symbol, ke.Interval });

		builder.Entity<KlineEntry>().HasOne(ke => ke.FuturesSymbol).WithMany(fs => fs.KlineEntries).HasForeignKey(ke => ke.Symbol);

		return builder;
	}
}
