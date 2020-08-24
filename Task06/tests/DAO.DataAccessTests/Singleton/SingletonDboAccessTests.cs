using NUnit.Framework;
using DAO.DataAccess.Factory;
using System.Linq;
using System.IO;
using SQLServer.Task6.Presentation.Views;
using SQLServer.Task6.CvsReportManager.Services;
using SQLServer.Task6.CvsReportManager.Services.Utils;

namespace DAO.DataAccess.Singleton.Tests
{
    [TestFixture()]
    public class SingletonDboAccessTests
    {
        [Test()]
        public void GetInstanceTest()
        {
            var dbConnString = @"Data Source=LAIT-PC\SQLEXPRESS;Initial Catalog=SQLServer.Task6.Database;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SingletonDboAccess test = SingletonDboAccess.GetInstance(new ADORepositoryFactory(dbConnString));

            //test.AbstractFactory.CreateGroups().Add(
            //    new Groups()
            //    { Name = "1" });

            //test.AbstractFactory.CreateStudents().Add(
            //    new Students() 
            //    { 
            //        LastName = "asda", DateOfBirthday =DateTime.Now, FirstName ="firs",
            //        Gender = "ASd", GroupsID = 1, MiddleName = "asd", Id = 0
            //    });


            //var testGetAllGroups = test.RepositoryFactory.CreateGroups().GetAll();
            //var testGetAllStudents = test.RepositoryFactory.CreateStudents().GetAll();
            //var testGetAllSessionResults = test.RepositoryFactory.CreateSessionsResults().GetAll();

            //var testGetByIdGroup = test.RepositoryFactory.CreateGroups().GetByID(5);

            //test.RepositoryFactory.CreateGroups().Update(new Groups() { Id = 2, Name = "LOL" });
            //test.RepositoryFactory.CreateGroups().Delete(4);

            SessionsResultsView sessionsResultsView = new SessionsResultsView(test);
            IOrderedEnumerable<SessionsResultsView> sessionResultView = sessionsResultsView.GetView("1", "PM-1").ToList().OrderBy(x => x.SessionName).ThenBy(x => x.GroupName);

            AggregateOperationsView aggregateOperationsView = new AggregateOperationsView(test);
            var aggragateValue =  aggregateOperationsView.GetView("1", "PM-1");


            //sessionsResultsView.order

            string testStr = sessionsResultsView.ToString(sessionResultView);

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var path = Path.GetDirectoryName(location);


            CvsReportManager excelReportManager = new CvsReportManager(new Excel(path, "Test"), testStr, ';');
            excelReportManager.Print();

            excelReportManager.CvsText = aggregateOperationsView.ToString(aggragateValue);
            excelReportManager.Printer = new Excel(path, "Test2");
            excelReportManager.Print();
        }
    }
}