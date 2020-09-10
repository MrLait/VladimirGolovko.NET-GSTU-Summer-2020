using SQLServer.Task7.Domain.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Exam schedules table in database.
    /// </summary>
    [Table(Name = "ExamSchedules")]
    public class ExamSchedules : IEntity
    {
        /// <summary>
        /// Id column in table.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// SessionsId column in table.
        /// </summary>
        [Column(Name = "SessionsId")]
        public int SessionsId { get; set; }

        /// <summary>
        /// GroupsId column in table.
        /// </summary>
        [Column(Name = "GroupsId")]
        public int GroupsId { get; set; }

        /// <summary>
        /// SubjectsId column in table.
        /// </summary>
        [Column(Name = "SubjectsId")]
        public int SubjectsId { get; set; }

        /// <summary>
        /// Exam date column in table.
        /// </summary>
        [Column(Name = "ExamDate")]
        public DateTime ExamDate { get; set; }
    }
}
