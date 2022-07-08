using Educational_Api.Models;
using Educational_Api.Models.Context;
using Educational_Api.Models.Response;
using Educational_Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Educational_Api.Services
{
	public class ClassService : IClassService
	{

		#region Private Properties

		private readonly EducationalContext _context;

		#endregion

		#region Public Constructors

		public ClassService(EducationalContext context)
		{
			_context = context;
		}

		#endregion

		#region Public Methods
		public async Task<ApiResponse<string>> CreateClassAsync(Class @class)
		{
			if (ContextAvailable())
			{
				_context.Classes.Add(@class);
				await _context.SaveChangesAsync();

				return new ApiResponse<string>
				{
					IsSuccessful = true,
					Response = @class.Id.ToString()
				};
			}

			return BuildContextFailedMessage();
		}

		public async Task<ApiResponse<string>> DeleteClassAsync(int id)
		{
			if (ContextAvailable())
			{
				var @class = await _context.Classes.FindAsync(id);
				if (@class != null)
				{
					if (HasStudents(@class))
					{
						return new ApiResponse<string>
						{
							IsSuccessful = false,
							StatusCode = HttpStatusCode.BadRequest,
							Response = $"There are students enrolled in the informed class"
						};
					}

					_context.Classes.Remove(@class);
					await _context.SaveChangesAsync();

					return new ApiResponse<string>(true);
				}

				return new ApiResponse<string>
				{
					IsSuccessful = false,
					StatusCode = HttpStatusCode.NotFound,
					Response = $"Class id {id} not found"
				};
			}

			return BuildContextFailedMessage();
		}

		public async Task<ApiResponse<Class>> GetClassByIdAsync(int id)
		{
			if (ContextAvailable())
			{
				var @class = await _context.Classes.FindAsync(id);

				if (@class != null)
				{
					return new ApiResponse<Class>
					{
						IsSuccessful = true,
						Response = @class
					};
				}
			}

			return new ApiResponse<Class>(false);
		}

		public Task<IEnumerable<Class>> GetClasses()
		{
			if (ContextAvailable())
			{
				var classes = _context.Classes.ToList();

				var activeClasses = classes.Where(s => s.IsActive);

				foreach (var @class in activeClasses)
				{
					if (@class.Students is not null)
					{
						var students = @class.Students.Where(s => s.IsActive);
						@class.Students = students.ToList();
					}
				}

				return Task.FromResult(activeClasses);
			}

			return Task.FromResult(Enumerable.Empty<Class>());
		}

		public async Task<ApiResponse<string>> UpdateClassAsync(int id, Class @class)
		{

			_context.Entry(@class).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException concurrencyException)
			{
				if (!ClassExists(id))
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

			return new ApiResponse<string>
			{
				IsSuccessful = true
			};
		}

		#endregion

		#region Private Methods

		private bool ClassExists(int id)
		{
			return (_context.Classes?.Any(e => e.Id == id)).GetValueOrDefault();
		}

		private static bool HasStudents(Class @class)
		{
			return @class.Students.Count > 0;
		}

		private bool ContextAvailable()
		{
			return _context.Classes != null;
		}

		private static ApiResponse<string> BuildContextFailedMessage()
		{
			return new ApiResponse<string>
			{
				IsSuccessful = false,
				StatusCode = HttpStatusCode.ServiceUnavailable,
				Response = "Failed to reach Classes data"
			};
		}

		#endregion
	}
}
