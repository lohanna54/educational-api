using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Api.Models.UI
{
	public class Class
	{
		[Key]
		public int Id { get; set; }

		[Column("CurrentName")]
		public string Name { get; set; }

		public bool IsActive { get; set; }

		#region Navigation Properties

		public virtual ICollection<Student>? Students { get; set; }

		#endregion Navigation Properties
	}
}
