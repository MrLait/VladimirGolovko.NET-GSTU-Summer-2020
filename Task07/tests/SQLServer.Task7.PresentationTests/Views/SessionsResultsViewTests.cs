using NUnit.Framework;
using SQLServer.Task7.PresentationTests;
using SQLServer.Task7.PresentationTests.TestCaseSources;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views.Tests
{
    /// <summary>
    /// Test cases for Sessions results view. 
    /// </summary>
    [TestFixture()]
    public class SessionsResultsViewTests : MockBaseView
    {
        /// <summary>
        /// Test for sessions results view no ordered.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="groupName">Group name parameter.</param>
        /// <returns>Returns string.</returns>
        [Test, TestCaseSource(typeof(MyFactorySessionsResultsViewTests), "GiveToString_WhenNoOrdered_ThenOutIsToString")]
        public string GiveToString_WhenNoOrdered_ThenOutIsToString(int sessionName, string groupName)
        {
            //Arrange
            SessionsResultsView sessionsResultsView = new SessionsResultsView(Mock.Object);
            //Act
            IEnumerable<SessionsResultsView> actual = sessionsResultsView.GetView(sessionName, groupName).ToList();
            var actualString = sessionsResultsView.ToString(actual);
            return actualString;
        }

        /// <summary>
        /// Test for sessions results view ordered by descending first name and value.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="groupName">Group name parameter.</param>
        /// <returns>Returns string.</returns>
        [Test, TestCaseSource(typeof(MyFactorySessionsResultsViewTests), "GiveToString_WhenOrderByDescendingFirstNameAndValue_ThenOutIsToStringOrderBy")]
        public string GiveToString_WhenOrderByDescendingFirstNameAndValue_ThenOutIsToStringOrderBy(int sessionName, string groupName)
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