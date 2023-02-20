using DI.Interfaces.Contexts;
using DI.Models;

namespace DI.Contexts
{
    public class ProductTransformationContext : IProductTransformationContext
    {
        private Product? initialProduct;
        private Product? product;
        public Product GetProduct()
        {
            if (product == null)
            {
                throw new InvalidOperationException("Set Product");
            }

            return product;
        }

        public bool IsProductChanged()
        {
            if (product == null || initialProduct == null)
            {
                return false;
            }

            return !initialProduct.Equals(product);
        }

        public void SetProduct(Product p)
        {
            product = p;

            if (initialProduct == null)
            {
                initialProduct = product;
            }
        }
    }
}
