using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class VirtualStrategyRowConfiguration
{
	public static ModelBuilder ConfigureVirtualStrategyRow(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<VirtualStrategyRow>(entity =>
		{
			entity.HasKey(e => e.Symbol);
			entity.Property(e => e.StateJson).IsRequired();
		});

		return modelBuilder;
	}
}
