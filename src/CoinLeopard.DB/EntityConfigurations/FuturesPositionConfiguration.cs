using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class FuturesPositionConfiguration
{
	public static ModelBuilder ConfigureFuturesPositionEntity(this ModelBuilder builder)
	{
		builder.Entity<FuturesPosition>().HasKey(fp => fp.Id);

		builder.Entity<FuturesPosition>().Property(fp => fp.Type).HasConversion<int>();
		builder.Entity<FuturesPosition>().Property(fp => fp.OrderSide).HasConversion<int>();
		builder.Entity<FuturesPosition>().Property(fp => fp.PositionSide).HasConversion<int>();

		builder.Entity<FuturesPosition>().HasOne(fp => fp.FuturesSymbol).WithMany(fs => fs.Positions).HasForeignKey(fp => fp.Symbol);


		return builder;
	}
}
