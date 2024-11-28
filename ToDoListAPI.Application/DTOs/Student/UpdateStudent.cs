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
		public Guid Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		[Required]
		[EmailAddress(ErrorMessage = "Email type is not true")]
		public string Gmail { get; set; }
		[Required]
		[MinLength(6, ErrorMessage = "Password must be min 6 character")]
		public string Password { get; set; }
	}
}
