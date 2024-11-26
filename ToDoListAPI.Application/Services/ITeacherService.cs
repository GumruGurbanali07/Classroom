using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Domain.Entities;

namespace ToDoListAPI.Application.Services
{
	public interface ITeacherService
	{
		Task<Teacher> RegisterAsTeacherAsync(RegisterTeacher registerTeacher);
		Task<Teacher> LoginAsTeacherAsync(LoginTeacher loginTeacher);
		Task<Teacher> UpdateTeacherAsync(UpdateTeacher updateTeacher);
		Task<IEnumerable<Teacher>> GetAllTeachersAsync();
		Task<Teacher> GetTeacherByIdAsync(string id);
		Task<bool> LogOut();
	}
}
