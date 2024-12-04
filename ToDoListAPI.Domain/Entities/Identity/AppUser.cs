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
		public AppUser()
		{
			Id=Guid.NewGuid().ToString();
		}
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Subject { get; set; }

	}
}
