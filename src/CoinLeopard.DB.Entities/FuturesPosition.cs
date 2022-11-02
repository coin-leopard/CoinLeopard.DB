using CoinLeopard.DB.Entities.Enums;

namespace CoinLeopard.DB.Entities;

public class FuturesPosition
{
	public Guid Id { get; set; }
	public FuturesPositionType Type { get; set; }
	public decimal BaseAssetAmount { get; set; }
	public string Symbol { get; set; } = null!;
	public DateTime CreatedDate { get; set; }
	public DateTime? ClosedDate { get; set; }
	public virtual FuturesSymbol? FuturesSymbol { get; set; }
}
