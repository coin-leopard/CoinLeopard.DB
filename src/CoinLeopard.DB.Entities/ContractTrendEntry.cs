namespace CoinLeopard.DB.Entities;

public class ContractTrendEntry
{
	public Guid Id { get; set; }
	public string Symbol { get; set; } = null!;
	public virtual FuturesSymbol? FuturesSymbol { get; set; }
	public long Timestamp { get; set; }
	public decimal MarkPrice { get; set; }
	public decimal IndexPrice { get; set; }
	public decimal EstimatedSettlePrice { get; set; }
}
