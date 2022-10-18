namespace CoinLeopard.DB.Entities;

public class CryptoCurrency
{
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public virtual ICollection<CryptoPair> LeftPairs { get; set; } = new List<CryptoPair>();
    public virtual ICollection<CryptoPair> RightPairs { get; set; } = new List<CryptoPair>();
}
