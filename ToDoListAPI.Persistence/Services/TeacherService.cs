using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Application.Services;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Persistence.Services
{
	public class TeacherService : ITeacherService
	{
		public Task<IEnumerable<Teacher>> GetAllTeachersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> GetTeacherByIdAsync(string id)
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> LoginAsTeacherAsync(LoginTeacher loginTeacher)
		{
			throw new NotImplementedException();
		}

		public Task<bool> LogOut()
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> RegisterAsTeacherAsync(RegisterTeacher registerTeacher)
		{
			throw new NotImplementedException();
		}

		public Task<Teacher> UpdateTeacherAsync(UpdateTeacher updateTeacher)
		{
			throw new NotImplementedException();
		}
	}
}
