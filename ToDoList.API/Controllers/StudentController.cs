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
	

	}
}
