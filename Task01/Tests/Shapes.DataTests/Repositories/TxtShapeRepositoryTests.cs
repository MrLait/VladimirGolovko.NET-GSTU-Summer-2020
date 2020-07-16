using NUnit.Framework;
using Shapes.Data.Repositories;
using Shapes.Domain;
using System.Collections.Generic;

namespace Shapes.DataTests.Repositories
{
    /// <summary>
    /// Test cases to testing class TxtShapeRepository.
    /// </summary>
    [TestFixture()]
    public class TxtShapeRepositoryTests
    {
        private string _pathToTxtFilecCorrectFigures = @"fileData\correctFigures.txt";
        private string _pathToTxtFiletThreeDifferentShape = @"fileData\threeDifferentShape.txt";

        /// <summary>
        /// Test case to testing GetShapeLis method. 
        /// </summary>
        [TestCase()]
        public void GivenGetShapeList_WhenInputIsThreeDifferentShape_ThenOutIsEqual()
        {
            //Arrange
            List<BaseShape> expectedResult = new List<BaseShape> { new Rectangle(10, 20), new Circle(30), new Square(11) };
            //Act
            IEnumerable<BaseShape> actualResult = new TxtShapeRepository(_pathToTxtFiletThreeDifferentShape).GetShapeList();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Test case to testing GetShapeLis method.  
        /// </summary>
        [TestCase()]
        public void GivenGetShapeList_WhenInputIsThreeDifferentShape_ThenOutAreNotEqual()
        {
            //Arrange
            List<BaseShape> expectedResult = new List<BaseShape> { new Rectangle(10, 21), new Circle(30), new Square(11) };
            //Act
            IEnumerable<BaseShape> actualResult = new TxtShapeRepository(_pathToTxtFiletThreeDifferentShape).GetShapeList();
            //Assert
            Assert.AreNotEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Test case to testing GetShapeLis method.  
        /// </summary>
        [TestCase()]
        public void GivenGetShapeList_WhenInputIsCorrectFigures_ThenOutIsEqual()
        {
            //Arrange
            List<BaseShape> expectedResult = new List<BaseShape> {
                new Rectangle(10, 20),
                new Rectangle(10, 20),
                new Square(5.1),
                new Square(5.1),
                new Circle(30),
                new Rectangle(100, 30),
                new Rectangle(1000, 1),
                new Rectangle(11515, 21510),
                new Rectangle(13630, 264560),
                new Square(1.1),
                new Square(511.1),
                new Square(5123.1),
                new Square(125.1),
                new Circle(30),
                new Circle(30),
                new Circle(30),
                new Circle(30),
                new Circle(31),
                new Circle(100),
                new Rectangle(0, 0),
                new Square(0),
                new Circle( 0)
            };
            //Act
            IEnumerable<BaseShape> actualResult = new TxtShapeRepository(_pathToTxtFilecCorrectFigures).GetShapeList();
            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Test case to testing GetAllRow method.  
        /// </summary>
        /// <param name="pathToFile">Path to file.</param>
        [TestCase(@"fileData\figureWithEmptyName.txt")]
        [TestCase(@"fileData\figureWithEmptyParameter.txt")]
        [TestCase(@"fileData\figureWithStringParameter.txt")]
        [TestCase(@"fileData\differentText.txt")]
        public void GivenGetAllRow_WhenPathtToFileIsNotValid_ThenOutIsDirectoryNotFoundException(string pathToFile)
        {
            //Assert
            Assert.That(() => new TxtShapeRepository(pathToFile).GetShapeList(), Throws.TypeOf<System.FormatException>());
        }

    }
}
