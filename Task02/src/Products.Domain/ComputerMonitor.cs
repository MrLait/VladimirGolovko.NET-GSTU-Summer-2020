﻿using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    /// <summary>
    /// Class computer monitor with overloading opertors.
    /// </summary>
    public class ComputerMonitor : BaseProduct
    {
        /// <summary>
        /// Constructor with name and computer monitor parameters.
        /// </summary>
        /// <param name="name">Name of computer monitor.</param>
        /// <param name="price">Price of computer monitor.</param>
        public ComputerMonitor(string name, decimal price) : base(name, price, ProductType.ComputerMonitor)
        {

        }

        /// <summary>
        /// Operator + returns the average price of products.
        /// </summary>
        /// <param name="productOne">Product one.</param>
        /// <param name="productTwo">Product two.</param>
        /// <returns>Returns the average price of products.</returns>
        public static ComputerMonitor operator +(ComputerMonitor productOne, ComputerMonitor productTwo)
        {
            if (productOne == null)
                throw new ArgumentNullException("Product one is null");
            if (productTwo == null)
                throw new ArgumentNullException("Product two is null");

            return new ComputerMonitor(
               name: string.Format("{0}-{1}", productOne.Name, productTwo.Name),
               price: (productOne.Price + productTwo.Price) / 2
               );
        }

        /// <summary>
        /// Convet book type to computer monitor.
        /// </summary>
        /// <param name="v">Return computer monitor.</param>
        public static explicit operator ComputerMonitor(Book v)
        {
            return new ComputerMonitor(v.Name, v.Price);
        }

        /// <summary>
        /// Convert ComputerMonitor type to computer monitor.
        /// </summary>
        /// <param name="v">Returns computer monitor.</param>
        public static explicit operator ComputerMonitor(Phone v)
        {
            return new ComputerMonitor(v.Name, v.Price);
        }
    }
}
