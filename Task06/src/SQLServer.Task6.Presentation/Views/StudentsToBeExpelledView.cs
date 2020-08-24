using DAO.DataAccess.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLServer.Task6.Presentation.Views
{
    public class StudentsToBeExpelledView : BaseView
    {
        public int StudentId { get; private set; }
        public string SessionName { get; private set; }
        public string GroupName { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }

        public StudentsToBeExpelledView() { }

        public StudentsToBeExpelledView(SingletonDboAccess singletonDboAccess) : base(singletonDboAccess) { }

        public IEnumerable<IGrouping<string, StudentsToBeExpelledView>> GetView(string sessionName, int minPassingGrade)
        {
            IEnumerable<StudentsToBeExpelledView> studentsToBeExpelled =
                (from itemSessionsResult in SessionsResults
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
                where itemSessions.Name == sessionName & itemSubjects.IsAssessment == "True"
                    & itemSessionsResult.Value != string.Empty //& Convert.ToInt32(itemSessionsResult.Value) < minPassingGrade
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

        public string ToString(IEnumerable<IOrderedEnumerable<StudentsToBeExpelledView>> studentsToBeExpelledGrouped)
        {
            string[] header = { "StudentId; SessionName; GroupName; FirstName; LastName; MiddleName" };
            var dataArray = studentsToBeExpelledGrouped.ToArray();
            var appendedLine = new StringBuilder().AppendLine(string.Concat(header));

            for (int i = 0; i < dataArray.Length; i++)
            {
                foreach (var item in dataArray[i])
                    appendedLine.AppendLine($"{item.StudentId}; {item.SessionName}; {item.GroupName}; {item.FirstName}; {item.LastName}; {item.MiddleName}");
            }

            return appendedLine.ToString();
        }
    }
}
