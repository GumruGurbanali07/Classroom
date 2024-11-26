using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Application.Services
{
	public interface IStudentService
	{
		public Task<Student> RegisterStudentAsync(RegisterStudent createStudent);
		public Task<Student> LoginStudentAsync(LoginStudent createStudent);
		public Task<Student> UpdateStudentAsync(UpdateStudent updateStudent);
		Task<IEnumerable<Student>> GetAllStudentAsync();
		Task<Student> GetStudentByIdAsync(string id);
		Task<bool> LogOut();
	}
}
