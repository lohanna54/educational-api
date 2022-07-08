using Educational_Api.Models;
using Educational_Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Educational_Api.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class ClassesController : ControllerBase
	{
		private readonly IClassService _classService;

		public ClassesController(IClassService classService)
		{
			_classService = classService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
		{
			var result = await _classService.GetClasses();

			if (!result.Any())
			{
				return NotFound();
			}

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Class>> GetClass(int id)
		{
			var result = await _classService.GetClassByIdAsync(id);

			if (result.IsSuccessful)
			{
				return Ok(result.Response);
			}

			return NotFound();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateClass(int id, Class @class)
		{
			if (id != @class.Id)
			{
				return BadRequest();
			}

			var result = await _classService.UpdateClassAsync(id, @class);

			return StatusCode((int)result.StatusCode);
		}

		[HttpPost]
		public async Task<ActionResult<Class>> CreateClass(Class @class)
		{
			var result = await _classService.CreateClassAsync(@class);

			if (!result.IsSuccessful)
			{
				return Problem(result.Response.ToString());
			}

			return Ok(result.Response.ToString());
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteClass(int id)
		{
			var result = await _classService.DeleteClassAsync(id);

			if (result.IsSuccessful)
			{
				return NoContent();
			}

			return new ObjectResult(result.Response.ToString())
			{ StatusCode = (int)result.StatusCode };
		}
	}
}
