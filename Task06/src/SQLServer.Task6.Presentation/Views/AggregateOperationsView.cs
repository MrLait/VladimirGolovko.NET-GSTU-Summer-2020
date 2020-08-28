using DAO.DataAccess.Singleton;
using SQLServer.Task6.Presentation.Interfaces;
using System;
using System.Linq;

namespace SQLServer.Task6.Presentation.Views
{
    public class AggregateOperationsView : BaseView
    {
        public string SessionName { get; private set; }
        public string GroupName { get; private set; }

        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public double AverageValue { get; set; }

        public AggregateOperationsView() { }
        public AggregateOperationsView(IView view) : base(view){}
        public AggregateOperationsView(SingletonDboAccess singletonDboAccess, IView view) : base(singletonDboAccess, view) { }

        public AggregateOperationsView GetView(string sessionName, string groupName)
        {
            var aggregateValue =
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
                where itemSessions.Name == sessionName & itemGroups.Name == groupName & itemSubjects.IsAssessment == "True"
                    & string.IsNullOrEmpty(itemSessionsResult.Value) != true
                select new 
                {
                    SessionName = itemSessions.Name,
                    GroupName = itemGroups.Name,
                    Value = itemSessionsResult.Value
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

        public string ToString(AggregateOperationsView view)
        {
            string[] header = { "SessionName; GroupName; AverageValue; MaxValue; MinValue" };
            string[] data = { $"{view.SessionName}; {view.GroupName}; {view.AverageValue.ToString()}; {view.MaxValue.ToString()}; {view.MinValue.ToString()}" };

            return string.Join(System.Environment.NewLine, header.Concat(data));

        }

    }
}
