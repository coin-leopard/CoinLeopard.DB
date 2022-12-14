using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class FuturesSymbolConfiguration
{
	public static ModelBuilder ConfigureFuturesSymbol(this ModelBuilder builder)
	{
		builder.Entity<FuturesSymbol>().HasKey(fs => fs.Symbol);

		builder.Entity<FuturesSymbol>().HasMany(fs => fs.TrendEntries).WithOne(cte => cte.FuturesSymbol).HasForeignKey(cte => cte.Symbol);
		builder.Entity<FuturesSymbol>().HasMany(fs => fs.Positions).WithOne(cte => cte.FuturesSymbol).HasForeignKey(cte => cte.Symbol);

		return builder;
	}
}
