using DAO.DataAccess.Interfaces;
using SQLServer.Task7.Domain.Models;

namespace DAO.DataAccess.Factory
{
    /// <summary>
    /// Abstract factory to get access to database tables.
    /// </summary>
    public abstract class AbstractFactory
    {
        /// <summary>
        /// Create exam schedules.
        /// </summary>
        /// <returns>Returns exam schedules.</returns>
        public abstract ICRUD<Examiners> CreateExaminers();

        /// <summary>
        /// Create exam schedules.
        /// </summary>
        /// <returns>Returns exam schedules.</returns>
        public abstract ICRUD<ExamSchedules> CreateExamSchedules();

        /// <summary>
        /// Create groups
        /// </summary>
        /// <returns>Returns groups.</returns>
        public abstract ICRUD<Groups> CreateGroups();

        /// <summary>
        /// Create sessions.
        /// </summary>
        /// <returns>Returns sessions</returns>
        public abstract ICRUD<Sessions> CreateSessions();

        /// <summary>
        /// Create sessions results.
        /// </summary>
        /// <returns>Returns sessions results</returns>
        public abstract ICRUD<SessionsResults> CreateSessionsResults();

        /// <summary>
        /// Create students.
        /// </summary>
        /// <returns>Returns students.</returns>
        public abstract ICRUD<Specialties> CreateSpecialties();

        /// <summary>
        /// Create students.
        /// </summary>
        /// <returns>Returns students.</returns>
        public abstract ICRUD<Students> CreateStudents();
        
        /// <summary>
        /// Create subjects.
        /// </summary>
        /// <returns>Returns subjects.</returns>
        public abstract ICRUD<Subjects> CreateSubjects();
    }
}
