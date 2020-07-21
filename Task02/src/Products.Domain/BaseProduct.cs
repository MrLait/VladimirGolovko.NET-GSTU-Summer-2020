using Products.Domain.Enums;

namespace Products.Domain
{
    public class BaseProduct
    {
        public BaseProduct(string name, decimal price, ProductType productType)
        {
            ProductType = productType;
            Name = name;
            Price = price;
        }

        public ProductType ProductType { get; }
        public string Name { get; }
        public decimal Price { get; }
    }
}
