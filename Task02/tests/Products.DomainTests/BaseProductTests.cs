using NUnit.Framework;
using Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Tests
{
    [TestFixture()]
    public class BaseProductTests
    {
        [TestCase()]
        public void BaseProductTest()
        {
            var bookOne = new Book("cool", 10);
            var bookTwo = new Book("cool2", 1000);
            var samsungPhone = new Phone("Samsung", 100);

            var sum = bookOne + bookTwo;

            int justForTest;
        }
    }
}