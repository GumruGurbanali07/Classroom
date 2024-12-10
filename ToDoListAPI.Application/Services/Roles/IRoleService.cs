using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Role;

namespace ToDoListAPI.Application.Services.Roles
{
	public interface IRoleService
	{
		public  Task<IdentityResult> CreateRoleAsync(string roleName, RoleModel roleModel);
	}
}
