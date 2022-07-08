using Educational_Api.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Educational_Api.Models
{
	public class Student
	{
		[Key]
		public int Id { get; set; }

		[Column("FullName")]
		public string Name { get; set; }

		[Column("BirthDate")]
		public DateTime BirthDate { get; set; }

		[Column("Genre")]
		public EGenre Genre { get; set; }

		public int ClassId { get; set; }

		public int? TotalAbsences { get; set; }

		public bool IsActive { get; set; }

		#region Navigation Properties

		public virtual Class? Class { get; set; }

		#endregion Navigation Properties
	}
}