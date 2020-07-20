using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    public class BaseProduct
    {
        public BaseProduct(string name, decimal price, ProductType productType )
        {
            ProductType = productType;
            Name = name;
            Price = price;
        }

        public ProductType ProductType { get; }
        public string Name { get; }
        public decimal Price { get; }

        public static BaseProduct operator +(BaseProduct productOne, BaseProduct productTwo)
        {
            if (productOne == null)
                throw new ArgumentNullException("Product one is null");
            if (productTwo == null)
                throw new ArgumentNullException("Product two is null");

            if (productOne.ProductType == productTwo.ProductType)
            {
                return new BaseProduct(
                   name: string.Format("{0}-{1}", productOne.Name, productTwo.Name),
                   price: (productOne.Price + productTwo.Price) / 2,
                   productType: productOne.ProductType
                   );
            }
            else
            {
                throw new ArgumentException("Product type isn't equal");
            }
        }
    }
}
