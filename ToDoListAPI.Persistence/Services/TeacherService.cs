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

	public async Task<bool> UpdateTeacherAsync(UpdateTeacher updateTeacher)
		{
			var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"];
			if (string.IsNullOrEmpty(token))
			{
				throw new UnauthorizedAccessException("Authorization token is missing.");
			}

			var currentTeacherId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
			if (currentTeacherId == null || currentTeacherId != updateTeacher.Id.ToString())
			{
				throw new UnauthorizedAccessException("You are not authorized to update this teacher's information");
			}
			var teacher = await _teacherReadRepository.GetByIdAsync(updateTeacher.Id.ToString());
			if (teacher == null)
			{
				throw new UserNotFoundException("Teacher not found");
			}
			

			var result = _teacherWriteRepository.Update(teacher);
			return result;

		}
		public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
		{
			var users = _httpContextAccessor?.HttpContext?.User?.Identity?.Name;
			AppUser user = await _userManager.Users.Include(a=>a.Teacher).FirstOrDefaultAsync(a=>a.Name==users);
			var teacher = await _teacherReadRepository.GetAll().Include(a=>a.User).OrderBy(a=>a.UserId==user.Id).ToListAsync();


			return teacher;
		}
	
		public async Task<Teacher> GetTeacherByIdAsync(string username)
		{
			return await _context.Set<Teacher>().FirstOrDefaultAsync();
			
		}

		public Task<IEnumerable<Student>> GetStudentForTeacherAsync(string teacherId)
		{
			throw new NotImplementedException();
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
