using NUnit.Framework;
using Shapes.Domain;

namespace Shapes.DomainTests
{
        [TestFixture()]
        public class SquareTest
        {
            [TestCase(10.0, 100.0)]
            [TestCase(100.1, 10020.009999999998)]
            [TestCase(1000.15, 1000300.0225)]
            public void GivenArea_WhenLengthIsPositive_ThenOutIsPositiveArea(double length, double expectedArea)
            {
                //Arrange
                Square square = new Square(length);
                //Act
                var actualArea = square.Area;
                //Assert
                Assert.AreEqual(expectedArea, actualArea);
            }

            [TestCase(-10.0, 100.0)]
            [TestCase(-100.1, 10020.009999999998)]
            [TestCase(-1000.15, 1000300.0225)]
            public void GivenArea_WhenLengthIsNegative_ThenOutIsPositiveArea(double length, double expectedArea)
            {
                //Arrange
                Square square = new Square(length);
                //Act
                var actualArea = square.Area;
                //Assert
                Assert.AreEqual(expectedArea, actualArea);
            }

            [TestCase(0.0, 0)]
            public void GivenArea_WhenLengthIsZero_ThenOutIsZero(double length, double expectedArea)
            {
                //Arrange
                Square square = new Square(length);
                //Act
                var actualArea = square.Area;
                //Assert
                Assert.AreEqual(expectedArea, actualArea);
            }

            [TestCase(10.0, 40)]
            [TestCase(100.1, 400.39999999999998)]
            [TestCase(1000.15, 4000.5999999999999)]
            public void GivenPerimeter_WhenLengthIsPositive_ThenOutIsPositivePerimeter(double length, double expectedPerimeter)
            {
                //Arrange
                Square square = new Square(length);
                //Act
                var actualPerimetera = square.Perimeter;
                //Assert
                Assert.AreEqual(expectedPerimeter, actualPerimetera);
            }

            [TestCase(-10.0, -40)]
            [TestCase(-100.1, -400.39999999999998)]
            [TestCase(-1000.15, -4000.5999999999999)]
            public void GivenPerimeter_WhenLengthIsNegative_ThenOutIsPositivePerimeter(double length, double expectedPerimeter)
            {
                //Arrange
                Square square = new Square(length);
                //Act
                var actualPerimeter = square.Perimeter;
                //Assert
                Assert.AreEqual(expectedPerimeter, actualPerimeter);
            }

            [TestCase(0.0, 0)]
            public void GivenPerimeter_WhenLengthIsZero_ThenOutIsZero(double length, double expectedPerimeter)
            {
                //Arrange
                Square square = new Square(length);
                //Act
                var actualPerimeter = square.Perimeter;
                //Assert
                Assert.AreEqual(expectedPerimeter, actualPerimeter);
            }

            [TestCase(0.0, true)]
            public void GivenEquals_ThenOutIsTrue(double length, bool expected)
            {
                //Arrange
                Square actualSquare = new Square(length);
                Square expectedSquare = new Square(length);
                //Act
                var actual = actualSquare.Equals(expectedSquare);
                //Assert
                Assert.AreEqual(expected, actual);
            }

            [TestCase(10.0, false)]
            public void GivenEquals_ThenOutIsFalse(double length, bool expected)
            {
                //Arrange
                Square actualSquare = new Square(length);
                Square expectedSquare = new Square(3);
                //Act
                var actual = actualSquare.Equals(expectedSquare);
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }
}
