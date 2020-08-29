using DAO.DataAccess.Interfaces;
using DAO.DataAccess.Repositories.ADO.NetUsingReflection;
using SQLServer.Task6.Domain.Models;

namespace DAO.DataAccess.Factory
{
    /// <summary>
    /// ADO repository factory class.
    /// </summary>
    public class ADORepositoryFactory : AbstractFactory
    {
        /// <summary>
        /// Represent access to ExamSchedules table.
        /// </summary>
        protected internal ADORepository<ExamSchedules> ExamSchedules { get;  set; }

        /// <summary>
        /// Represent access to Groups.
        /// </summary>
        protected internal ADORepository<Groups> Groups { get;  set; }

        /// <summary>
        /// Represent access to Sessions.
        /// </summary>
        protected internal ADORepository<Sessions> Sessions { get;  set; }

        /// <summary>
        /// Represent access to SessionsResults.
        /// </summary>
        protected internal ADORepository<SessionsResults> SessionsResults { get;  set; }

        /// <summary>
        /// Represent access to Students.
        /// </summary>
        protected internal ADORepository<Students> Students { get;  set; }

        /// <summary>
        /// Represent access to Subjects.
        /// </summary>
        protected internal ADORepository<Subjects> Subjects { get;  set; }

        /// <summary>
        /// Constructor to initializing access with tables and get connection string to database.
        /// </summary>
        /// <param name="dbConnectionStrig"></param>
        public ADORepositoryFactory(string dbConnectionStrig)
        {
            ExamSchedules = new ADORepository<ExamSchedules>(dbConnectionStrig);
            Groups = new ADORepository<Groups>(dbConnectionStrig);
            Sessions = new ADORepository<Sessions>(dbConnectionStrig);
            SessionsResults = new ADORepository<SessionsResults>(dbConnectionStrig);
            Students = new ADORepository<Students>(dbConnectionStrig);
            Subjects = new ADORepository<Subjects>(dbConnectionStrig);
        }

        /// <summary>
        /// Factory method to create ExamSchedules table.
        /// </summary>
        /// <returns>Returns ExamSchedules.</returns>
        public override ICRUD<ExamSchedules> CreateExamSchedules() => ExamSchedules;

        /// <summary>
        /// Factory method to create Groups table.
        /// </summary>
        /// <returns>Returns Groups.</returns>
        public override ICRUD<Groups> CreateGroups() => Groups;

        /// <summary>
        /// Factory method to create Sessions table.
        /// </summary>
        /// <returns>Returns Sessions.</returns>
        public override ICRUD<Sessions> CreateSessions() => Sessions;

        /// <summary>
        /// Factory method to create SessionsResults table.
        /// </summary>
        /// <returns>Returns SessionsResults.</returns>
        public override ICRUD<SessionsResults> CreateSessionsResults() => SessionsResults;

        /// <summary>
        /// Factory method to create Students table.
        /// </summary>
        /// <returns>Returns Students.</returns>
        public override ICRUD<Students> CreateStudents() => Students;

        /// <summary>
        /// Factory method to create Subjects table.
        /// </summary>
        /// <returns>Returns Subjects.</returns>
        public override ICRUD<Subjects> CreateSubjects() => Subjects;
    }
}
