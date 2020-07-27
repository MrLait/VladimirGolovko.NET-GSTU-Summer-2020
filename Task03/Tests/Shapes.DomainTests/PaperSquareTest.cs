using NUnit.Framework;
using Shapes.Domain;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using Shapes.Domain.UserExceprion;

namespace Shapes.DomainTests
{
    /// <summary>
    /// Test cases to testing class paper square.
    /// </summary>
    [TestFixture()]
    public class PaperSquareTest
    {
        /// <summary>
        /// Test case to testing property area.
        /// </summary>
        /// <param name="length">Square length.</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(10.0, 100.0)]
        [TestCase(100.1, 10020.009999999998)]
        [TestCase(1000.15, 1000300.0225)]
        public void GivenArea_WhenLengthIsPositive_ThenOutIsPositiveArea(double length, double expectedArea)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            //Act
            var actualArea = square.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property area. 
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(-10.0, 100.0)]
        [TestCase(-100.1, 10020.009999999998)]
        [TestCase(-1000.15, 1000300.0225)]
        public void GivenArea_WhenLengthIsNegative_ThenOutIsPositiveArea(double length, double expectedArea)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            //Act
            var actualArea = square.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property area. 
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expectedArea">Expected area.</param>
        [TestCase(0.0, 0)]
        public void GivenArea_WhenLengthIsZero_ThenOutIsZero(double length, double expectedArea)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            //Act
            var actualArea = square.Area;
            //Assert
            Assert.AreEqual(expectedArea, actualArea);
        }

        /// <summary>
        /// Test case to testing property perimeter. 
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(10.0, 40)]
        [TestCase(100.1, 400.39999999999998)]
        [TestCase(1000.15, 4000.5999999999999)]
        public void GivenPerimeter_WhenLengthIsPositive_ThenOutIsPositivePerimeter(double length, double expectedPerimeter)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            //Act
            var actualPerimetera = square.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimetera);
        }

        /// <summary>
        /// Test case to testing property perimeter. 
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(-10.0, -40)]
        [TestCase(-100.1, -400.39999999999998)]
        [TestCase(-1000.15, -4000.5999999999999)]
        public void GivenPerimeter_WhenLengthIsNegative_ThenOutIsPositivePerimeter(double length, double expectedPerimeter)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            //Act
            var actualPerimeter = square.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test case to testing property perimeter.  
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expectedPerimeter">Expected perimeter.</param>
        [TestCase(0.0, 0)]
        public void GivenPerimeter_WhenLengthIsZero_ThenOutIsZero(double length, double expectedPerimeter)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            //Act
            var actualPerimeter = square.Perimeter;
            //Assert
            Assert.AreEqual(expectedPerimeter, actualPerimeter);
        }

        /// <summary>
        /// Test case to testing method equals.  
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expected">Expected True</param>
        [TestCase(0.0, true)]
        public void GivenEquals_ThenOutIsTrue(double length, bool expected)
        {
            //Arrange
            PaperSquare actualSquare = new PaperSquare(length, Color.White);
            PaperSquare expectedSquare = new PaperSquare(length, Color.White);
            //Act
            var actual = actualSquare.Equals(expectedSquare);
            //Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Test case to testing method equals.  
        /// </summary>
        /// <param name="length">Square length</param>
        /// <param name="expected">Expected False</param>
        [TestCase(10.0, false)]
        public void GivenEquals_ThenOutIsFalse(double length, bool expected)
        {
            //Arrange
            PaperSquare actualSquare = new PaperSquare(length, Color.White);
            PaperSquare expectedSquare = new PaperSquare(3, Color.White);
            //Act
            var actual = actualSquare.Equals(expectedSquare);
            //Assert
            Assert.AreEqual(expected, actual);
        }
        /////////////////////////////////////////////////
        /// <summary>
        /// Test case to testing cut square from square.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaSquareShapeIsMore(double squareLength, double length)
        {
            //Arrange
            PaperSquare cutSquare = new PaperSquare(squareLength, Color.White);
            PaperSquare curSquare = new PaperSquare(length, Color.White);

            PaperSquare expectedShape = new PaperSquare(squareLength, Color.White);
            //Act
            PaperSquare actualShape = new PaperSquare(curSquare, cutSquare);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut square from rectangle.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaRectangleShapeIsMore(double squareLength, double length)
        {
            //Arrange
            PaperSquare cutSquare = new PaperSquare(squareLength, Color.White);
            PaperRectangle rectangle = new PaperRectangle(length, length, Color.White);

            PaperSquare expectedShape = new PaperSquare(squareLength, Color.White);
            //Act
            PaperSquare actualShape = new PaperSquare(rectangle, cutSquare);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut square from circle.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 100)]
        [TestCase(100.0, 1000)]
        [TestCase(13.0, 100)]
        public void GivenCutConstructor_WhenAreaCircleShapeIsMore(double squareLength, double length)
        {
            //Arrange
            PaperSquare cutSquare = new PaperSquare(squareLength, Color.White);
            PaperCircle circleTwo = new PaperCircle(length, Color.White);

            PaperSquare expectedShape = new PaperSquare(squareLength, Color.White);
            //Act
            PaperSquare actualShape = new PaperSquare(circleTwo, cutSquare);
            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        /// <summary>
        /// Test case to testing cut square from square.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenAreaSquareShapeIsLess_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            PaperSquare cutSquare = new PaperSquare(squareLength, Color.White);
            PaperSquare square = new PaperSquare(length, Color.White);
            PaperSquare expectedShape = new PaperSquare(squareLength, Color.White);
            //Assert
            Assert.That(() => new PaperSquare(square, cutSquare), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut square from rectangle.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenAreaRectangleShapeIsLess_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            PaperSquare cutSquare = new PaperSquare(squareLength, Color.White);
            PaperRectangle rectangle = new PaperRectangle(length, length, Color.White);
            PaperSquare expectedShape = new PaperSquare(squareLength, Color.White);
            //Assert
            Assert.That(() => new PaperSquare(rectangle, cutSquare), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut square from circle.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 2)]
        [TestCase(100.0, 5)]
        [TestCase(13.0, 5)]
        public void GivenCutConstructor_WhenAreaCircleShapeIsLess_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            PaperSquare cutSquare = new PaperSquare(squareLength, Color.White);
            FilmCircle circleTwo = new FilmCircle(length);
            PaperSquare expectedShape = new PaperSquare(squareLength, Color.White);
            //Assert
            Assert.That(() => new PaperSquare(circleTwo, cutSquare), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut square from square.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenSquareMaterialIsnotEqual_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            FilmSquare cutSquare = new FilmSquare(squareLength);
            PaperSquare square = new PaperSquare(length, Color.Blue);
            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Assert
            Assert.That(() => new FilmSquare(square, cutSquare), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut square from rectangle.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenRectangleMaterialIsnotEqual_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            FilmSquare cutSquare = new FilmSquare(squareLength);
            PaperRectangle rectangle = new PaperRectangle(length, length, Color.Blue);
            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Assert
            Assert.That(() => new FilmSquare(rectangle, cutSquare), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing cut square from circle.
        /// </summary>
        /// <param name="squareLength">Square length.</param>
        /// <param name="length">Length.</param>
        [TestCase(10.0, 9)]
        [TestCase(100.0, 99)]
        [TestCase(13.0, 10)]
        public void GivenCutConstructor_WhenCircleMaterialIsnotEqual_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            FilmSquare cutSquare = new FilmSquare(squareLength);
            PaperCircle circleTwo = new PaperCircle(length, Color.Blue);
            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Assert
            Assert.That(() => new FilmSquare(circleTwo, cutSquare), Throws.TypeOf<ShapeException>());
        }

        /// <summary>
        /// Test case to testing recolor figure.
        /// </summary>
        /// <param name="length">Square length.</param>
        [TestCase(10.0)]
        [TestCase(100.0)]
        [TestCase(13.0)]
        public void GivenColor_WhenPressColorTwice_ThenShapeException(double length)
        {
            //Arrange
            PaperSquare square = new PaperSquare(length, Color.White);
            square.Color = Color.Green;
            //Assert
            Assert.That(() => square.Color = Color.Blue, Throws.TypeOf<ShapeException>());
        }
    }
}
