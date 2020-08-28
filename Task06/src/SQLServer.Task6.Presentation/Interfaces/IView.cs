using DAO.DataAccess.Singleton;
using SQLServer.Task6.Domain.Models;
using System.Collections.Generic;

namespace SQLServer.Task6.Presentation.Interfaces
{
    public interface IView
    {
        IEnumerable<Groups> Groups { get; }
        IEnumerable<Sessions> Sessions { get; }
        IEnumerable<Students> Students { get; }
        IEnumerable<ExamSchedules> ExamSchedules { get; }
        IEnumerable<SessionsResults> SessionsResults { get; }
        IEnumerable<Subjects> Subjects { get; }
    }
}
