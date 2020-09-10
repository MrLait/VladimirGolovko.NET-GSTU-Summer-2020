using DAO.DataAccess.Singleton;
using SQLServer.Task6.Presentation.Interfaces;
using SQLServer.Task6.Presentation.Models;

namespace SQLServer.Task6.Presentation.Views
{
    /// <summary>
    /// Base class for view.
    /// </summary>
    public abstract class BaseView
    {
        /// <summary>
        /// Acceess to database.
        /// </summary>
        protected SingletonDboAccess SingletonDboAccess { get; private set; }

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
        /// <param name="tables">Tables property.</param>
        public BaseView(ITables tables) : this() => Tables = tables;

        /// <summary>
        /// Iitialazing access to database and view.
        /// </summary>
        /// <param name="singletonDboAccess">SingletonDboAccess parameter.</param>
        public BaseView(SingletonDboAccess singletonDboAccess)
        {
            SingletonDboAccess = singletonDboAccess;

            Tables = new Tables()
            {
                Groups = SingletonDboAccess.ADORepositoryFactory.CreateGroups().GetAll(),
                Sessions = SingletonDboAccess.ADORepositoryFactory.CreateSessions().GetAll(),
                Students = SingletonDboAccess.ADORepositoryFactory.CreateStudents().GetAll(),
                ExamSchedules = SingletonDboAccess.ADORepositoryFactory.CreateExamSchedules().GetAll(),
                SessionsResults = SingletonDboAccess.ADORepositoryFactory.CreateSessionsResults().GetAll(),
                Subjects = SingletonDboAccess.ADORepositoryFactory.CreateSubjects().GetAll()
            };
        }
    }
}
