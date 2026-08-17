using System;
using CoinLeopard.DB.Ticks.Entities;

namespace CoinLeopard.DB.Ticks.Aggregates;

public abstract class AggregateBase : KlineBase
{
	public DateTime TimeBucket { get; set; }
}
