using SQLServer.Task7.Domain.Interfaces;

namespace SQLServer.Task7.Domain.Models
{
	public class Examiners : IEntity
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string MiddleName { get; set; }
	}
}
