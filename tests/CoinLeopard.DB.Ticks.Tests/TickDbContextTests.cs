using CoinLeopard.DB.Ticks.Entities;
using CoinLeopard.DB.Ticks.Tests.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace CoinLeopard.DB.Ticks.Tests;

public class TickDbContextTests : IClassFixture<TickDbContextFixture>
{
	private readonly TickDbContextFixture _fixture;
	private readonly ITestContextAccessor _testContextAccessor;

	private CancellationToken CT => _testContextAccessor.Current.CancellationToken;

	public TickDbContextTests(TickDbContextFixture fixture, ITestContextAccessor testContextAccessor)
	{
		_fixture = fixture;
		_testContextAccessor = testContextAccessor;
	}

	[Fact]
	public async Task BasicTest()
	{
		string dbName = Guid.NewGuid().ToString();

		var context = await _fixture.GetContextAsync(dbName);

		var kline = new Kline
		{
			Symbol = "BTCUSDT",
			OpenTime = DateTime.UtcNow.AddHours(-2),
			OpenPrice = 50000,
			HighPrice = 51000,
			LowPrice = 49000,
			ClosePrice = 50500,
			Volume = 1000,
			CloseTime = DateTime.UtcNow.AddHours(-1),
			QuoteVolume = 50000000,
			TradeCount = 100,
			TakerBuyBaseVolume = 600,
			TakerBuyQuoteVolume = 30000000
		};

		context.Klines.Add(kline);
		await context.SaveChangesAsync(CT);

		var savedKline = await context.Klines.ToListAsync(CT);

		var aggregate = await context.AggregateKline5s.ToListAsync(CT);

		Assert.Single(savedKline);
		Assert.NotNull(aggregate);
	}
}
