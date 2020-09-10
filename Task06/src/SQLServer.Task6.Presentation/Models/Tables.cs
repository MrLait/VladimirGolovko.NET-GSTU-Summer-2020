using SQLServer.Task6.Domain.Models;
using SQLServer.Task6.Presentation.Interfaces;
using System.Collections.Generic;

namespace SQLServer.Task6.Presentation.Models
{
    /// <summary>
    /// Tables from database.
    /// </summary>
    public class Tables : ITables
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<Groups> Groups { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<Sessions> Sessions { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<Students> Students { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<ExamSchedules> ExamSchedules { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<SessionsResults> SessionsResults { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IEnumerable<Subjects> Subjects { get; set; }
    }
}
