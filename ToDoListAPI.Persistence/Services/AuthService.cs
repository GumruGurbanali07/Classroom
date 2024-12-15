using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using ToDoListAPI.Application.DTOs;
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
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IAppUserService _appUserService;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly ITokenHandler _tokenHandler;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly ITeacherReadRepository _teacherReadRepository;
		private readonly ITeacherWriteRepository _teacherWriteRepository;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly IStudentReadRepository _studentReadRepository;
		private readonly IStudentWriteRepository _studentWriteRepository;

		public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager = null, RoleManager<AppRole> roleManager = null, ITeacherWriteRepository teacherWriteRepository = null, ITeacherReadRepository teacherReadRepository = null, IHttpContextAccessor httpContextAccessor = null, ITokenHandler tokenHandler = null, IAppUserService appUserService = null, IStudentReadRepository studentReadRepository = null, IStudentWriteRepository studentWriteRepository = null)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
			_teacherWriteRepository = teacherWriteRepository;
			_teacherReadRepository = teacherReadRepository;
			_httpContextAccessor = httpContextAccessor;
			_tokenHandler = tokenHandler;
			_appUserService = appUserService;
			_studentReadRepository = studentReadRepository;
			_studentWriteRepository = studentWriteRepository;
		}



		public async Task<RegisterTeacherResponse> RegisterAsTeacherAsync(RegisterTeacher registerTeacher)
		{
			if (registerTeacher.Password != registerTeacher.ResetPassword)
			{
				return new RegisterTeacherResponse
				{
					Message = "Password and ResetPassword do not match",
					Succeeded = false
				};
			}
			var email = await _userManager.FindByEmailAsync(registerTeacher.Gmail);
			if (email != null) throw new FailedRegisterException(" Email is already registered.");
			var user = new AppUser
			{
				Id = Guid.NewGuid().ToString(),
				Name = registerTeacher.Name,
				Surname = registerTeacher.Surname,
				UserName = $"{registerTeacher.Name}.{registerTeacher.Surname}",
				Email = registerTeacher.Gmail,
				
			};		

			IdentityResult result = await _userManager.CreateAsync(user, registerTeacher.Password);

			if (!result.Succeeded)
			{
				var errors = string.Join(", ", result.Errors.Select(e => e.Description));
				throw new FailedRegisterException($"User could not register: {errors}");
			}				

			
			if (!await _roleManager.RoleExistsAsync("Teacher"))
			{

				await _roleManager.CreateAsync(new AppRole { Name = "Teacher" });
			}

			await _userManager.AddToRoleAsync(user, "Teacher");
			var teacher = new Teacher
			{
				UserId=user.Id,
				Subject=registerTeacher.Subject,
				Username=$"{registerTeacher.Name}.{registerTeacher.Surname}" 
			};
			await _teacherWriteRepository.AddAsnyc(teacher);
			await _teacherWriteRepository.SaveAsync();

			return new RegisterTeacherResponse
			{
				Message = "User registered successfully and role assigned",
				Succeeded = true
			};
		}


		public async Task<T.Token> LoginAsTeacherAsync(LoginTeacher loginTeacher, int accesTokenLifeTime)
		{
			
			AppUser user = await _userManager.FindByEmailAsync(loginTeacher.Gmail);
			if (user == null)
			{
				throw new UserNotFoundException("User could not be found");
			}

			
			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginTeacher.Password, false);
			if (!result.Succeeded)
			{
				throw new UnauthorizedAccessException("Invalid credentials");
			}

		

			
			T.Token? token = await _tokenHandler.CreateAccessToken(accesTokenLifeTime, user);

			
			await _appUserService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, accesTokenLifeTime);
			return token;
		}

		public async Task<RegisterStudentResponse> RegisterAsStudentAsync(RegisterStudent registerStudent)
		{
			if (registerStudent.Password != registerStudent.ResetPassword)
			{
				return new RegisterStudentResponse
				{
					Message = "Password and ResetPassword do not match",
					Succeded = false
				};
			}
			var email = await _userManager.FindByEmailAsync(registerStudent.Gmail);
			if (email != null) throw new FailedRegisterException("Email is already registered.");

			var user = new AppUser
			{
				Id = Guid.NewGuid().ToString(),
				Name = registerStudent.Name,
				Surname = registerStudent.Surname,
				UserName = $"{registerStudent.Name}.{registerStudent.Surname}",
				Email = registerStudent.Gmail,
			};

			IdentityResult result = await _userManager.CreateAsync(user, registerStudent.Password);
			if (!result.Succeeded)
			{
				var errors = string.Join(", ", result.Errors.Select(e => e.Description));
				throw new FailedRegisterException($"User could not register: {errors}");
			}

			if (!await _roleManager.RoleExistsAsync("Student"))
			{
				await _roleManager.CreateAsync(new AppRole { Name = "Student" });
			}
			await _userManager.AddToRoleAsync(user, "Student");

			var student = new Student
			{
				UserId = user.Id,				
				Username = $"{registerStudent.Name}.{registerStudent.Surname}"
			};
			await _studentWriteRepository.AddAsnyc(student);
			await _studentWriteRepository.SaveAsync();

			return new RegisterStudentResponse
			{
				Message = "User registered successfully and role assigned",
				Succeded = true
			};
		}

		public async Task<T.Token> LoginAsStudentAsync(LoginStudent loginStudent, int accesTokenLifeTime)
		{			
			AppUser user = await _userManager.FindByEmailAsync(loginStudent.Gmail);
			if (user == null)
			{
				throw new UserNotFoundException("User could not be found");
			}		
			SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, loginStudent.Password, false);
			if (!result.Succeeded)
			{
				throw new UnauthorizedAccessException("Invalid credentials");
			}			
			T.Token? token = await _tokenHandler.CreateAccessToken(accesTokenLifeTime, user);
			
			await _appUserService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, accesTokenLifeTime);

			return token;
		}


		public async Task<Token> RefreshTokenLogin(string refreshToken)
		{
			AppUser? user = _userManager.Users.FirstOrDefault(a => a.RefreshToken == refreshToken);
			if (user != null && user.RefreshTokenDate > DateTime.UtcNow)
			{
				Token token = await _tokenHandler.CreateAccessToken(900, user);
				await _appUserService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 900);
				return token;
			}
			throw new Exception("User not found or refresh token has expired");
		}


		public Task<bool> LogOutTeacher()
		{
			throw new NotImplementedException();
		}
		public Task<bool> LogOutStudent()
		{
			throw new NotImplementedException();
		}
	}
}
