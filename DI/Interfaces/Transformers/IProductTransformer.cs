using DI.Models;

namespace DI.Interfaces.Transformers
{
    public interface IProductTransformer
    {
        Product ApplyTransformation(Product product);
    }
}
