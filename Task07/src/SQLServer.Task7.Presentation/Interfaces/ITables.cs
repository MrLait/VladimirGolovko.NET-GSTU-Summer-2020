using DAO.DataAccess.Interfaces;
using SQLServer.Task7.Domain.Models;
using System.Linq;

namespace SQLServer.Task7.Presentation.Interfaces
{
    /// <summary>
    /// Interface with tables contract.
    /// </summary>
    public interface ITables
    {
        /// <summary>
        /// Examiners table.
        /// </summary>
        IQueryable<Examiners> Examiners { get; set; }

        /// <summary>
        /// Groups table.
        /// </summary>
        IQueryable<Groups> Groups { get; set; }

        /// <summary>
        /// Sessions table.
        /// </summary>
        IQueryable<Sessions> Sessions { get; set; }

        /// <summary>
        /// Students table.
        /// </summary>
        IQueryable<Students> Students { get; set; }

        /// <summary>
        /// Exam schedules table.
        /// </summary>
        IQueryable<ExamSchedules> ExamSchedules { get; set; }

        /// <summary>
        /// Sessions results table.
        /// </summary>
        IQueryable<SessionsResults> SessionsResults { get; set; }

        /// <summary>
        /// Sessions results table.
        /// </summary>
        IQueryable<Specialties> Specialties { get; set; }

        /// <summary>
        /// Subjects table.
        /// </summary>
        IQueryable<Subjects> Subjects { get; set; }
    }
}
