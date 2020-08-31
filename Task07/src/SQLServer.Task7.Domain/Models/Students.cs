using SQLServer.Task7.Domain.Interfaces;
using System;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Students table.
    /// </summary>
    [Table(Name = "Students")]
    public class Students : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// FirstName column.
        /// </summary>
        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName column.
        /// </summary>
        [Column(Name = "LastName")]
        public string LastName { get; set; }

        /// <summary>
        /// MiddleName column.
        /// </summary>
        [Column(Name = "MiddleName")]
        public string MiddleName { get; set; }

        /// <summary>
        /// Gender column.
        /// </summary>
        [Column(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// DateOfBirthday column.
        /// </summary>
        [Column(Name = "DateOfBirthday")]
        public DateTime DateOfBirthday { get; set; }

        /// <summary>
        /// GroupsId column.
        /// </summary>
        [Column(Name = "GroupsId")]
        public int GroupsId { get; set; }
    }
}
