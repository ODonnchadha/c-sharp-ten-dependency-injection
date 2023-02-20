using DI.Models;

namespace DI.Interfaces.Contexts
{
    public interface IProductTransformationContext
    {
        Product GetProduct();
        void SetProduct(Product product);
        bool IsProductChanged();
    }
}
