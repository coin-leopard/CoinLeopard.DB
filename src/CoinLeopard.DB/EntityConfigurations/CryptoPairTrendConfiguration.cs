using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class CryptoPairTrendConfiguration
{
	public static ModelBuilder ConfigureCryptoPairTrendEntity(this ModelBuilder builder)
	{
		builder.Entity<CryptoPairTrend>().HasKey(cpt => cpt.Id);

		builder.Entity<CryptoPairTrend>().HasOne(cpt => cpt.Pair).WithMany(cp => cp.Trends).HasForeignKey(cpt => cpt.CryptoPairId);

		return builder;
	}
}
