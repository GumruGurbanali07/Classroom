using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Application.DTOs.Teacher
{
	public class RegisterTeacher
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Surname { get; set; }
		[Required]
		public string Subject { get; set; }
		[Required]
		[EmailAddress(ErrorMessage = "Email type is not true")]
		public string Gmail { get; set; }
		[Required]
		[MinLength(6, ErrorMessage = "Password must be min 6 character")]

		public string Password { get; set; }
		[Required]
		[Compare("Password")]
		public string ResetPassword { get; set; }

	}
}
