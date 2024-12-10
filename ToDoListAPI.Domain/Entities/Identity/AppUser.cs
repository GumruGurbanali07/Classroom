using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListAPI.Domain.Entities.Identity
{
	public class AppUser:IdentityUser<string>
	{
		
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Gmail {  get; set; }
		public string Password { get; set; }
		public string ResetPassword { get; set; }
		public string Subject { get; set; }


		public string? RefreshToken { get; set; }
		public DateTime RefreshTokenDate { get; set; }

		public Teacher Teacher { get; set; }	
		public Student Student { get; set; }
	}
}
