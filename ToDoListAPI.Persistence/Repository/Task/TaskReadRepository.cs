using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.Repository;
using ToDoListAPI.Persistence.Context;
using Task = ToDoListAPI.Domain.Entities.Task;

namespace ToDoListAPI.Persistence.Repository
{
	public class TaskReadRepository : ReadRepository<Task>, ITaskReadRepository
	{
		public TaskReadRepository(AppDbContext context) : base(context)
		{
		}
	}
}
