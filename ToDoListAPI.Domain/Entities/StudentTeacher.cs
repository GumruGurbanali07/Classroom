using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Domain.Entities
{
	public class StudentTeacher
	{
		public Guid StudentId { get; set; }
		public Student Student { get; set; }

		public Guid TeacherId { get; set; }
		public Teacher Teacher { get; set; }
	}
}
