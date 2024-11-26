using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Persistence.Services
{
	public class StudentService : IStudentService
	{
		public Task<IEnumerable<Student>> GetAllStudentAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Student> GetStudentByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<Student> LoginStudentAsync(LoginStudent createStudent)
		{
			throw new NotImplementedException();
		}

		public Task<bool> LogOut()
		{
			throw new NotImplementedException();
		}

		public Task<Student> RegisterStudentAsync(RegisterStudent createStudent)
		{
			throw new NotImplementedException();
		}

		public Task<Student> UpdateStudentAsync(UpdateStudent updateStudent)
		{
			throw new NotImplementedException();
		}
	}
}
