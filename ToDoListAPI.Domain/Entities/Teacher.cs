using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Common;
using ToDoListAPI.Domain.Entities.Identity;

namespace ToDoListAPI.Domain.Entities
{
	public class Teacher : BaseEntity
	{

		public AppUser User { get; set; }		
		public string UserId { get; set; }
		public string Username {  get; set; } 
		public string Subject { get; set; }
		public ICollection<StudentTask> StudentTasks { get; set; }		
		public ICollection<Task> Tasks { get; set; }
	
		
	}
}
