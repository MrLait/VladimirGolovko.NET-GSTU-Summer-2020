using SQLServer.Task6.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    /// <summary>
    /// SessionsResults table.
    /// </summary>
    [Table("SessionsResults")]
    public class SessionsResults : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// StudentsId column.
        /// </summary>
        [ForeignKey("StudentsId")]
        public int StudentsId { get; set; }

        /// <summary>
        /// ExamSchedulesId column.
        /// </summary>
        [ForeignKey("ExamSchedulesId")]
        public int ExamSchedulesId { get; set; }

        /// <summary>
        /// Value column.
        /// </summary>
        public string Value { get; set; }
    }
}
