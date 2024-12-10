using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P=ToDoListAPI.Application.DTOs;
using ToDoListAPI.Domain.Entities.Identity;

namespace ToDoListAPI.Application.Token
{
	public interface ITokenHandler
	{
		Task<P::Token> CreateAccessToken(int second, AppUser appUser);
		string CreateRefreshToken();

	}
}
