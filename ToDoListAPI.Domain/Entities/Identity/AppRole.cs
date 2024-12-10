using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Role;

namespace ToDoListAPI.Domain.Entities.Identity
{
	public class AppRole:IdentityRole<string>
	{
		
		public RoleModel RoleModel { get; set; }
	}
}
