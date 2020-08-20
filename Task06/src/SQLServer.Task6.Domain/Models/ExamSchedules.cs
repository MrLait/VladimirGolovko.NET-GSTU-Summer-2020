using SQLServer.Task6.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    [Table("ExamSchedules")]
    public class ExamSchedules : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("SessionsId")]
        public int SessionsId { get; set; }

        [ForeignKey("GroupsId")]
        public int GroupsId { get; set; }

        [ForeignKey("SubjectsId")]
        public int SubjectsId { get; set; }

        public DateTime ExamDate { get; set; }
    }
}
