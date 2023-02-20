using DI.Interfaces.Contexts;
using DI.Interfaces.Generators;
using DI.Interfaces.Transformers;
using DI.Models;

namespace DI.Transformers
{
    public class ReferenceAdder : IReferenceAdder
    {
        private readonly IProductTransformationContext context;
        private readonly IReferenceGenerator generator;

        public ReferenceAdder(IProductTransformationContext context, IReferenceGenerator generator)
        {
            this.context = context;
            this.generator = generator;
        }

        public void Execute()
        {
            var p = context.GetProduct();

            var reference = generator.GetReference();

            var product = new Product(
                p.Id, p.Name.ToLowerInvariant(), p.Price, p.Stock, reference);

            context.SetProduct(product);
        }
    }
}
