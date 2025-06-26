using System;
using CoinLeopard.DB.Entities.Enums;

namespace CoinLeopard.DB.Entities;

public class FuturesLimitOrder
{
	public Guid Id { get; set; }
	public string Symbol { get; set; } = null!;
	public FuturesOrderSide OrderSide { get; set; }
	public DateTime CreatedDate { get; set; }
	public bool Handled { get; set; }
}
