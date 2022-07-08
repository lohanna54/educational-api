using Educational_Api.Models.Response;
using Educational_Api.Models.UI;

namespace Educational_Api.Services.Interfaces
{
	public interface IClassService
	{
		public Task<IEnumerable<Class>> GetClasses();

		public Task<ApiResponse<Class>> GetClassByIdAsync(int id);

		public Task<ApiResponse<string>> UpdateClassAsync(int id, Class @class);

		public Task<ApiResponse<string>> CreateClassAsync(Class @class);

		public Task<ApiResponse<string>> DeleteClassAsync(int id);

	}
}
