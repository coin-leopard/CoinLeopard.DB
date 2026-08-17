using System;
using CmdScale.EntityFrameworkCore.TimescaleDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CoinLeopard.DB.Ticks;

public class DesignTimeTickDbContextFactory : IDesignTimeDbContextFactory<TickDbContext>
{
	public TickDbContext CreateDbContext(string[] args)
	{
		if (args.Count() == 0)
		{
			throw new ArgumentException("Missing connection string argument");
		}

		var conStr = args[0];

		var optionsBuilder = new DbContextOptionsBuilder<TickDbContext>();

		optionsBuilder
			.UseNpgsql(
				args[0],
				postgresOptions =>
				{
					postgresOptions.MigrationsAssembly("CoinLeopard.DB.Ticks");
				}
			)
			.UseTimescaleDb();

		return new TickDbContext(optionsBuilder.Options);
	}
}
