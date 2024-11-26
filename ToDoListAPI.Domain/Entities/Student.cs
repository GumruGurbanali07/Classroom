using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;

namespace ToDoListAPI.Domain.Entities
{
	public class Student:BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Gmail {  get; set; }
		public string Password { get; set; }
		public ICollection<Teacher> Teachers { get; set; }
		public ICollection<Task> Tasks { get; set; }
	}
}
