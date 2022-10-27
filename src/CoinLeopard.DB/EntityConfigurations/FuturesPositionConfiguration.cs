using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class FuturesPositionConfiguration
{
	public static ModelBuilder ConfigureFuturesPositionEntity(this ModelBuilder builder)
	{
		builder.Entity<FuturesPosition>().HasKey(fp => fp.Id);

		builder.Entity<FuturesPosition>().HasOne(fp => fp.FuturesSymbol).WithMany(cp => cp.Positions).HasForeignKey(fp => fp.Symbol);

        builder.Entity<FuturesPosition>().Property(fp => fp.Type).HasConversion<int>();

		return builder;
	}
}
