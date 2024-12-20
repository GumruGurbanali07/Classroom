using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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


		public async Task<bool> UpdateStudentAsync(UpdateStudent updateStudent)
		{
			var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
			if (string.IsNullOrEmpty(token))
			{
				throw new UnauthorizedAccessException("Authorization token is missing.");
			}
			var currentStudentId = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(currentStudentId))
			{
				throw new UnauthorizedAccessException("You are not authorized to update this student's information");
			}
			var student = await _studentReadRepository.GetByIdAsync(updateStudent.Id.ToString());
			if (student == null)
			{
				throw new UserNotFoundException("Student not found");
			}
			student.Id = Guid.Parse(updateStudent.Id);
			student.UserId = student.UserId;
			var result = _studentWriteRepository.Update(student);
			await _studentWriteRepository.SaveAsync();
			return result;
		}

		public async Task<IEnumerable<object>> GetAllStudentAsync()
		{
			var users = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(users))
			{
				throw new UnauthorizedAccessException("User is not authenticated");
			}
			AppUser user = await _userManager.Users.Include(x => x.Student).FirstOrDefaultAsync(x => x.UserName == users);
			if (user == null)
			{
				throw new UserNotFoundException("User not found");
			}
			var students = await _studentReadRepository.GetAll()
				.Include(x => x.User)
				.Select(x => new
				{
					UserName=x.User.Name
				}).ToListAsync();
			return students;
		}

		public Task<Student> GetStudentByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Teacher>> GetTeacherForStudentAsync(string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> RemoveTeacherFromStudentAsync(string studentId, string teacherId)
		{
			throw new NotImplementedException();
		}

		Task<GetByIdStudent> IStudentService.GetStudentByUserIdAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> AcceptClassroomInviteAsync(string classroomId, string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> LeaveClassroomAsync(string classroomId, string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Classroom>> GetClassroomsForStudentAsync(string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<string>> GetStudentUsernamesInClassroomAsync(string classroomId)
		{
			throw new NotImplementedException();
		}
	}
}
