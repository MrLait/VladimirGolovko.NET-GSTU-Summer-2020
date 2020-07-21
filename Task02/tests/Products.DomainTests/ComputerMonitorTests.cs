using NUnit.Framework;
using Products.Domain;
using System;

namespace Products.DomainTests
{
    /// <summary>
    /// Test cases to testing class ComputerMonitor.
    /// </summary>
    [TestFixture()]
    class ComputerMonitorTests
    {
        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="computerMonitorTwoName">Name of computer monitor two.</param>
        /// <param name="priceTwo">Price two</param>
        /// <param name="expectedName">Expected name of computerMonitor.</param>
        /// <param name="expectedPrice">Expected prices of computerMonitor/</param>
        [TestCase("computerMonitorOne", 10.1, "computerMonitorTwo", 10.1, "computerMonitorOne-computerMonitorTwo", 10.1)]
        [TestCase("computerMonitorOne", 10.12, "computerMonitorTwo", 10.20, "computerMonitorOne-computerMonitorTwo", 10.16)]
        [TestCase("computerMonitorOne", 110.99, "computerMonitorTwo", 110.1, "computerMonitorOne-computerMonitorTwo", 110.545)]
        public void GivenOperatorSum_WhenNumbersIsPositive_ThenOutIsPositive(
            string computerMonitorOneName, decimal priceOne, string computerMonitorTwoName, decimal priceTwo,
            string expectedName, decimal expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            ComputerMonitor computerMonitorTwo = new ComputerMonitor(computerMonitorTwoName, priceTwo);
            ComputerMonitor expected = new ComputerMonitor(expectedName, expectedPrice);
            //Act
            var actualSum = computerMonitorOne + computerMonitorTwo;
            //Assert
            Assert.AreEqual(expected, actualSum);
        }
        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="computerMonitorTwoName">Name of computer monitor two.</param>
        /// <param name="priceTwo">Price two</param>
        /// <param name="expectedName">Expected name of computerMonitor.</param>
        /// <param name="expectedPrice">Expected prices of computerMonitor/</param>
        [TestCase("computerMonitorOne", -10.1, "computerMonitorTwo", -10.1, "computerMonitorOne-computerMonitorTwo", -10.1)]
        [TestCase("computerMonitorOne", -10.12, "computerMonitorTwo", -10.20, "computerMonitorOne-computerMonitorTwo", -10.16)]
        [TestCase("computerMonitorOne", -110.99, "computerMonitorTwo", -110.1, "computerMonitorOne-computerMonitorTwo", -110.545)]
        public void GivenOperatorSum_WhenNumbersIsNegative_ThenOutIsNegative(
            string computerMonitorOneName, decimal priceOne, string computerMonitorTwoName, decimal priceTwo,
            string expectedName, decimal expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            ComputerMonitor computerMonitorTwo = new ComputerMonitor(computerMonitorTwoName, priceTwo);
            ComputerMonitor expected = new ComputerMonitor(expectedName, expectedPrice);
            //Act
            var actualSum = computerMonitorOne + computerMonitorTwo;
            //Assert
            Assert.AreEqual(expected, actualSum);
        }

        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        [TestCase("computerMonitorOne", 10.1)]
        [TestCase("computerMonitorOne", 10.12)]
        [TestCase("computerMonitorOne", 110.99)]
        public void GivenOperatorSum_WhenFirstComputerMonitorReferenceNull_ThenOutIsNullReferenceException(
            string computerMonitorOneName, decimal priceOne)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            //Assert
            Assert.That(() => computerMonitorOne + null, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="computerMonitorTwoName">Name of computer monitor two.</param>
        /// <param name="priceTwo">Price one.</param>
        [TestCase("computerMonitorTwo", 10.1)]
        [TestCase("computerMonitorTwo", 10.12)]
        [TestCase("computerMonitorTwo", 110.99)]
        public void GivenOperatorSum_WhenSecondComputerMonitorReferenceNull_ThenOutIsNullReferenceException(
            string computerMonitorTwoName, decimal priceTwo)
        {
            //Arrange
            ComputerMonitor computerMonitorTwo = new ComputerMonitor(computerMonitorTwoName, priceTwo);
            //Assert
            Assert.That(() => null + computerMonitorTwo, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test cases for explicit operator Book to computerMonitor.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="bookOneName">Name of computer monitor one.</param>
        /// <param name="priceTwo">Price two</param>
        [TestCase("computerMonitorOne", -10.1, "computerMonitorOne", -10.1)]
        [TestCase("computerMonitorOne", -10.12, "computerMonitorOne", -10.20)]
        [TestCase("computerMonitorOne", -110.99, "computerMonitorOne", -110.1)]
        public void GivenOperatorBookToComputerMonitor_ThenOutIsComputerMonitor(
            string computerMonitorOneName, decimal priceOne, string bookOneName, decimal priceTwo)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            Book bookOne = new Book(bookOneName, priceTwo);
            ComputerMonitor expected = new ComputerMonitor(bookOneName, priceTwo);
            //Act
            computerMonitorOne = (ComputerMonitor)bookOne;
            //Assert
            Assert.AreEqual(expected, computerMonitorOne);
        }

        /// <summary>
        /// Test cases for explicit operator Phone to ComputerMonitor.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="computerMonitorName">Name of computer monitor one.</param>
        /// <param name="priceTwo">Price two</param>
        [TestCase("computerMonitorOne", -10.1, "computerMonitorOne", -10.1)]
        [TestCase("computerMonitorOne", -10.12, "computerMonitorOne", -10.20)]
        [TestCase("computerMonitorOne", -110.99, "computerMonitorOne", -110.1)]
        public void GivenOperatorComputerMonitorToComputerMonitor_ThenOutIsComputerMonitor(
            string computerMonitorOneName, decimal priceOne, string computerMonitorName, decimal priceTwo)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            Phone computerMonitor = new Phone(computerMonitorName, priceTwo);
            ComputerMonitor expected = new ComputerMonitor(computerMonitorName, priceTwo);
            //Act
            computerMonitorOne = (ComputerMonitor)computerMonitor;
            //Assert
            Assert.AreEqual(expected, computerMonitorOne);
        }

        /// <summary>
        /// Test cases for explicit operator int.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("computerMonitorOne", 10.1, 10)]
        [TestCase("computerMonitorOne", 10.12, 12)]
        [TestCase("computerMonitorOne", 110.99, 99)]
        public void GivenOperatorInt_WhenNumbersIsPositive_ThenOutIsPositivePennyInt(
            string computerMonitorOneName, decimal priceOne, int expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (int)computerMonitorOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator int.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("computerMonitorOne", -10.1, -10)]
        [TestCase("computerMonitorOne", -10.12, -12)]
        [TestCase("computerMonitorOne", -110.99, -99)]
        public void GivenOperatorInt_WhenNumbersIsNegative_ThenOutIsNegativePennyInt(
            string computerMonitorOneName, decimal priceOne, int expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (int)computerMonitorOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator float.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("computerMonitorOne", 10.1, 10.1000004f)]
        [TestCase("computerMonitorOne", 10.12, 10.1199999f)]
        [TestCase("computerMonitorOne", 110.99, 110.989998f)]
        public void GivenOperatorFloat_WhenNumbersIsPositive_ThenOutIsPositiveFloat(
            string computerMonitorOneName, decimal priceOne, float expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            var expected = expectedPrice;
            //Act
            float actual = (float)computerMonitorOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator float.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("computerMonitorOne", -10.1, -10.1000004f)]
        [TestCase("computerMonitorOne", -10.12, -10.1199999f)]
        [TestCase("computerMonitorOne", -110.99, -110.989998f)]
        public void GivenOperatorFloat_WhenNumbersIsNegative_ThenOutIsNegativeFloat(
            string computerMonitorOneName, decimal priceOne, float expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (float)computerMonitorOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator double.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("computerMonitorOne", 10.1, 10.1)]
        [TestCase("computerMonitorOne", 10.12, 10.119999999999999)]
        [TestCase("computerMonitorOne", 110.99, 110.99)]
        public void GivenOperatorDouble_WhenNumbersIsPositive_ThenOutIsPositiveDouble(
            string computerMonitorOneName, decimal priceOne, double expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (double)computerMonitorOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator double.
        /// </summary>
        /// <param name="computerMonitorOneName">Name of computer monitor one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("computerMonitorOne", -10.1, -10.1)]
        [TestCase("computerMonitorOne", -10.12, -10.119999999999999)]
        [TestCase("computerMonitorOne", -110.99, -110.99)]
        public void GivenOperatorDouble_WhenNumbersIsNegative_ThenOutIsNegativeDouble(
            string computerMonitorOneName, decimal priceOne, double expectedPrice)
        {
            //Arrange
            ComputerMonitor computerMonitorOne = new ComputerMonitor(computerMonitorOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (double)computerMonitorOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
