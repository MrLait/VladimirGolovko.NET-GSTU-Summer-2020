using SQLServer.Task6.Domain.Models;
using System.Collections.Generic;

namespace SQLServer.Task6.Presentation.Interfaces
{
    /// <summary>
    /// Interface with tables contract.
    /// </summary>
    public interface ITables
    {
        /// <summary>
        /// Groups table.
        /// </summary>
        IEnumerable<Groups> Groups { get; set; }

        /// <summary>
        /// Sessions table.
        /// </summary>
        IEnumerable<Sessions> Sessions { get; set; }

        /// <summary>
        /// Students table.
        /// </summary>
        IEnumerable<Students> Students { get; set; }

        /// <summary>
        /// Exam schedules table.
        /// </summary>
        IEnumerable<ExamSchedules> ExamSchedules { get; set; }

        /// <summary>
        /// Sessions results table.
        /// </summary>
        IEnumerable<SessionsResults> SessionsResults { get; set; }

        /// <summary>
        /// Subjects table.
        /// </summary>
        IEnumerable<Subjects> Subjects { get; set; }
    }
}
