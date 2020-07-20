using Products.Domain.Enums;

namespace Products.Domain
{
    public class ComputerMonitor : BaseProduct
    {
        public ComputerMonitor(string name, decimal price) : base(name, price, ProductType.ComputerMonitor)
        {

        }
    }
}
