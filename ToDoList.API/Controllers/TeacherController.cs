using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Entities.Role;


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


		[HttpPost]
		public async Task<IActionResult> Create(CreateTeacher createTeacher)
		{
			try
			{
				var result = await _teacherService.CreateTeacher(createTeacher);
				if (!result)
				{
					return BadRequest(new { message = "Failed to create teacher's information." });
				}

				return Ok(new { message = "Teacher's information create successfully." });
			}
			
			catch (Exception ex)
			{
				return BadRequest(new { ex.Message });
			}
		}

		[Authorize(AuthenticationSchemes = "Teacher")]
		[HttpPut("update")]
		public async Task<IActionResult> UpdateTeacherAsync([FromBody] UpdateTeacher updateTeacher)
		{
			try
			{
				var result = await  _teacherService.UpdateTeacherAsync(updateTeacher);
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


		



		[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		[HttpGet("getall")]
	
		public async Task<ActionResult> GetAllTeachersAsync()
		{
			try
			{
				var teachers = await _teacherService.GetAllTeachersAsync();
				return Ok(teachers);
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(new { message = ex.Message });
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
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
