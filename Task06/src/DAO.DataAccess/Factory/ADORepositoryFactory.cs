using DAO.DataAccess.Interfaces;
using DAO.DataAccess.Repositories.ADO.NetUsingReflection;
using SQLServer.Task6.Domain.Models;

namespace DAO.DataAccess.Factory
{
    public class ADORepositoryFactory : AbstractFactory
    {
        protected internal ADORepository<ExamSchedules> ExamSchedules { get;  set; }
        protected internal ADORepository<Groups> Groups { get;  set; }
        protected internal ADORepository<Sessions> Sessions { get;  set; }
        protected internal ADORepository<SessionsResults> SessionsResults { get;  set; }
        protected internal ADORepository<Students> Students { get;  set; }
        protected internal ADORepository<Subjects> Subjects { get;  set; }

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
