using DI.Models;

namespace DI.Interfaces.Targets
{
	public interface IProductFormatter
	{
		string Format(Product product);
		string GetHeaderLine();
	}
}
