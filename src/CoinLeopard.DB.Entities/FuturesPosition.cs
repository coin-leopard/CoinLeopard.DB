using CoinLeopard.DB.Entities.Enums;

namespace CoinLeopard.DB.Entities;

public class FuturesPosition
{
    public Guid Id { get; set; }
    public decimal Capital { get; set; }
    public FuturesPositionType Type { get; set; }
    public Guid CryptoPairId { get; set; }
    public virtual CryptoPair Pair { get; set; } = null!;
}
