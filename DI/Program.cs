using DI.Interfaces.Sources;
using DI.Interfaces.Statistics;
using DI.Interfaces.Targets;
using DI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Module2.BeforeDI;
using Module2.BeforeDI.Shared;
using Module2.BeforeDI.Source;
using Module2.BeforeDI.Target;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
	{
		services.AddTransient<Configuration>();
		services.AddTransient<IPriceParser, PriceParser>();
		services.AddTransient<IProductSource, ProductSource>();
		services.AddTransient<IProductTarget, ProductTarget>();
		services.AddTransient<IProductFormatter, ProductFormatter>();
		services.AddTransient<ProductImporter>();
		services.AddSingleton<IImportStatistics, ImportStatisticsService>();
	})
    .Build();

var productImporter = host.Services.GetRequiredService<ProductImporter>();
productImporter.Run();