using CoinLeopard.DB.Ticks.Aggregates;
using CoinLeopard.DB.Ticks.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.Ticks;

public class TickDbContext : DbContext
{
	public TickDbContext(DbContextOptions<TickDbContext> options) : base(options) { }

	public DbSet<Kline> Klines { get; set; }
	public DbSet<KlineTick> KlineTicks { get; set; }
	public DbSet<AggregateKline5> AggregateKline5s { get; set; }
	public DbSet<AggregateKline10> AggregateKline10s { get; set; }
	public DbSet<AggregateKline30> AggregateKline30s { get; set; }
	public DbSet<AggregateKline60> AggregateKline60s { get; set; }
	public DbSet<AggregateKline240> AggregateKline240s { get; set; }
	public DbSet<AggregateKline600> AggregateKline600s { get; set; }
	public DbSet<AggregateKline1440> AggregateKline1440s { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(TickDbContext).Assembly);
	}
}
