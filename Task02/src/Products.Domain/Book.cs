using Products.Domain.Enums;

namespace Products.Domain
{
    public class Book : BaseProduct
    {
        public Book(string name, decimal price) : base(name, price, ProductType.Book)
        {

        }
    }
}
