using SQLServer.Task6.Domain.Interfaces;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQLServer.Task6.Domain.Models
{
    [Table("Sessions")]
    public class Sessions : IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
