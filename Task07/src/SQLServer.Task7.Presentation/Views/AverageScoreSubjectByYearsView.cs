using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views
{
    /// <summary>
    /// Class to view average score subject by years.
    /// </summary>
    public class AverageScoreSubjectByYearsView : BaseView
    {
        /// <summary>
        /// SubjectName property.
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Year property.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// AverageValue property.
        /// </summary>
        public double AverageValue { get; set; }

        /// <inheritdoc/>
        public AverageScoreSubjectByYearsView(){ }

        /// <inheritdoc/>
        public AverageScoreSubjectByYearsView(ITables view) : base(view){}

        /// <inheritdoc/>
        public AverageScoreSubjectByYearsView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess){}

        /// <summary>
        /// Get view method.
        /// </summary>
        /// <param name="subjectName">Subject name.</param>
        /// <returns>Returns view.</returns>
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
                     itemSubjects.Id,
                     itemSubjects.Name,
                     itemExamShedules.ExamDate.Year,
                     itemSessionsResult.Value
                 })
                 .GroupBy(x => new { x.Id, x.Name, x.Year })
                 .Select( y => new { y.Key.Name, y.Key.Year, AverageValue = y.Average(a => Convert.ToDouble(a.Value)) });

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
