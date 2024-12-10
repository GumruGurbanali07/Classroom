using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListAPI.Application.Services.Roles;
using ToDoListAPI.Domain.Entities.Role;
using ToDoListAPI.Persistence.Services.Roles;

namespace ToDoList.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _roleService;

		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}
		[HttpPost("create")]
		public async Task<IActionResult> CreateRole(string roleName,RoleModel roleModel	)
		{
			var result = await _roleService.CreateRoleAsync(roleName,roleModel);
			if (result.Succeeded)
			{
				return Ok("Role created");
			}
			else
			{
				return BadRequest(result.Errors);
			}
		}
	}
}
