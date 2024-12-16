using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Classroom
{
	public class CreateClassroom
	{
		public string Name { get; set; }		
		public string Description { get; set; }	
		public Guid TeacherId { get; set; }	
		public List<string> StudentEmails { get; set; }
	}
}
