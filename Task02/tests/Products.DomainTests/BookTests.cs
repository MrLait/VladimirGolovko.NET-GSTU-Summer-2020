using NUnit.Framework;
using System;

namespace Products.Domain.Tests
{
    /// <summary>
    /// Test cases to testing class Book.
    /// </summary>
    [TestFixture()]
    public class BookTests
    {
        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="bookTwoName">Name of book two.</param>
        /// <param name="priceTwo">Price two</param>
        /// <param name="expectedName">Expected name of book.</param>
        /// <param name="expectedPrice">Expected prices of book/</param>
        [TestCase("bookOne", 10.1, "bookTwo", 10.1, "bookOne-bookTwo", 10.1)]
        [TestCase("bookOne", 10.12, "bookTwo", 10.20, "bookOne-bookTwo", 10.16)]
        [TestCase("bookOne", 110.99, "bookTwo", 110.1, "bookOne-bookTwo", 110.545)]
        public void GivenOperatorSum_WhenNumbersIsPositive_ThenOutIsPositive(
            string bookOneName, decimal priceOne, string bookTwoName, decimal priceTwo,
            string expectedName, decimal expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            Book bookTwo = new Book(bookTwoName, priceTwo);
            Book expected = new Book(expectedName, expectedPrice);
            //Act
            var actualSum = bookOne + bookTwo;
            //Assert
            Assert.AreEqual(expected, actualSum);
        }
        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="bookTwoName">Name of book two.</param>
        /// <param name="priceTwo">Price two</param>
        /// <param name="expectedName">Expected name of book.</param>
        /// <param name="expectedPrice">Expected prices of book/</param>
        [TestCase("bookOne", -10.1, "bookTwo", -10.1, "bookOne-bookTwo", -10.1)]
        [TestCase("bookOne", -10.12, "bookTwo", -10.20, "bookOne-bookTwo", -10.16)]
        [TestCase("bookOne", -110.99, "bookTwo", -110.1, "bookOne-bookTwo", -110.545)]
        public void GivenOperatorSum_WhenNumbersIsNegative_ThenOutIsNegative(
            string bookOneName, decimal priceOne, string bookTwoName, decimal priceTwo,
            string expectedName, decimal expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            Book bookTwo = new Book(bookTwoName, priceTwo);
            Book expected = new Book(expectedName, expectedPrice);
            //Act
            var actualSum = bookOne + bookTwo;
            //Assert
            Assert.AreEqual(expected, actualSum);
        }

        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        [TestCase("bookOne", 10.1)]
        [TestCase("bookOne", 10.12)]
        [TestCase("bookOne", 110.99)]
        public void GivenOperatorSum_WhenFirstBookReferenceNull_ThenOutIsNullReferenceException(
            string bookOneName, decimal priceOne)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            //Assert
            Assert.That(() => bookOne + null, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test cases for operator +.
        /// </summary>
        /// <param name="bookTwoName">Name of book two.</param>
        /// <param name="priceTwo">Price one.</param>
        [TestCase("bookTwo", 10.1)]
        [TestCase("bookTwo", 10.12)]
        [TestCase("bookTwo", 110.99)]
        public void GivenOperatorSum_WhenSecondBookReferenceNull_ThenOutIsNullReferenceException(
            string bookTwoName, decimal priceTwo)
        {
            //Arrange
            Book bookTwo = new Book(bookTwoName, priceTwo);
            //Assert
            Assert.That(() => null + bookTwo, Throws.TypeOf<NullReferenceException>());
        }

        /// <summary>
        /// Test cases for explicit operator Book to phone.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="phoneOneName">Name of phone one.</param>
        /// <param name="priceTwo">Price two</param>
        [TestCase("bookOne", -10.1, "phoneOne", -10.1)]
        [TestCase("bookOne", -10.12, "phoneOne", -10.20)]
        [TestCase("bookOne", -110.99, "phoneOne", -110.1)]
        public void GivenOperatorPhoneToBook_ThenOutIsBook(
            string bookOneName, decimal priceOne, string phoneOneName, decimal priceTwo)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            Phone phoneOne = new Phone(phoneOneName, priceTwo);
            Book expected = new Book(phoneOneName, priceTwo);
            //Act
            bookOne = (Book)phoneOne;
            //Assert
            Assert.AreEqual(expected, bookOne);
        }

