using DI.Interfaces.Sources;
using DI.Interfaces.Statistics;
using DI.Interfaces.Targets;
using DI.Interfaces.Transformers;

namespace Module2.BeforeDI;
public class ProductImporter
{
	private readonly IImportStatistics statistics;
	private readonly IProductSource source;
    private readonly IProductTarget target;
    private readonly IProductTransformer transformer;

    public ProductImporter(
		IImportStatistics statistics, IProductSource source, IProductTarget target, IProductTransformer transformer)
    {
        this.source = source;
        this.statistics = statistics;
		this.target = target;
        this.transformer = transformer;
    }

    public void Run()
    {
		source.Open();
		target.Open();

        while (source.hasMoreProducts())
        {
            var product = source.GetNextProduct();

            var transform = transformer.ApplyTransformation(product);

			target.AddProduct(transform);
        }

		source.Close();
		target.Close();

        Console.WriteLine(statistics.GetStatistics());
    }
}