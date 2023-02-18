using Module2.BeforeDI.Shared;
using DI.Models;
using DI.Interfaces.Targets;
using DI.Interfaces.Statistics;

namespace Module2.BeforeDI.Target;

public class ProductTarget : IProductTarget
{
    private readonly Configuration configuration;
	private readonly IImportStatistics statistics;
	private readonly IProductFormatter formatter;

    private StreamWriter? _streamWriter;

    public ProductTarget(
        Configuration configuration, IImportStatistics statistics, IProductFormatter formatter)
    {
        this.configuration = configuration;
        this.formatter = formatter;
        this.statistics = statistics;
    }

    public void Open()
    {
        _streamWriter = new StreamWriter(configuration.TargetCsvPath);

        var headerLine = formatter.GetHeaderLine();
        _streamWriter.WriteLine(headerLine);
    }

    public void AddProduct(Product product)
    {
        if (_streamWriter == null)
            throw new InvalidOperationException("Cannot add products to a target that is not yet open");

        var productLine = formatter.Format(product);

        statistics.IncrementOutputCount();

		_streamWriter.WriteLine(productLine);
    }

    public void Close()
    {
        if (_streamWriter == null)
            throw new InvalidOperationException("Cannot close a target that is not yet open");

        _streamWriter.Flush();
        _streamWriter.Close();
    }
}
