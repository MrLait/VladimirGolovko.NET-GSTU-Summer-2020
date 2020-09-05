using SQLServer.Task7.Domain.Interfaces;
using System.Data.Linq.Mapping;

namespace SQLServer.Task7.Domain.Models
{
	/// <summary>
	/// Specialties table.
	/// </summary>
	[Table(Name = "Specialties")]
	public class Specialties : IEntity
	{
		/// <summary>
		/// Id column in table.
		/// </summary>
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int Id { get; set; }

		/// <summary>
		/// Name column in table.
		/// </summary>
		[Column(Name = "Name")]
		public string Name { get; set; }

		/// <summary>
		/// Info column in table. 
		/// </summary>
		[Column(Name = "Info")]
		public string Info { get; set; }
	}
}
