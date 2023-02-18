namespace DI.Models
{
	public class Money
	{
		public string IsoCurrency { get; private set; }
		public decimal Amount { get; private set; }
		public Money(string isoCurrency, decimal amount)
		{
			IsoCurrency = isoCurrency;
			Amount = amount;
		}
	}
}
