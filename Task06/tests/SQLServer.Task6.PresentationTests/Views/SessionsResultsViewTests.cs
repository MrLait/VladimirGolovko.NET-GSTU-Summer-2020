using NUnit.Framework;
using SQLServer.Task6.PresentationTests;
using SQLServer.Task6.PresentationTests.TestCaseSources;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task6.Presentation.Views.Tests
{
    [TestFixture()]
    public class SessionsResultsViewTests : MockBaseView
    {
        [Test, TestCaseSource(typeof(MyFactorySessionsResultsViewTests), "GiveToString_WhenNoOrdered_ThenOutIsToString")]
        public string GiveToString_WhenNoOrdered_ThenOutIsToString(string sessionName, string groupName)
        {
            //Arrange
            SessionsResultsView sessionsResultsView = new SessionsResultsView(Mock.Object);
            //Act
            IEnumerable<SessionsResultsView> actual = sessionsResultsView.GetView(sessionName, groupName).ToList();
            var actualString = sessionsResultsView.ToString(actual);
            return actualString;
        }

        [Test, TestCaseSource(typeof(MyFactorySessionsResultsViewTests), "GiveToString_WhenOrderByDescendingFirstNameAndValue_ThenOutIsToStringOrderBy")]
        public string GiveToString_WhenOrderByDescendingFirstNameAndValue_ThenOutIsToStringOrderBy(string sessionName, string groupName)
        {
            //Arrange
            SessionsResultsView sessionsResultsView = new SessionsResultsView(Mock.Object);
            //Act
            var actual = sessionsResultsView.GetView(sessionName, groupName).ToList().OrderByDescending(f => f.FirstName).ThenByDescending(v => v.Value);
            var actualString = sessionsResultsView.ToString(actual);
            return actualString;
        }
    }
}