using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreSubjectByYearsView : BaseView
    {
        public string SubjectName { get; set; }
        public int Year { get; set; }
        public double AverageValue { get; set; }

        public AverageScoreSubjectByYearsView()
        {
        }

        public AverageScoreSubjectByYearsView(ITables view) : base(view)
        {
        }

        public AverageScoreSubjectByYearsView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess)
        {
        }

        public IEnumerable<AverageScoreSubjectByYearsView> GetView(string subjectName)
        {
            var scoreResultsBySubjectByYears =
                (from itemSessionsResult in Tables.SessionsResults.Where(x => string.IsNullOrEmpty(x.Value) != true).AsEnumerable()
                 join itemStudents in Tables.Students.AsEnumerable()
                     on itemSessionsResult.StudentsId equals itemStudents.Id
                 join itemExamShedules in Tables.ExamSchedules.AsEnumerable()
                     on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                 join itemGroups in Tables.Groups.AsEnumerable()
                     on itemStudents.GroupsId equals itemGroups.Id
                 join itemSpesialty in Tables.Specialties.AsEnumerable()
                     on itemGroups.SpecialtiesId equals itemSpesialty.Id
                 join itemSessions in Tables.Sessions.AsEnumerable()
                     on itemExamShedules.SessionsId equals itemSessions.Id
                 join itemSubjects in Tables.Subjects.Where(x => x.IsAssessment == "True" & x.Name == subjectName).AsEnumerable()
                     on itemExamShedules.SubjectsId equals itemSubjects.Id
                 select new
                 {
                     Id = itemSubjects.Id,
                     Name = itemSubjects.Name,
                     Year = itemExamShedules.ExamDate.Year,
                     Value = itemSessionsResult.Value
                 })
                 .GroupBy(x => new { x.Id, x.Name, x.Year })
                 .Select( y => new { Name = y.Key.Name, Year = y.Key.Year, AverageValue = y.Average(a => Convert.ToDouble(a.Value)) });

            return scoreResultsBySubjectByYears
                .Select(x => new AverageScoreSubjectByYearsView { SubjectName = x.Name, AverageValue = x.AverageValue, Year = x.Year });
        }

        /// <summary>
        /// Conver view to string.
        /// </summary>
        /// <param name="view">Aggregate operations view parameter.</param>
        /// <returns>Returns string.</returns>
        public string ToString(IEnumerable<AverageScoreSubjectByYearsView> view)
        {
            string[] header = { "SubjectName; Year; AverageValue"};
            string[] data = view.Select(p => string.Format("{0}; {1}; {2}", p.SubjectName, p.Year, p.AverageValue)).ToArray();

            return string.Join(Environment.NewLine, header.Concat(data));
        }

    }
}
