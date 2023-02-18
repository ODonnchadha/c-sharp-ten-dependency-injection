using DI.Interfaces.Statistics;
using System.Text;

namespace DI.Services
{
	public class ImportStatisticsService : IImportStatistics
	{
		private int importCount;
		private int outputCount;
		public string GetStatistics()
		{
			var builder = new StringBuilder { };

			builder.AppendFormat("Read a total of {0} products from Source.", importCount);
			builder.AppendLine();
			builder.AppendFormat("Written a total of {0} products to Target.", outputCount);

			return builder.ToString();
		}

		public void IncrementImportCount() => importCount++;
		public void IncrementOutputCount() => outputCount++;
	}
}
