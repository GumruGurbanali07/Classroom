using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Application.Token;
using ToDoListAPI.Domain.Entities;
using T = ToDoListAPI.Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Domain.Entities.Identity;
using ToDoListAPI.Application.Exceptions;
using System.Web.Mvc;
using ToDoListAPI.Application.DTOs;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using ToDoListAPI.Application.Repository;
using Microsoft.EntityFrameworkCore;
using ToDoListAPI.Persistence.Context;
using Task = ToDoListAPI.Domain.Entities.Task;
using ToDoListAPI.Domain.Entities.Role;
using ToDoListAPI.Application.DTOs.Teacher;

namespace ToDoListAPI.Persistence.Services
{
	public class TeacherService : ITeacherService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IAppUserService _appUserService;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ITeacherReadRepository _teacherReadRepository;
		private readonly ITeacherWriteRepository _teacherWriteRepository;
		private readonly AppDbContext _context;
		private readonly RoleManager<AppRole> _roleManager;

		public TeacherService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IHttpContextAccessor httpContextAccessor, ITeacherReadRepository teacherReadRepository, ITeacherWriteRepository teacherWriteRepository, AppDbContext context, RoleManager<AppRole> roleManager, IAppUserService appUserService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
			_httpContextAccessor = httpContextAccessor;
			_teacherReadRepository = teacherReadRepository;
			_teacherWriteRepository = teacherWriteRepository;
			_context = context;
			_roleManager = roleManager;
			_appUserService = appUserService;
		}


		public async Task<bool> CreateTeacher(CreateTeacher createTeacher)
		{

			AppUser appUser = await _userManager.FindByIdAsync(createTeacher.UserId) ?? throw new Exception("User Not Found");

			var isRoleTeacher = await _userManager.IsInRoleAsync(appUser, RoleModel.Teacher.ToString());

			if (isRoleTeacher)
			{
				Teacher teacher = new Teacher()
				{
					UserId = createTeacher.UserId,
					Subject = createTeacher.Subject,
					Username = appUser.UserName
				};
				await _teacherWriteRepository.AddAsnyc(teacher);
				await _context.SaveChangesAsync();
				return true;
			}
			throw new Exception("User is Not Teacher");
		}

		public async Task<bool> UpdateTeacherAsync(UpdateTeacher updateTeacher)
		{

			var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
			if (string.IsNullOrEmpty(token))
			{
				throw new UnauthorizedAccessException("Authorization token is missing.");
			}

			var currentTeacherId = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(currentTeacherId))
			{
				throw new UnauthorizedAccessException("You are not authorized to update this teacher's information");
			}
			var teacher = await _teacherReadRepository.GetByIdAsync(updateTeacher.Id.ToString());
			if (teacher == null)
			{
				throw new UserNotFoundException("Teacher not found");
			}
			teacher.Id = Guid.Parse(updateTeacher.Id);
			teacher.Subject = updateTeacher.Subject;
			teacher.UserId = teacher.UserId;

			var result = _teacherWriteRepository.Update(teacher);
			await _teacherWriteRepository.SaveAsync();

			return result;
		}
		public async Task<IEnumerable<object>> GetAllTeachersAsync()
		{
			var users = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(users))
			{
				throw new UnauthorizedAccessException("User is not authenticated");
			}

			AppUser user = await _userManager.Users.Include(a => a.Teacher).FirstOrDefaultAsync(a => a.UserName == users);
			if (user == null)
			{
				throw new Exception("User not found");
			}

			var teachers = await _teacherReadRepository.GetAll()
			.Include(a => a.User)
			 .Select(a => new
			 {
				 Username = a.User.Name,
				 Subject = a.Subject
			 })
			  .ToListAsync();

			return teachers;
		}

		public async Task<GetByIdTeacher> GetTeacherByUserIdAsync(string userId)
		{
			var users = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(users))
			{
				throw new UnauthorizedAccessException("User is not authenticated");
			}
			AppUser user = await _userManager.Users.Include(x => x.Teacher).FirstOrDefaultAsync(x => x.UserName == users);
			if (user == null)
			{
				throw new Exception("User not found");
			}
			var teacher = await _teacherReadRepository.GetByUserIdAsync(userId);
			if (teacher == null)
			{
				throw new Exception("Teacher  not found");
			}
			var relatedUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == teacher.UserId);
			if (relatedUser == null)
			{
				throw new Exception("Related user not found");
			}
			return new GetByIdTeacher
			{
				Username = teacher.User.Name,
				Gmail = teacher.User.Email,
				Subject = teacher.Subject
			};


		}
		public async Task<bool> AddStudentToTeacherAsync(string studentId, string teacherId)
		{
			var users = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(users))
			{
				throw new UnauthorizedAccessException("User is not authenticated");
			}

			AppUser user = await _userManager.Users.Include(a => a.Teacher).FirstOrDefaultAsync(a => a.UserName == users);
			if (user == null)
			{
				throw new Exception("User not found");
			}

		}

		public async Task<IEnumerable<object>> GetAllStudentsForTeacherAsync(string teacherId)
		{
			var users = _httpContextAccessor.HttpContext?.User?.Identity?.Name;
			if (string.IsNullOrEmpty(users))
			{
				throw new Exception("User Not Found");
			}
			AppUser user = await _userManager.Users.Include(x => x.Teacher).FirstOrDefaultAsync(x => x.UserName == users);
			if (user == null)
			{
				throw new Exception("User Not Found");
			}
			var students = await _context.StudentTeachers
	   .Where(st => st.Teacher.UserId == user.Id)
	   .Select(st => new
	   {
		   Username = st.Student.Username,
		   Gmail = st.Student.User.Email
	   })
	   .ToListAsync();

			return students;
		}
		public Task<bool> RemoveStudentFromTeacherAsync(string teacherId, string studentId)
		{
			throw new NotImplementedException();
		}
		public Task<IEnumerable<Task>> GetAssignedTasksForTeacherAsync(string teacherId)
		{
			throw new NotImplementedException();
		}

		public Task<IDictionary<string, TaskStatus>> GetStudentTasksStatusAsync(string teacherId)
		{
			throw new NotImplementedException();
		}


	}
}
