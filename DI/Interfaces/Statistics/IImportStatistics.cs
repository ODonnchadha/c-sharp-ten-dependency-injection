namespace DI.Interfaces.Statistics
{
	public interface IImportStatistics
	{
		void IncrementImportCount();
        void IncrementTransformationCount();
        void IncrementOutputCount();
		string GetStatistics();
	}
}
