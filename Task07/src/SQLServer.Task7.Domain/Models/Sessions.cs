using SQLServer.Task7.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Sessions table.
    /// </summary>
    [Table("Sessions")]
    public class Sessions : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name column.
        /// </summary>
        public string Name { get; set; }
    }
}
