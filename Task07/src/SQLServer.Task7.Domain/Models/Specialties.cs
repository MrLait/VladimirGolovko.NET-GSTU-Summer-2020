using SQLServer.Task7.Domain.Interfaces;

namespace SQLServer.Task7.Domain.Models
{
	public class Specialties : IEntity
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Info { get; set; }
	}
}
