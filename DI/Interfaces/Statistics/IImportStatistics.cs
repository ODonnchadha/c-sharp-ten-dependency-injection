namespace DI.Interfaces.Statistics
{
	public interface IImportStatistics
	{
		void IncrementImportCount();
		void IncrementOutputCount();
		string GetStatistics();
	}
}
