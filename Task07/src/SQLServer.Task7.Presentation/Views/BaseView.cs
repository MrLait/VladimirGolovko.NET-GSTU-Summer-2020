using DAO.DataAccess.Singleton;
using SQLServer.Task7.Domain.Models;
using SQLServer.Task7.Presentation.Interfaces;
using SQLServer.Task7.Presentation.Models;
using System.Linq;

namespace SQLServer.Task7.Presentation.Views
{
    /// <summary>
    /// Base class for view.
    /// </summary>
    public abstract class BaseView
    {
        /// <summary>
        /// Acceess to database.
        /// </summary>
        protected SingletonLinqToSql SingletonDboAccess { get; private set; }

        /// <summary>
        /// Tables for view.
        /// </summary>
        protected ITables Tables;

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BaseView() { }

        /// <summary>
        /// Initial view.
        /// </summary>
        /// <param name="view">View property.</param>
        public BaseView(ITables view) : this() => Tables = view;

        /// <summary>
        /// Iitialazing access to database and view.
        /// </summary>
        /// <param name="singletonDboAccess">SingletonDboAccess parameter.</param>
        public BaseView(SingletonLinqToSql singletonDboAccess)
        {
            SingletonDboAccess = singletonDboAccess;

            Tables = new Tables()
            {
                Examiners = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateExaminers().GetAll(),
                Groups = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateGroups().GetAll(),
                Sessions = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateSessions().GetAll(),
                Students = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateStudents().GetAll(),
                ExamSchedules = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateExamSchedules().GetAll(),
                SessionsResults = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateSessionsResults().GetAll(),
                Specialties = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateSpecialties().GetAll(),
                Subjects = SingletonDboAccess.LinqToSqlRepositoryFactory.CreateSubjects().GetAll()
            };
        }
    }
}
