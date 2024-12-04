using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;

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
				int tokenLifetime = 30;
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

				return BadRequest(new { ex.Message });
			}
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPut("update")]

		public async Task<IActionResult> UpdateTeacherAsync([FromBody] UpdateTeacher updateTeacher)
		{
			try
			{
				var result = await _teacherService.UpdateTeacherAsync(updateTeacher);
				if (!result)
				{
					return BadRequest(new { message = "Failed to update teacher's information." });
				}

				return Ok(new { message = "Teacher's information updated successfully." });
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(new{ex.Message});
			}
			catch (Exception ex)
			{
				return BadRequest(new { ex.Message });
			}

		}
		[HttpGet("getall")]
		public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachersAsync()
		{
			var teachers = await _teacherService.GetAllTeachersAsync();
			if (teachers == null)
			{
				return NotFound("There are no any teacher");
			}
			return Ok(teachers);
		}
		[HttpGet("username")]
		public async Task<IActionResult> GetTeacherByUsernameAsync(string username)
		{
			var teacher = await _teacherService.GetTeacherByIdAsync(username);
			if (teacher == null)
			{
				return NotFound();
			}
			return Ok(teacher);
		}
	}
}
