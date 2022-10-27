using CoinLeopard.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace CoinLeopard.DB.EntityConfigurations
{
	public static class CryptoCurrencyConfiguration
	{
		public static ModelBuilder ConfigureCryptoCurrencyEntity(this ModelBuilder builder)
		{
			builder.Entity<CryptoCurrency>().HasKey(e => e.Code);

			builder.Entity<CryptoCurrency>().Property(e => e.Code).HasMaxLength(6);

			builder.Entity<CryptoCurrency>().HasMany(cc => cc.LeftPairs).WithOne(cc => cc.LeftCurrency).HasForeignKey(cc => cc.Left);

			builder.Entity<CryptoCurrency>().HasMany(cc => cc.RightPairs).WithOne(cc => cc.RightCurrency).HasForeignKey(cc => cc.Right);

			return builder;
		}
	}
}
