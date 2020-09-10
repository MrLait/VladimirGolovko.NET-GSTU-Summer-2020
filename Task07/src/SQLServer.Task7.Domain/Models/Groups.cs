using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Groups table in database.
    /// </summary>
    [Table(Name = "Groups")]
    public class Groups : IEntity
    {
        /// <summary>
        /// Id column in table.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        /// <summary>
        /// Name column in table.
        /// </summary>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// SpecialtiesId column in table.
        /// </summary>
        [Column(Name = "SpecialtiesId")]
        public int SpecialtiesId { get; set; }
    }
}
