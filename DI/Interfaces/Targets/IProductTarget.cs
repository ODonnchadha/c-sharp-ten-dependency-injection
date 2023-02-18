using DI.Models;

namespace DI.Interfaces.Targets
{
	public interface IProductTarget
	{
		void Open();
		void AddProduct(Product product);
		void Close();
	}
}
