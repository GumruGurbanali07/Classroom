using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using System.Net;
using ToDoListAPI.Application.DTOs.Classroom;
using ToDoListAPI.Application.DTOs.StudentTeacher;
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
		[HttpPost("createclassroom")]
		public async Task<IActionResult> CreateClassroom([FromBody] CreateClassroom createClassroom)
		{
			try
			{
				var result = await _teacherService.CreateClassroomAsync(createClassroom);

				if (result)
				{
					return Ok(new { Message = "Classroom created successfully" });
				}
				else
				{
					return BadRequest(new { Message = "Failed to create classroom" });
				}
			}
			catch (UserNotFoundException ex)
			{
				return NotFound(new { Message = ex.Message });
			}
			catch (Exception ex)
			{
				return BadRequest(new
				{
					message = "An error occurred",
					details = ex.InnerException?.Message ?? ex.Message
				});
			}
		}

		[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		[HttpPost("addstudenttoclassroom")]
		public async Task<IActionResult> AddStudentToClassroom([FromBody] StudentClass studentClass)
		{
			try
			{
				var result = await _teacherService.AddStudentToClassroomAsync(studentClass);
				if (result)
				{
					return Ok(new { Message = "Student added to classroom successfully" });
				}
				return BadRequest(new { Message = "Failed to add student to classroom" });
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		[HttpGet("getallstudentsinclassroom/{classroomId}")]
		public async Task<IActionResult> GetAllStudentsInClassroom([FromRoute]string classroomId)
		{
			try
			{
				var students = await _teacherService.GetAllStudentsInClassroomAsync(classroomId);
				return Ok(new { Students = students });
			}
			catch (Exception ex)
			{
				return BadRequest(new { Message = ex.Message });
			}
		}

		//[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		//[HttpGet("getall")]	
		//public async Task<ActionResult> GetAllTeachersAsync()
		//{
		//	try
		//	{
		//		var teachers = await _teacherService.GetAllTeachersAsync();
		//		return Ok(teachers);
		//	}
		//	catch (UnauthorizedAccessException ex)
		//	{
		//		return Unauthorized(new { message = ex.Message });
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(new { message = ex.Message });
		//	}
		//}

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


		//[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		//[HttpGet("allstudents/{teacherId}")]
		//public async Task<ActionResult<IEnumerable<object>>> GetStudentsForTeacher(string teacherId)
		//{
		//	try
		//	{
		//		var students = await _teacherService.GetAllStudentsForTeacherAsync(teacherId);
		//		if (students == null)
		//		{
		//			return NotFound("No students found for this teacher.");
		//		}
		//		return Ok(students);
		//	}
		//	catch (UnauthorizedAccessException ex)
		//	{
		//		return Unauthorized(ex.Message);
		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode(500, ex.Message);
		//	}
		//}
		//[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		//[HttpPost("addstudent")]
		//public async Task<IActionResult> AddStudent([FromBody]CreateTeacherStudent createTeacherStudent)
		//{
			
		//	try
		//	{
		//		var students = await _teacherService.AddStudentToTeacherAsync(createTeacherStudent);
		//		if (students == null)
		//		{
		//			return NotFound("No students found for this teacher.");
		//		}
		//		return Ok(students);
		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode((int)HttpStatusCode.BadRequest,  ex.Message);
		//	}
		//}
		//[Authorize(AuthenticationSchemes = nameof(RoleModel.Teacher))]
		//[HttpDelete("removestudent")]
		//public async Task<IActionResult> RemoveStudent([FromBody] RemoveTeacherStudent removeTeacherStudent)
		//{
		//	try
		//	{
		//		var students = await _teacherService.RemoveStudentFromTeacherAsync(removeTeacherStudent);
		//		if (students == null)
		//		{
		//			return NotFound("No students found for this teacher.");
		//		}
		//		return Ok(students);
		//	}
		//	catch (Exception ex)
		//	{
		//		return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
		//	}
		//}

	}
}
