using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities.Role;
using ToDoListAPI.Persistence.Services;

namespace ToDoList.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]

	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}


		//[Authorize(AuthenticationSchemes = nameof(RoleModel.Student))]
		//[HttpPut("update")]
		//public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudent updateStudent)
		//{
		//	try
		//	{
		//		var result = await _studentService.UpdateStudentAsync(updateStudent);
		//		if (!result)
		//		{
		//			return BadRequest(new { message = "Failed to update student's information." });
		//		}

		//		return Ok(new { message = "Teacher's information updated successfully." });
		//	}
		//	catch (UnauthorizedAccessException ex)
		//	{
		//		return Unauthorized(new { ex.Message });
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(new { ex.Message });
		//	}
		//}

		//[Authorize(AuthenticationSchemes =nameof(RoleModel.Student))]
		//[HttpGet("getall")]
		//public async Task<IActionResult> GetAllStudents()
		//{
		//	try
		//	{
		//		var students = await _studentService.GetAllStudentAsync();		

		//		return Ok(students);
		//	}
		//	catch (UnauthorizedAccessException ex)
		//	{
		//		return Unauthorized(new { ex.Message });
		//	}
		//	catch (Exception ex)
		//	{
		//		return BadRequest(new { ex.Message });
		//	}
		//}

	}
}