        /// <summary>
        /// Test cases for explicit operator Book to ComputerMonitor.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="computerMonitorName">Name of phone one.</param>
        /// <param name="priceTwo">Price two</param>
        [TestCase("bookOne", -10.1, "computerMonitorOne", -10.1)]
        [TestCase("bookOne", -10.12, "computerMonitorOne", -10.20)]
        [TestCase("bookOne", -110.99, "computerMonitorOne", -110.1)]
        public void GivenOperatorComputerMonitorToBook_ThenOutIsBook(
            string bookOneName, decimal priceOne, string computerMonitorName, decimal priceTwo)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            ComputerMonitor computerMonitor = new ComputerMonitor(computerMonitorName, priceTwo);
            Book expected = new Book(computerMonitorName, priceTwo);
            //Act
            bookOne = (Book)computerMonitor;
            //Assert
            Assert.AreEqual(expected, bookOne);
        }

        /// <summary>
        /// Test cases for explicit operator int.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("bookOne", 10.1, 10)]
        [TestCase("bookOne", 10.12, 12)]
        [TestCase("bookOne", 110.99, 99)]
        public void GivenOperatorInt_WhenNumbersIsPositive_ThenOutIsPositivePennyInt(
            string bookOneName, decimal priceOne, int expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (int)bookOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator int.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("bookOne", -10.1, -10)]
        [TestCase("bookOne", -10.12, -12)]
        [TestCase("bookOne", -110.99, -99)]
        public void GivenOperatorInt_WhenNumbersIsNegative_ThenOutIsNegativePennyInt(
            string bookOneName, decimal priceOne, int expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (int)bookOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator float.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("bookOne", 10.1, 10.1000004f)]
        [TestCase("bookOne", 10.12, 10.1199999f)]
        [TestCase("bookOne", 110.99, 110.989998f)]
        public void GivenOperatorFloat_WhenNumbersIsPositive_ThenOutIsPositiveFloat(
            string bookOneName, decimal priceOne, float expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            var expected = expectedPrice;
            //Act
            float actual = (float)bookOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator float.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("bookOne", -10.1, -10.1000004f)]
        [TestCase("bookOne", -10.12, -10.1199999f)]
        [TestCase("bookOne", -110.99, -110.989998f)]
        public void GivenOperatorFloat_WhenNumbersIsNegative_ThenOutIsNegativeFloat(
            string bookOneName, decimal priceOne, float expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (float)bookOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator double.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("bookOne", 10.1, 10.1)]
        [TestCase("bookOne", 10.12, 10.119999999999999)]
        [TestCase("bookOne", 110.99, 110.99)]
        public void GivenOperatorDouble_WhenNumbersIsPositive_ThenOutIsPositiveDouble(
            string bookOneName, decimal priceOne, double expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (double)bookOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test cases for explicit operator double.
        /// </summary>
        /// <param name="bookOneName">Name of book one.</param>
        /// <param name="priceOne">Price one.</param>
        /// <param name="expectedPrice">Expected price.</param>
        [TestCase("bookOne", -10.1, -10.1)]
        [TestCase("bookOne", -10.12, -10.119999999999999)]
        [TestCase("bookOne", -110.99, -110.99)]
        public void GivenOperatorDouble_WhenNumbersIsNegative_ThenOutIsNegativeDouble(
            string bookOneName, decimal priceOne, double expectedPrice)
        {
            //Arrange
            Book bookOne = new Book(bookOneName, priceOne);
            var expected = expectedPrice;
            //Act
            var actual = (double)bookOne;
            //Assert
            Assert.AreEqual(expected, actual);
        }

    }
}