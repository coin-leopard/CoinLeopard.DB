namespace CoinLeopard.DB.Entities;

public class CryptoPair
{
	public Guid Id { get; set; }
	public string Left { get; set; } = null!;
	public string Right { get; set; } = null!;
	public decimal Value { get; set; }
	public virtual CryptoCurrency LeftCurrency { get; set; } = null!;
	public virtual CryptoCurrency RightCurrency { get; set; } = null!;
	public virtual ICollection<FuturesPosition> Positions { get; set; } = new List<FuturesPosition>();
	public virtual ICollection<CryptoPairTrend> Trends { get; set; } = new List<CryptoPairTrend>();
}
