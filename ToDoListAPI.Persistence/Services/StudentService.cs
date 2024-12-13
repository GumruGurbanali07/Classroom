using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Application.Token;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Entities.Identity;
using ToDoListAPI.Domain.Entities.Role;
using T = ToDoListAPI.Application.DTOs;

namespace ToDoListAPI.Persistence.Services
{
	public class StudentService : IStudentService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;
		private readonly RoleManager<AppRole> _roleManager;

		public StudentService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
			_roleManager = roleManager;
		}

	
		public Task<IEnumerable<Student>> GetAllStudentAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entities.Task>> GetAssignedTasksForStudentAsync(string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<Student> GetStudentByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entities.Task>> GetSubmittedTasksForStudentAsync(string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Teacher>> GetTeacherForStudentAsync(string studentId)
		{
			throw new NotImplementedException();
		}

	
		public Task<bool> LogOut()
		{
			throw new NotImplementedException();
		}

		

		public Task<bool> RemoveTeacherFromStudentAsync(string studentId, string teacherId)
		{
			throw new NotImplementedException();
		}

		public Task<Student> UpdateStudentAsync(UpdateStudent updateStudent)
		{
			throw new NotImplementedException();
		}
	}
}
