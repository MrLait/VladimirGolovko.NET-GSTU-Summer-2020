using NUnit.Framework;
using System;
using Vectors.Domain;

namespace Vectors.DomainTests
{
    /// <summary>
    /// Test cases to testing class Vector.
    /// </summary>
    [TestFixture]
    class VectorTests
    {
        /// <summary>
        /// Test for correct calculation operator -subtracts one vector from another 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        /// <param name="vectorExpectedX">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedY">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedZ">X coordinate of the expected vector.</param>
        [TestCase(10, 20, 21, 9, 10, 20, 1, 10, 1)]
        public void GivenOperatorSubtracts_WhenNumbersIsPositive_ThenOutIsPositive(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ,
            int vectorExpectedX, int vectorExpectedY, int vectorExpectedZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);
            Vector expectedVector = new Vector(vectorExpectedX, vectorExpectedY, vectorExpectedZ);

            // Act
            Vector actual = vectorOne - vectorTwo;

            // Assert
            Assert.AreEqual(expectedVector, actual);
        }

        /// <summary>
        /// Test for correct calculation operator -subtracts one vector from another 
        /// when numbers is negative.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        /// <param name="vectorExpectedX">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedY">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedZ">X coordinate of the expected vector.</param>
        [TestCase(-10, -20, -21, -9, -10, -20, -1, -10, -1)]
        public void GivenOperatorSubtracts_WhenNumbersIsNegativeOutIsNegative(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ,
            int vectorExpectedX, int vectorExpectedY, int vectorExpectedZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);
            Vector expectedVector = new Vector(vectorExpectedX, vectorExpectedY, vectorExpectedZ);

            // Act
            Vector actual = vectorOne - vectorTwo;

