using DI.Contexts;
using DI.Interfaces.Contexts;
using DI.Interfaces.Transformers;
using DI.Models;

namespace DI.Transformers
{
    public class CurrencyNormalizer : ICurrencyNormalizer
    {
        private readonly IProductTransformationContext context;
        public CurrencyNormalizer(IProductTransformationContext context) => this.context = context;
        public void Execute()
        {
            var p = context.GetProduct();

            if (p.Price.IsoCurrency == Money.USD)
            {
                var newPrice = new Money(Money.EUR, p.Price.Amount * Money.USDToEURRate);
                var newProduct = new Product(p.Id, p.Name, newPrice, p.Stock);

                context.SetProduct(newProduct);
            }
        }
    }
}
