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
                throw new NullReferenceException("Product one is null");
            if (productTwo == null)
                throw new NullReferenceException("Product two is null");

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

        /// <summary>
        /// Returns penny.
        /// </summary>
        /// <param name="phone">Returns penny.</param>
        public static explicit operator int(Phone phone)
        {
            int intNum = (int)phone.Price;
            int penny = (int)((phone.Price - intNum) * 100);
            return penny;
        }

        /// <summary>
        /// Returns price in float.
        /// </summary>
        /// <param name="phone">Returns price in float.</param>
        public static explicit operator float(Phone phone) => (float)phone.Price;

        /// <summary>
        /// Returns price in double.
        /// </summary>
        /// <param name="phone">Returns price in double.</param>
        public static explicit operator double(Phone phone) => (double)phone.Price;
    }
}   
