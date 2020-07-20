using Products.Domain.Enums;

namespace Products.Domain
{
    public class Phone : BaseProduct
    {
        public Phone(string name, decimal price) : base(name, price, ProductType.Phone)
        {

        }
    }
}
