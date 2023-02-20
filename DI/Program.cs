using DI.Contexts;
using DI.Interfaces.Contexts;
using DI.Interfaces.Sources;
using DI.Interfaces.Statistics;
using DI.Interfaces.Targets;
using DI.Interfaces.Transformers;
using DI.Services;
using DI.Transformers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module2.BeforeDI;
using Module2.BeforeDI.Shared;
using Module2.BeforeDI.Source;
using Module2.BeforeDI.Target;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<IImportStatistics, ImportStatisticsService>();

        services.AddTransient<Configuration>();
		services.AddTransient<IPriceParser, PriceParser>();
		services.AddTransient<IProductSource, ProductSource>();
        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, ProductTarget>();
		services.AddTransient<ProductImporter>();

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<INameDecapitalizer, NameDecapitalizer>();
        services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IProductTransformer, ProductTransformer>();
	})
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();
productImporter.Run();