using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreByExaminerView : BaseView
    {
        public AverageScoreByExaminerView() { }

        public AverageScoreByExaminerView(ITables view) : base(view) { }

        public AverageScoreByExaminerView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess) { }

        public int SessionName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public double AverageValue { get; private set; }

        public AverageScoreByExaminerView GetView(int sessionName, string firstName, string lastName, string middleName)
        {
            var scoreResultsByExaminer =
                from itemSessionsResult in Tables.SessionsResults.Where(x => string.IsNullOrEmpty(x.Value) != true).AsEnumerable()
                join itemStudents in Tables.Students.AsEnumerable()
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in Tables.ExamSchedules.AsEnumerable()
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemGroups in Tables.Groups.AsEnumerable()
                    on itemStudents.GroupsId equals itemGroups.Id
                join itemSessions in Tables.Sessions.Where(x => x.Name == sessionName).AsEnumerable()
                    on itemExamShedules.SessionsId equals itemSessions.Id
                join itemSubjects in Tables.Subjects.Where(x => x.IsAssessment == "True").AsEnumerable()
                    on itemExamShedules.SubjectsId equals itemSubjects.Id
                join itemExaminers in Tables.Examiners.Where(x => x.FirstName == firstName & x.LastName == lastName & x.MiddleName == middleName).AsEnumerable()
                    on itemSubjects.ExaminersId equals itemExaminers.Id
                select new
                {
                    itemSessions.Name,
                    itemExaminers.FirstName,
                    itemExaminers.LastName,
                    itemExaminers.MiddleName,
                    itemSessionsResult.Value
                };

            return new AverageScoreByExaminerView()
            {
                SessionName =  sessionName,
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                AverageValue = scoreResultsByExaminer.Average(x => Convert.ToDouble(x.Value))
            };
        }

        /// <summary>
        /// Conver view to string.
        /// </summary>
        /// <param name="view">Aggregate operations view parameter.</param>
        /// <returns>Returns string.</returns>
        public string ToString(AverageScoreByExaminerView view)
        {
            string[] header = { "SessionName; FirstName; LastName; MiddleName; AverageValue" };
            string[] data = { $"{view.SessionName}; {view.FirstName}; {view.LastName}; {view.MiddleName}; {view.AverageValue.ToString()};" };

            return string.Join(Environment.NewLine, header.Concat(data));
        }
    }
}
