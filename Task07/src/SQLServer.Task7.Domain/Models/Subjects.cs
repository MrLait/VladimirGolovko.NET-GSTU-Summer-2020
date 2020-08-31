using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Subject table.
    /// </summary>
    [Table(Name = "Subjects")]
    public class Subjects : IEntity
    {
        /// <summary>
        /// Id collumn.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Name collumn.
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// IsAssessment collumn.
        /// </summary>
        [Column(Name = "IsAssessment")]
        public string IsAssessment { get; set; }

        /// <summary>
        /// ExaminersId collumn.
        /// </summary>
        [Column(Name = "ExaminersId")]
        public int ExaminersId { get; set; }
    }
}
