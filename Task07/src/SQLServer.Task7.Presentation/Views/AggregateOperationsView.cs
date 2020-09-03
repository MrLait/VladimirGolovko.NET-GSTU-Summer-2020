using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views
{
    /// <summary>
    /// Aggregate operations view.
    /// </summary>
    public class AggregateOperationsView : BaseView
    {
        /// <summary>
        /// SessionName column.
        /// </summary>
        public int SessionName { get; private set; }

        /// <summary>
        /// GroupName column.
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        /// MaxValue column.
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// MinValue column.
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// AverageValue column.
        /// </summary>
        public double AverageValue { get; set; }

        /// <summary>
        /// Constructur without parameters.
        /// </summary>
        public AggregateOperationsView() { }

        /// <summary>
        /// Constructor for initialazing view.
        /// </summary>
        /// <param name="tables">View parameter.</param>
        public AggregateOperationsView(ITables tables) : base(tables) { }

        /// <summary>
        /// Constructor for initialazing view and singletonDboAccess.
        /// </summary>
        /// <param name="singletonDboAccess">SingletonDboAccess parameter.</param>
        public AggregateOperationsView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess) { }

        /// <summary>
        /// Method for get view.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="groupName">Group name parameter.</param>
        /// <returns>Returns new view.</returns>
        public AggregateOperationsView GetView(int sessionName, string groupName)
        {

            var aggregateValue =
                from itemSessionsResult in Tables.SessionsResults.Where(x => string.IsNullOrEmpty(x.Value) != true).AsEnumerable()
                join itemStudents in Tables.Students.AsEnumerable()
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in Tables.ExamSchedules.AsEnumerable()
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemGroups in Tables.Groups.Where(x => x.Name == groupName).AsEnumerable()
                    on itemStudents.GroupsId equals itemGroups.Id
                join itemSessions in Tables.Sessions.Where(x => x.Name == sessionName).AsEnumerable()
                    on itemExamShedules.SessionsId equals itemSessions.Id
                join itemSubjects in Tables.Subjects.Where(x => x.IsAssessment == "True").AsEnumerable()
                    on itemExamShedules.SubjectsId equals itemSubjects.Id
                select new
                {
                    SessionName = itemSessions.Name,
                    GroupName = itemGroups.Name,
                    itemSessionsResult.Value
                };

            return new AggregateOperationsView()
            {
                SessionName = sessionName,
                GroupName = groupName,
                AverageValue = aggregateValue.Average(x => Convert.ToDouble(x.Value)),
                MaxValue = aggregateValue.Max(x => Convert.ToInt32(x.Value)),
                MinValue = aggregateValue.Min(x => Convert.ToInt32(x.Value))
            };
        }

        /// <summary>
        /// Conver view to string.
        /// </summary>
        /// <param name="view">Aggregate operations view parameter.</param>
        /// <returns>Returns string.</returns>
        public string ToString(AggregateOperationsView view)
        {
            string[] header = { "SessionName; GroupName; AverageValue; MaxValue; MinValue" };
            string[] data = { $"{view.SessionName}; {view.GroupName}; {view.AverageValue.ToString()}; {view.MaxValue.ToString()}; {view.MinValue.ToString()}" };

            return string.Join(Environment.NewLine, header.Concat(data));
        }
    }
}