            // Assert
            Assert.AreEqual(expectedVector, actual);
        }

        /// <summary>
        /// Test for correct calculation operator -subtracts one vector from another 
        /// when numbers is negative.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        /// <param name="vectorExpectedX">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedY">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedZ">X coordinate of the expected vector.</param>
        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, 0)]
        public void GivenOperatorSubtracts_WhenNumbersIsZeroOutIsZero(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ,
            int vectorExpectedX, int vectorExpectedY, int vectorExpectedZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);
            Vector expectedVector = new Vector(vectorExpectedX, vectorExpectedY, vectorExpectedZ);

            // Act
            Vector actual = vectorOne - vectorTwo;

            // Assert
            Assert.AreEqual(expectedVector, actual);
        }
        /// <summary>
        /// Test for operator != when vectors is different.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        [TestCase(10, 20, 21, 9, 10, 20)]
        [TestCase(0, 0, 0, 9, 10, 20)]
        [TestCase(-10, -20, -21, 9, 10, 20)]
        public void GivenOperatorNotEqual_WhenVectorIsDifferentOutIsTrue(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);

            // Act
            bool actualBool = vectorOne != vectorTwo;

            // Assert
            Assert.IsTrue(actualBool);
        }

        /// <summary>
        /// Test for operator != when vectors is the same.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        [TestCase(10, 20, 21, 10, 20, 21)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(-10, -20, -21, -10, -20, -21)]
        public void GivenOperatorNotEqual_WhenVectorIsSameOutIsFalse(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);

            // Act
            bool actualBool = vectorOne != vectorTwo;

            // Assert
            Assert.IsFalse(actualBool);
        }

        /// <summary>
        /// Test for operator == when vectors is different.
        /// </summary>
        [TestCase(10, 20, 21, 9, 10, 20)]
        [TestCase(0, 0, 0, 9, 10, 20)]
        [TestCase(-10, -20, -21, 9, 10, 20)]
        public void GivenOperatorEqual_ForVectorWhenVectorIsDifferentOutIsFalse(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);

            // Act
            bool actualBool = vectorOne == vectorTwo;

            // Assert
            Assert.IsFalse(actualBool);
        }

        /// <summary>
        /// Test for operator == when vectors is the same.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        [TestCase(10, 20, 21, 10, 20, 21)]
        [TestCase(0, 0, 0, 0, 0, 0)]
        [TestCase(-10, -20, -21, -10, -20, -21)]
        public void GivenOperatorEqual_ForVectorWhenVectorIsTheSameOutIsTrue(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);

            // Act
            bool actualBool = vectorOne == vectorTwo;

            // Assert
            Assert.IsTrue(actualBool);
        }

        /// <summary>
        /// Test for correct calculation operator +Adds one vector to another 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        /// <param name="vectorExpectedX">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedY">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedZ">X coordinate of the expected vector.</param>
        [TestCase(10, 20, 21, 9, 10, 20, 19, 30, 41)]
        public void GivenOperatorAdds_ForVectorWhenNumbersIsPositiveOutIsPositive(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ,
            int vectorExpectedX, int vectorExpectedY, int vectorExpectedZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);
            Vector expectedVector = new Vector(vectorExpectedX, vectorExpectedY, vectorExpectedZ);

            // Act
            Vector actual = vectorOne + vectorTwo;

            // Assert
            Assert.AreEqual(expectedVector, actual);
        }

        /// <summary>
        /// Test for correct calculation operator +Adds one vector to another 
        /// when numbers is negative.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="vectorTwoX">Y coordinate of the vector two.</param>
        /// <param name="vectorTwoY">Z coordinate of the vector two.</param>
        /// <param name="vectorTwoZ">Z coordinate of the vector two.</param>
        /// <param name="vectorExpectedX">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedY">X coordinate of the expected vector.</param>
        /// <param name="vectorExpectedZ">X coordinate of the expected vector.</param>
        [TestCase(-10, -20, -2, -9, -10, -20, -19, -30, -22)]
        public void GivenOperatorAdds_ForVectorWhenNumbersIsNegativeOutIsNegative(
            int vectorOneX, int vectorOneY, int vectorOneZ,
            int vectorTwoX, int vectorTwoY, int vectorTwoZ,
            int vectorExpectedX, int vectorExpectedY, int vectorExpectedZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector vectorTwo = new Vector(vectorTwoX, vectorTwoY, vectorTwoZ);
            Vector expectedVector = new Vector(vectorExpectedX, vectorExpectedY, vectorExpectedZ);

            // Act
            Vector actual = vectorOne + vectorTwo;

            // Assert
            Assert.AreEqual(expectedVector, actual);
        }


        /// <summary>
        /// Test for correct calculation operator +Adds one vector to another 
        /// when numbers is zero.
        /// </summary>
        /// <param name="zero">Zero number.</param>
        [TestCase(0)]
        public void GivenOperatorAdds_ForVectorWhenNumbersIsZeroOutIsZero(int zero)
        {
            // Arrange
            Vector vectorOne = new Vector(zero, zero, zero);
            Vector vectorTwo = new Vector(zero, zero, zero);
            Vector expectedVector = new Vector(zero, zero, zero);

            // Act
            Vector actual = vectorOne + vectorTwo;

            // Assert
            Assert.AreEqual(expectedVector, actual);
        }

        /// <summary>
        /// Test for correct calculation operator *Multiplies a vector by a number 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="multiplier">Multiplier.</param>
        [TestCase(10, 20, 2, 5)]
        [TestCase(10, 20, 2, -5)]
        [TestCase(-10, -20, -21, 5)]
        [TestCase(-10, -20, -21, -5)]
        public void GivenOperatorMultiplies_WhenVectorMultipleOnDigit(
            int vectorOneX, int vectorOneY, int vectorOneZ, int multiplier)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector expected = new Vector(vectorOneX * multiplier, vectorOneY * multiplier, vectorOneZ * multiplier);

            // Act
            var actualOne = vectorOne * multiplier;

            // Assert
            Assert.AreEqual(expected, actualOne);
        }

        /// <summary>
        /// Test for correct calculation operator *Multiplies a number  by a vector  
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="multiplier">Multiplier.</param>
        [TestCase(10, 20, 2, 5)]
        [TestCase(10, 20, 2, -5)]
        [TestCase(-10, -20, -21, 5)]
        [TestCase(-10, -20, -21, -5)]
        public void GivenOperatorMultiplies_WhenDigitMultipleOnVector(
            int vectorOneX, int vectorOneY, int vectorOneZ, int multiplier)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector expected = new Vector(vectorOneX * multiplier, vectorOneY * multiplier, vectorOneZ * multiplier);

            // Act
            var actualOne = multiplier * vectorOne;

            // Assert
            Assert.AreEqual(expected, actualOne);
        }


        /// <summary>
        /// Test for correct calculation operator / Divides a vector by a number.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="devider">Devider.</param>
        [TestCase(10, 20, 25, 5)]
        [TestCase(200, 40, 50, 5)]
        [TestCase(10, 20, 25, -5)]
        [TestCase(-10, -20, -200, 5)]
        [TestCase(-10, -20, -25, -5)]
        public void GivenOperatorDivides_WhenVectorDevideOnDigit(
            int vectorOneX, int vectorOneY, int vectorOneZ, int devider)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            Vector expectedOne = new Vector(vectorOneX / devider, vectorOneY / devider, vectorOneZ / devider);
            // Act
            var actualOne = vectorOne / devider;
            // Assert
            Assert.AreEqual(expectedOne, actualOne);
        }

        /// <summary>
        /// Test for correct calculation operator / Divides a vector by a number 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        /// <param name="devider">Devider.</param>
        [TestCase(10, 20, 25, 5)]
        [TestCase(200, 40, 50, 5)]
        [TestCase(10, 20, 25, -5)]
        [TestCase(-10, -20, -2, 5)]
        [TestCase(-10, -20, -25, -5)]
        public void GivenOperatorDivides_WhenDigitDevideOnVector(
            int vectorOneX, int vectorOneY, int vectorOneZ, int devider)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            double expectedX = (double)devider / (double)vectorOneX;
            double expectedY = (double)devider / (double)vectorOneY;
            double expectedZ = (double)devider / (double)vectorOneZ;
            Vector expectedOne = new Vector(expectedX, expectedY, expectedZ);
            // Act
            var actualOne = devider / vectorOne;
            // Assert
            Assert.AreEqual(expectedOne, actualOne);
        }

        /// <summary>
        /// Test for correct get property X, Y and Z from vector 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        [TestCase(10, 20, 25)]
        [TestCase(2, 4, 5)]
        [TestCase(10, 20, 25)]
        [TestCase(-10, -20, -2)]
        [TestCase(-10, -20, -25)]
        public void GivenX_Y_Z_ForGetDataWhen(
            int vectorOneX, int vectorOneY, int vectorOneZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);

            // Assert
            Assert.AreEqual(vectorOneX, vectorOne.X);
            Assert.AreEqual(vectorOneY, vectorOne.Y);
            Assert.AreEqual(vectorOneZ, vectorOne.Z);
        }

        /// <summary>
        /// Test for correct get property Magnitude from vector 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        [TestCase(10, 20, 25)]
        [TestCase(2, 4, 5)]
        [TestCase(10, 20, 25)]
        [TestCase(-10, -20, -2)]
        [TestCase(-10, -20, -25)]
        public void GivenMagnitude_WhenDifferentDigits(
            int vectorOneX, int vectorOneY, int vectorOneZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);
            var expected = Math.Sqrt(vectorOneX * vectorOneX + vectorOneY * vectorOneY + vectorOneZ * vectorOneZ);

            // Assert
            Assert.AreEqual(expected, vectorOne.Magnitude);
        }

        /// <summary>
        /// Test for correct get property Normalized from vector 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        [TestCase(10, 20, 25)]
        [TestCase(2, 4, 5)]
        [TestCase(10, 20, 25)]
        [TestCase(-10, -20, -25)]
        public void GivenNormalized_WhenDifferentDigits_ThenOutIsOne(
            int vectorOneX, int vectorOneY, int vectorOneZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);

            // Act
            var actualVector = vectorOne.Normalized;

            // Assert
            Assert.AreEqual(1, actualVector.Magnitude);
        }

        /// <summary>
        /// Test for correct get property SqrMagnitude from vector 
        /// when numbers is positive.
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        [TestCase(10, 20, 25)]
        [TestCase(2, 4, 5)]
        [TestCase(10, 20, 25)]
        [TestCase(-10, -20, -2)]
        [TestCase(-10, -20, -25)]
        public void GivenSqrMagnitude_WhenDifferentDigits(
            int vectorOneX, int vectorOneY, int vectorOneZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);

            // Act 
            var actual = vectorOne.SqrMagnitude;
            var expected =
                        (vectorOne.X * vectorOne.X) +
                        (vectorOne.Y * vectorOne.Y) +
                        (vectorOne.Z * vectorOne.Z);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test for correct get property this[int i] from vector 
        /// when numbers is positive.
        /// </summary>
        /// <param name="vectorOneX">X coordinate of the vector one.</param>
        /// <param name="vectorOneY">X coordinate of the vector one.</param>
        /// <param name="vectorOneZ">X coordinate of the vector one.</param>
        [TestCase(10, 20, 25)]
        [TestCase(2, 4, 5)]
        [TestCase(10, 20, 25)]
        [TestCase(-10, -20, -2)]
        [TestCase(-10, -20, -25)]
        public void GivenThisInt_i_ForGetDataWhenNumbers_2_4_6_OutIs2_4_6(
            int vectorOneX, int vectorOneY, int vectorOneZ)
        {
            // Arrange
            Vector vectorOne = new Vector(vectorOneX, vectorOneY, vectorOneZ);

            // Assert
            Assert.AreEqual(vectorOne.X, vectorOne[0]);
            Assert.AreEqual(vectorOne.Y, vectorOne[1]);
            Assert.AreEqual(vectorOne.Z, vectorOne[2]);
        }

        /// <summary>
        /// Test for correct get property this[int i] from vector 
        /// when numbers is out of range.
        /// </summary>
        /// <param name="index">Index.</param>
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(100)]
        public void GivenThisInt_i_WhenIndexMoreThenTWO_OutIsArgumentOutOfRangeException(
            int index)
        {
            // Assert
            Assert.That(() => new Vector(0, 0, 0)[index], Throws.TypeOf<ArgumentOutOfRangeException>());
        }
    }
}
