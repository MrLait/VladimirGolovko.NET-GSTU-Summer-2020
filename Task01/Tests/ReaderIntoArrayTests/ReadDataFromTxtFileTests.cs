using NUnit.Framework;
using ReaderIntoArray.Model;
using ReaderIntoArray.Repositories;

namespace ReaderIntoArray.Tests
{
    [TestFixture()]
    public class ReadDataFromTxtFileTests
    {
        private string correctPathToTxtFile = @"src\ReaderIntoArray\txtFile\figures.txt";
        private string notValidPathToTxtFile = @"src\ReaderIntoArray\txtFile\figuress.txt";

        [TestCase()]
        public void GivenStringsProperty_WhenPathtToFileIsTrue_ThenOutIsTrue()
        {
            //Arrange
            ConvertStringToArray convertStringToArr = new ConvertStringToArray(new ReadDataFromTxtFileRepository(correctPathToTxtFile));
            //Act
            var actualArray = convertStringToArr.Strings;
            string[] expectedResult = new string[] { "Rectangle; 10; 20;", "Square; 5;", "Circle; 30;" };
            //Assert
            Assert.AreEqual(expectedResult, actualArray);
        }

        [TestCase()]
        public void GivenStringsProperty_WhenPathtToFileIsNotValid_ThenOutIsFileNotFoundException()
        {
            //Assert
            Assert.That(() => new ConvertStringToArray(new ReadDataFromTxtFileRepository(notValidPathToTxtFile)), Throws.TypeOf<System.IO.FileNotFoundException>());
        }
    }
}