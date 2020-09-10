using DAO.DataAccess.Interfaces;
using DAO.DataAccess.Repositories.LINQtoSQLRepositories;
using SQLServer.Task7.Domain.Models;

namespace DAO.DataAccess.Factory
{
    /// <summary>
    /// ADO repository factory class.
    /// </summary>
    public class LinqToSqlRepositoryFactory : AbstractFactory
    {
        /// <summary>
        /// Represent access to ExamSchedules table.
        /// </summary>
        protected internal LinqToSqlRepository<ExamSchedules> ExamSchedules { get;  set; }

        /// <summary>
        /// Represent access to Groups.
        /// </summary>
        protected internal LinqToSqlRepository<Groups> Groups { get;  set; }

        /// <summary>
        /// Represent access to Sessions.
        /// </summary>
        protected internal LinqToSqlRepository<Sessions> Sessions { get;  set; }

        /// <summary>
        /// Represent access to SessionsResults.
        /// </summary>
        protected internal LinqToSqlRepository<SessionsResults> SessionsResults { get;  set; }

        /// <summary>
        /// Represent access to Students.
        /// </summary>
        protected internal LinqToSqlRepository<Students> Students { get;  set; }

        /// <summary>
        /// Represent access to Subjects.
        /// </summary>
        protected internal LinqToSqlRepository<Subjects> Subjects { get;  set; }

        /// <summary>
        /// Represent access to Examiners.
        /// </summary>
        protected internal LinqToSqlRepository<Examiners> Examiners { get; set; }

        /// <summary>
        /// Represent access to Specialties.
        /// </summary>
        protected internal LinqToSqlRepository<Specialties> Specialties { get; set; }

        /// <summary>
        /// Constructor to initializing access with tables and get connection string to database.
        /// </summary>
        /// <param name="dbConnectionStrig">Connection string.</param>
        public LinqToSqlRepositoryFactory(string dbConnectionStrig)
        {
            ExamSchedules = new LinqToSqlRepository<ExamSchedules>(dbConnectionStrig);
            Groups = new LinqToSqlRepository<Groups>(dbConnectionStrig);
            Sessions = new LinqToSqlRepository<Sessions>(dbConnectionStrig);
            SessionsResults = new LinqToSqlRepository<SessionsResults>(dbConnectionStrig);
            Students = new LinqToSqlRepository<Students>(dbConnectionStrig);
            Subjects = new LinqToSqlRepository<Subjects>(dbConnectionStrig);
            Examiners = new LinqToSqlRepository<Examiners>(dbConnectionStrig);
            Specialties = new LinqToSqlRepository<Specialties>(dbConnectionStrig);
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

        /// <summary>
        /// Factory method to create Examiners table.
        /// </summary>
        /// <returns>Returns Examiners.</returns>
        public override ICRUD<Examiners> CreateExaminers() => Examiners;

        /// <summary>
        /// Factory method to create Specialties table.
        /// </summary>
        /// <returns>Returns Specialties.</returns>
        public override ICRUD<Specialties> CreateSpecialties() => Specialties;
    }
}
