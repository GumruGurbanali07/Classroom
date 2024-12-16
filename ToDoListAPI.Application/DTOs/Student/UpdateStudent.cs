using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Student
{
	public class UpdateStudent
	{
		public string Id { get; set; }
		public string UserId { get; set; }
	}
}
