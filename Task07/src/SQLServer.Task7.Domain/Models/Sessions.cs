using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Sessions table.
    /// </summary>
    [Table(Name = "Sessions")]
    public class Sessions : IEntity
    {
        /// <summary>
        /// Id column.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Name column.
        /// </summary>
        [Column(Name = "Name")]
        public int Name { get; set; }
    }
}
