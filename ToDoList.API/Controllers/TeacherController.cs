using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
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


		[HttpPost("create")]
		public async Task<IActionResult> CreateTeacher(CreateTeacher createTeacher)
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

		[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
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

		[Authorize(AuthenticationSchemes =nameof(RoleModel.Teacher))]
		[HttpGet("GetTeacherByUserId/{userId}")]
		public  async Task<IActionResult> GetTeacherByIdAsync(string userId)
		{
			try
			{
				var teacher = await _teacherService.GetTeacherByUserIdAsync(userId);
				if(teacher == null)
				{
					return NotFound("Teacher not found");
				}
				return Ok(teacher);
			}
			catch(UnauthorizedAccessException ex)
			{
				return Unauthorized(new {message=ex.Message});
			}
			catch(Exception ex)
			{
				return BadRequest(new {message=ex.Message});
			}
		}


		[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		[HttpGet("allstudents/{teacherId}")]
		public async Task<ActionResult<IEnumerable<object>>> GetStudentsForTeacher(string teacherId)
		{
			try
			{
				var students = await _teacherService.GetAllStudentsForTeacherAsync(teacherId);
				if (students == null)
				{
					return NotFound("No students found for this teacher.");
				}
				return Ok(students);
			}
			catch (UnauthorizedAccessException ex)
			{
				return Unauthorized(ex.Message);
			}
			catch (Exception ex)
			{
				return StatusCode(500, ex.Message);
			}
		}


	}
}
