using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.StudentTask
{
	public class CreateStudentTask
	{
		public Guid StudentId { get; set; }
		public Guid TaskId { get; set; }
		public DateTime CompletionDate { get; set; }
		public bool IsCompleted { get; set; }
	}
}
