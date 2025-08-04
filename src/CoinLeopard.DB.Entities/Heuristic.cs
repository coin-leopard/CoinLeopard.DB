using System;

namespace CoinLeopard.DB.Entities;

public class Heuristic
{
	public Guid Id { get; set; }
	public string Symbol { get; set; } = null!;
	public string Name { get; set; } = null!;
	public int EntrySize { get; set; }
	public decimal FirstEntryValue { get; set; }
	public decimal Value { get; set; }
	public DateTime LastUpdated { get; set; }

	public FuturesSymbol? FuturesSymbol { get; set; } = null!;
}
