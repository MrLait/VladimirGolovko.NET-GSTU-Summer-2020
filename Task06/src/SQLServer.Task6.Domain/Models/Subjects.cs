using SQLServer.Task6.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    /// <summary>
    /// Subject table.
    /// </summary>
    [Table("Subjects")]
    public class Subjects : IEntity
    {
        /// <summary>
        /// Id collumn.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name collumn.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// IsAssessment collumn.
        /// </summary>
        public string IsAssessment { get; set; }
    }
}
