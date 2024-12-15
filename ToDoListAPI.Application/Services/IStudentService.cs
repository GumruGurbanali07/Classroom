using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Student;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;
using T = ToDoListAPI.Application.DTOs;

namespace ToDoListAPI.Application.Services
{
	public interface IStudentService
	{
	    public Task<bool> CreateStudent(CreateStudent createStudent);
		public Task<Student> UpdateStudentAsync(UpdateStudent updateStudent);
		Task<IEnumerable<Student>> GetAllStudentAsync();
		Task<Student> GetStudentByIdAsync(string id);
		Task<IEnumerable<Task>> GetAssignedTasksForStudentAsync(string studentId);
		Task<IEnumerable<Task>> GetSubmittedTasksForStudentAsync(string studentId);
		Task<IEnumerable<Teacher>> GetTeacherForStudentAsync(string studentId);
		Task<bool> RemoveTeacherFromStudentAsync(string studentId, string teacherId);

	
	}
}
