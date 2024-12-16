using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Domain.Entities
{
	public class Classroom:BaseEntity
	{
		public string Name { get; set; } 
		public string Description { get; set; } 

	
		public Guid TeacherId { get; set; }
		public Teacher Teacher { get; set; } 

	
		public ICollection<StudentClassroom> StudentClassrooms { get; set; }
	}
}
