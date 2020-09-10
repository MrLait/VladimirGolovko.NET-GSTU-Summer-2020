using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
	/// <summary>
	/// Examiners table in database.
	/// </summary>
	[Table(Name = "Examiners")]
	public class Examiners : IEntity
	{
		/// <summary>
		/// Id column in table.
		/// </summary>
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }

		/// <summary>
		/// First name column in table.
		/// </summary>
		[Column(Name = "FirstName")]
		public string FirstName { get; set; }

		/// <summary>
		/// Last name column in table.
		/// </summary>
		[Column(Name = "LastName")]
		public string LastName { get; set; }

		/// <summary>
		/// Middle name column in table.
		/// </summary>
		[Column(Name = "MiddleName")]
		public string MiddleName { get; set; }
	}
}
