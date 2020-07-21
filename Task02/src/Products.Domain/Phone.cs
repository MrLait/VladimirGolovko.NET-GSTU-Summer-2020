using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    public class Phone : BaseProduct
    {
        public Phone(string name, decimal price) : base(name, price, ProductType.Phone)
        {
        }

        public static explicit operator Phone(Book v)
        {
            return new Phone(v.Name, v.Price);
        }

        public static explicit operator Phone(ComputerMonitor v)
        {
            return new Phone(v.Name, v.Price);
        }

        public static explicit operator int(Phone phone)
        {
            int intNum = (int)phone.Price;
            int penny = (int)((phone.Price - intNum) * 100);
            return penny;
        }

        public static explicit operator float(Phone phone) => (float)phone.Price;
        public static explicit operator double(Phone phone) => (double)phone.Price;
    }
}   
