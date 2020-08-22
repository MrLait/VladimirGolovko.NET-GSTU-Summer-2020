using DAO.DataAccess.Singleton;
using System.Linq;

namespace SQLServer.Task6.ReportManager.Presentation.Reports
{
    public class SessionSummaryReports
    {
        public SingletonDboAccess SingletonDboAccess { get; set; }

        public SessionSummaryReports(SingletonDboAccess singletonDboAccess)
        {
            SingletonDboAccess = singletonDboAccess;
        }

        public void GetReport()
        {
            var groups = SingletonDboAccess.RepositoryFactory.CreateGroups().GetAll();
            var sessions = SingletonDboAccess.RepositoryFactory.CreateSessions().GetAll();
            var students = SingletonDboAccess.RepositoryFactory.CreateStudents().GetAll();
            var examSchedules = SingletonDboAccess.RepositoryFactory.CreateExamSchedules().GetAll();
            var sessionsResults = SingletonDboAccess.RepositoryFactory.CreateSessionsResults().GetAll();
            var subjects = SingletonDboAccess.RepositoryFactory.CreateSubjects().GetAll();

            var studentsView =
                from itemS in students
                join itemG in groups
                    on itemS.GroupsID equals itemG.Id
                select new { itemS.Id, itemS.FirstName, itemS.LastName, itemS.MiddleName, GroupName = itemG.Name };

            var examShedulesView =
                from itemExamShedudels in examSchedules
                join itemSes in sessions
                    on itemExamShedudels.SessionsId equals itemSes.Id
                join itemG in groups
                    on itemExamShedudels.GroupsId equals itemG.Id
                join itemSub in subjects
                    on itemExamShedudels.SubjectsId equals itemSub.Id
                select new { itemExamShedudels.Id, SessionName = itemSes.Name, GroupName = itemG.Name, SubjectName = itemSub.Name, itemSub.IsAssessment };

            var sessionsResultsView =
                from itemSessionsResult in sessionsResults
                join itemStudents in students
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in examSchedules
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemG in groups
                    on itemStudents.GroupsID equals itemG.Id
                join itemSes in sessions
                    on itemExamShedules.SessionsId equals itemSes.Id
                join itemSub in subjects
                    on itemExamShedules.SubjectsId equals itemSub.Id
                select new {itemSessionsResult.Id, SessionName = itemSes.Name, GroupName = itemG.Name, itemStudents.FirstName, itemStudents.LastName,
                    itemStudents.MiddleName, SubjectName = itemSub.Name, itemSessionsResult.Value };
            var ses = sessionsResultsView.OrderBy(x => x.SessionName).ThenBy(x => x.GroupName);
        }
    }
}
