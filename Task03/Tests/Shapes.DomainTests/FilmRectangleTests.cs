using NUnit.Framework;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using Shapes.Domain.UserExceprion;

namespace Shapes.DomainTests
{
    /// <summary>
    /// Test cases to testing class film rectangle.
    /// </summary>
    [TestFixture()]
    class FilmRectangleTests
    {
        /// <summary>
        /// Test case to testing property area.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(10.0, 10.0, 100.0)]
        [TestCase(100.1, 10.0, 1001.0)]
        [TestCase(1000.15, 10.0, 10001.5)]
        public void GivenArea_WhenParametersIsPositive_ThenOutIsPositiveArea(double length, double width, double expectedArea)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(length, width);
            //Act
            var actualArea = rectangle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property area.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(-10.0, -10.0, 100.0)]
        [TestCase(-100.1, -10.0, 1001.0)]
        [TestCase(-1000.15, -10.0, 10001.5)]
        public void GivenArea_WhenParametersIsNegative_ThenOutIsPositiveArea(double length, double width, double expectedArea)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(length, width);
            //Act
            var actualArea = rectangle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property area.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(0.0, 0.0, 0)]
        public void GivenArea_WhenParametersIsZero_ThenOutIsZero(double length, double width, double expectedArea)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(length, width);
            //Act
            var actualArea = rectangle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property perimeter.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(10.0, 10.0, 40.0)]
        [TestCase(100.1, 10.0, 220.19999999999999)]
        [TestCase(1000.15, 10.0, 2020.3)]
        public void GivenPerimeter_WhenParametersIsPositive_ThenOutIsPositivePerimeter(double length, double width, double expectedPerimeter)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(length, width);
            //Act
            var actualPerimetera = rectangle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimetera);
        }

        /// <summary>
        /// Test case to testing property perimeter.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(-10.0, -10.0, -40.0)]
        [TestCase(-100.1, -10.0, -220.19999999999999)]
        [TestCase(-1000.15, -10.0, -2020.3)]
        public void GivenPerimeter_WhenParametersIsNegative_ThenOutIsPositivePerimeter(double length, double width, double expectedPerimeter)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(length, width);
            //Act
            var actualPerimeter = rectangle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test case to testing property perimeter.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(0.0, 0.0, 0)]
        public void GivenPerimeter_WhenParametersIsZero_ThenOutIsZero(double length, double width, double expectedPerimeter)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(length, width);
            //Act
            var actualPerimeter = rectangle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test case to testing equals.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expected">Expected equals.</param>
        [TestCase(0.0, 0.0, true)]
        public void GivenEquals_ThenOutIsTrue(double length, double width, bool expected)
        {
            //Arrange
            FilmRectangle actualRectangle = new FilmRectangle(length, width);
            FilmRectangle expectedRectangle = new FilmRectangle(length, width);
            //Act
            var actual = actualRectangle.Equals(expectedRectangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case to testing equals.
        /// </summary>
        /// <param name="length">Rectangle length.</param>
        /// <param name="width">Rectangle width.</param>
        /// <param name="expected">Expected equals.</param>
        [TestCase(10.0, 10.0, false)]
        public void GivenEquals_ThenOutIsFalse(double length, double width, bool expected)
        {
            //Arrange
            FilmRectangle actualRectangle = new FilmRectangle(length, width);
            FilmRectangle expectedRectangle = new FilmRectangle(3, 3);
            //Act
            var actual = actualRectangle.Equals(expectedRectangle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case to testing cut rectangle from square.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaSquareShapeIsMore(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            FilmSquare square = new FilmSquare(length);

            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Act
            FilmRectangle actualShape = new FilmRectangle(square, rectangle);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut rectangle from rectangle.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaRectangleShapeIsMore(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            FilmRectangle cuttingRectangle = new FilmRectangle(length, length);

            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Act
            FilmRectangle actualShape = new FilmRectangle(cuttingRectangle, rectangle);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut rectangle from circle.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 500)]
        [TestCase(100.0, 500)]
        [TestCase(13.0, 500)]
        public void GivenCutConstructor_WhenAreaCircleShapeIsMore(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            FilmCircle circleTwo = new FilmCircle(length);

            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Act
            FilmRectangle actualShape = new FilmRectangle(circleTwo, rectangle);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut rectangle from square.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 9)]
        public void GivenCutConstructor_WhenAreaSquareShapeIsLess_ThenShapeException(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            FilmSquare square = new FilmSquare(length);
            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Assert
            Assert.That(() => new FilmRectangle(square, rectangle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut rectangle from rectangle.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 9)]
        public void GivenCutConstructor_WhenAreaRectangleShapeIsLess_ThenShapeException(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            FilmRectangle cuttingRectangle = new FilmRectangle(length, length);
            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Assert
            Assert.That(() => new FilmRectangle(cuttingRectangle, rectangle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut rectangle from circle.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 5)]
        [TestCase(100.0, 5)]
        [TestCase(13.0, 5)]
        public void GivenCutConstructor_WhenAreaCircleShapeIsLess_ThenShapeException(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            FilmCircle circleTwo = new FilmCircle(length);
            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Assert
            Assert.That(() => new FilmRectangle(circleTwo, rectangle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut rectangle from square.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenSquareMaterialIsnotEqual_ThenShapeException(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            PaperSquare square = new PaperSquare(length, Color.Blue);
            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Assert
            Assert.That(() => new FilmRectangle(square, rectangle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut rectangle from rectangle.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 9)]
        public void GivenCutConstructor_WhenRectangleMaterialIsnotEqual_ThenShapeException(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            PaperRectangle cuttingRectangle = new PaperRectangle(length, length, Color.Blue);
            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Assert
            Assert.That(() => new FilmRectangle(cuttingRectangle, rectangle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut rectangle from circle.
        /// </summary>
        /// <param name="rectangleLength">Rectangle length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenCircleMaterialIsnotEqual_ThenShapeException(double rectangleLength, double length)
        {
            //Arrange
            FilmRectangle rectangle = new FilmRectangle(rectangleLength, rectangleLength);
            PaperCircle circleTwo = new PaperCircle(length, Color.Blue);
            FilmRectangle expectedShape = new FilmRectangle(rectangleLength, rectangleLength);
            //Assert
            Assert.That(() => new FilmRectangle(circleTwo, rectangle), Throws.TypeOf<ShapeException>());
        }
    }
}
