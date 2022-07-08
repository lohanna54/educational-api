using Educational_Api.Models;
using Educational_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class StudentsController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentsController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
		{
			var result = await _studentService.GetStudents();

			if(!result.Any())
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> GetStudent(int id)
		{
			var result = await _studentService.GetStudentById(id);

			if (result.IsSuccessful)
			{
				return Ok(result.Response);
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateStudent(int id, Student student)
		{
			if (id != student.Id)
			{
				return BadRequest();
			}

			var result = await _studentService.UpdateStudent(id, student);

			return StatusCode((int)result.StatusCode);
			
		}

		[HttpPost]
		public async Task<ActionResult> CreateStudent(Student student)
		{
			var result = await _studentService.CreateStudent(student);

			if (!result.IsSuccessful)
			{
				return Problem(result.Response.ToString());
			}

			return new ObjectResult(result.Response.ToString()) 
			{ StatusCode = StatusCodes.Status201Created };
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStudent(int id)
		{
			var result = await _studentService.DeleteStudent(id);

			if (result.IsSuccessful)
			{
				return NoContent();
			}

			return new ObjectResult(result.Response.ToString())
			{ StatusCode = (int)result.StatusCode };
		}
	}
}
