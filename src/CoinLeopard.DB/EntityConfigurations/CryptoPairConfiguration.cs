using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class CryptoPairConfiguration
{
	public static ModelBuilder ConfigureCryptoPairEntity(this ModelBuilder builder)
	{
		builder.Entity<CryptoPair>().HasKey(cp => cp.Id);

		builder.Entity<CryptoPair>().Property(cp => cp.Left).HasMaxLength(6);
		builder.Entity<CryptoPair>().Property(cp => cp.Right).HasMaxLength(6);

		builder.Entity<CryptoPair>().HasOne(cp => cp.LeftCurrency).WithMany(cc => cc.LeftPairs).HasForeignKey(cp => cp.Left);
		builder.Entity<CryptoPair>().HasOne(cp => cp.RightCurrency).WithMany(cc => cc.RightPairs).HasForeignKey(cp => cp.Right);

		builder.Entity<CryptoPair>().HasMany(cp => cp.Trends).WithOne(cpt => cpt.Pair).HasForeignKey(cpt => cpt.CryptoPairId);

		return builder;
	}
}
