using NUnit.Framework;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using Shapes.Domain.UserExceprion;

namespace Shapes.DomainTests
{
    /// <summary>
    /// Test cases to testing class circle.
    /// </summary>
    [TestFixture()]
    public class PaperCircleTests
    {
        /// <summary>
        /// Test case to testing property area.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(10.0, 314.16000000000003)]
        [TestCase(100.1, 31478.790000000001)]
        [TestCase(1000.15, 3142535.2000000002d)]
        public void GivenArea_WhenRadiusIsPositive_ThenOutIsPositiveArea(double radius, double expectedArea)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius,Color.White);
            //Act
            var actualArea = circle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property area. 
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(-10.0, 314.16000000000003)]
        [TestCase(-100.1, 31478.790000000001)]
        [TestCase(-1000.15, 3142535.2000000002d)]
        public void GivenArea_WhenRadiusIsNegative_ThenOutIsPositiveArea(double radius, double expectedArea)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            //Act
            var actualArea = circle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property area.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(0.0, 0)]
        public void GivenArea_WhenRadiusIsZero_ThenOutIsZero(double radius, double expectedArea)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            //Act
            var actualArea = circle.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property perimeter.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(10.0, 62.829999999999998d)]
        [TestCase(100.1, 628.95000000000005)]
        [TestCase(1000.15, 6284.1300000000001)]
        public void GivenPerimeter_WhenRadiusIsPositive_ThenOutIsPositivePerimeter(double radius, double expectedPerimeter)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            //Act
            var actualPerimetera = circle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimetera);
        }

        /// <summary>
        /// Test case to testing property perimeter.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(-10.0, -62.829999999999998)]
        [TestCase(-100.1, -628.95000000000005)]
        [TestCase(-1000.15, -6284.1300000000001)]
        public void GivenPerimeter_WhenRadiusIsNegative_ThenOutIsPositivePerimeter(double radius, double expectedPerimeter)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            //Act
            var actualPerimeter = circle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test case to testing property perimeter.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(0.0, 0)]
        public void GivenPerimeter_WhenRadiusIsZero_ThenOutIsZero(double radius, double expectedPerimeter)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            //Act
            var actualPerimeter = circle.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test case to testing equals.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expected">Expected True</param>
        [TestCase(0.0, true)]
        public void GivenEquals_ThenOutIsTrue(double radius, bool expected)
        {
            //Arrange
            PaperCircle actualCircle = new PaperCircle(radius, Color.White);
            PaperCircle expectedCircle = new PaperCircle(radius, Color.White);
            //Act
            var actual = actualCircle.Equals(expectedCircle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case to testing equals.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="expected">Expected False</param>
        [TestCase(10.0, false)]
        public void GivenEquals_ThenOutIsFalse(double radius, bool expected)
        {
            //Arrange
            PaperCircle actualCircle = new PaperCircle(radius, Color.White);
            PaperCircle expectedCircle = new PaperCircle(3, Color.White);
            //Act
            var actual = actualCircle.Equals(expectedCircle);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case to testing cut circle from square.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaSquareShapeIsMore(double radius, double length)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            PaperSquare square = new PaperSquare(length, Color.White);

            PaperCircle expectedShape = new PaperCircle(radius, Color.White);
            //Act
            PaperCircle actualShape = new PaperCircle(square, circle);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut circle from rectangle.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaRectangleShapeIsMore(double radius, double length)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            PaperRectangle rectangle = new PaperRectangle(length, length, Color.White);

            PaperCircle expectedShape = new PaperCircle(radius, Color.White);
            //Act
            PaperCircle actualShape = new PaperCircle(rectangle, circle);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut circle from circle.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaCircleShapeIsMore(double radius, double length)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            PaperCircle circleTwo = new PaperCircle(length, Color.White);

            PaperCircle expectedShape = new PaperCircle(radius, Color.White);
            //Act
            PaperCircle actualShape = new PaperCircle(circleTwo, circle);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut circle from square.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 10)]
        [TestCase(100.0, 100)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenAreaSquareShapeIsLess_ThenShapeException(double radius, double length)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            FilmSquare square = new FilmSquare(length);
            PaperCircle expectedShape = new PaperCircle(radius, Color.White);
            //Assert
            Assert.That(() => new PaperCircle(square, circle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut circle from rectangle.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 10)]
        [TestCase(100.0, 100)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenAreaRectangleShapeIsLess_ThenShapeException(double radius, double length)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            FilmRectangle rectangle = new FilmRectangle(length, length);
            PaperCircle expectedShape = new PaperCircle(radius, Color.White);
            //Assert
            Assert.That(() => new PaperCircle(rectangle, circle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut circle from circle.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenAreaCircleShapeIsLess_ThenShapeException(double radius, double length)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            PaperCircle circleTwo = new PaperCircle(length, Color.White);
            PaperCircle expectedShape = new PaperCircle(radius, Color.White);
            //Assert
            Assert.That(() => new PaperCircle(circleTwo, circle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut circle from square.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 10)]
        [TestCase(100.0, 100)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenSquareMaterialIsnotEqual_ThenShapeException(double radius, double length)
        {
            //Arrange
            FilmCircle circle = new FilmCircle(radius);
            PaperSquare square = new PaperSquare(length, Color.Blue);
            FilmCircle expectedShape = new FilmCircle(radius);
            //Assert
            Assert.That(() => new FilmCircle(square, circle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut circle from rectangle.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 10)]
        [TestCase(100.0, 100)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenRectangleMaterialIsnotEqual_ThenShapeException(double radius, double length)
        {
            //Arrange
            FilmCircle circle = new FilmCircle(radius);
            PaperRectangle rectangle = new PaperRectangle(length, length, Color.Blue);
            FilmCircle expectedShape = new FilmCircle(radius);
            //Assert
            Assert.That(() => new FilmCircle(rectangle, circle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut circle from circle.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenCircleMaterialIsnotEqual_ThenShapeException(double radius, double length)
        {
            //Arrange
            FilmCircle circle = new FilmCircle(radius);
            PaperCircle circleTwo = new PaperCircle(length, Color.Blue);
            FilmCircle expectedShape = new FilmCircle(radius);
            //Assert
            Assert.That(() => new FilmCircle(circleTwo, circle), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing recolor figure.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
        [TestCase(10.0)]
        [TestCase(100.0)]
        [TestCase(13.0)]
        public void GivenColor_WhenPressColorTwice_ThenShapeException(double radius)
        {
            //Arrange
            PaperCircle circle = new PaperCircle(radius, Color.White);
            circle.Color = Color.Green;
            //Assert
            Assert.That(() => circle.Color = Color.Blue, Throws.TypeOf<ShapeException>());
        }
    }
}
