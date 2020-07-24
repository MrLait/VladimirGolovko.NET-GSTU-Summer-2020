using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    /// <summary>
    /// Class Book with overloading opertors.
    /// </summary>
    public class Book : BaseProduct
    {
        /// <summary>
        /// Constructor with name and book parameters.
        /// </summary>
        /// <param name="name">Name of book.</param>
        /// <param name="price">Price of book.</param>
        public Book(string name, decimal price) : base(name, price, ProductType.Book)
        {
        }

        /// <summary>
        /// Operator + returns the average price of products.
        /// </summary>
        /// <param name="productOne">Product one.</param>
        /// <param name="productTwo">Product two.</param>
        /// <returns>Returns the average price of products.</returns>
        public static Book operator +(Book productOne, Book productTwo)
        {
            if (productOne == null)
                throw new ArgumentNullException("Product one is null");
            if (productTwo == null)
                throw new ArgumentNullException("Product two is null");

            return new Book(
               name: string.Format("{0}-{1}", productOne.Name, productTwo.Name),
               price: (productOne.Price + productTwo.Price) / 2
               );
        }

        /// <summary>
        /// Convet phone type to book.
        /// </summary>
        /// <param name="v">Return book.</param>
        public static explicit operator Book(Phone v)
        {
            return new Book(v.Name, v.Price);
        }

        /// <summary>
        /// Convert ComputerMonitor type to book.
        /// </summary>
        /// <param name="v">Returns book.</param>
        public static explicit operator Book(ComputerMonitor v)
        {
            return new Book(v.Name, v.Price);
        }
    }
}
