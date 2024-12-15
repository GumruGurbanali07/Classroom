using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Domain.Entities
{
	public class StudentTeacher :BaseEntity
	{
		public Guid StudentId { get; set; }
		public List<Student> Student { get; set; }

		public Guid TeacherId { get; set; }
		public Teacher Teacher { get; set; }
	}
}
