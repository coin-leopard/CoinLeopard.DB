﻿using CoinLeopard.DB.Entities;
using CoinLeopard.DB.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB;

public class CoinLeopardContext : DbContext
{
	public CoinLeopardContext(DbContextOptions options) : base(options) { }

	public virtual DbSet<CryptoCurrency> CryptoCurrencies { get; set; } = null!;
	public virtual DbSet<CryptoPair> CryptoPairs { get; set; } = null!;
	public virtual DbSet<FuturesPosition> FuturesPositions { get; set; } = null!;
	public virtual DbSet<CryptoPairTrend> CryptoPairTrends { get; set; } = null!;
	public virtual DbSet<ContractTrendEntry> ContractTrends { get; set; } = null!;
	public virtual DbSet<FuturesSymbol> FuturesSymbols { get; set; } = null!;
	public virtual DbSet<AnalysisInterval> Analyses { get; set; } = null!;
	public virtual DbSet<AssetValueEntry> AssetValueEntries { get; set; } = null!;
	public virtual DbSet<FuturesLimitOrder> FuturesLimitOrders { get; set; } = null!;

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(
			modelBuilder
				.ConfigureCryptoCurrencyEntity()
				.ConfigureCryptoPairEntity()
				.ConfigureCryptoPairTrendEntity()
				.ConfigureFuturesPositionEntity()
				.ConfigureFuturesSymbolEntity()
				.ConfigureContractTrendEntryInterval()
				.ConfigureAnalysisIntervalEntity()
				.ConfigureAssetValueEntryEntity()
				.ConfigureFuturesLimitOrderEntity()
		);
	}
}
