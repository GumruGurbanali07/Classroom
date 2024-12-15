using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Repository;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Application.Token;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Entities.Identity;
using ToDoListAPI.Domain.Entities.Role;
using ToDoListAPI.Persistence.Context;
using T = ToDoListAPI.Application.DTOs;

namespace ToDoListAPI.Persistence.Services
{
	public class StudentService : IStudentService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly IStudentReadRepository _studentReadRepository;
		private readonly IStudentWriteRepository _studentWriteRepository;
		private readonly AppDbContext _context;
		public StudentService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, RoleManager<AppRole> roleManager, IHttpContextAccessor httpContextAccessor, IStudentReadRepository studentReadRepository, IStudentWriteRepository studentWriteRepository, AppDbContext context)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
			_roleManager = roleManager;
			_httpContextAccessor = httpContextAccessor;
			_studentReadRepository = studentReadRepository;
			_studentWriteRepository = studentWriteRepository;
			_context = context;
		}

		public async Task<bool> CreateStudent(CreateStudent createStudent)
		{
			AppUser appUser = await _userManager.FindByIdAsync(createStudent.UserId);
			if (appUser == null)
			{
				throw new Exception("User Not Found");
			}
			var isRoleStudent = await _userManager.IsInRoleAsync(appUser, RoleModel.Student.ToString());
			if (isRoleStudent)
			{
				Student student = new Student
				{
					UserId = createStudent.UserId,
					Username = appUser.UserName,
				};
				await _studentWriteRepository.AddAsnyc(student);
				await _context.SaveChangesAsync();
				return true;
			}
			throw new Exception("User is  Not Student");
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
