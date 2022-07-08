using Educational_Api.Models.Response;
using Educational_Api.Models.UI;

namespace Educational_Api.Services.Interfaces
{
	public interface IStudentService
	{
		public Task<IEnumerable<Student>> GetStudents();

		public Task<ApiResponse<Student>> GetStudentById(int id);

		public Task<ApiResponse<string>> UpdateStudent(int id, Student student);

		public Task<ApiResponse<string>> CreateStudent(Student student);

		public Task<ApiResponse<string>> DeleteStudent(int id);
	}
}
