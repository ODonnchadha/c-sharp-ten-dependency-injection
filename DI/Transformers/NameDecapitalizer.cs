using DI.Contexts;
using DI.Interfaces.Contexts;
using DI.Interfaces.Transformers;
using DI.Models;

namespace DI.Transformers
{
    public class NameDecapitalizer : INameDecapitalizer
    {
        private readonly IProductTransformationContext context;
        public NameDecapitalizer(IProductTransformationContext context) => this.context = context;
        public void Execute()
        {
            var p = context.GetProduct();

            if (p.Name.Any(p => char.IsUpper(p)))
            {
                var product =
                    new Product(p.Id, p.Name.ToLowerInvariant(), p.Price, p.Stock);

                if (product.Name.Any(x => char.IsUpper(x)))
                {
                    var update = new Product(
                        product.Id, product.Name.ToLowerInvariant(), product.Price, product.Stock);
                    context.SetProduct(update);
                }
            }
        }
    }
}
