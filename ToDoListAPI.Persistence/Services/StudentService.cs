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
			var email = await _userManager.FindByEmailAsync(registerStudent.Gmail);
			if (email != null) throw new FailedRegisterException(" Email is already registered.");

			var user = new AppUser
			{
				Id= Guid.NewGuid().ToString(),
				Name= registerStudent.Name,
				Surname= registerStudent.Surname,
				UserName = $"{registerStudent.Name}.{registerStudent.Surname}",
				Email = registerStudent.Gmail
			};
			IdentityResult result = await _userManager.CreateAsync(user, registerStudent.Password);
			if (!result.Succeeded)
			{
				var errors=string.Join(", ",result.Errors.Select(e=>e.Description));
				throw new FailedRegisterException($"User could not register: {errors}");
			}
			else
			{
				if (!await _roleManager.RoleExistsAsync(RoleModel.Student.ToString()))
				{

					await _roleManager.CreateAsync(new AppRole { Name = RoleModel.Student.ToString() });
				}

				await _userManager.AddToRoleAsync(user, RoleModel.Student.ToString());
				
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
				T.Token token =await _tokenHandler.CreateAccessToken(tokenLifetime, user);
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
