namespace DI.Models
{
	public class Product
	{
		public Guid Id { get; private set; }
		public string Name { get; private set; }
		public Money Price { get; private set; }
		public int Stock { get; private set; }
        public string Reference { get; set; }

        public Product(Guid id, string name, Money price, int stock) : 
            this(id, name, price, stock, string.Empty) { }
        public Product(Guid id, string name, Money price, int stock, string reference)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Stock = stock;
            this.Reference = reference;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = (Product)obj;

            return Id == other.Id
                && Name == other.Name
                && Price == other.Price
                && Stock == other.Stock;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Price, Stock);
        }
    }
}
