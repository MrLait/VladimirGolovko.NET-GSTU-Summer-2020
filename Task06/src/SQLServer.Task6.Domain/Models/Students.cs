using SQLServer.Task6.Domain.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    /// <summary>
    /// Students table.
    /// </summary>
    [Table("Students")]
    public class Students : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// FirstName column.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// LastName column.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// MiddleName column.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gender column.
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// DateOfBirthday column.
        /// </summary>
        public DateTime DateOfBirthday { get; set; }

        /// <summary>
        /// GroupsId column.
        /// </summary>
        [ForeignKey("GroupsId")]
        public int GroupsId { get; set; }
    }
}
