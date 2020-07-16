using GCDAlgorithm;
using NUnit.Framework;

namespace GCDAlgorithmTests
{
    /// <summary>
    /// Class for testing CalculationOfGCDTest methods.
    /// </summary>
    [TestFixture()]
    public class CalculationOfGCDTest
    {
        /// <summary>
        /// Testing the GetEuclidGcd method with two parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(1, 2, 1)]
        [TestCase(10, 0, 10)]
        [TestCase(100000, 27, 1)]
        [TestCase(100000, 28, 4)]
        [TestCase(16, 100000, 16)]
        public void GetEuclidGcd_ForTwoNubmers_PositiveNumbers(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with two parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, -2, 1)]
        [TestCase(-10, 0, 10)]
        [TestCase(-100000, -27, 1)]
        [TestCase(-100000, -28, 4)]
        [TestCase(-16, -100000, 16)]
        public void GetEuclidGcd_ForTwoNubmers_NegativeNumbars(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with two parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, 2, 1)]
        [TestCase(-10, 0, 10)]
        [TestCase(100000, -27, 1)]
        [TestCase(-100000, 28, 4)]
        [TestCase(16, -100000, 16)]
        public void GetEuclidGcd_ForTwoNubmers_PositiveAndNegativeNumbers(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with three parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(1, 2, 1, 1)]
        [TestCase(10, 0, 10, 10)]
        [TestCase(100000, 27, 1, 1)]
        [TestCase(100000, 28, 4, 4)]
        [TestCase(16, 100000, 16, 16)]
        public void GetEuclidGcd_ForThreeNubmers_PositiveNumbers(int numOne, int numTwo, int numThree, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, numThree, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with three parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, -2, -1, 1)]
        [TestCase(-10, 0, -10, 10)]
        [TestCase(-100000, -27, -1, 1)]
        [TestCase(-100000, -28, -4, 4)]
        [TestCase(-16, -100000, -16, 16)]
        public void GetEuclidGcd_ForThreeNubmer_NegativeNumbers(int numOne, int numTwo, int numThree, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, numThree, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with three parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, 2, 1, 1)]
        [TestCase(-10, 0, 10, 10)]
        [TestCase(100000, -27, 1, 1)]
        [TestCase(-100000, 28, 4, 4)]
        [TestCase(16, -100000, 16, 16)]
        public void GetEuclidGcd_ForThreeNubmer_PositiveAndNegativeNumbers(int numOne, int numTwo, int numThree, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, numThree, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(1, 2, 1, 1, 1)]
        [TestCase(10, 0, 10, 10, 10)]
        [TestCase(100000, 27, 1, 1, 1)]
        [TestCase(100000, 28, 4, 4, 4)]
        [TestCase(16, 100000, 16, 16, 16)]
        public void GetEuclidGcd_ForFourNubmers_PositiveNumbers(int numOne, int numTwo, int numThree, int numFour, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, numThree, numFour, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, -2, -1, -1, 1)]
        [TestCase(-10, 0, -10, -10, 10)]
        [TestCase(-100000, -27, -1, -1, 1)]
        [TestCase(-100000, -28, -4, -4, 4)]
        [TestCase(-16, -100000, -16, -16, 16)]
        public void GetEuclidGcd_ForFourNubmers_NegativeNumbers(int numOne, int numTwo, int numThree, int numFour, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, numThree, numFour, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetEuclidGcd method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, 2, 1, 1, 1)]
        [TestCase(-10, 0, 10, 10, 10)]
        [TestCase(100000, -27, 1, 1, 1)]
        [TestCase(-100000, 28, 4, 4, 4)]
        [TestCase(16, -100000, 16, 16, 16)]
        public void GetEuclidGcd_ForFourNubmers_PositiveAndNegativeNumbers(int numOne, int numTwo, int numThree, int numFour, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, numThree, numFour, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with two parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(1, 2, 1)]
        [TestCase(10, 0, 10)]
        [TestCase(100000, 27, 1)]
        [TestCase(100000, 28, 4)]
        [TestCase(16, 100000, 16)]
        public void GetBinaryGcd_ForTwoNubmers_PositiveNumbers(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with two parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, -2, 1)]
        [TestCase(-10, 0, 10)]
        [TestCase(-100000, -27, 1)]
        [TestCase(-100000, -28, 4)]
        [TestCase(-16, -100000, 16)]
        public void GetBinaryGcd_ForTwoNubmers_NegativeNumbars(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with two parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, 2, 1)]
        [TestCase(-10, 0, 10)]
        [TestCase(100000, -27, 1)]
        [TestCase(-100000, 28, 4)]
        [TestCase(16, -100000, 16)]
        public void GetBinaryGcd_ForTwoNubmers_PositiveAndNegativeNumbers(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with three parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(1, 2, 1, 1)]
        [TestCase(10, 0, 10, 10)]
        [TestCase(100000, 27, 1, 1)]
        [TestCase(100000, 28, 4, 4)]
        [TestCase(16, 100000, 16, 16)]
        public void GetBinaryGcd_ForThreeNubmers_PositiveNumbers(int numOne, int numTwo, int numThree, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, numThree, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with three parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, -2, -1, 1)]
        [TestCase(-10, 0, -10, 10)]
        [TestCase(-100000, -27, -1, 1)]
        [TestCase(-100000, -28, -4, 4)]
        [TestCase(-16, -100000, -16, 16)]
        public void GetBinaryGcd_ForThreeNubmer_NegativeNumbers(int numOne, int numTwo, int numThree, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, numThree, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with three parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, 2, 1, 1)]
        [TestCase(-10, 0, 10, 10)]
        [TestCase(100000, -27, 1, 1)]
        [TestCase(-100000, 28, 4, 4)]
        [TestCase(16, -100000, 16, 16)]
        public void GetBinaryGcd_ForThreeNubmer_PositiveAndNegativeNumbers(int numOne, int numTwo, int numThree, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, numThree, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(1, 2, 1, 1, 1)]
        [TestCase(10, 0, 10, 10, 10)]
        [TestCase(100000, 27, 1, 1, 1)]
        [TestCase(100000, 28, 4, 4, 4)]
        [TestCase(16, 100000, 16, 16, 16)]
        public void GetBinaryGcd_ForFourNubmers_PositiveNumbers(int numOne, int numTwo, int numThree, int numFour, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, numThree, numFour, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, -2, -1, -1, 1)]
        [TestCase(-10, 0, -10, -10, 10)]
        [TestCase(-100000, -27, -1, -1, 1)]
        [TestCase(-100000, -28, -4, -4, 4)]
        [TestCase(-16, -100000, -16, -16, 16)]
        public void GetBinaryGcd_ForFourNubmers_NegativeNumbers(int numOne, int numTwo, int numThree, int numFour, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, numThree, numFour, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the GetBinaryGcd method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is positive number.</param>
        [TestCase(-1, 2, 1, 1, 1)]
        [TestCase(-10, 0, 10, 10, 10)]
        [TestCase(100000, -27, 1, 1, 1)]
        [TestCase(-100000, 28, 4, 4, 4)]
        [TestCase(16, -100000, 16, 16, 16)]
        public void GetBinaryGcd_ForFourNubmers_PositiveAndNegativeNumbers(int numOne, int numTwo, int numThree, int numFour, int expectedResult)
        {
            //Arrange
            int actualBinaryGcd;
            //Act
            actualBinaryGcd = CalculationOfGCD.GetBinaryGcd(numOne, numTwo, numThree, numFour, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualBinaryGcd);
        }

        /// <summary>
        /// Testing the PrepareDataForHistogram method with four parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="expectedResult">Expected result is true.</param>
        [TestCase(-1, -2, -1, -1, true)]
        [TestCase(-10, 0, -10, -10, true)]
        [TestCase(-100000, -27, -1, -1, true)]
        [TestCase(-100000, -28, -4, -4, true)]
        [TestCase(-16, -100000, -16, -16, true)]
        [TestCase(-1, 2, 1, 1, true)]
        [TestCase(-10, 0, 10, 10, true)]
        [TestCase(100000, -27, 1, 1, true)]
        [TestCase(-100000, 28, 4, 4, true)]
        [TestCase(16, -100000, 16, 16, true)]
        public void PrepareDataForHistogram_ForFourNubmers_PositiveAndNegativeNumbers_OutIsTrue(int numOne, int numTwo, int numThree, int numFour, bool expectedResult)
        {        
            //Arrange
            bool actualIsPrepeared;
            //Act
            actualIsPrepeared = CalculationOfGCD.PrepareDataForHistogram(numOne, numTwo, numThree, numFour);
            //Assert
            Assert.AreEqual(expectedResult, actualIsPrepeared);
        }

        /// <summary>
        /// Testing the PrepareDataForHistogram method with five parameters.
        /// </summary>
        /// <param name="numOne">The first parameter.</param>
        /// <param name="numTwo">The second parameter.</param>
        /// <param name="numThree">The third parameter.</param>
        /// <param name="numFour">The fourth parameter.</param>
        /// <param name="numFive">The fifth parameter.</param>
        /// <param name="expectedResult">Expected result is false.</param>
        [TestCase(16, -100000, 16, 16, 10, false)]
        public void PrepareDataForHistogram_ForFiveNubmers_OutIsFalse(int numOne, int numTwo, int numThree, int numFour, int numFive, bool expectedResult)
        {
            //Arrange
            bool actualIsPrepeared;
            //Act
            actualIsPrepeared = CalculationOfGCD.PrepareDataForHistogram(numOne, numTwo, numThree, numFour, numFive);
            //Assert
            Assert.AreEqual(expectedResult, actualIsPrepeared);
        }

        /// <summary>
        /// Testing the PrepareDataForHistogram method.
        /// </summary>
        /// <param name="expectedResult">Expected result is false.</param>
        [TestCase(false)]
        public void PrepareDataForHistogram_ForZeroNumbers_OutIsFalse(bool expectedResult)
        {
            //Arrange
            bool actualIsPrepeared;
            //Act
            actualIsPrepeared = CalculationOfGCD.PrepareDataForHistogram();
            //Assert
            Assert.AreEqual(expectedResult, actualIsPrepeared);
        }
    }
}
