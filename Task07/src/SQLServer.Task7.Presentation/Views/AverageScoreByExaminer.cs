using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreByExaminer : BaseView
    {
        public AverageScoreByExaminer() { }

        public AverageScoreByExaminer(IView view) : base(view) { }

        public AverageScoreByExaminer(SingletonLinqToSql singletonDboAccess, IView view) : base(singletonDboAccess, view) { }

        public string SessionName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public double AverageValue { get; private set; }

        public AverageScoreByExaminer GetView(string sessionName, string firstName, string lastName, string middleName)
        {
            var scoreResultsByExaminer =
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
                join itemExaminers in View.Examiners
                    on itemSubjects.ExaminersId equals itemExaminers.Id
                    where itemExaminers.FirstName == firstName & itemExaminers.LastName == lastName
                    & itemExaminers.MiddleName == middleName
                where itemSessions.Name == sessionName & itemSubjects.IsAssessment == "True"
                    & string.IsNullOrEmpty(itemSessionsResult.Value) != true
                select new
                {
                    SessionName = itemSessions.Name,
                    FirstName = itemExaminers.FirstName,
                    LastName = itemExaminers.LastName,
                    MiddleName = itemExaminers.MiddleName,
                    itemSessionsResult.Value
                };

            return new AverageScoreByExaminer()
            {
                SessionName = sessionName,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                AverageValue = scoreResultsByExaminer.Average(x => Convert.ToDouble(x.Value))
            };

        }
    }
}
