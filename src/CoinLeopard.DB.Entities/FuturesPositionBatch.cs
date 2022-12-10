using CoinLeopard.DB.Entities.Enums;

namespace CoinLeopard.DB.Entities;

public class FuturesPositionBatch
{
	public Guid Id { get; set; }
	public string Symbol { get; set; } = null!;
	public decimal BaseAssetAmount { get; set; }
	public decimal PNL { get; set; }
	public bool TestMode { get; set; }
	public FuturesPositionSide Side { get; set; }
	public DateTime CreatedDate { get; set; }
	public DateTime? ClosedDate { get; set; }
	public virtual ICollection<FuturesPosition>? Positions { get; set; }
	public virtual FuturesSymbol? FuturesSymbol { get; set; }
}
