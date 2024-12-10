using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Identity;

namespace ToDoListAPI.Application.Services
{
	public class AppUserService : IAppUserService
	{
		readonly private UserManager<AppUser> _userManager;

		public AppUserService(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async  Task<bool> UpdateRefreshToken(string refreshToken, AppUser user, DateTime refreshTokenTime, int accessTokenDate)
		{
			if(user!=null)
			{
				DateTime refreshTokenDate = refreshTokenTime;
				user.RefreshToken = refreshToken;
				user.RefreshTokenDate = refreshTokenTime.AddSeconds(accessTokenDate);

				await _userManager.UpdateAsync(user);
				return true;
			}


			throw new Exception("Not Found");
		
		}
	}
}
