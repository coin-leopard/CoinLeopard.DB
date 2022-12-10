using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class ContractTrendEntryConfiguration
{
	public static ModelBuilder ConfigureContractTrendEntryInterval(this ModelBuilder builder)
	{
		builder.Entity<ContractTrendEntry>().HasKey(cte => cte.Id);

		builder
			.Entity<ContractTrendEntry>()
			.HasOne(cte => cte.FuturesSymbol)
			.WithMany(fs => fs.TrendEntries)
			.HasForeignKey(cte => cte.Symbol);

		return builder;
	}
}
