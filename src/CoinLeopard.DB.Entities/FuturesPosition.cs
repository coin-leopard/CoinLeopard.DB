using CoinLeopard.DB.Entities.Enums;

namespace CoinLeopard.DB.Entities;

public class FuturesPosition
{
	public Guid Id { get; set; }
	public string Symbol { get; set; } = null!;
	public decimal EntryPrice { get; set; }
    public decimal Quantity { get; set; }
	public decimal TakeProfitPrice { get; set; }
	public decimal StopPrice { get; set; }
	public long? StopLossOrderId { get; set; }
	public long? TakeProfitOrderId { get; set; }
	public bool Closed { get; set; }
	public DateTime DateOpened { get; set; }
	public DateTime? DateClosed { get; set; }
	public FuturesOrderSide OrderSide { get; set; }
	public FuturesPositionSide PositionSide { get; set; }
	public FuturesPositionType Type { get; set; }
	public string ClientOrderId { get; set; } = null!;
	public decimal? PNL { get; set; }
	public virtual FuturesSymbol? FuturesSymbol { get; set; }
	public string? AnalysisSnapshot { get; set; }
}
