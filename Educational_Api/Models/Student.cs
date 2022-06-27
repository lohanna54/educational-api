using Educational_Api.Models.Enums;

namespace Educational_Api.Models
{
	public class Student
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime BirthDate { get; set; }

		public EGenre Genre { get; set; }

		public Class Class { get; set; }

		public int? TotalAbsences { get; set; }

		public bool IsActive { get; set; }
	}
}