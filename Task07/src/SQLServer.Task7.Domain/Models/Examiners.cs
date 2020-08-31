using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
	[Table(Name = "Examiners")]
	public class Examiners : IEntity
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }
		[Column(Name = "FirstName")]
		public string FirstName { get; set; }
		[Column(Name = "LastName")]
		public string LastName { get; set; }
		[Column(Name = "MiddleName")]
		public string MiddleName { get; set; }
	}
}
