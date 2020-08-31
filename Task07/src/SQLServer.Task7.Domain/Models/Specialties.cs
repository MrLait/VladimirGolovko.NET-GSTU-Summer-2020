using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
	[Table(Name = "Specialties")]
	public class Specialties : IEntity
	{
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }
		[Column(Name = "Name")]
		public string Name { get; set; }
		[Column(Name = "Info")]
		public string Info { get; set; }
	}
}
