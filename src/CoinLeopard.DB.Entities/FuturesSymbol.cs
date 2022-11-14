using CoinLeopard.DB.Entities.Enums;
using System.Collections.ObjectModel;

namespace CoinLeopard.DB.Entities
{
	public class FuturesSymbol
	{
		public string Symbol { get; set; } = null!;
		public BaseCrypto BaseCrypto { get; set; }
		public virtual ICollection<ContractTrendEntry> TrendEntries { get; set; } = new Collection<ContractTrendEntry>();
		public virtual ICollection<FuturesPosition> Positions { get; set; } = new Collection<FuturesPosition>();
		public virtual ICollection<AnalysisInterval> Analyses { get; set; } = new Collection<AnalysisInterval>();
	}
}
