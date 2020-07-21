using Products.Domain.Enums;
using System;

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

        /// <summary>
        /// Comparison of the properties of vectors.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Returns bool after comparison.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
            BaseProduct v = (BaseProduct)obj;
            return ProductType.Equals(v.ProductType) && Name.Equals(v.Name) && Price.Equals(v.Price);
        }

        /// <summary>
        /// Calculate hash code.
        /// </summary>
        /// <returns>The total hesh code.</returns>
        public override int GetHashCode()
        {
            return Tuple.Create(ProductType, Name, Price).GetHashCode();
        }

    }
}
