using DAO.DataAccess.Singleton;
using SQLServer.Task6.Presentation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task6.Presentation.Views
{
    public class SessionsResultsView : BaseView
    {
        public string SessionName { get; private set; }
        public string GroupName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string SubjectName { get; private set; }
        public string Value { get; private set; }

        public SessionsResultsView() { }
        public SessionsResultsView(IView view) : base(view) { }
        public SessionsResultsView(SingletonDboAccess singletonDboAccess, IView view) : base(singletonDboAccess, view) { }

        public IEnumerable<SessionsResultsView> GetView(string sessionName, string groupName)
        {
            IEnumerable<SessionsResultsView> sessionsResultsView =
                from itemSessionsResult in View.SessionsResults
                join itemStudents in View.Students
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in View.ExamSchedules
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemGroups in View.Groups
                    on itemStudents.GroupsId equals itemGroups.Id
                join itemSessions in View.Sessions
                    on itemExamShedules.SessionsId equals itemSessions.Id
                join itemSubjects in View.Subjects
                    on itemExamShedules.SubjectsId equals itemSubjects.Id
                where itemSessions.Name == sessionName & itemGroups.Name == groupName & string.IsNullOrEmpty(itemSessionsResult.Value) != true
                select new SessionsResultsView
                {
                    SessionName = itemSessions.Name,
                    GroupName = itemGroups.Name,
                    FirstName = itemStudents.FirstName,
                    LastName = itemStudents.LastName,
                    MiddleName = itemStudents.MiddleName,
                    SubjectName = itemSubjects.Name,
                    Value = itemSessionsResult.Value
                };

            return sessionsResultsView;
        }

        public string ToString(IEnumerable<SessionsResultsView> sessionResultView)
        {
            string[] header = { "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value" };
            string[] data = sessionResultView.Select(p => string.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}", p.SessionName, p.GroupName, p.FirstName, p.LastName, p.MiddleName, p.SubjectName, p.Value)).ToArray();

            return string.Join(System.Environment.NewLine, header.Concat(data));
            
        }


    }
}
