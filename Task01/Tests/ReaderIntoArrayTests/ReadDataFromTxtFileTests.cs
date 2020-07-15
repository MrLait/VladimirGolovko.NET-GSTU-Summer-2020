using NUnit.Framework;
using Shape.Data.Repositories;
using Shapes.Domain;
using System.Collections.Generic;

namespace ReaderIntoArray.Tests
{
    [TestFixture()]
    public class ReadDataFromTxtFileTests
    {
        private string correctPathToTxtFile = @"Task01\fileData\correctFigures.txt";
        private string notValidPathToTxtFile = @"src\ReaderIntoArray\txtFile\figuress.txt";

       // [TestCase()]
       // public void GivenStringsProperty_WhenPathtToFileIsTrue_ThenOutIsTrue()
       // {
       //     //Arrange
       //     ConvertStringToArray convertStringToArr = new ConvertStringToArray(new TxtFileContextRepository(correctPathToTxtFile));
       //     //Act
       //     var actualArray = convertStringToArr.Strings;
       //     string[] expectedResult = new string[] { "Rectangle; 10; 20;", "Square; 5;", "Circle; 30;" };
       //     //Assert
       //     Assert.AreEqual(expectedResult, actualArray);
       // }

       // [TestCase()]
       // public void GivenStringsProperty_WhenPathtToFileIsNotValid_ThenOutIsFileNotFoundException()
       // {
       //     //Assert
       //     Assert.That(() => new ConvertStringToArray(new TxtFileContextRepository(notValidPathToTxtFile)), Throws.TypeOf<System.IO.FileNotFoundException>());
       // }

        [TestCase()]
        public void JustForTest()
        {
            BaseShape[] shapeArray = new BaseShape[] { new Circle(10), new Square(10), new Rectangle(10,20) };

            TxtShapeRepository txtShapeRepository = new TxtShapeRepository(correctPathToTxtFile);

            IEnumerable<BaseShape> test = txtShapeRepository.GetShapeList();


        }


    }
}