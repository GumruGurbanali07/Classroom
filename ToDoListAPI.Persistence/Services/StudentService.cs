using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.Exceptions;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Application.Token;
using ToDoListAPI.Domain.Entities;
using ToDoListAPI.Domain.Entities.Identity;
using T = ToDoListAPI.Application.DTOs;

namespace ToDoListAPI.Persistence.Services
{
	public class StudentService : IStudentService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;

		public StudentService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_tokenHandler = tokenHandler;
		}

		public async Task<RegisterStudentResponse> RegisterStudentAsync(RegisterStudent registerStudent)
		{
			if (registerStudent.Password != registerStudent.ResetPassword)
			{
				return new RegisterStudentResponse
				{
					Message = "Password and ResetPassword don't match",
					Succeded = false
				};
			}

			var user = new AppUser
			{
				UserName = new string((registerStudent.Name + registerStudent.Surname)
				 .Replace(" ", "")
				 .Where(e => char.IsLetterOrDigit(e))
				 .ToArray()),
				Email=registerStudent.Gmail
			};
			IdentityResult result = await _userManager.CreateAsync(user, registerStudent.Password);
			if (!result.Succeeded)
			{
				var errors=string.Join(", ",result.Errors.Select(e=>e.Description));
				throw new FailedRegisterException($"User could not register: {errors}");
			}
			else
			{
				return new RegisterStudentResponse
				{
					Message = "User registered Successfully",
					Succeded=true
				};
			}
		}
		public async Task<T.Token> LoginStudentAsync(LoginStudent loginStudent, int tokenLifetime)
		{
			AppUser user = await _userManager.FindByEmailAsync(loginStudent.Gmail);
			if(user == null)
			{
				throw new UserNotFoundException("User could not found");
			}
			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginStudent.Password, false);
			if (result.Succeeded)
			{
				T.Token token = _tokenHandler.CreateAccessToken(tokenLifetime, user);
				return token;
			}
			else
			{
				throw new UserNotFoundException("User could not found");
			}
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
