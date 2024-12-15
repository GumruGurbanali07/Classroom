using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.StudentTeacher;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Application.Services
{
	public interface ITeacherService
	{
		
		Task<bool> UpdateTeacherAsync(UpdateTeacher updateTeacher);
		Task<IEnumerable<object>> GetAllTeachersAsync();
		Task<GetByIdTeacher> GetTeacherByUserIdAsync(string userId);
		Task<bool> AddStudentToTeacherAsync(CreateTeacherStudent createTeacherStudent);
		Task<IEnumerable<object>> GetAllStudentsForTeacherAsync(string teacherId);
		Task<bool> RemoveStudentFromTeacherAsync(RemoveTeacherStudent removeTeacherStudent);
		

	}
}
