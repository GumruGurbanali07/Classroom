using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.Services;

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
		[HttpPost("create")]
		public async Task<IActionResult> CreateStudent (CreateStudent createStudent)
		{
			try
			{
				var result=await _studentService.CreateStudent(createStudent);
				if (!result)
				{
					return BadRequest(new { message ="Failed to create student's information"});
				}
				return Ok(new { message = "Student's information create successfully" });
			}
			catch(Exception ex) 
			{
				return BadRequest(new {ex.Message});
			}
		}

	}
}
