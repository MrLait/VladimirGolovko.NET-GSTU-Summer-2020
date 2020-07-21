using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    /// <summary>
    /// Base class BaseProduct.
    /// </summary>
    public class BaseProduct
    {
        /// <summary>
        /// Constructor with name, price and productType parameters.
        /// </summary>
        /// <param name="name">Name of book.</param>
        /// <param name="price">Price of book.</param>
        /// <param name="productType">ProductType of broduct.</param>
        public BaseProduct(string name, decimal price, ProductType productType)
        {
            ProductType = productType;
            Name = name;
            Price = price;
        }

        /// <summary>
        /// Product type property.
        /// </summary>
        public ProductType ProductType { get; }

        /// <summary>
        /// Name property.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Price property.
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// Comparison of the properties of products.
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
