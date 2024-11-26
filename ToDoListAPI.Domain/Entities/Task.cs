using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Domain.Entities
{
	public class Task:BaseEntity
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Status { get; set; }
		
		public Guid TeacherId { get; set; }
		public Teacher Teacher { get; set; }
		public ICollection<StudentTask> StudentTasks { get; set; }
	}
}
