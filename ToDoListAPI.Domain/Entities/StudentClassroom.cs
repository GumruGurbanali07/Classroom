using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Domain.Entities
{
	public class StudentClassroom:BaseEntity
	{
		public Guid StudentId { get; set; }
		public Student Student { get; set; }

		public Guid ClassroomId { get; set; }
		public Classroom Classroom { get; set; }
	}
}
