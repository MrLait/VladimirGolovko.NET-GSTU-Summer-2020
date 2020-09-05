using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views
{
    public class AverageScoreBySpecialtyView : BaseView
    {
        public int SessionName { get; private set; }
        public string SpecialtyName { get; private set; }
        public double AverageValue { get; private set; }

        /// <inheritdoc/>
        public AverageScoreBySpecialtyView() { }

        /// <inheritdoc/>
        public AverageScoreBySpecialtyView(ITables view) : base(view) { }

        /// <inheritdoc/>
        public AverageScoreBySpecialtyView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess) { }

        public AverageScoreBySpecialtyView GetView(int sessionName, string specialtyName)
        {
            var scoreResultsBySpecialty =
                from itemSessionsResult in Tables.SessionsResults.Where(x => string.IsNullOrEmpty(x.Value) != true).AsEnumerable()
                join itemStudents in Tables.Students.AsEnumerable()
                    on itemSessionsResult.StudentsId equals itemStudents.Id
                join itemExamShedules in Tables.ExamSchedules.AsEnumerable()
                    on itemSessionsResult.ExamSchedulesId equals itemExamShedules.Id
                join itemGroups in Tables.Groups.AsEnumerable()
                    on itemStudents.GroupsId equals itemGroups.Id
                    join itemSpesialty in Tables.Specialties.Where(x => x.Name == specialtyName).AsEnumerable()
                        on itemGroups.SpecialtiesId equals itemSpesialty.Id
                join itemSessions in Tables.Sessions.Where(x => x.Name == sessionName).AsEnumerable()
                    on itemExamShedules.SessionsId equals itemSessions.Id
                join itemSubjects in Tables.Subjects.Where(x => x.IsAssessment == "True").AsEnumerable()
                    on itemExamShedules.SubjectsId equals itemSubjects.Id
                select new
                {
                    itemSessions.Name,
                    itemSessionsResult.Value
                };

            return new AverageScoreBySpecialtyView()
            {
                SessionName = sessionName,
                SpecialtyName = specialtyName,
                AverageValue = scoreResultsBySpecialty.Average(x => Convert.ToDouble(x.Value))
            };
        }

        /// <summary>
        /// Conver view to string.
        /// </summary>
        /// <param name="view">Aggregate operations view parameter.</param>
        /// <returns>Returns string.</returns>
        public string ToString(AverageScoreBySpecialtyView view)
        {
            string[] header = { "SessionName; SpecialtyName; AverageValue" };
            string[] data = { $"{view.SessionName}; {view.SpecialtyName}; {view.AverageValue.ToString()}" };

            return string.Join(Environment.NewLine, header.Concat(data));
        }

    }
}
