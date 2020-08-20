using SQLServer.Task6.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    [Table("SessionsResults")]
    public class SessionsResults : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StudentsId")]
        public int StudentsId { get; set; }

        [ForeignKey("ExamSchedulesId")]
        public int ExamSchedulesId { get; set; }

        public string Value { get; set; }
    }
}
