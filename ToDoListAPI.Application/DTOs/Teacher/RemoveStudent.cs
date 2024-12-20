using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Teacher
{
	public class RemoveStudent
	{
		public string classroomId {  get; set; }
		public string studentId { get; set; }
	}
}
