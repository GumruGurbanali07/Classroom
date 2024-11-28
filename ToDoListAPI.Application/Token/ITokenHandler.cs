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
		P.Token CreateAccessToken(int minute, AppUser user);

	}
}
