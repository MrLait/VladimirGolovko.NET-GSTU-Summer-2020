using SQLServer.Task7.Domain.Models;
using System.Collections.Generic;

namespace SQLServer.Task7.Presentation.Interfaces
{
    /// <summary>
    /// Interface with tables contract.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Examiners table.
        /// </summary>
        IEnumerable<Examiners> Examiners { get; }

        /// <summary>
        /// Groups table.
        /// </summary>
        IEnumerable<Groups> Groups { get; }

        /// <summary>
        /// Sessions table.
        /// </summary>
        IEnumerable<Sessions> Sessions { get; }

        /// <summary>
        /// Students table.
        /// </summary>
        IEnumerable<Students> Students { get; }

        /// <summary>
        /// Exam schedules table.
        /// </summary>
        IEnumerable<ExamSchedules> ExamSchedules { get; }

        /// <summary>
        /// Sessions results table.
        /// </summary>
        IEnumerable<SessionsResults> SessionsResults { get; }

        /// <summary>
        /// Sessions results table.
        /// </summary>
        IEnumerable<Specialties> Specialties { get; }

        /// <summary>
        /// Subjects table.
        /// </summary>
        IEnumerable<Subjects> Subjects { get; }
    }
}
