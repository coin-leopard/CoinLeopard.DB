using CoinLeopard.DB.Entities.Enums;
using System.Collections.ObjectModel;

namespace CoinLeopard.DB.Entities
{
	public class FuturesSymbol
	{
		public string Symbol { get; set; } = null!;
		public BaseCrypto BaseCrypto { get; set; }
		public virtual ICollection<ContractTrendEntry>? TrendEntries { get; set; }
		public virtual ICollection<AnalysisInterval>? Analyses { get; set; }
		public virtual ICollection<FuturesPositionBatch>? Batches { get; set; }
	}
}
