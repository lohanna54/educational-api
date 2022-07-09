using Educational_Api.Models.Context;
using Educational_Api.Models.Response;
using Educational_Api.Models.UI;
using Educational_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

using System.Net;

namespace Educational_Api.Services
{
	public class StudentService : IStudentService
	{
		#region Private Properties

		private readonly EducationalContext _context;

		#endregion

		#region Public Constructors

		public StudentService(EducationalContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods
		public async Task<ApiResponse<Student>> GetStudentById(int id)
		{
			if (ContextAvailable())
			{
				var student = await _context.Students.FindAsync(id);

				if(student != null)
				{
					return new ApiResponse<Student>
					{
						IsSuccessful = true,
						Response = student
					};
				}
			}

			return new ApiResponse<Student>(false);
		}

		public Task<IEnumerable<Student>> GetStudents()
		{
			if (ContextAvailable())
			{
				var students = _context.Students.ToList();

				return Task.FromResult(students.Where(s => s.IsActive));
			}

			return Task.FromResult(Enumerable.Empty<Student>());
		}

		public async Task<ApiResponse<string>> UpdateStudent(int id, Student student)
		{
			_context.Entry(student).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException concurrencyException)
			{
				if (!StudentExists(id))
				{
					return new ApiResponse<string>
					{
						IsSuccessful = false,
						StatusCode = HttpStatusCode.NotFound,
						Response = $"Provided id {id} does not exist"
					};
				}
				else
				{
					return new ApiResponse<string>
					{
						IsSuccessful = false,
						StatusCode = HttpStatusCode.NotImplemented,
						Response = concurrencyException.Message
					};
				}
			}

			return new ApiResponse<string>(true);
			
		}

		public async Task<ApiResponse<string>> CreateStudent(Student student)
		{
			if (ContextAvailable())
			{
				_context.Students.Add(student);
				await _context.SaveChangesAsync();

				return new ApiResponse<string>
				{
					IsSuccessful = true,
					Response = student.Id.ToString()
				};
			}

			return BuildContextFailedMessage();
		}

		public async Task<ApiResponse<string>> DeleteStudent(int id)
		{
			if (ContextAvailable())
			{
				var student = await _context.Students.FindAsync(id);
				if (student != null)
				{
					_context.Students.Remove(student);
					await _context.SaveChangesAsync();

					return new ApiResponse<string>(true);
				}

				return new ApiResponse<string>
				{
					IsSuccessful = false,
					Response = $"Student id {id} not found"
				};
			}

			return BuildContextFailedMessage();

		}

		#endregion

		#region Private Methods
		private bool StudentExists(int id)
		{
			return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		private bool ContextAvailable()
		{
			return _context.Students != null;
		}

		private static ApiResponse<string> BuildContextFailedMessage()
		{
			return new ApiResponse<string>
			{
				IsSuccessful = false,
				StatusCode = HttpStatusCode.ServiceUnavailable,
				Response = "Failed to reach Students data"
			};
		}

		#endregion
	}
}
