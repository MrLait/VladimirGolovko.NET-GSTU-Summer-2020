using GCDAlgorithm;
using NUnit.Framework;

namespace GCDAlgorithmTests
{
    [TestFixture()]
    public class CalculationOfGCDTest
    {
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
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        [TestCase(-1, -2, 1)]
        [TestCase(-10, 0, 10)]
        [TestCase(-100000, -27, 1)]
        [TestCase(-100000, -28, 4)]
        [TestCase(-16, -100000, 16)]
        public void GetEuclidGcd_ForTwoNubmers_PositiveNegative(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

        [TestCase(-1, 2, 1)]
        [TestCase(-10, 0, 10)]
        [TestCase(100000, -27, 1)]
        [TestCase(-100000, 28, 4)]
        [TestCase(16, -100000, 16)]
        public void GetEuclidGcd_ForTwoNubmers_PositiveAndNegative(int numOne, int numTwo, int expectedResult)
        {
            //Arrange
            int actualEuclidGcd;
            //Act
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }
    }
}
