namespace DI.Models
{
	public class Product
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public Money Price { get; private set; }
		public int Stock { get; private set; }
		public Product(Guid id, string name, Money price, int stock)
		{
			Id = id;
			Name = name;
			Price = price;
			Stock = stock;
		}
	}
}
