using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoinLeopard.DB.EntityConfigurations;

public static class AssetValueEntryConfiguration
{
	public static ModelBuilder ConfigureAssetValueEntryEntity(this ModelBuilder builder)
	{
		builder.Entity<AssetValueEntry>().HasKey(ai => ai.Id);

		return builder;
	}
}
