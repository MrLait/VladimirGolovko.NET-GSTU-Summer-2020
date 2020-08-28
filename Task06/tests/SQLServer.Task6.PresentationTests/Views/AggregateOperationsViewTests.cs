using Moq;
using NUnit.Framework;
using SQLServer.Task6.PresentationTests;
using SQLServer.Task6.PresentationTests.TestCaseSources;

namespace SQLServer.Task6.Presentation.Views.Tests
{
    [TestFixture()]
    public class AggregateOperationsViewTests : MockBaseView
    {
        [TestCase("1", "PM-1", 97)]
        [TestCase("1", "PM-2", 64)]
        [TestCase("2", "PM-1", 94)]
        [TestCase("2", "PM-2", 38)]
        public void GiveGetView_WhenMaxValue_ThenOutIsMaxValue(string sessionName, string groupName, int expected)
        {
            //Arrange
            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(Mock.Object);
            //Act
            var actual = aggregateOperationsView.GetView(sessionName, groupName).MaxValue;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", "PM-1", 27)]
        [TestCase("1", "PM-2", 16)]
        [TestCase("2", "PM-1", 3)]
        [TestCase("2", "PM-2", 5)]
        public void GiveGetView_WhenMinValue_ThenOutIsMinValue(string sessionName, string groupName, int expected)
        {
            //Arrange
            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(Mock.Object);
            //Act
            var actual = aggregateOperationsView.GetView(sessionName, groupName).MinValue;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", "PM-1", 58.399999999999999)]
        [TestCase("1", "PM-2", 37.0)]
        [TestCase("2", "PM-1", 51.75)]
        [TestCase("2", "PM-2", 19.5)]
        public void GiveGetView_WhenAverageValue_ThenOutIsAverageValue(string sessionName, string groupName, double expected)
        {
            //Arrange
            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(Mock.Object);
            //Act
            var actual = aggregateOperationsView.GetView(sessionName, groupName).AverageValue;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", "PM-1", "1")]
        [TestCase("1", "PM-2", "1")]
        [TestCase("2", "PM-1", "2")]
        [TestCase("2", "PM-2", "2")]
        public void GiveGetView_WhenSessionName_ThenOutIsSessionName(string sessionName, string groupName, string expected)
        {
            //Arrange
            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(Mock.Object);
            //Act
            var actual = aggregateOperationsView.GetView(sessionName, groupName).SessionName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase("1", "PM-1", "PM-1")]
        [TestCase("1", "PM-2", "PM-2")]
        [TestCase("2", "PM-1", "PM-1")]
        [TestCase("2", "PM-2", "PM-2")]
        public void GiveGetView_WhenGroupName_ThenOutIsGroupName(string sessionName, string groupName, string expected)
        {
            //Arrange
            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(Mock.Object);
            //Act
            var actual = aggregateOperationsView.GetView(sessionName, groupName).GroupName;
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(MyFactoryAggregateOperationsViewTests), "GiveToString_ThenOutIsToString")]
        public string GiveToString_ThenOutIsToString(string sessionName, string groupName)
        {
            //Arrange
            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(Mock.Object);
            //Act
            var actual = aggregateOperationsView.GetView(sessionName, groupName);
            var actualString = aggregateOperationsView.ToString(actual);
            return actualString;
        }
    }
}