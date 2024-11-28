using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.Validator.StudentTask;

namespace ToDoListAPI.Application.DTOs.StudentTask
{
	public class UpdateStudentTask
	{
		public Guid Id { get; set; }
		[Required]
		[DataType(DataType.Date)]
		[FutureDate(ErrorMessage = "Deadline must be a future date.")]
		public DateTime CompletionDate { get; set; }
		public bool IsCompleted { get; set; } = false;
	}
}
