using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    /// <summary>
    /// Class phone with overloading opertors.
    /// </summary>
    public class Phone : BaseProduct
    {
        /// <summary>
        /// Constructor with name and phone parameters.
        /// </summary>
        /// <param name="name">Name of phone.</param>
        /// <param name="price">Price of phone.</param>
        public Phone(string name, decimal price) : base(name, price, ProductType.Phone)
        {
        }

        /// <summary>
        /// Operator + returns the average price of products.
        /// </summary>
        /// <param name="productOne">Product one.</param>
        /// <param name="productTwo">Product two.</param>
        /// <returns>Returns the average price of products.</returns>
        public static Phone operator +(Phone productOne, Phone productTwo)
        {
            if (productOne == null)
                throw new ArgumentNullException("Product one is null");
            if (productTwo == null)
                throw new ArgumentNullException("Product two is null");

            return new Phone(
               name: string.Format("{0}-{1}", productOne.Name, productTwo.Name),
               price: (productOne.Price + productTwo.Price) / 2
               );
        }

        /// <summary>
        /// Convet book type to phone.
        /// </summary>
        /// <param name="v">Return phone.</param>
        public static explicit operator Phone(Book v)
        {
            return new Phone(v.Name, v.Price);
        }

        /// <summary>
        /// Convert ComputerMonitor type to phone.
        /// </summary>
        /// <param name="v">Returns phone.</param>
        public static explicit operator Phone(ComputerMonitor v)
        {
            return new Phone(v.Name, v.Price);
        }
    }
}
