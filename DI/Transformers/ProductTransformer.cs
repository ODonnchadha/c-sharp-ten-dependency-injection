using DI.Interfaces.Contexts;
using DI.Interfaces.Statistics;
using DI.Interfaces.Transformers;
using DI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DI.Transformers
{
    public class ProductTransformer : IProductTransformer
    {
        private readonly IImportStatistics statistics;
        private readonly IServiceScopeFactory factory;
        public ProductTransformer(IImportStatistics statistics, IServiceScopeFactory factory)
        {
            this.factory = factory;
            this.statistics = statistics;
        }
        public Product ApplyTransformation(Product product)
        {
            using var scope = factory.CreateScope();

            var context = scope.ServiceProvider.GetRequiredService<IProductTransformationContext>();
            context.SetProduct(product);

            var name = scope.ServiceProvider.GetRequiredService<INameDecapitalizer>();
            var currency = scope.ServiceProvider.GetRequiredService<ICurrencyNormalizer>();

            name.Execute();
            currency.Execute();

            if (context.IsProductChanged())
            {
                statistics.IncrementTransformationCount();
            }

            return context.GetProduct();
        }
    }
}
