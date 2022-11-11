using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class AnalysisIntervalConfiguration
{
	public static ModelBuilder ConfigureAnalysisInterval(this ModelBuilder builder)
	{
		builder.Entity<AnalysisInterval>().HasKey(ai => ai.Id);

		builder.Entity<AnalysisInterval>().HasOne(ai => ai.FuturesSymbol).WithMany(fs => fs.Analyses).HasForeignKey(ai => ai.Symbol);

		return builder;
	}
}
