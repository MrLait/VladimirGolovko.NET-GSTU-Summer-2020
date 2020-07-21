using NUnit.Framework;
using Products.Domain;
using System;

namespace Products.DomainTests
{
    /// <summary>
    /// Test cases to testing class phone.
    /// </summary>
    [TestFixture()]
    class PhoneTests
    {
        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="phoneTwoName">Name of phone two.</param>
        /// <param name="priceTwo">Price two</param>
        /// <param name="expectedName">Expected name of phone.</param>
        /// <param name="expectedPrice">Expected prices of phone/</param>
        [TestCase("phoneOne", 10.1, "phoneTwo", 10.1, "phoneOne-phoneTwo", 10.1)]
        [TestCase("phoneOne", 10.12, "phoneTwo", 10.20, "phoneOne-phoneTwo", 10.16)]
        [TestCase("phoneOne", 110.99, "phoneTwo", 110.1, "phoneOne-phoneTwo", 110.545)]
        public void GivenOperatorSum_WhenNumbersIsPositive_ThenOutIsPositive(
            string phoneOneName, decimal priceOne, string phoneTwoName, decimal priceTwo,
            string expectedName, decimal expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            Phone phoneTwo = new Phone(phoneTwoName, priceTwo);
            Phone expected = new Phone(expectedName, expectedPrice);
            //Act
            var actualSum = phoneOne + phoneTwo;
            //Assert
            Assert.AreEqual(expected, actualSum);
        }
        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="phoneTwoName">Name of phone two.</param>
        /// <param name="priceTwo">Price two</param>
        /// <param name="expectedName">Expected name of phone.</param>
        /// <param name="expectedPrice">Expected prices of phone/</param>
        [TestCase("phoneOne", -10.1, "phoneTwo", -10.1, "phoneOne-phoneTwo", -10.1)]
        [TestCase("phoneOne", -10.12, "phoneTwo", -10.20, "phoneOne-phoneTwo", -10.16)]
        [TestCase("phoneOne", -110.99, "phoneTwo", -110.1, "phoneOne-phoneTwo", -110.545)]
        public void GivenOperatorSum_WhenNumbersIsNegative_ThenOutIsNegative(
            string phoneOneName, decimal priceOne, string phoneTwoName, decimal priceTwo,
            string expectedName, decimal expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            Phone phoneTwo = new Phone(phoneTwoName, priceTwo);
            Phone expected = new Phone(expectedName, expectedPrice);
            //Act
            var actualSum = phoneOne + phoneTwo;
            //Assert
            Assert.AreEqual(expected, actualSum);
        }

        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        [TestCase("phoneOne", 10.1)]
        [TestCase("phoneOne", 10.12)]
        [TestCase("phoneOne", 110.99)]
        public void GivenOperatorSum_WhenFirstPhoneReferenceNull_ThenOutIsNullReferenceException(
            string phoneOneName, decimal priceOne)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            //Assert
            Assert.That(() => phoneOne + null, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="phoneTwoName">Name of phone two.</param>
        /// <param name="priceTwo">Price one.</param>
        [TestCase("phoneTwo", 10.1)]
        [TestCase("phoneTwo", 10.12)]
        [TestCase("phoneTwo", 110.99)]
        public void GivenOperatorSum_WhenSecondPhoneReferenceNull_ThenOutIsNullReferenceException(
            string phoneTwoName, decimal priceTwo)
        {
            //Arrange
            Phone phoneTwo = new Phone(phoneTwoName, priceTwo);
            //Assert
            Assert.That(() => null + phoneTwo, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test cases for explicit operator Book to Phone.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="bookOneName">Name of phone one.</param>
        /// <param name="priceTwo">Price two</param>
        [TestCase("phoneOne", -10.1, "phoneOne", -10.1)]
        [TestCase("phoneOne", -10.12, "phoneOne", -10.20)]
        [TestCase("phoneOne", -110.99, "phoneOne", -110.1)]
        public void GivenOperatorBookToPhone_ThenOutIsPhone(
            string phoneOneName, decimal priceOne, string bookOneName, decimal priceTwo)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            Book bookOne = new Book(bookOneName, priceTwo);
            Phone expected = new Phone(bookOneName, priceTwo);
            //Act
            phoneOne = (Phone)bookOne;
            //Assert
            Assert.AreEqual(expected, phoneOne);
        }

        /// <summary>
        /// Test cases for explicit operator ComputerMonitor to Phone.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="computerMonitorName">Name of phone one.</param>
        /// <param name="priceTwo">Price two</param>
        [TestCase("phoneOne", -10.1, "computerMonitorOne", -10.1)]
        [TestCase("phoneOne", -10.12, "computerMonitorOne", -10.20)]
        [TestCase("phoneOne", -110.99, "computerMonitorOne", -110.1)]
        public void GivenOperatorComputerMonitorToPhone_ThenOutIsPhone(
            string phoneOneName, decimal priceOne, string computerMonitorName, decimal priceTwo)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            ComputerMonitor computerMonitor = new ComputerMonitor(computerMonitorName, priceTwo);
            Phone expected = new Phone(computerMonitorName, priceTwo);
            //Act
            phoneOne = (Phone)computerMonitor;
            //Assert
            Assert.AreEqual(expected, phoneOne);
        }

        /// <summary>
        /// Test cases for explicit operator int.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("phoneOne", 10.1, 10)]
        [TestCase("phoneOne", 10.12, 12)]
        [TestCase("phoneOne", 110.99, 99)]
        public void GivenOperatorInt_WhenNumbersIsPositive_ThenOutIsPositivePennyInt(
            string phoneOneName, decimal priceOne, int expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (int)phoneOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator int.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("phoneOne", -10.1, -10)]
        [TestCase("phoneOne", -10.12, -12)]
        [TestCase("phoneOne", -110.99, -99)]
        public void GivenOperatorInt_WhenNumbersIsNegative_ThenOutIsNegativePennyInt(
            string phoneOneName, decimal priceOne, int expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (int)phoneOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator float.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("phoneOne", 10.1, 10.1000004f)]
        [TestCase("phoneOne", 10.12, 10.1199999f)]
        [TestCase("phoneOne", 110.99, 110.989998f)]
        public void GivenOperatorFloat_WhenNumbersIsPositive_ThenOutIsPositiveFloat(
            string phoneOneName, decimal priceOne, float expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            var expected = expectedPrice;
            //Act
            float actual = (float)phoneOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator float.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("phoneOne", -10.1, -10.1000004f)]
        [TestCase("phoneOne", -10.12, -10.1199999f)]
        [TestCase("phoneOne", -110.99, -110.989998f)]
        public void GivenOperatorFloat_WhenNumbersIsNegative_ThenOutIsNegativeFloat(
            string phoneOneName, decimal priceOne, float expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (float)phoneOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator double.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("phoneOne", 10.1, 10.1)]
        [TestCase("phoneOne", 10.12, 10.119999999999999)]
        [TestCase("phoneOne", 110.99, 110.99)]
        public void GivenOperatorDouble_WhenNumbersIsPositive_ThenOutIsPositiveDouble(
            string phoneOneName, decimal priceOne, double expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (double)phoneOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator double.
        /// </summary>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("phoneOne", -10.1, -10.1)]
        [TestCase("phoneOne", -10.12, -10.119999999999999)]
        [TestCase("phoneOne", -110.99, -110.99)]
        public void GivenOperatorDouble_WhenNumbersIsNegative_ThenOutIsNegativeDouble(
            string phoneOneName, decimal priceOne, double expectedPrice)
        {
            //Arrange
            Phone phoneOne = new Phone(phoneOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (double)phoneOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
