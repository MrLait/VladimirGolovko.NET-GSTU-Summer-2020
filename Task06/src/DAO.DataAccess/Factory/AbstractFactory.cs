using DAO.DataAccess.Interfaces;
using SQLServer.Task6.Domain.Models;

namespace DAO.DataAccess.Factory
{
    public abstract class AbstractFactory
    {
       public abstract ICRUD<ExamSchedules> CreateExamSchedules();
       public abstract ICRUD<Groups> CreateGroups();
       public abstract ICRUD<Sessions> CreateSessions();
       public abstract ICRUD<SessionsResults> CreateSessionsResults();
       public abstract ICRUD<Students> CreateStudents();
       public abstract ICRUD<Subjects> CreateSubjects();
    }
}
