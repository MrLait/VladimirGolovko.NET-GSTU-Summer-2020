using DAO.DataAccess.Singleton;
using SQLServer.Task7.Presentation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLServer.Task7.Presentation.Views
{
    /// <summary>
    /// Students to be expelled view.
    /// </summary>
    public class StudentsToBeExpelledView : BaseView
    {
        /// <summary>
        /// StudentId column.
        /// </summary>
        public int StudentId { get; private set; }

        /// <summary>
        /// SessionName column.
        /// </summary>
        public int SessionName { get; private set; }

        /// <summary>
        /// GroupName column.
        /// </summary>
        public string GroupName { get; private set; }

        /// <summary>
        ///  column.
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
        /// Constructur without parameters.
        /// </summary>
        public StudentsToBeExpelledView() { }

        /// <summary>
        /// Constructor for initialazing view.
        /// </summary>
        /// <param name="tables">View parameter.</param>
        public StudentsToBeExpelledView(ITables tables) : base(tables) { }

        /// <summary>
        /// Constructor for initialazing view and singletonDboAccess.
        /// </summary>
        /// <param name="singletonDboAccess">SingletonDboAccess parameter.</param>
        public StudentsToBeExpelledView(SingletonLinqToSql singletonDboAccess) : base(singletonDboAccess) { }

        /// <summary>
        /// Method for get view.
        /// </summary>
        /// <param name="sessionName">Session name parameter.</param>
        /// <param name="minPassingGrade">Session minimum passing grade parameter.</param>
        /// <returns>Returns new view.</returns>
        public IEnumerable<IGrouping<string, StudentsToBeExpelledView>> GetView(int sessionName, int minPassingGrade)
        {
            IEnumerable<StudentsToBeExpelledView> studentsToBeExpelled =
                (from itemSessionsResult in Tables.SessionsResults.AsEnumerable()
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
                 where itemSessions.Name == sessionName & itemSubjects.IsAssessment == "True"
                     & itemSessionsResult.Value != string.Empty
                 where Convert.ToInt32(itemSessionsResult.Value) < minPassingGrade
                 select new StudentsToBeExpelledView
                 {
                     StudentId = itemStudents.Id,
                     SessionName = itemSessions.Name,
                     GroupName = itemGroups.Name,
                     FirstName = itemStudents.FirstName,
                     LastName = itemStudents.LastName,
                     MiddleName = itemStudents.MiddleName
                 }).GroupBy(x => x.StudentId).Select(y => y.First());

            var studentsToBeExpelledGroupedByGroup =
                from itemStudentsToBeExpelled in studentsToBeExpelled
                group itemStudentsToBeExpelled by itemStudentsToBeExpelled.GroupName;

            return studentsToBeExpelledGroupedByGroup;
        }

        /// <summary>
        /// Conver view to string.
        /// </summary>
        /// <param name="studentsToBeExpelledGrouped">Students to be expelled grouped parameter.</param>
        /// <returns>Returns string.</returns>
        public string ToString(IEnumerable<IEnumerable<StudentsToBeExpelledView>> studentsToBeExpelledGrouped)
        {
            string[] header = { "StudentId; SessionName; GroupName; FirstName; LastName; MiddleName" };
            var dataArray = studentsToBeExpelledGrouped.ToArray();
            var appendedLine = new StringBuilder().AppendLine(string.Concat(header));
            
            for (int i = 0; i < dataArray.Length; i++)
            {
                var elementsInArrCount = dataArray[dataArray.Length - 1].ToList().Count;
                int curElementIndex = default;

                foreach (var item in dataArray[i])
                {
                    if (i == dataArray.Length - 1)
                    {
                        if (curElementIndex == elementsInArrCount - 1)
                            appendedLine.Append($"{item.StudentId}; {item.SessionName}; {item.GroupName}; {item.FirstName}; {item.LastName}; {item.MiddleName}");
                        else
                            appendedLine.AppendLine($"{item.StudentId}; {item.SessionName}; {item.GroupName}; {item.FirstName}; {item.LastName}; {item.MiddleName}");
                        curElementIndex++;
                    }
                    else
                    {
                        appendedLine.AppendLine($"{item.StudentId}; {item.SessionName}; {item.GroupName}; {item.FirstName}; {item.LastName}; {item.MiddleName}");
                    }
                }
            }
            return appendedLine.ToString();
        }
    }
}
