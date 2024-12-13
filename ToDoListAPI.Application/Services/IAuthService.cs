using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.DTOs.Teacher;
using T = ToDoListAPI.Application.DTOs;
namespace ToDoListAPI.Application.Services
{
	public interface IAuthService
	{
		Task<RegisterTeacherResponse> RegisterAsTeacherAsync(RegisterTeacher registerTeacher);
		Task<T::Token> LoginAsTeacherAsync(LoginTeacher loginTeacher, int tokenLifetime);
		 Task<RegisterStudentResponse> RegisterAsStudentAsync(RegisterStudent registerStudent);
		 Task<T.Token> LoginAsStudentAsync(LoginStudent loginStudent, int tokenLifetime);
		Task<T::Token> RefreshTokenLogin(string refreshToken);
		Task<bool> LogOutTeacher();
		Task<bool> LogOutStudent();
	}
}
