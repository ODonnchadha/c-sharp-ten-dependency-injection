using DI.Models;

namespace DI.Interfaces.Sources
{
	public interface IPriceParser
	{
		Money Parse(string price);
	}
}
