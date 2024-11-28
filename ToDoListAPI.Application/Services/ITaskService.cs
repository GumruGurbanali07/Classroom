using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Task;
using ToDoListAPI.Domain.Entities;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Application.Services
{
	public interface ITaskService
	{
		Task<Task> GetTaskByIdForTeacherAsync(Guid id);
		Task<Task> GetTaskByIdForStudentAsync(Guid id);
		Task<IEnumerable<Task>> GetAllTasksForTeacherAsync();
		Task<IEnumerable<Task>> GetAllTasksForStudentAsync();
		Task<IEnumerable<Task>> GetOverdueTasksAsync(string teacherId);//vaxti kecmis tasklar	
		Task<bool> SubmitTaskAsync(string taskId);
		Task<Task> CreateTaskAsync(CreateTask createTaskDTO);//t
		Task<Task> UpdateTaskAsync(UpdateTask updateTaskDTO);//t
		Task<bool> DeleteTaskAsync(Guid id);//t
	}
}
