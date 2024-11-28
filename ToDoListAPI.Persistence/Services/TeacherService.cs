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

using ToDoListAPI.Domain.Entities.Identity;
using ToDoListAPI.Application.Exceptions;

namespace ToDoListAPI.Persistence.Services
{
	public class TeacherService : ITeacherService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;

		public TeacherService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
		}

		public async Task<T.Token> RegisterAsTeacherAsync(RegisterTeacher registerTeacher,int tokenLifetime)
		{
			AppUser user = await _userManager.FindByEmailAsync(registerTeacher.Gmail);
			if (user != null)
			{
				throw new UserIsExistException("User is already exist");
			}
			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, registerTeacher.Password, false);
			if (result.Succeeded)
			{
				T.Token token = _tokenHandler.CreateAccessToken(tokenLifetime, user);
				await _userManager.
			}
		}
		public Task<T.Token> LoginAsTeacherAsync(LoginTeacher loginTeacher)
		{
			throw new NotImplementedException();
		}
		public Task<IEnumerable<Teacher>> GetAllTeachersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entities.Task>> GetAssignedTasksForTeacherAsync(string teacherId)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Student>> GetStudentForTeacherAsync(string teacherId)
		{
			throw new NotImplementedException();
		}

		public Task<IDictionary<string, TaskStatus>> GetStudentTasksStatusAsync(string teacherId)
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> GetTeacherByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		

		public Task<bool> LogOut()
		{
			throw new NotImplementedException();
		}

		

		public Task<bool> RemoveStudentFromTeacherAsync(string teacherId, string studentId)
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> UpdateTeacherAsync(UpdateTeacher updateTeacher)
		{
			throw new NotImplementedException();
		}
	}
}
