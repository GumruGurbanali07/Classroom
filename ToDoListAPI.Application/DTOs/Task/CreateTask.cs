using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Task
{
	public class CreateTask
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		public bool Status { get; set; }
		public Guid TeacherId { get; set; }
		public DateTime Deadline { get; set; }

	}
}
