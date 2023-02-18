using DI.Models;

namespace DI.Interfaces.Sources
{
	public interface IProductSource
	{
		void Open();
		bool hasMoreProducts();
		Product GetNextProduct();
		void Close();
	}
}
