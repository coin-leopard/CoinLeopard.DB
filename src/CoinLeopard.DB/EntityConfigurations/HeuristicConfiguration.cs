using System;
using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.EntityConfigurations;

public static class HeuristicConfiguration
{
	public static ModelBuilder ConfigureHeuristicEntity(this ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Heuristic>(entity =>
		{
			entity.HasKey(e => e.Id);
			entity.Property(e => e.Symbol).IsRequired();
			entity.Property(e => e.Name).IsRequired();
			entity.Property(e => e.EntrySize).IsRequired();
			entity.Property(e => e.Value).IsRequired();
			entity.Property(e => e.LastUpdated).IsRequired();
		});

		modelBuilder.Entity<Heuristic>().HasOne<FuturesSymbol>(h => h.FuturesSymbol).WithMany(fs => fs.Heuristics);

		modelBuilder.Entity<Heuristic>().HasIndex(h => new { h.Symbol, h.Name });

		return modelBuilder;
	}
}
