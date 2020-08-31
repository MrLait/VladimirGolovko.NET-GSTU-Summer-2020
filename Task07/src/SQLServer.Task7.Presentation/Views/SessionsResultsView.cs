using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views
{
    /// <summary>
    /// Sessions results view.
    /// </summary>
    public class SessionsResultsView : BaseView
    {
        /// <summary>
        /// SessionName column.
        /// </summary>
        public string SessionName { get; private set; }

        /// <summary>
        /// GroupName column.
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// FirstName column.
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// LastName column.
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        /// MiddleName column.
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        /// SubjectName column.
        /// </summary>
        public string SubjectName { get; private set; }

        /// <summary>
        /// Value column.
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// Constructur without parameters.
        /// </summary>
        public SessionsResultsView() { }

        /// <summary>
        /// Constructor for initialazing view.
        /// </summary>
        /// <param name="view">View parameter.</param>
        public SessionsResultsView(IView view) : base(view) { }

        /// <summary>
        /// Constructor for initialazing view and singletonDboAccess.
        /// </summary>
        /// <param name="singletonDboAccess">SingletonDboAccess parameter.</param>
        /// <param name="view">View parameter.</param>
        public SessionsResultsView(SingletonDboAccess singletonDboAccess, IView view) : base(singletonDboAccess, view) { }

        /// <summary>
        /// Method for get view.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="groupName">Group name parameter.</param>
        /// <returns>Returns new view.</returns>
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

        /// <summary>
        /// Conver view to string.
        /// </summary>
        /// <param name="sessionResultView">Session result view parameter.</param>
        /// <returns>Returns string.</returns>
        public string ToString(IEnumerable<SessionsResultsView> sessionResultView)
        {
            string[] header = { "SessionName; GroupName; FirstName; LastName; MiddleName; SubjectName; Value" };
            string[] data = sessionResultView.Select(p => string.Format("{0}; {1}; {2}; {3}; {4}; {5}; {6}", p.SessionName, p.GroupName, p.FirstName, p.LastName, p.MiddleName, p.SubjectName, p.Value)).ToArray();

            return string.Join(System.Environment.NewLine, header.Concat(data));
            
        }


    }
}
