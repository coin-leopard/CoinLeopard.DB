﻿using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class FuturesSymbolConfiguration
{
	public static ModelBuilder ConfigureFuturesSymbolEntity(this ModelBuilder builder)
	{
		builder.Entity<FuturesSymbol>().HasKey(fs => fs.Symbol);

		builder.Entity<FuturesSymbol>().HasMany(fs => fs.TrendEntries).WithOne(cte => cte.FuturesSymbol).HasForeignKey(cte => cte.Symbol);
		builder.Entity<FuturesSymbol>().HasMany(fs => fs.Positions).WithOne(fp => fp.FuturesSymbol).HasForeignKey(fp => fp.Symbol);
		builder.Entity<FuturesSymbol>().HasMany(fs => fs.Analyses).WithOne(ai => ai.FuturesSymbol).HasForeignKey(ai => ai.Symbol);
		builder.Entity<FuturesSymbol>().Property(fs => fs.BaseCrypto).HasConversion<int>();

		return builder;
	}
}
