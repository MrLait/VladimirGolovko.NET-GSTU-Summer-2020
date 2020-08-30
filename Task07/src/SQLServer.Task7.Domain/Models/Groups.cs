using SQLServer.Task7.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task7.Domain.Models
{
    /// <summary>
    /// Groups table in database.
    /// </summary>
    [Table("Groups")]
    public class Groups : IEntity
    {
        /// <summary>
        /// Id column in table.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name column in table.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// SpecialtiesId column in table.
        /// </summary>
        public string SpecialtiesId { get; set; }
    }
}
