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
            Book bookOne = new Book("cool", 10.1m);
            Book bookTwo = new Book("cool2", 1000.0001m);
            ComputerMonitor computerMonitorOne = new ComputerMonitor("Asus", 100);
            Phone samsungPhoneOne = new Phone("Samsung", 100);

            BaseProduct sumProducts = (Book)bookOne + (Book)bookTwo;

            int penny = (int)bookOne.Price;

            samsungPhoneOne = (Phone)bookOne;
            samsungPhoneOne = (Phone)computerMonitorOne;

            bookOne = (Book)samsungPhoneOne;
            bookOne = (Book)computerMonitorOne;

            computerMonitorOne = (ComputerMonitor)bookOne;
            computerMonitorOne = (ComputerMonitor)samsungPhoneOne;

        }
    }
}