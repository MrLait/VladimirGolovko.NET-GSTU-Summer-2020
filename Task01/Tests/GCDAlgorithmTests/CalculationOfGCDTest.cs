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
            actualEuclidGcd = CalculationOfGCD.GetEuclidGcd(numOne, numTwo, out double totalMs);
            //Assert
            Assert.AreEqual(expectedResult, actualEuclidGcd);
        }

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

    }
}
