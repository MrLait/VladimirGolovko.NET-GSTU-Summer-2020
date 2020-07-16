using NUnit.Framework;
using Shapes.Data.Repositories;
using Shapes.Domain;
using System.Collections.Generic;

namespace Shapes.Services.Tests
{
    [TestFixture()]
    public class ShapeServiceTests
    {
        private string correctPathToTxtFile = @"fileData\correctFigures.txt";

        [TestCase()]
        public void FindEqualsObjectsByObject_WhenInputIsCorrectFigures_ThenOutIsFiveCircle()
        {
            //Arrange
            List<BaseShape> expectedResult = new List<BaseShape> { new Circle(30), new Circle(30), new Circle(30), new Circle(30), new Circle(30) };
            //Act
            IEnumerable<BaseShape> shapes = new TxtShapeRepository(correctPathToTxtFile).GetShapeList();
            IEnumerable<BaseShape> actualShapes =  ShapeService<BaseShape>.FindEqualsObjectsByObject(shapes, new Circle(30));
            //Assert
            Assert.AreEqual(expectedResult, actualShapes);
        }

        [TestCase()]
        public void FindEqualsObjectsByObject_WhenInputIsCorrectFigures_ThenOutIsZeroFigures()
        {
            //Arrange
            List<BaseShape> expectedResult = new List<BaseShape>();
            //Act
            IEnumerable<BaseShape> shapes = new TxtShapeRepository(correctPathToTxtFile).GetShapeList();
            IEnumerable<BaseShape> actualShapes = ShapeService<BaseShape>.FindEqualsObjectsByObject(shapes, new Circle(300));
            //Assert
            Assert.AreEqual(expectedResult, actualShapes);
        }

        [TestCase()]
        public void FindEqualsObjectsByObject_WhenShapesIsNull_ThenOutIsNullReferenceException()
        {
            //Assert
            Assert.That(() => ShapeService<BaseShape>.FindEqualsObjectsByObject(null, new Circle(300)), Throws.TypeOf<System.NullReferenceException>());
        }

        [TestCase()]
        public void FindEqualsObjectsByObject_WhenBaseShapeIsNull_ThenOutIsNullReferenceException()
        {
            //Act
            IEnumerable<BaseShape> shapes = new TxtShapeRepository(correctPathToTxtFile).GetShapeList();
            //Assert
            Assert.That(() => ShapeService<BaseShape>.FindEqualsObjectsByObject(shapes, null), Throws.TypeOf<System.NullReferenceException>());
        }

        [TestCase()]
        public void FindEqualsObjectsByObject_WhenBaseShapeAndShapeIsNull_ThenOutIsNullReferenceException()
        {
            //Assert
            Assert.That(() => ShapeService<BaseShape>.FindEqualsObjectsByObject(null, null), Throws.TypeOf<System.NullReferenceException>());
        }
    }
}