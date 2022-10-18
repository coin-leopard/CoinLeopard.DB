namespace CoinLeopard.DB.Entities;

public class CryptoPairTrend
{
	public Guid Id { get; set; }
	public DateTime UpdatedAt { get; set; }
	public decimal TrendValue { get; set; }
	public Guid CryptoPairId { get; set; }
	public virtual CryptoPair Pair { get; set; } = null!;
}
