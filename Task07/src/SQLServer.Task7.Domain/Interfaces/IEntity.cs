using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Interfaces
{
    /// <summary>
    /// Entity interface with Id contract.
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Id column in table.
        /// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        int Id { get; set; }
    }
}