using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class FuturesPositionBatchConfiguration
{
	public static ModelBuilder ConfigureFuturesPositionBatchEntity(this ModelBuilder builder)
	{
		builder.Entity<FuturesPositionBatch>().HasKey(fpb => fpb.Id);

		builder.Entity<FuturesPositionBatch>().Property(fpb => fpb.Side).HasConversion<int>();

		builder.Entity<FuturesPositionBatch>().HasMany(fpb => fpb.Positions).WithOne(fp => fp.Batch).HasForeignKey(fp => fp.BatchId);

		builder.Entity<FuturesPositionBatch>().HasOne(fpb => fpb.FuturesSymbol).WithMany(fs => fs.Batches).HasForeignKey(fpb => fpb.Symbol);

		return builder;
	}
}
