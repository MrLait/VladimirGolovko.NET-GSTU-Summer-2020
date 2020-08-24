using DAO.DataAccess.Singleton;
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

        public AggregateOperationsView(SingletonDboAccess singletonDboAccess) : base(singletonDboAccess) { }

        public AggregateOperationsView GetView(string sessionName, string groupName)
        {
            var aggregateValue =
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
                where itemSessions.Name == sessionName & itemGroups.Name == groupName & itemSubjects.IsAssessment == "True"
                    & itemSessionsResult.Value != string.Empty
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
