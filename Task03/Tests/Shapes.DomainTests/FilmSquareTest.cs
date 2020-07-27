using NUnit.Framework;
using Shapes.Domain;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;
using Shapes.Domain.UserExceprion;

namespace Shapes.DomainTests
{
    /// <summary>
    /// Test cases to testing class square.
    /// </summary>
    [TestFixture()]
    public class FilmSquareTest
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
            FilmSquare square = new FilmSquare(length);
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
            FilmSquare square = new FilmSquare(length);
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
            FilmSquare square = new FilmSquare(length);
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
            FilmSquare square = new FilmSquare(length);
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
            FilmSquare square = new FilmSquare(length);
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
            FilmSquare square = new FilmSquare(length);
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
            FilmSquare actualSquare = new FilmSquare(length);
            FilmSquare expectedSquare = new FilmSquare(length);
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
            FilmSquare actualSquare = new FilmSquare(length);
            FilmSquare expectedSquare = new FilmSquare(3);
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
            FilmSquare cutSquare = new FilmSquare(squareLength);
            FilmSquare curSquare = new FilmSquare(length);

            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Act
            FilmSquare actualShape = new FilmSquare(curSquare, cutSquare);
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
            FilmSquare cutSquare = new FilmSquare(squareLength);
            FilmRectangle rectangle = new FilmRectangle(length, length);

            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Act
            FilmSquare actualShape = new FilmSquare(rectangle, cutSquare);
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
            FilmSquare cutSquare = new FilmSquare(squareLength);
            FilmCircle circleTwo = new FilmCircle(length);

            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Act
            FilmSquare actualShape = new FilmSquare(circleTwo, cutSquare);
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
            FilmSquare cutSquare = new FilmSquare(squareLength);
            FilmSquare square = new FilmSquare(length);
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
        public void GivenCutConstructor_WhenAreaRectangleShapeIsLess_ThenShapeException(double squareLength, double length)
        {
            //Arrange
            FilmSquare cutSquare = new FilmSquare(squareLength);
            FilmRectangle rectangle = new FilmRectangle(length, length);
            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Assert
            Assert.That(() => new FilmSquare(rectangle, cutSquare), Throws.TypeOf<ShapeException>());
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
            FilmSquare cutSquare = new FilmSquare(squareLength);
            FilmCircle circleTwo = new FilmCircle(length);
            FilmSquare expectedShape = new FilmSquare(squareLength);
            //Assert
            Assert.That(() => new FilmSquare(circleTwo, cutSquare), Throws.TypeOf<ShapeException>());
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
    }
}
