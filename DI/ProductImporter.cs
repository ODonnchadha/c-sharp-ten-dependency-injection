using DI.Interfaces.Sources;
using DI.Interfaces.Statistics;
using DI.Interfaces.Targets;

namespace Module2.BeforeDI;
public class ProductImporter
{
	private readonly IImportStatistics statistics;
	private readonly IProductSource source;
    private readonly IProductTarget target;

    public ProductImporter(
		IImportStatistics statistics, IProductSource source, IProductTarget target)
    {
        this.source = source;
        this.statistics = statistics;
		this.target = target;
    }

    public void Run()
    {
		source.Open();
		target.Open();

        while (source.hasMoreProducts())
        {
            var product = source.GetNextProduct();
			target.AddProduct(product);
        }

		source.Close();
		target.Close();

        Console.WriteLine(statistics.GetStatistics());
    }
}