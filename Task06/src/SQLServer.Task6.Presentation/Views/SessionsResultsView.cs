using DAO.DataAccess.Singleton;
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

        public SessionsResultsView(SingletonDboAccess singletonDboAccess) : base(singletonDboAccess) { }

        public IEnumerable<SessionsResultsView> GetView(string sessionName, string groupName)
        {
            IEnumerable<SessionsResultsView> sessionsResultsView =
                from itemSessionsResult in SessionsResults
                join itemStudents in Students
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in ExamSchedules
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemGroups in Groups
                    on itemStudents.GroupsID equals itemGroups.Id
                join itemSessions in Sessions
                    on itemExamShedules.SessionsId equals itemSessions.Id
                join itemSubjects in Subjects
                    on itemExamShedules.SubjectsId equals itemSubjects.Id
                where itemSessions.Name == sessionName & itemGroups.Name == groupName
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

        public string ToString(IOrderedEnumerable<SessionsResultsView> sessionResultView)
        {
            string[] header = { "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value" };
            string[] data = sessionResultView.Select(p => string.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}", p.SessionName, p.GroupName, p.FirstName, p.LastName, p.MiddleName, p.SubjectName, p.Value)).ToArray();

            return string.Join(System.Environment.NewLine, header.Concat(data));
            
        }


    }
}
