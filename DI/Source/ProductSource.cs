using DI.Interfaces.Sources;
using DI.Interfaces.Statistics;
using DI.Models;
using Microsoft.VisualBasic.FileIO;
using Module2.BeforeDI.Shared;

namespace Module2.BeforeDI.Source;

public class ProductSource : IProductSource
{
    private readonly Configuration configuration;
    private readonly IImportStatistics statistics;
	private readonly IPriceParser parser;

	private TextFieldParser? _textFieldParser;

    public ProductSource(
        Configuration configuration, IImportStatistics statistics, IPriceParser parser)
    {
        this.configuration = configuration;
        this.parser = parser;
        this.statistics= statistics;
    }

    public void Open()
    {
        _textFieldParser = new TextFieldParser(configuration.SourceCsvPath);
        _textFieldParser.SetDelimiters(",");
    }

    public bool hasMoreProducts()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("Cannot read from a source that is not yet open");

        return !_textFieldParser.EndOfData;
    }

    public Product GetNextProduct()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("Cannot read from a source that is not yet open");

        var fields = _textFieldParser.ReadFields() ?? throw new InvalidOperationException("Could not read from source");

        var id = Guid.Parse(fields[0]);
        var name = fields[1];
        var price = parser.Parse(fields[2]);
        var stock = int.Parse(fields[3]);

        var product = new Product(id, name, price, stock);

        statistics.IncrementImportCount();

		return product;
    }

    public void Close()
    {
        if (_textFieldParser == null)
            throw new InvalidOperationException("Cannot close a source that is not yet open");

        _textFieldParser.Close();
        ((IDisposable)_textFieldParser).Dispose();
    }
}