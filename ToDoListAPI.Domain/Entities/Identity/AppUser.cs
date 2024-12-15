using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Domain.Entities.Identity
{
	public class AppUser:IdentityUser<string>
	{
		
		public string Name { get; set; }
		public string Surname { get; set; }

		[DataType(DataType.Password)]
		public string? ResetPassword { get; set; }
		

		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenDate { get; set; }

		public Teacher Teacher { get; set; }	
		public Student Student { get; set; }
	}
}
