using Products.Domain.Enums;
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
                throw new NullReferenceException("Product one is null");
            if (productTwo == null)
                throw new NullReferenceException("Product two is null");

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

        /// <summary>
        /// Returns penny.
        /// </summary>
        /// <param name="computerMonitor">Returns penny.</param>
        public static explicit operator int(ComputerMonitor computerMonitor)
        {
            int intNum = (int)computerMonitor.Price;
            int penny = (int)((computerMonitor.Price - intNum) * 100);
            return penny;
        }

        /// <summary>
        /// Returns price in float.
        /// </summary>
        /// <param name="computerMonitor">Returns price in float.</param>
        public static explicit operator float(ComputerMonitor computerMonitor) => (float)computerMonitor.Price;

        /// <summary>
        /// Returns price in double.
        /// </summary>
        /// <param name="computerMonitor">Returns price in double.</param>
        public static explicit operator double(ComputerMonitor computerMonitor) => (double)computerMonitor.Price;
    }
}
