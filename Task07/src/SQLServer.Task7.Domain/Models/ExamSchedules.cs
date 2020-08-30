using SQLServer.Task7.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    /// <summary>
    /// Exam schedules table in database.
    /// </summary>
    [Table("ExamSchedules")]
    public class ExamSchedules : IEntity
    {
        /// <summary>
        /// Id column in table.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// SessionsId column in table.
        /// </summary>
        [ForeignKey("SessionsId")]
        public int SessionsId { get; set; }

        /// <summary>
        /// GroupsId column in table.
        /// </summary>
        [ForeignKey("GroupsId")]
        public int GroupsId { get; set; }

        /// <summary>
        /// SubjectsId column in table.
        /// </summary>
        [ForeignKey("SubjectsId")]
        public int SubjectsId { get; set; }

        /// <summary>
        /// Exam date column in table.
        /// </summary>
        public DateTime ExamDate { get; set; }
    }
}
