using System;
using System.Linq.Expressions;

namespace CoinLeopard.DB.Entities;

public class KlineEntry
{
	public DateTime Open { get; set; }
	public DateTime Close { get; set; }
	public long Interval { get; set; }
	public string Symbol { get; set; } = null!;
	public decimal OpenPrice { get; set; }
	public decimal ClosePrice { get; set; }
	public decimal HighPrice { get; set; }
	public decimal LowPrice { get; set; }
	public decimal Volume { get; set; }
	public virtual FuturesSymbol FuturesSymbol { get; set; } = null!;
}
