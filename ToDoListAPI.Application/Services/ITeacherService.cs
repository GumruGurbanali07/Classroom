
using ToDoListAPI.Application.DTOs.Teacher;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;
using T = ToDoListAPI.Application.DTOs;
namespace ToDoListAPI.Application.Services
{
	public interface ITeacherService
	{

		Task<bool> UpdateTeacherAsync(UpdateTeacher updateTeacher);
		Task<IEnumerable<Teacher>> GetAllTeachersAsync();
		Task<Teacher> GetTeacherByIdAsync(string id);
		Task<IEnumerable<Task>> GetAssignedTasksForTeacherAsync(string teacherId);
		Task<IDictionary<string, TaskStatus>> GetStudentTasksStatusAsync(string teacherId);
		Task<IEnumerable<Student>> GetStudentForTeacherAsync(string teacherId);
		Task<bool> RemoveStudentFromTeacherAsync(string teacherId, string studentId);
		
	
	
		
	}
}
