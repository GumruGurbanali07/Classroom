using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.StudentTask
{
	public class UpdateStudentTask
	{
		public Guid Id { get; set; }
		public DateTime CompletionDate { get; set; }
		public bool IsCompleted { get; set; }
	}
}
