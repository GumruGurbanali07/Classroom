using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Application.Services.Roles;
using ToDoListAPI.Domain.Entities.Identity;
using ToDoListAPI.Domain.Entities.Role;

namespace ToDoListAPI.Persistence.Services.Roles
{
	public class RoleService : IRoleService
	{
		private readonly RoleManager<AppRole> _roleManager;

		public RoleService(RoleManager<AppRole> roleManager)
		{
			_roleManager = roleManager;
		}

		public async Task<IdentityResult> CreateRoleAsync(string roleName,RoleModel roleModel)
		{
			var roleExist=await _roleManager.RoleExistsAsync(roleName);
			if (!roleExist)
			{
				var role = new AppRole { Name = roleName, RoleModel=roleModel };
				var result = await _roleManager.CreateAsync(role);
				return result;
			}
			else
			{
				return IdentityResult.Failed(new IdentityError { Description = "Role is already exist!" });
			}
		}
	}
}
