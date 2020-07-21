using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    public class Book : BaseProduct
    {
        public Book(string name, decimal price) : base(name, price, ProductType.Book)
        {
        }

        public static Book operator +(Book productOne, Book productTwo)
        {
            if (productOne == null)
                throw new NullReferenceException("Product one is null");
            if (productTwo == null)
                throw new NullReferenceException("Product two is null");

            return new Book(
               name: string.Format("{0}-{1}", productOne.Name, productTwo.Name),
               price: (productOne.Price + productTwo.Price) / 2
               );
        }

        public static explicit operator Book(Phone v)
        {
            return new Book(v.Name, v.Price);
        }

        public static explicit operator Book(ComputerMonitor v)
        {
            return new Book(v.Name, v.Price);
        }

        public static explicit operator int(Book book)
        {
            int intNum = (int)book.Price;
            int penny = (int)((book.Price - intNum) * 100);
            return penny;
        }

        public static explicit operator float(Book book) => (float)book.Price;
        public static explicit operator double(Book book) => (double)book.Price;

    }
}
