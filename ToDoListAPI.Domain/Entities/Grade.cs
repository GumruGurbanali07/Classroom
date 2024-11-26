using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Domain.Entities
{
	public class Grade : BaseEntity
	{
		public Guid StudentTaskId { get; set; }
		public StudentTask StudentTask { get; set; }
		public int StudentGrade { get; set; }
	}
}
