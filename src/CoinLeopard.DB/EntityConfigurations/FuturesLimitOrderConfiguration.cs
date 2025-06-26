using System;
using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class FuturesLimitOrderConfiguration
{
	public static ModelBuilder ConfigureFuturesLimitOrderEntity(this ModelBuilder builder)
	{
		builder.Entity<FuturesLimitOrder>().HasKey(fp => fp.Id);

		builder.Entity<FuturesLimitOrder>().Property(fp => fp.OrderSide).HasConversion<int>();

		builder.Entity<FuturesLimitOrder>().HasIndex(fp => fp.Handled);
		builder.Entity<FuturesLimitOrder>().HasIndex(fp => fp.CreatedDate);

		return builder;
	}
}
