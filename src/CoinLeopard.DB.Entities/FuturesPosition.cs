using CoinLeopard.DB.Entities.Enums;

namespace CoinLeopard.DB.Entities;

public class FuturesPosition
{
	public Guid Id { get; set; }
	public Guid BatchId { get; set; }
	public decimal Price { get; set; }
	public decimal? StopPrice { get; set; }
	public FuturesOrderSide OrderSide { get; set; }
	public FuturesPositionSide PositionSide { get; set; }
	public FuturesPositionType Type { get; set; }
	public string ClientOrderId { get; set; } = null!;
	public virtual FuturesPositionBatch? Batch { get; set; }
}
