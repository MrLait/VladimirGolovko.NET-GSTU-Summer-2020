using Girls.Data.Repository;
using NUnit.Framework;
using Shapes.Domain.Enum;
using Shapes.Domain.Shape.FilmShapes;
using Shapes.Domain.Shape.PaperShapes;

namespace Shapes.Domain.Tests
{
    /// <summary>
    /// Test cases to testing class circle.
    /// </summary>
    [TestFixture()]
    public class CircleTests
    {
        [TestCase(10.0, 314.16000000000003)]
        public void TestTestCase(double radius, double expectedArea)
        {
            PaperCircle paperCircleOne = new PaperCircle(15, Color.White);
            PaperCircle paperCircleTwo = new PaperCircle(10, Color.White);
            PaperCircle paperCircleGreenCut = new PaperCircle(10, Color.Green);
            FilmCircle filmCircleOne = new FilmCircle(11);
            FilmCircle filmCircleCur = new FilmCircle(11);
            FilmCircle filmCircleCut = new FilmCircle(12);


            var paperSquareCut = new PaperSquare(1, Color.White);

            var paperSquareCutting = new PaperSquare(paperCircleOne, paperSquareCut);


            var paperCircleWhite = new PaperCircle(paperCircleOne, paperCircleTwo);
            //var paperCircleGreen = new PaperCircle(paperCircleOne, paperCircleGreenCut);
            //var filmCircle = new FilmCircle(paperCircleOne, filmCircleOne);
            //var filmCircle = new FilmCircle(filmCircleCur, filmCircleCut);


            ShapeBoxRepository shapeBoxRepository = new ShapeBoxRepository();
            shapeBoxRepository.AddShapeToBox(paperCircleTwo);
            shapeBoxRepository.AddShapeToBox(filmCircleCut);

            var getShape = shapeBoxRepository.FindShapeById(0);
            var getShape2 = shapeBoxRepository.ExecuteShapeById(1);

            shapeBoxRepository.ReplaceById(5, filmCircleOne);

            var getByPattern = shapeBoxRepository.FindShapeByPattern(filmCircleOne);

            var numShape = shapeBoxRepository.GetNumOfShapesInBox();

            var totalArea = shapeBoxRepository.GetTotalArea();
            var totalPerimeter = shapeBoxRepository.GetTotalPerimeter();

            var getAllCircle = shapeBoxRepository.GetAllCircles();
            var getAllFilmShape = shapeBoxRepository.GetAllFilmShapes();
        }

        ///// <summary>
        ///// Test case to testing property area.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expectedArea">Expected area.</param>
        //[TestCase(10.0, 314.16000000000003)]
        //[TestCase(100.1, 31478.790000000001)]
        //[TestCase(1000.15, 3142535.2000000002d)]
        //public void GivenArea_WhenRadiusIsPositive_ThenOutIsPositiveArea(double radius, double expectedArea)
        //{
        //    //Arrange
        //    Circle circle = new Circle(radius);
        //    //Act
        //    var actualArea = circle.Area;
        //    //Assert
        //    Assert.AreEqual(expectedArea, actualArea);
        //}

        ///// <summary>
        ///// Test case to testing property area. 
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expectedArea">Expected area.</param>
        //[TestCase(-10.0, 314.16000000000003)]
        //[TestCase(-100.1, 31478.790000000001)]
        //[TestCase(-1000.15, 3142535.2000000002d)]
        //public void GivenArea_WhenRadiusIsNegative_ThenOutIsPositiveArea(double radius, double expectedArea)
        //{
        //    //Arrange
        //    Circle circle = new Circle(radius);
        //    //Act
        //    var actualArea = circle.Area;
        //    //Assert
        //    Assert.AreEqual(expectedArea, actualArea);
        //}

        ///// <summary>
        ///// Test case to testing property area.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expectedArea">Expected area.</param>
        //[TestCase(0.0, 0)]
        //public void GivenArea_WhenRadiusIsZero_ThenOutIsZero(double radius, double expectedArea)
        //{
        //    //Arrange
        //    Circle circle = new Circle(radius);
        //    //Act
        //    var actualArea = circle.Area;
        //    //Assert
        //    Assert.AreEqual(expectedArea, actualArea);
        //}

        ///// <summary>
        ///// Test case to testing property perimeter.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expectedPerimeter">Expected perimeter.</param>
        //[TestCase(10.0, 62.829999999999998d)]
        //[TestCase(100.1, 628.95000000000005)]
        //[TestCase(1000.15, 6284.1300000000001)]
        //public void GivenPerimeter_WhenRadiusIsPositive_ThenOutIsPositivePerimeter(double radius, double expectedPerimeter)
        //{
        //    //Arrange
        //    Circle circle = new Circle(radius);
        //    //Act
        //    var actualPerimetera = circle.Perimeter;
        //    //Assert
        //    Assert.AreEqual(expectedPerimeter, actualPerimetera);
        //}

        ///// <summary>
        ///// Test case to testing property perimeter.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expectedPerimeter">Expected perimeter.</param>
        //[TestCase(-10.0, -62.829999999999998)]
        //[TestCase(-100.1, -628.95000000000005)]
        //[TestCase(-1000.15, -6284.1300000000001)]
        //public void GivenPerimeter_WhenRadiusIsNegative_ThenOutIsPositivePerimeter(double radius, double expectedPerimeter)
        //{
        //    //Arrange
        //    Circle circle = new Circle(radius);
        //    //Act
        //    var actualPerimeter = circle.Perimeter;
        //    //Assert
        //    Assert.AreEqual(expectedPerimeter, actualPerimeter);
        //}

        ///// <summary>
        ///// Test case to testing property perimeter.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expectedPerimeter">Expected perimeter.</param>
        //[TestCase(0.0, 0)]
        //public void GivenPerimeter_WhenRadiusIsZero_ThenOutIsZero(double radius, double expectedPerimeter)
        //{
        //    //Arrange
        //    Circle circle = new Circle(radius);
        //    //Act
        //    var actualPerimeter = circle.Perimeter;
        //    //Assert
        //    Assert.AreEqual(expectedPerimeter, actualPerimeter);
        //}

        ///// <summary>
        ///// Test case to testing equals.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expected">Expected True</param>
        //[TestCase(0.0, true)]
        //public void GivenEquals_ThenOutIsTrue(double radius, bool expected)
        //{
        //    //Arrange
        //    Circle actualCircle = new Circle(radius);
        //    Circle expectedCircle = new Circle(radius);
        //    //Act
        //    var actual = actualCircle.Equals(expectedCircle);
        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}

        ///// <summary>
        ///// Test case to testing equals.
        ///// </summary>
        ///// <param name="radius">Circle radius.</param>
        ///// <param name="expected">Expected False</param>
        //[TestCase(10.0, false)]
        //public void GivenEquals_ThenOutIsFalse(double radius, bool expected)
        //{
        //    //Arrange
        //    Circle actualCircle = new Circle(radius);
        //    Circle expectedCircle = new Circle(3);
        //    //Act
        //    var actual = actualCircle.Equals(expectedCircle);
        //    //Assert
        //    Assert.AreEqual(expected, actual);
        //}
    }
}