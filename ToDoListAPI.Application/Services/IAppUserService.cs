using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListAPI.Domain.Entities.Identity;

namespace ToDoListAPI.Application.Services
{
	public interface IAppUserService
	{
		Task<bool> UpdateRefreshToken(string refreshToken, AppUser user, DateTime RefreshTokenTime , int accessTokenDate);
	}
}
