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

        public AverageScoreByExaminer(ITables view) : base(view) { }

        public AverageScoreByExaminer(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess) { }

        public int SessionName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public double AverageValue { get; private set; }

        public AverageScoreByExaminer GetView(int sessionName, string firstName, string lastName, string middleName)
        {
            var scoreResultsByExaminer =
                from itemSessionsResult in Tables.SessionsResults.AsEnumerable()
                join itemStudents in Tables.Students.AsEnumerable()
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in Tables.ExamSchedules.AsEnumerable()
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemGroups in Tables.Groups.AsEnumerable()
                    on itemStudents.GroupsId equals itemGroups.Id
                join itemSessions in Tables.Sessions.AsEnumerable()
                    on itemExamShedules.SessionsId equals itemSessions.Id
                join itemSubjects in Tables.Subjects.AsEnumerable()
                    on itemExamShedules.SubjectsId equals itemSubjects.Id
                join itemExaminers in Tables.Examiners.AsEnumerable()
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
