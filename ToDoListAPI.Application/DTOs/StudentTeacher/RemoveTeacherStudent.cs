using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.StudentTeacher
{
	public class RemoveTeacherStudent
	{
		public string teacherId { get; set; }
		public string studentId { get; set; }
	}
}
