using System;

namespace CoinLeopard.DB.Entities;

public class VirtualStrategyRow
{
	public string Symbol { get; set; } = "";
	public string StateJson { get; set; } = "";
}
