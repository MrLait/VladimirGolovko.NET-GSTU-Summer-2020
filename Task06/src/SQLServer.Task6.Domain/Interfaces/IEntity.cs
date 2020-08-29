using System.ComponentModel.DataAnnotations;

namespace SQLServer.Task6.Domain.Interfaces
{
    /// <summary>
    /// Entity interface with Id contract.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id column in table.
        /// </summary>
        [Key]
        int Id { get; set; }
    }
}