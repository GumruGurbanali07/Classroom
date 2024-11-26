using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.DTOs.Task;
using ToDoListAPI.Application.Services;

namespace ToDoListAPI.Persistence.Services
{
	public class TaskService : ITaskService
	{
		public Task<Domain.Entities.Task> CreateTaskAsync(CreateTask createTaskDTO)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteTaskAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entities.Task>> GetAllTasksForStudentAsync()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Domain.Entities.Task>> GetAllTasksForTeacherAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Domain.Entities.Task> GetTaskByIdForStudentAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Domain.Entities.Task> GetTaskByIdForTeacherAsync(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<bool> SubmitTaskAsync(string taskId)
		{
			throw new NotImplementedException();
		}

		public Task<Domain.Entities.Task> UpdateTaskAsync(UpdateTask updateTaskDTO)
		{
			throw new NotImplementedException();
		}
	}
}
