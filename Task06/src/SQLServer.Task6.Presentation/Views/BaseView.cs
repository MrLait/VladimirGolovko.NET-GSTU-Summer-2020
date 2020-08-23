using DAO.DataAccess.Singleton;
using SQLServer.Task6.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace SQLServer.Task6.Presentation.Views
{
    public class BaseView
    {
        protected SingletonDboAccess SingletonDboAccess { get; private set; }
        protected IEnumerable<Groups> Groups { get; }
        protected IEnumerable<Sessions> Sessions { get;}
        protected IEnumerable<Students> Students { get;}
        protected IEnumerable<ExamSchedules> ExamSchedules { get;}
        protected IEnumerable<SessionsResults> SessionsResults { get; }
        protected IEnumerable<Subjects> Subjects { get; }

        public BaseView() { }

        public BaseView(SingletonDboAccess singletonDboAccess)
        {
            SingletonDboAccess = singletonDboAccess;

            Groups = SingletonDboAccess.RepositoryFactory.CreateGroups().GetAll();
            Sessions = SingletonDboAccess.RepositoryFactory.CreateSessions().GetAll();
            Students = SingletonDboAccess.RepositoryFactory.CreateStudents().GetAll();
            ExamSchedules = SingletonDboAccess.RepositoryFactory.CreateExamSchedules().GetAll();
            SessionsResults = SingletonDboAccess.RepositoryFactory.CreateSessionsResults().GetAll();
            Subjects = SingletonDboAccess.RepositoryFactory.CreateSubjects().GetAll();

        }
    }
}
