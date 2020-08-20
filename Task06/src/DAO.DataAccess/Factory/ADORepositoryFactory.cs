using DAO.DataAccess.Interfaces;
using DAO.DataAccess.Repositories.ADO.NetUsingReflection;
using SQLServer.Task6.Domain.Models;

namespace DAO.DataAccess.Factory
{
    public class ADORepositoryFactory : AbstractFactory
    {
        public ADORepository<ExamSchedules> ExamSchedules { get; private set; }
        public ADORepository<Groups> Groups { get; private set; }
        public ADORepository<Sessions> Sessions { get; private set; }
        public ADORepository<SessionsResults> SessionsResults { get; private set; }
        public ADORepository<Students> Students { get; private set; }
        public ADORepository<Subjects> Subjects { get; private set; }

        public ADORepositoryFactory(string dbConnectionStrig)
        {
            ExamSchedules = new ADORepository<ExamSchedules>(dbConnectionStrig);
            Groups = new ADORepository<Groups>(dbConnectionStrig);
            Sessions = new ADORepository<Sessions>(dbConnectionStrig);
            SessionsResults = new ADORepository<SessionsResults>(dbConnectionStrig);
            Students = new ADORepository<Students>(dbConnectionStrig);
            Subjects = new ADORepository<Subjects>(dbConnectionStrig);
        }

        public override ICRUD<ExamSchedules> CreateExamSchedules() => ExamSchedules;
        public override ICRUD<Groups> CreateGroups() => Groups;
        public override ICRUD<Sessions> CreateSessions() => Sessions;
        public override ICRUD<SessionsResults> CreateSessionsResults() => SessionsResults;
        public override ICRUD<Students> CreateStudents() => Students;
        public override ICRUD<Subjects> CreateSubjects() => Subjects;
    }
}
