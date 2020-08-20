using System.ComponentModel.DataAnnotations;

namespace SQLServer.Task6.Domain.Interfaces
{
    public interface IEntity
    {
        [Key]
        int Id { get; set; }
    }
}
