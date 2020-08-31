using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// SessionsResults table.
    /// </summary>
    [Table(Name = "SessionsResults")]
    public class SessionsResults : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// StudentsId column.
        /// </summary>
        [Column(Name = "StudentsId")]
        public int StudentsId { get; set; }

        /// <summary>
        /// ExamSchedulesId column.
        /// </summary>
        [Column(Name = "ExamSchedulesId")]
        public int ExamSchedulesId { get; set; }

        /// <summary>
        /// Value column.
        /// </summary>
        [Column(Name = "Value")]
        public string Value { get; set; }
    }
}
