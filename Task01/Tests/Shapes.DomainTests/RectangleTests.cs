using NUnit.Framework;
using Shapes.Domain;

namespace Shapes.DomainTests
{
    [TestFixture()]
    class RectangleTests
    {
        [TestCase(10.0, 10.0, 100.0)]
        [TestCase(100.1, 10.0, 1001.0)]
        [TestCase(1000.15, 10.0, 10001.5)]
        public void GivenArea_WhenParametersIsPositive_ThenOutIsPositiveArea(double length, double width, double expectedArea)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(length, width);
            //Act
            var actualArea = rectangle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestCase(-10.0, -10.0, 100.0)]
        [TestCase(-100.1, -10.0, 1001.0)]
        [TestCase(-1000.15, -10.0, 10001.5)]
        public void GivenArea_WhenParametersIsNegative_ThenOutIsPositiveArea(double length, double width, double expectedArea)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(length, width);
            //Act
            var actualArea = rectangle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestCase(0.0, 0.0, 0)]
        public void GivenArea_WhenParametersIsZero_ThenOutIsZero(double length, double width, double expectedArea)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(length, width);
            //Act
            var actualArea = rectangle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        [TestCase(10.0, 10.0, 40.0)]
        [TestCase(100.1, 10.0, 220.19999999999999)]
        [TestCase(1000.15, 10.0, 2020.3)]
        public void GivenPerimeter_WhenParametersIsPositive_ThenOutIsPositivePerimeter(double length, double width, double expectedPerimeter)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(length, width);
            //Act
            var actualPerimetera = rectangle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimetera);
        }

        [TestCase(-10.0, -10.0, -40.0)]
        [TestCase(-100.1, -10.0, -220.19999999999999)]
        [TestCase(-1000.15, -10.0, -2020.3)]
        public void GivenPerimeter_WhenParametersIsNegative_ThenOutIsPositivePerimeter(double length, double width, double expectedPerimeter)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(length, width);
            //Act
            var actualPerimeter = rectangle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestCase(0.0, 0.0, 0)]
        public void GivenPerimeter_WhenParametersIsZero_ThenOutIsZero(double length, double width, double expectedPerimeter)
        {
            //Arrange
            Rectangle rectangle = new Rectangle(length, width);
            //Act
            var actualPerimeter = rectangle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        [TestCase(0.0, 0.0, true)]
        public void GivenEquals_ThenOutIsTrue(double length, double width, bool expected)
        {
            //Arrange
            Rectangle actualRectangle = new Rectangle(length, width);
            Rectangle expectedRectangle = new Rectangle(length, width);
            //Act
            var actual = actualRectangle.Equals(expectedRectangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(10.0, 10.0, false)]
        public void GivenEquals_ThenOutIsFalse(double length, double width, bool expected)
        {
            //Arrange
            Rectangle actualRectangle = new Rectangle(length, width);
            Rectangle expectedRectangle = new Rectangle(3,3);
            //Act
            var actual = actualRectangle.Equals(expectedRectangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
