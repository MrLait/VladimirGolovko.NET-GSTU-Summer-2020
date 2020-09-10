using SQLServer.Task7.Domain.Models;
using SQLServer.Task7.Presentation.Interfaces;
using System.Linq;

namespace SQLServer.Task7.Presentation.Models
{   
    /// <summary>
    /// Tables from database.
    /// </summary>
    public class Tables : ITables
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<Examiners> Examiners { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<Groups> Groups { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<Sessions> Sessions { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<Students> Students { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<ExamSchedules> ExamSchedules { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<SessionsResults> SessionsResults { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<Specialties> Specialties { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IQueryable<Subjects> Subjects { get; set; }
    }
}
