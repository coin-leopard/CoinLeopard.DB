using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoinLeopard.DB.Extensions.PostgreSQL;

public static class CoinLeopardDbExtensions
{
	public static IServiceCollection AddCoinLeopardDb(this IServiceCollection services, string connectionString)
	{
		services.AddDbContext<CoinLeopardContext>(options =>
		{
			options.UseNpgsql(
				connectionString,
				npgSqlOptions =>
				{
					npgSqlOptions.MigrationsAssembly("CoinLeopard.DB.Migrations.PostgreSQL");
				}
			);
		});

		return services;
	}

	public static async Task MigrateAsync(string connectionString)
	{
		var dbContextOptionsBuilder = new DbContextOptionsBuilder().UseNpgsql(
			connectionString,
			opts =>
			{
				opts.MigrationsAssembly("CoinLeopard.DB.Migrations.PostgreSQL");
			}
		);

		var db = new CoinLeopardContext(dbContextOptionsBuilder.Options);

		await db.Database.MigrateAsync();
	}
}
