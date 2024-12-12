using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Persistence.Services;

namespace ToDoList.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		readonly private IAuthService? _authService;
		readonly private IStudentService _studentService;

		public AuthController(IAuthService? authService, IStudentService studentService)
		{
			_authService = authService;
			_studentService = studentService;
		}
		[HttpPost("student/register")]
	    public async Task<IActionResult> RegisterAsStudent(RegisterStudent registerStudent)
		{
			try
			{
				var response = await _studentService.RegisterStudentAsync(registerStudent);

				if (response.Succeded)
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
		[HttpPost("register")]
		public async Task<IActionResult> RegisterAsTeacher([FromBody] RegisterTeacher registerTeacher)
		{

			try
			{
				var response = await _authService.RegisterAsTeacherAsync(registerTeacher);

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
			
				var token = await _authService.LoginAsTeacherAsync(loginTeacher, 900);
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

				return BadRequest(new { ex.Message });
			}
		}
	}
}
