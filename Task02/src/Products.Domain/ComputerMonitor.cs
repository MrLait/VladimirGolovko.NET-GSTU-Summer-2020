using Products.Domain.Enums;
using System;

namespace Products.Domain
{
    public class ComputerMonitor : BaseProduct
    {
        public ComputerMonitor(string name, decimal price) : base(name, price, ProductType.ComputerMonitor)
        {

        }

        public static explicit operator ComputerMonitor(Book v)
        {
            return new ComputerMonitor(v.Name, v.Price);
        }

        public static explicit operator ComputerMonitor(Phone v)
        {
            return new ComputerMonitor(v.Name, v.Price);
        }

        public static explicit operator int(ComputerMonitor computerMonitor)
        {
            int intNum = (int)computerMonitor.Price;
            int penny = (int)((computerMonitor.Price - intNum) * 100);
            return penny;
        }

        public static explicit operator float(ComputerMonitor computerMonitor) => (float)computerMonitor.Price;
        public static explicit operator double(ComputerMonitor computerMonitor) => (double)computerMonitor.Price;
    }
}
