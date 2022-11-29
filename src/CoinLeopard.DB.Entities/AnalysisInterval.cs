namespace CoinLeopard.DB.Entities;

public class AnalysisInterval
{
    public Guid Id { get; set; }
    public string Symbol { get; set; } = null!;
    public decimal Inclination { get; set; }
    public decimal Low { get; set; }
    public decimal High { get; set; }
    public decimal LastMarketPrice { get; set; }
    public decimal InclinationDirectionFactor { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public FuturesSymbol? FuturesSymbol { get; set; }
}
