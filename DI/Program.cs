using DI.Contexts;
using DI.Generators;
using DI.Interfaces.Contexts;
using DI.Interfaces.Generators;
using DI.Interfaces.Providers;
using DI.Interfaces.Sources;
using DI.Interfaces.Statistics;
using DI.Interfaces.Targets;
using DI.Interfaces.Transformers;
using DI.Providers;
using DI.Services;
using DI.Transformers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module2.BeforeDI;
using Module2.BeforeDI.Shared;
using Module2.BeforeDI.Source;
using Module2.BeforeDI.Target;

using var host = Host.CreateDefaultBuilder(args)
    .UseDefaultServiceProvider((context, options) =>
    {
        // e.g.: System.InvalidOperationException: Cannot resolve 'Module2.BeforeDI.ProductImporter' from
        // root provider because it requires scoped service 'DI.Interfaces.Transformers.IProductTransformer'.
        options.ValidateScopes = true;
    })
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton<Configuration>();
        services.AddSingleton<IImportStatistics, ImportStatisticsService>();
        services.AddSingleton<IIncrementingCounter, IncrementingCounter>();

        services.AddTransient<IPriceParser, PriceParser>();
		services.AddTransient<IProductSource, ProductSource>();
        services.AddTransient<IProductFormatter, ProductFormatter>();
        services.AddTransient<IProductTarget, FileProductTarget>();
		services.AddTransient<ProductImporter>();
        services.AddTransient<IProductTransformer, ProductTransformer>();

        services.AddScoped<IProductTransformationContext, ProductTransformationContext>();
        services.AddScoped<INameDecapitalizer, NameDecapitalizer>();
        services.AddScoped<ICurrencyNormalizer, CurrencyNormalizer>();
        services.AddScoped<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IReferenceAdder, ReferenceAdder>();
        services.AddScoped<IReferenceGenerator, ReferenceGenerator>();

    })
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();
productImporter.Run();