using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Services;

namespace ToDoList.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ITeacherService _teacherService;

		public TeacherController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsTeacher([FromBody] RegisterTeacher registerTeacher)
		{

			try
			{
				var response = await _teacherService.RegisterAsTeacherAsync(registerTeacher);

				if (response.Succeeded)
				{
					return Ok(response);
				}
				else
				{
					return BadRequest(response);
				}
			}
			catch (FailedRegisterException ex)
			{
				return StatusCode(500, new { Message = ex.Message });
			}
		}
		[HttpPost("login")]
		public async Task<IActionResult> LoginAsTeacherAsync([FromBody] LoginTeacher loginTeacher)
		{
			try
			{
				int tokenLifetime = 20;
				var token = await _teacherService.LoginAsTeacherAsync(loginTeacher, tokenLifetime);
				return Ok(token);
			}
			catch (UserNotFoundException)
			{
				return NotFound("User could not found");
			}
			catch (UnauthorizedAccessException)
			{
				return Unauthorized("Invalid credentials");
			}
			catch (Exception ex)
			{
				 ModelState.AddModelError("Error", ex.Message);
				return BadRequest(ModelState);
			}
		}
	}
}
