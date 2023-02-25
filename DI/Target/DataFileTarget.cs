using DI.Contexts;
using DI.Interfaces.Targets;
using DI.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Module2.BeforeDI.Target;

public class DataFileTarget : IProductTarget
{
    private readonly IServiceScopeFactory factory;

    public DataFileTarget(IServiceScopeFactory factory) => this.factory = factory;

    public void AddProduct(Product product)
    {
        using var scope = factory.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TargetContext>();

        context.Products.Add(product);
        context.SaveChanges();
    }

    public void Close()
    {
        ;
    }

    public void Open()
    {
        using var scope = factory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<TargetContext>();

        context.Database.EnsureCreated();
    }
}
