using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Application.Services
{
	public interface ITeacherService
	{
		Task<bool> CreateTeacher(CreateTeacher	 createTeacher);
		Task<bool> UpdateTeacherAsync(UpdateTeacher updateTeacher);
		Task<IEnumerable<Teacher>> GetAllTeachersAsync();
		Task<Teacher> GetTeacherByIdAsync(string id);
		Task<IEnumerable<Task>> GetAssignedTasksForTeacherAsync(string teacherId);
		Task<IDictionary<string, TaskStatus>> GetStudentTasksStatusAsync(string teacherId);
		Task<IEnumerable<Student>> GetStudentForTeacherAsync(string teacherId);
		Task<bool> RemoveStudentFromTeacherAsync(string teacherId, string studentId);
	}
}
