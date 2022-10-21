using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoinLeopard.DB.Extensions.PostgreSQL;

public class CoinLeopardPostgresDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CoinLeopardContext>
{
	public CoinLeopardContext CreateDbContext(string[] args)
	{
		if (args.Length != 1)
			throw new ArgumentException("No connection string provided");

		var optionsBuilder = new DbContextOptionsBuilder<CoinLeopardContext>();

		optionsBuilder.UseNpgsql(
			args[0],
			postgresOptions =>
			{
				postgresOptions.MigrationsAssembly("CoinLeopard.DB.Migrations.PostgreSQL");
			}
		);

		return new CoinLeopardContext(optionsBuilder.Options);
	}
}
