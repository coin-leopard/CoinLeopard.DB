using System;

namespace CoinLeopard.DB.Entities;

public class AssetValueEntry
{
	public Guid Id { get; set; }
	public decimal Value { get; set; }
	public DateTime? Date { get; set; }
	public DateTime? MonthDate { get; set; }
}
