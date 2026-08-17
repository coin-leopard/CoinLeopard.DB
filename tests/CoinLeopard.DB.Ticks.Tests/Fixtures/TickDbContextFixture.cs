using CmdScale.EntityFrameworkCore.TimescaleDB;
using CoinLeopard.DB.Ticks.Migrations;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace CoinLeopard.DB.Ticks.Tests.Fixtures;

public class TickDbContextFixture : IAsyncLifetime
{
	private readonly PostgreSqlContainer _container = new PostgreSqlBuilder("timescale/timescaledb:latest-pg18").Build();

	private string ConnectionString(string dbName)
	{
		var connectionString = _container.GetConnectionString();
		return connectionString.Replace("Database=postgres;", $"Database={dbName};");
	}

	public async Task<TickDbContext> GetContextAsync(string dbName)
	{
		var connectionString = ConnectionString(dbName);
		var options = new DbContextOptionsBuilder<TickDbContext>()
			.UseNpgsql(
				connectionString,
				npgSqlOptions =>
				{
					npgSqlOptions.MigrationsAssembly("CoinLeopard.DB.Ticks");
				}
			)
			.UseTimescaleDb();

		var context = new TickDbContext(options.Options);

		await context.Database.MigrateAsync();
		return context;
	}

	public async ValueTask DisposeAsync()
	{
		await _container.StopAsync();
		await _container.DisposeAsync();
	}

	public async ValueTask InitializeAsync()
	{
		await _container.StartAsync();
	}
}
